using System;
using System.Collections.Generic;
using PublicHoliday.HolidayDefinitions;
using PublicHoliday.HolidayDefinitions.Base;
using PublicHoliday.Dates;

namespace PublicHoliday.HolidayDefinitions.CountrySpecific.Germany
{
    /// <summary>German Unity Day - 3 October.</summary>
    public class GermanUnityDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public GermanUnityDay() : base(HolidayKeys.GermanUnityDE, "German Unity Day", 10, 3) { }
    }

    /// <summary>
    /// Buß- und Bettag (Repentance Day, Saxony) - the Wednesday before the last Sunday before
    /// Advent (11 days before the first Advent Sunday).
    /// </summary>
    public class RepentanceDay : HolidayDefinition
    {
        /// <summary>Creates the definition.</summary>
        public RepentanceDay() : base(HolidayKeys.RepentanceDayDE, "Repentance Day") { }

        /// <inheritdoc />
        protected override IEnumerable<DateTime> GetDates(int year)
        {
            var firstAdvent = HolidayCalculator.FindPrevious(new DateTime(year, 11, 30), DayOfWeek.Thursday).AddDays(3);
            yield return HolidayCalculator.FindPrevious(firstAdvent.AddDays(-7), DayOfWeek.Wednesday);
        }
    }

    /// <summary>World Children's Day (Thuringia) - 20 September, since 2019.</summary>
    public class WorldChildrensDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public WorldChildrensDay() : base(HolidayKeys.WorldChildrensDayDE, "World Children's Day", 9, 20) { }
    }

    /// <summary>Liberation Day (Berlin) - one-off 80th anniversary, 8 May 2025.</summary>
    public class LiberationDay2025 : OneOffHoliday
    {
        /// <summary>Creates the definition.</summary>
        public LiberationDay2025() : base(HolidayKeys.LiberationDayDE, "Liberation Day", new DateTime(2025, 5, 8)) { }
    }

    /// <summary>East German Uprising Memorial Day (Berlin) - one-off 75th anniversary, 17 June 2028.</summary>
    public class EastGermanUprisingMemorialDay2028 : OneOffHoliday
    {
        /// <summary>Creates the definition.</summary>
        public EastGermanUprisingMemorialDay2028() : base(HolidayKeys.EastGermanUprisingDE, "East German Uprising Memorial Day", new DateTime(2028, 6, 17)) { }
    }
}
