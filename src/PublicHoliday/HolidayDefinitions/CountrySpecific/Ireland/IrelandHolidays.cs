using System;
using System.Collections.Generic;
using PublicHoliday.HolidayDefinitions;
using PublicHoliday.HolidayDefinitions.Base;
using PublicHoliday.Dates;

namespace PublicHoliday.HolidayDefinitions.CountrySpecific.Ireland
{
    /// <summary>
    /// Saint Brigid's Day (Imbolc), public holiday since 2023: 1 February when that is a Friday,
    /// otherwise the first Monday of February.
    /// </summary>
    public class StBrigidsDay : HolidayDefinition
    {
        /// <summary>Creates the definition.</summary>
        public StBrigidsDay() : base(HolidayKeys.StBrigidsDayIE, "Saint Brigid's Day")
        {
            AppliesInYear = From2023;
        }

        private static bool From2023(int year)
        {
            return year >= 2023;
        }

        /// <inheritdoc />
        protected override IEnumerable<DateTime> GetDates(int year)
        {
            var firstOfFebruary = new DateTime(year, 2, 1);
            yield return firstOfFebruary.DayOfWeek == DayOfWeek.Friday
                ? firstOfFebruary
                : HolidayCalculator.FindFirstMonday(firstOfFebruary);
        }
    }

    /// <summary>May Day - first Monday of May.</summary>
    public class MayDay : NthWeekdayHoliday
    {
        /// <summary>Creates the definition.</summary>
        public MayDay() : base(HolidayKeys.MayDayIE, "May Day", 5, DayOfWeek.Monday, 1) { }
    }

    /// <summary>June Holiday - first Monday of June.</summary>
    public class JuneHoliday : NthWeekdayHoliday
    {
        /// <summary>Creates the definition.</summary>
        public JuneHoliday() : base(HolidayKeys.JuneHolidayIE, "June Holiday", 6, DayOfWeek.Monday, 1) { }
    }

    /// <summary>August Holiday - first Monday of August.</summary>
    public class AugustHoliday : NthWeekdayHoliday
    {
        /// <summary>Creates the definition.</summary>
        public AugustHoliday() : base(HolidayKeys.AugustHolidayIE, "August Holiday", 8, DayOfWeek.Monday, 1) { }
    }

    /// <summary>October Holiday - the Monday on or before 31 October (last Monday of October).</summary>
    public class OctoberHoliday : WeekdayOnOrBeforeHoliday
    {
        /// <summary>Creates the definition.</summary>
        public OctoberHoliday() : base(HolidayKeys.OctoberHolidayIE, "October Holiday", 10, 31, DayOfWeek.Monday) { }
    }

    /// <summary>Covid-19 Commemoration - one-off, 18 March 2022.</summary>
    public class Covid19Commemoration : OneOffHoliday
    {
        /// <summary>Creates the definition.</summary>
        public Covid19Commemoration() : base(HolidayKeys.Covid19CommemorationIE, "Covid-19 Commemoration", new DateTime(2022, 3, 18)) { }
    }

    /// <summary>Millennium holiday - one-off, 31 December 1999.</summary>
    public class Millennium : OneOffHoliday
    {
        /// <summary>Creates the definition.</summary>
        public Millennium() : base(HolidayKeys.MillenniumIE, "Millennium", new DateTime(1999, 12, 31)) { }
    }
}
