using PublicHoliday.HolidayDefinitions.Base;

namespace PublicHoliday.HolidayDefinitions.CountrySpecific.Slovakia
{
    /// <summary>
    /// Day of the Establishment of the Slovak Republic - 1 January (since 1994; the same date
    /// was New Year's Day before the split of Czechoslovakia).
    /// </summary>
    public class SlovakRepublicEstablishmentDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public SlovakRepublicEstablishmentDay() : base(HolidayKeys.SlovakEstablishmentDay, "Day of the Establishment of the Slovak Republic", 1, 1) { }
    }

    /// <summary>Slovak National Uprising Anniversary - 29 August (since 1994).</summary>
    public class SlovakNationalUprisingDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public SlovakNationalUprisingDay() : base(HolidayKeys.SlovakNationalUprisingDay, "Slovak National Uprising Anniversary", 8, 29) { }
    }

    /// <summary>Day of the Constitution of the Slovak Republic - 1 September (since 1994).</summary>
    public class SlovakConstitutionDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public SlovakConstitutionDay() : base(HolidayKeys.SlovakConstitutionDay, "Day of the Constitution of the Slovak Republic", 9, 1) { }
    }

    /// <summary>Day of Our Lady of the Seven Sorrows, patron saint of Slovakia - 15 September.</summary>
    public class LadyOfSevenSorrowsDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public LadyOfSevenSorrowsDay() : base(HolidayKeys.LadySevenSorrowsSK, "Day of Our Lady of the Seven Sorrows", 9, 15) { }
    }
}
