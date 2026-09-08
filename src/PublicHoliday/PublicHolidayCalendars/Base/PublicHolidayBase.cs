using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using PublicHoliday.Dates;

namespace PublicHoliday
{

    /// <summary>
    /// Public Holiday operations
    /// </summary>
    /// <seealso cref="IPublicHolidays" />
    public abstract class PublicHolidayBase : IPublicHolidays
    {
        //one year's holidays, built once per instance. Day-by-day callers (NextWorkingDay,
        //BusinessDaysAdd, repeated IsPublicHoliday) would otherwise rebuild the year each time.
        private readonly HolidayYearCache _yearCache = new HolidayYearCache();

        /// <summary>
        /// Discards the cached holidays. A calendar with a settable region, state or option flag must call
        /// this from the setter, or it keeps answering from the previous configuration.
        /// </summary>
        protected void ClearHolidayCache()
        {
            _yearCache.Clear();
        }

        /// <summary>
        /// The language this calendar answers in - the culture of <see cref="Holiday.Name"/>.
        /// Defaults to <see cref="CountryCulture"/>; set it to read a multilingual country in one
        /// of its other languages:
        /// <code>
        /// var walloon = new BelgiumPublicHoliday { Culture = new CultureInfo("fr-BE") };
        /// walloon.PublicHolidaysInformation(2026).Last().Name;   // "Noël"
        /// </code>
        /// </summary>
        public CultureInfo Culture
        {
            get { return _culture ?? CountryCulture; }
            set
            {
                _culture = value;
                ClearHolidayCache();
            }
        }

        private CultureInfo _culture;

        /// <summary>
        /// The language this country's own holiday names are written in (<c>de-DE</c>,
        /// <c>et-EE</c>, Belgium <c>nl-BE</c>). English when a calendar has no language of its own.
        /// </summary>
        protected virtual CultureInfo CountryCulture
        {
            get { return _englishUs; }
        }

        private static readonly CultureInfo _englishUs = new CultureInfo("en-US");

        /// <summary>
        /// Identifies this calendar to the name resources, so a calendar that words a holiday differently
        /// from the culture it shares can have its own file - <c>Names.EcbTargetClosingDay.en-US.resx</c>
        /// is read before <c>Names.en-US.resx</c>. Defaults to the class name; nothing needs to override it.
        /// </summary>
        protected virtual string CalendarId
        {
            get { return GetType().Name; }
        }

        /// <summary>
        /// Returns whether todays date is a working day
        /// </summary>
        /// <returns>A boolean of whether today is a working day</returns>
        public virtual bool IsWorkingDay()
        {
            return IsWorkingDay(DateTime.Now);
        }

        /// <summary>
        /// Returns whether the specified date is a working day
        /// </summary>
        /// <param name="dt">The date to be checked</param>
        /// <returns>Returns a boolean of whether the specified date is a working day</returns>
        public virtual bool IsWorkingDay(DateTime dt)
        {
            return WorkingDayCalculator.IsWorkingDay(this, dt);
        }

        /// <summary>
        /// Get a list of dates for all public holidays in a year (excluding region-only holidays).
        /// Derived from <see cref="PublicHolidaysComplete"/>; a calendar that still implements this
        /// directly is also supported.
        /// </summary>
        /// <param name="year">The year.</param>
        public virtual IList<DateTime> PublicHolidays(int year)
        {
            return DatesFromComplete(year);
        }

        /// <summary>
        /// The single source of truth for a calendar: every holiday in the year, including
        /// region-only ones (<see cref="Holiday.IsPublic"/> = false, <see cref="Holiday.Regions"/>
        /// set) and observed-date shifts. All the other list/name members are derived from this.
        /// </summary>
        /// <param name="year">The year.</param>
        protected abstract IList<Holiday> PublicHolidaysComplete(int year);

        /// <summary>
        /// Returns observed and holiday dates for all holidays, with names.
        /// </summary>
        /// <param name="year">The current year</param>
        /// <returns>A list of holidays</returns>
        public virtual IList<Holiday> PublicHolidaysInformation(int year)
        {
            return new List<Holiday>(PublicHolidaysCompleteCached(year));
        }

        /// <summary>
        /// Memoized <see cref="PublicHolidaysComplete"/>. Internal callers (derivations,
        /// <see cref="IsPublicHoliday"/>) use this directly; public callers get a copy via
        /// <see cref="PublicHolidaysInformation"/> so they cannot mutate the cache.
        /// </summary>
        private IList<Holiday> PublicHolidaysCompleteCached(int year)
        {
            return _yearCache.GetOrAdd(year, PublicHolidaysComplete, Culture, CalendarId);
        }

