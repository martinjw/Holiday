using System;
using System.Globalization;
using PublicHoliday.Localization;

namespace PublicHoliday
{
    /// <summary>
    /// A single occurrence of a holiday. Plain value object: the culture-aware name resolution
    /// policy lives in <see cref="HolidayNameResolver"/>.
    /// </summary>
    public class Holiday : IHoliday
    {
        private readonly string _localName;

        private Holiday(DateTime date, DateTime observedDate, string englishName, string localName,
            string holidayKey, bool isPublic, string[] regions)
        {
            HolidayDate = date;
            ObservedDate = observedDate;
            EnglishName = englishName;
            _localName = localName;
            HolidayKey = holidayKey;
            IsPublic = isPublic;
            Regions = regions;
        }

        /// <summary>
        /// A holiday observed on the day it falls, with an English name.
        /// </summary>
        /// <param name="date">The date it falls on, which is also the date it is observed.</param>
        /// <param name="englishName">The English name.</param>
        public Holiday(DateTime date, string englishName)
            : this(date, date, englishName, null, null, true, null)
        {
        }

        /// <summary>
        /// A holiday observed on the day it falls, with an English name and a name in the country's own
        /// language.
        /// </summary>
        /// <param name="date">The date it falls on, which is also the date it is observed.</param>
        /// <param name="englishName">The English name.</param>
        /// <param name="localName">The name in the country's own language.</param>
        public Holiday(DateTime date, string englishName, string localName)
            : this(date, date, englishName, localName, null, true, null)
        {
        }

        /// <summary>
        /// Constructs the holiday
        /// </summary>
        /// <param name="date">The date of the current holiday</param>
        /// <param name="observedDate">The date the current holiday is observed on</param>
        public Holiday(DateTime date, DateTime observedDate)
            : this(date, observedDate, null, null, null, true, null)
        {
        }

        /// <summary>
        /// Constructs the holiday
        /// </summary>
        /// <param name="date">The date of the current holiday</param>
        /// <param name="observedDate">The date the current holiday is observed on</param>
        /// <param name="holidayKey">The Id of text for the Localization</param>
        public Holiday(DateTime date, DateTime observedDate, string holidayKey)
            : this(date, observedDate, null, null, holidayKey, true, null)
        {
        }

        /// <summary>
        /// Constructs the holiday with an observed date, a local-language name and a localization id.
        /// </summary>
        /// <param name="date">The date of the current holiday</param>
        /// <param name="observedDate">The date the current holiday is observed on</param>
        /// <param name="localName">The name in the country's own language</param>
        /// <param name="holidayKey">The Id of text for the Localization</param>
        public Holiday(DateTime date, DateTime observedDate, string localName, string holidayKey)
            : this(date, observedDate, null, localName, holidayKey, true, null)
        {
        }

        /// <summary>
        /// A holiday observed in only part of the country: <see cref="IsPublic"/> is false and
        /// <see cref="Regions"/> names where it applies.
        /// </summary>
        /// <param name="date">The date it falls on, which is also the date it is observed.</param>
        /// <param name="englishName">The English name.</param>
        /// <param name="localName">The name in the country's own language.</param>
        /// <param name="regions">The regions of the country that observe it.</param>
        public Holiday(DateTime date, string englishName, string localName, string[] regions)
            : this(date, date, englishName, localName, null, false, regions)
        {
        }

        /// <summary>
        /// The date the Holiday is actually observed on
        /// </summary>
        public DateTime ObservedDate { get; set; }

        /// <summary>
        /// Date for the current holiday
        /// </summary>
        public DateTime HolidayDate { get; set; }

        /// <summary>
        /// English name of holiday. Use <see cref="Name"/> for local name
        /// </summary>
        public string EnglishName { get; set; }

        /// <summary>
        /// The name in the calendar's <see cref="Culture"/> - what that country calls it. Falls
        /// back to <see cref="EnglishName"/>. Use <see cref="GetName(CultureInfo)"/> to ask for a
        /// particular language instead.
        /// </summary>
        public string Name
        {
            get { return HolidayNameResolver.Name(this); }
        }

        /// <summary>
        /// The name the calendar set in code, if any - null for the great majority, which take their name
        /// from the resource file for their culture.
        /// </summary>
        internal string LocalName
        {
            get { return _localName; }
        }

        /// <summary>
        /// Which day of a multi-day holiday this is, counting from 1; 0 when the holiday lasts a day.
        /// Substituted into a name containing "{0}" - see <see cref="Name"/>.
        /// </summary>
        internal int DayNumber { get; set; }

        /// <summary>
        /// Which calendar produced this holiday, so a calendar that words a holiday differently from the
        /// culture it shares can be given its own resource file. Set by the calendar.
        /// </summary>
        internal string CalendarId { get; set; }

        /// <summary>
        /// Id of text for the localization
        /// </summary>
        public string HolidayKey { get; set; }

        /// <summary>
        /// The language this holiday's <see cref="Name"/> is in, and the fallback for
        /// <see cref="GetName(CultureInfo)"/>. Set by the calendar that produced it (see
        /// <see cref="PublicHolidayBase.Culture"/>).
        /// </summary>
        public CultureInfo Culture { get; set; }

        /// <summary>
        /// Is the holiday a public holiday for all regions
        /// </summary>
        public bool IsPublic { get; set; }

        /// <summary>
        /// Names of regions of the country where this holiday exists
        /// </summary>
        public string[] Regions { get; set; }

        /// <summary>
        /// Localized name for the given culture; see <see cref="HolidayNameResolver"/> for the
        /// resolution order. Never returns an empty string when a name exists anywhere.
        /// </summary>
        public string GetName(CultureInfo culture)
        {
            return HolidayNameResolver.Name(this, culture);
        }

        /// <summary>
        /// Localized name for the given culture name (e.g. "fr-BE"). See <see cref="GetName(CultureInfo)"/>.
        /// </summary>
        public string GetName(string culture)
        {
            return GetName(string.IsNullOrEmpty(culture) ? null : new CultureInfo(culture));
        }

        /// <summary>
        /// Gets the year component of the observed date
        /// </summary>
        public int Year => ObservedDate.Year;

        /// <summary>
        /// Gets the month component of the observed date
        /// </summary>
        public int Month => ObservedDate.Month;

        /// <summary>
        /// Gets the day component of the observed date
        /// </summary>
        public int Day => ObservedDate.Day;

        /// <summary>
        /// Gets the day of the week of the observed date
        /// </summary>
        public DayOfWeek DayOfWeek => ObservedDate.DayOfWeek;

        /// <summary>
        /// Implicitly casts a holiday as its observed date
        /// </summary>
        /// <param name="h">The holiday</param>
        public static implicit operator DateTime(Holiday h)
        {
            return h.ObservedDate;
        }

        /// <summary>
        /// The holiday name and date(s)
        /// </summary>
        public override string ToString()
        {
            return $"{Name} {ObservedDate:yyyy-MM-dd} {HolidayDate:yyyy-MM-dd}";
        }
    }
}
