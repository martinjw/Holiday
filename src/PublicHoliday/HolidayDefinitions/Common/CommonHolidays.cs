using PublicHoliday.HolidayDefinitions.Base;

namespace PublicHoliday.HolidayDefinitions.Common
{
    /// <summary>New Year's Day - 1 January.</summary>
    public class NewYear : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public NewYear() : base(HolidayKeys.NewYear, "New Year", 1, 1) { }
    }

    /// <summary>Day after New Year - 2 January.</summary>
    public class DayAfterNewYear : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public DayAfterNewYear() : base(HolidayKeys.DayAfterNewYear, "Day After New Year", 1, 2) { }
    }

    /// <summary>Labour Day / International Workers' Day - 1 May.</summary>
    public class LabourDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public LabourDay() : base(HolidayKeys.LabourDay, "Labour Day", 5, 1) { }
    }

    /// <summary>International Women's Day - 8 March.</summary>
    public class WomensDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public WomensDay() : base(HolidayKeys.WomensDay, "International Women's Day", 3, 8) { }
    }

    /// <summary>New Year's Eve - 31 December.</summary>
    public class NewYearsEve : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public NewYearsEve() : base(HolidayKeys.NewYearsEve, "New Year's Eve", 12, 31) { }
    }

    /// <summary>Armistice Day - 11 November (Belgium, France, Serbia).</summary>
    public class Armistice : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public Armistice() : base(HolidayKeys.Armistice, "Armistice Day", 11, 11) { }
    }

    /// <summary>Victory in Europe Day - 8 May (France, Czech Republic, Slovakia).</summary>
    public class VictoryInEuropeDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public VictoryInEuropeDay() : base(HolidayKeys.VictoryInEuropeDay, "Victory in Europe Day", 5, 8) { }
    }

    /// <summary>
    /// Second Labour Day - 2 May (Slovenia, Montenegro, Serbia). Countries override
    /// <see cref="HolidayDefinition.HolidayKey"/> with their own key.
    /// </summary>
    public class DayAfterLabourDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public DayAfterLabourDay() : base(HolidayKeys.DayAfterLabourDay, "Labour Day Holiday", 5, 2) { }
    }
}