        /// <summary>
        /// Dates of all public (non region-only) holidays in the year, from
        /// <see cref="PublicHolidaysComplete"/>. Helper for calendars migrated to the single method.
        /// </summary>
        protected IList<DateTime> DatesFromComplete(int year)
        {
            //two holidays can share a calendar day (e.g. Ascension on 1 May): the day is listed
            //once. PublicHolidaysInformation keeps them as distinct entries.
            return PublicHolidaysCompleteCached(year)
                .Where(h => h.IsPublic)
                .Select(h => h.ObservedDate.Date)
                .Distinct()
                .OrderBy(d => d)
                .ToList();
        }

        /// <summary>
        /// Dates + local names of all public holidays in the year, from
        /// <see cref="PublicHolidaysComplete"/>. Helper for calendars migrated to the single method.
        /// Two holidays on the same calendar day are two entries in the day's array - use
        /// <see cref="PublicHolidaysInformation"/> for the full <see cref="Holiday"/> objects.
        /// </summary>
        protected IDictionary<DateTime, string[]> NamesFromComplete(int year)
        {
            return NamesFromComplete(year, null);
        }

        private IDictionary<DateTime, string[]> NamesFromComplete(int year, CultureInfo culture)
        {
            var names = new SortedDictionary<DateTime, List<string>>();
            foreach (var holiday in PublicHolidaysCompleteCached(year))
            {
                if (!holiday.IsPublic) continue;
                var date = holiday.ObservedDate.Date;
                List<string> existing;
                if (!names.TryGetValue(date, out existing))
                {
                    existing = new List<string>();
                    names.Add(date, existing);
                }
                existing.Add(culture == null ? holiday.Name : holiday.GetName(culture));
            }
            var result = new SortedDictionary<DateTime, string[]>();
            foreach (var pair in names)
            {
                result.Add(pair.Key, pair.Value.ToArray());
            }
            return result;
        }

