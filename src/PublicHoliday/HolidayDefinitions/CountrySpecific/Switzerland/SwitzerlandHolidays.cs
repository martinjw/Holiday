using System;
using System.Collections.Generic;
using PublicHoliday.HolidayDefinitions;
using PublicHoliday.HolidayDefinitions.Christian;
using PublicHoliday.HolidayDefinitions.Base;
using PublicHoliday.Dates;

namespace PublicHoliday.HolidayDefinitions.CountrySpecific.Switzerland
{
    /// <summary>Berchtold's Day - 2 January (some cantons).</summary>
    public class BerchtoldsDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public BerchtoldsDay() : base(HolidayKeys.Berchtold, "Berchtold's Day", 1, 2) { }
    }

    /// <summary>Neuchâtel Republic Day - 1 March.</summary>
    public class NeuchatelRepublicDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public NeuchatelRepublicDay() : base(HolidayKeys.NeuchatelRepublicDay, "Republic Day", 3, 1) { }
    }

    /// <summary>Saint Joseph's Day - 19 March (some cantons).</summary>
    public class StJosephDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public StJosephDay() : base(HolidayKeys.StJoseph, "Saint Joseph's Day", 3, 19) { }
    }

    /// <summary>Swiss Ascension Day - 39 days after Easter (its own key for the CH/FR name variants).</summary>
    public class SwissAscension : EasterRelativeHoliday
    {
        /// <summary>Creates the definition.</summary>
        public SwissAscension() : base(HolidayKeys.SwissAscension, "Ascension Day", 39) { }
    }

    /// <summary>Swiss National Day (Bundesfeier) - 1 August.</summary>
    public class SwissNationalDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public SwissNationalDay() : base(HolidayKeys.SwissNationalDay, "National Day", 8, 1) { }
    }

    /// <summary>Jeûne genevois (Geneva Prayer Day) - the Thursday after the first Sunday of September.</summary>
    public class GenevaPrayDay : HolidayDefinition
    {
        /// <summary>Creates the definition.</summary>
        public GenevaPrayDay() : base(HolidayKeys.GenevaPrayDay, "Geneva Fast") { }

        /// <inheritdoc />
        protected override IEnumerable<DateTime> GetDates(int year)
        {
            var firstSundayOfSeptember = HolidayCalculator.FindOccurrenceOfDayOfWeek(new DateTime(year, 9, 1), DayOfWeek.Sunday, 1);
            yield return HolidayCalculator.FindNext(firstSundayOfSeptember, DayOfWeek.Thursday);
        }
    }
}
