using System;
using System.Collections.Generic;
using PublicHoliday.Dates;

namespace PublicHoliday.HolidayDefinitions.Base
{
    /// <summary>
    /// Defines a holiday: its stable identity (localization key), default English name, and how
    /// its date(s) are computed for a year. A calendar composes its year from a list of these.
    ///
    /// A country deviates from the defaults by setting properties on its own instance:
    /// <list type="bullet">
    /// <item><description><see cref="ObservedDateRule"/> - e.g. South Africa's
    /// <c>new NewYear { ObservedDateRule = HolidayCalculator.FixWeekendSundayAfter }</c></description></item>
    /// <item><description><see cref="LocalName"/> - the display name in the country's language</description></item>
    /// <item><description><see cref="AppliesInYear"/> - year gating, including disjoint historical
    /// ranges, e.g. <c>new GoodFriday { AppliesInYear = y => y >= 2016 || (y >= 1947 &amp;&amp; y &lt;= 1951) }</c></description></item>
    /// <item><description><see cref="Regions"/> - region/state/canton gating</description></item>
    /// </list>
    /// Subclass only when the date computation itself is bespoke (lookup tables, year-banded
    /// formulas); see <see cref="FixedDateHoliday"/> and the Christian/Islamic/Common definitions.
    ///
    /// The setters are internal: calendars hold their definitions in shared static arrays, so a
    /// definition is configured once at construction and never mutated afterwards.
    /// </summary>
    public abstract class HolidayDefinition
    {
        /// <summary>
        /// Creates the definition with its stable identity and default English name.
        /// </summary>
        /// <param name="holidayKey">Stable identity / localization key (e.g. "NewYear", "BelgianNationalDay").</param>
        /// <param name="englishName">Default English display name.</param>
        protected HolidayDefinition(string holidayKey, string englishName)
        {
            HolidayKey = holidayKey;
            EnglishName = englishName;
            ObservedDateRule = NoShift;
        }

        /// <summary>
        /// Stable identity / localization key of the holiday (e.g. "NewYear"). Shared keys resolve
        /// translations from the localization resource for every country that uses them.
        /// </summary>
        public string HolidayKey { get; internal set; }

        /// <summary>
        /// English display name.
        /// </summary>
        public string EnglishName { get; internal set; }

        /// <summary>
        /// Display name in the country's own language. Null = fall back to the localization
        /// resource / <see cref="EnglishName"/>.
        /// </summary>
        public string LocalName { get; internal set; }

        /// <summary>
        /// Transforms each actual date into the observed date (weekend-shift rules such as
        /// <see cref="HolidayCalculator.FixWeekend"/> plug in here). Default: no shift.
        /// </summary>
        public Func<DateTime, DateTime> ObservedDateRule { get; internal set; }

        /// <summary>
        /// Year gate: return false for years the holiday does not exist. Null (default) = always.
        /// </summary>
        public Func<int, bool> AppliesInYear { get; internal set; }

        /// <summary>
        /// Region/state/canton names this holiday is limited to. Null = applies everywhere.
        /// </summary>
        public string[] Regions { get; internal set; }

        /// <summary>
        /// The actual (unshifted) date(s) of the holiday in the year: zero (does not occur),
        /// one (the usual case), or several (multi-day holidays such as Eid).
        /// </summary>
        protected abstract IEnumerable<DateTime> GetDates(int year);

        /// <summary>
        /// The local display name for one occurrence; override for per-day labels of multi-day
        /// holidays. Default: <see cref="LocalName"/>.
        /// </summary>
        protected virtual string LocalNameFor(int year, int index, int count)
        {
            return LocalName;
        }

        /// <summary>
        /// The localization key for one occurrence; override for per-day keys of multi-day
        /// holidays. Default: <see cref="HolidayKey"/>.
        /// </summary>
        protected virtual string HolidayKeyFor(int year, int index, int count)
        {
            return HolidayKey;
        }

        /// <summary>
        /// Which day of a multi-day holiday this occurrence is, counting from 1; 0 for the great majority,
        /// which last a day. A name containing "{0}" has this substituted into it, so a holiday whose days
        /// are numbered needs one resource row rather than one per day
        /// (<c>"Ramazan Bayramı {0}. Gün"</c>).
        /// </summary>
        protected virtual int DayNumberFor(int year, int index, int count)
        {
            return 0;
        }

        /// <summary>
        /// Builds this definition's <see cref="Holiday"/> occurrence(s) for the year.
        /// Region-limited definitions produce region-only holidays (<see cref="Holiday.IsPublic"/> false).
        /// </summary>
        public IEnumerable<Holiday> Build(int year)
        {
            if (AppliesInYear != null && !AppliesInYear(year)) yield break;

            var dates = new List<DateTime>(GetDates(year));
            for (int i = 0; i < dates.Count; i++)
            {
                var observed = ObservedDateRule == null ? dates[i] : ObservedDateRule(dates[i]);
                var holiday = new Holiday(dates[i], observed, LocalNameFor(year, i, dates.Count), HolidayKeyFor(year, i, dates.Count))
                {
                    EnglishName = EnglishName,
                    DayNumber = DayNumberFor(year, i, dates.Count),
                };
                if (Regions != null)
                {
                    holiday.IsPublic = false;
                    holiday.Regions = Regions;
                }
                yield return holiday;
            }
        }

        /// <summary>
        /// Builds for a calendar configured for one specific region (canton, state, ...): a
        /// region-limited definition is skipped unless the selected region is in its
        /// <see cref="Regions"/>, and the produced holidays are public (unambiguous from that
        /// one region's point of view).
        /// </summary>
        public IEnumerable<Holiday> Build(int year, string selectedRegion)
        {
            if (Regions != null && Array.IndexOf(Regions, selectedRegion) < 0) yield break;
            foreach (var holiday in Build(year))
            {
                holiday.IsPublic = true;
                holiday.Regions = null;
                yield return holiday;
            }
        }

        private static DateTime NoShift(DateTime date)
        {
            return date;
        }
    }
}
