using System;
using System.Collections.Generic;
using PublicHoliday.HolidayDefinitions;
using PublicHoliday.HolidayDefinitions.Base;

namespace PublicHoliday.HolidayDefinitions.CountrySpecific.USA
{
    /// <summary>
    /// New Year's Day - 1 January. The observed-date rule differs per calendar (federal:
    /// Saturday observed the Friday before / Sunday the Monday after; Federal Reserve: only
    /// Sunday shifts).
    /// </summary>
    public class NewYearsDay : FixedDateHoliday
    {
        /// <summary>Creates the definition with the calendar's weekend rule.</summary>
        public NewYearsDay(Func<DateTime, DateTime> observedDateRule) : base(HolidayKeys.NewYear, "New Year", 1, 1)
        {
            ObservedDateRule = observedDateRule;
        }
    }

    /// <summary>
    /// Next year's New Year's Day when its observed date falls on 31 December of THIS year
    /// (1 January on a Saturday under the Saturday-before rule, e.g. 1999, 2005, 2011, 2022).
    /// </summary>
    public class NewYearSpillover : HolidayDefinition
    {
        private readonly Func<DateTime, DateTime> _rule;

        /// <summary>Creates the definition with the calendar's weekend rule.</summary>
        public NewYearSpillover(Func<DateTime, DateTime> observedDateRule) : base(HolidayKeys.NewYear, "New Year")
        {
            _rule = observedDateRule;
            ObservedDateRule = observedDateRule;
        }

        /// <inheritdoc />
        protected override IEnumerable<DateTime> GetDates(int year)
        {
            var nextNewYear = new DateTime(year + 1, 1, 1);
            if (_rule(nextNewYear).Year == year)
            {
                yield return nextNewYear;
            }
        }
    }

    /// <summary>Martin Luther King Day - third Monday of January (the Monday on or after 15 January).</summary>
    public class MartinLutherKingDay : WeekdayOnOrAfterHoliday
    {
        /// <summary>Creates the definition.</summary>
        public MartinLutherKingDay() : base(HolidayKeys.MartinLutherKing, "Martin Luther King Day", 1, 15, DayOfWeek.Monday) { }
    }

    /// <summary>Presidents Day (Washington's Birthday) - third Monday of February.</summary>
    public class PresidentsDay : WeekdayOnOrAfterHoliday
    {
        /// <summary>Creates the definition.</summary>
        public PresidentsDay() : base(HolidayKeys.PresidentsDay, "President's Day", 2, 15, DayOfWeek.Monday) { }
    }

    /// <summary>Memorial Day - last Monday of May (the Monday on or after 25 May).</summary>
    public class MemorialDay : WeekdayOnOrAfterHoliday
    {
        /// <summary>Creates the definition.</summary>
        public MemorialDay() : base(HolidayKeys.MemorialDay, "Memorial Day", 5, 25, DayOfWeek.Monday) { }
    }

    /// <summary>Juneteenth - 19 June; a federal holiday from 2021 (observed by NYSE from 2022).</summary>
    public class Juneteenth : FixedDateHoliday
    {
        /// <summary>Creates the definition with the calendar's weekend rule and start year.</summary>
        public Juneteenth(Func<DateTime, DateTime> observedDateRule, int fromYear = 2021) : base(HolidayKeys.Juneteenth, "Juneteenth", 6, 19)
        {
            ObservedDateRule = observedDateRule;
            var startYear = fromYear;
            AppliesInYear = y => y >= startYear;
        }
    }

    /// <summary>Independence Day - 4 July.</summary>
    public class IndependenceDay : FixedDateHoliday
    {
        /// <summary>Creates the definition with the calendar's weekend rule.</summary>
        public IndependenceDay(Func<DateTime, DateTime> observedDateRule) : base(HolidayKeys.IndependenceDay, "Independence Day", 7, 4)
        {
            ObservedDateRule = observedDateRule;
        }
    }

    /// <summary>Labor Day - first Monday of September.</summary>
    public class LaborDay : NthWeekdayHoliday
    {
        /// <summary>Creates the definition.</summary>
        public LaborDay() : base(HolidayKeys.LaborDay, "Labor Day", 9, DayOfWeek.Monday, 1) { }
    }

    /// <summary>Columbus Day - second Monday of October (the Monday on or after 8 October).</summary>
    public class ColumbusDay : WeekdayOnOrAfterHoliday
    {
        /// <summary>Creates the definition.</summary>
        public ColumbusDay() : base(HolidayKeys.ColumbusDay, "Columbus Day", 10, 8, DayOfWeek.Monday) { }
    }

    /// <summary>Veterans Day - 11 November.</summary>
    public class VeteransDay : FixedDateHoliday
    {
        /// <summary>Creates the definition with the calendar's weekend rule.</summary>
        public VeteransDay(Func<DateTime, DateTime> observedDateRule) : base(HolidayKeys.VeteransDay, "Veteran's Day", 11, 11)
        {
            ObservedDateRule = observedDateRule;
        }
    }

    /// <summary>Thanksgiving - fourth Thursday of November (the Thursday on or after 22 November).</summary>
    public class Thanksgiving : WeekdayOnOrAfterHoliday
    {
        /// <summary>Creates the definition.</summary>
        public Thanksgiving() : base(HolidayKeys.Thanksgiving, "Thanksgiving", 11, 22, DayOfWeek.Thursday) { }
    }

    /// <summary>Christmas Day - 25 December.</summary>
    public class ChristmasDay : FixedDateHoliday
    {
        /// <summary>Creates the definition with the calendar's weekend rule.</summary>
        public ChristmasDay(Func<DateTime, DateTime> observedDateRule) : base(HolidayKeys.Christmas, "Christmas", 12, 25)
        {
            ObservedDateRule = observedDateRule;
        }
    }
}