        /// <summary>
        /// Whether the date is a public holiday, from <see cref="PublicHolidaysComplete"/>.
        /// Helper for calendars migrated to the single method.
        /// </summary>
        protected bool IsPublicHolidayFromComplete(DateTime dt)
        {
            var date = dt.Date;
            foreach (var holiday in PublicHolidaysCompleteCached(dt.Year))
            {
                if (holiday.IsPublic && holiday.ObservedDate.Date == date)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Get a list of dates with (default local) names for all public holidays in a year.
        /// Derived from <see cref="PublicHolidaysComplete"/>; a calendar that still implements this
        /// directly is also supported.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>
        /// Dictionary of bank holidays
        /// </returns>
        public virtual IDictionary<DateTime, string[]> PublicHolidayNames(int year)
        {
            return NamesFromComplete(year);
        }

        /// <summary>
        /// Get a list of dates with names for all holidays in a year, in the given culture.
        /// Names with no translation for the culture fall back per
        /// <see cref="Holiday.GetName(CultureInfo)"/> (never empty).
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="culture">The culture for the names, e.g. new CultureInfo("fr-BE"). Null = default local names.</param>
        public virtual IDictionary<DateTime, string[]> PublicHolidayNames(int year, CultureInfo culture)
        {
            return NamesFromComplete(year, culture);
        }

        /// <summary>
        /// Returns the next working day (Mon-Fri, not public holiday)
        /// after the specified date (or the same date)
        /// </summary>
        /// <param name="dt">The date you wish to check</param>
        /// <returns>A date that is a working day</returns>
        public virtual DateTime NextWorkingDay(DateTime dt)
        {
            return WorkingDayCalculator.NextWorkingDay(this, dt);
        }

        /// <summary>
        /// Returns the next working day (Mon-Fri, not public holiday)
        /// after the specified date (not the same date)
        /// </summary>
        /// <param name="dt">The date you wish to check</param>
        /// <returns>A date that is a working day</returns>
        public virtual DateTime NextWorkingDayNotSameDay(DateTime dt)
        {
            return WorkingDayCalculator.NextWorkingDay(this, dt, false);
        }

        /// <summary>
        /// Returns the next working day (Mon-Fri, not public holiday)
        /// after x day of the specified date (or the same date)
        /// </summary>
        /// <param name="dt">The date you wish to check</param>
        /// <param name="openDayAdd">The number of open day to add</param>
        /// <returns>A date that is a working day</returns>
        public DateTime NextWorkingDay(DateTime dt, int openDayAdd)
        {
            return WorkingDayCalculator.NextWorkingDay(this, dt, openDayAdd);
        }

        /// <summary>
        /// Returns the next working day (Mon-Fri, not public holiday)
        /// after x day of the specified date (not the same date)
        /// </summary>
        /// <param name="dt">The date you wish to check</param>
        /// <param name="openDayAdd">The number of open day to add</param>
        /// <returns>A date that is a working day</returns>
        public DateTime NextWorkingDayNotSameDay(DateTime dt, int openDayAdd)
        {
            return WorkingDayCalculator.NextWorkingDay(this, dt, openDayAdd, false);
        }

        /// <summary>
        /// Returns the previous working day (Mon-Fri, not public holiday)
        /// before the specified date (or the same date)
        /// </summary>
        /// <param name="dt">The date you wish to check</param>
        /// <returns>A date that is a working day</returns>
        public virtual DateTime PreviousWorkingDay(DateTime dt)
        {
            return WorkingDayCalculator.PreviousWorkingDay(this, dt);
        }

        /// <summary>
        /// Returns the previous working day (Mon-Fri, not public holiday)
        /// before the specified date (not the same date)
        /// </summary>
        /// <param name="dt">The date you wish to check</param>
        /// <returns>A date that is a working day</returns>
        public virtual DateTime PreviousWorkingDayNotSameDay(DateTime dt)
        {
            return WorkingDayCalculator.PreviousWorkingDay(this, dt, false);
        }

        /// <summary>
        /// Returns the previous working day (Mon-Fri, not public holiday)
        /// before x day of the specified date (or the same date)
        /// </summary>
        /// <param name="dt">The date you wish to check</param>
        /// <param name="openDaySubstract">The number of open day to substract</param>
        /// <returns>A date that is a working day</returns>
        public DateTime PreviousWorkingDay(DateTime dt, int openDaySubstract)
        {
            return WorkingDayCalculator.PreviousWorkingDay(this, dt, openDaySubstract);
        }

        /// <summary>
        /// Returns the previous working day (Mon-Fri, not public holiday)
        /// before x day of the specified date (not the same date)
        /// </summary>
        /// <param name="dt">The date you wish to check</param>
        /// <param name="openDaySubstract">The number of open day to substract</param>
        /// <returns>A date that is a working day</returns>
        public DateTime PreviousWorkingDayNotSameDay(DateTime dt, int openDaySubstract)
        {
            return WorkingDayCalculator.PreviousWorkingDay(this, dt, openDaySubstract, false);
        }

        /// <summary>
        /// Gets Holidays between two date times.
        /// </summary>
        /// <param name="startDate">The beginning of the date range</param>
        /// <param name="endDate">The end of the date range</param>
        /// <returns>A list of holidays between the two dates</returns>
        public IList<Holiday> GetHolidaysInDateRange(DateTime startDate, DateTime endDate)
        {
            var holidays = new List<Holiday>();
            for (var year = startDate.Year; year <= endDate.Year; year++)
            {
                holidays.AddRange(PublicHolidaysInformation(year)
                                      .Where(d => d.ObservedDate >= startDate && d.ObservedDate <= endDate ||
                                                  d.HolidayDate >= startDate && d.HolidayDate <= endDate));
            }
            return holidays;
        }

        /// <summary>
        /// Check if a specific date is a public holiday.
        /// Default implementation checks the cached <see cref="PublicHolidaysComplete"/> list for
        /// this year, so a country only needs to override this if it has extra, non-list logic
        /// (rare - most calendars should just rely on this default).
        /// </summary>
        /// <param name="dt">The date you wish to check</param>
        /// <returns>
        /// True if date is a public holiday (excluding weekends)
        /// </returns>
        public virtual bool IsPublicHoliday(DateTime dt)
        {
            return IsPublicHolidayFromComplete(dt);
        }

        /// <summary>
        /// Adds business days (Mon-Fri, excluding public holidays) to a date
        /// </summary>
        /// <param name="dt">From date (exclusive: add 1 returns the next working day, not this date)</param>
        /// <param name="businessDays">Number of business days to add</param>
        /// <returns>The last business day</returns>
        public DateTime BusinessDaysAdd(DateTime dt, int businessDays)
        {
            return WorkingDayCalculator.BusinessDaysAdd(this, dt, businessDays);
        }

        /// <summary>
        /// Calculate the number of business days between two dates (inclusive)
        /// </summary>
        /// <param name="start">First date</param>
        /// <param name="end">Second date. If less than first date, always returns 0.</param>
        public int BusinessDaysBetween(DateTime start, DateTime end)
        {
            return WorkingDayCalculator.BusinessDaysBetween(this, start, end);
        }

    }
}
