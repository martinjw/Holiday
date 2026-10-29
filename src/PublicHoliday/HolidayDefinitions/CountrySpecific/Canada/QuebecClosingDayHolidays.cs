using System;
using System.Collections.Generic;
using PublicHoliday.HolidayDefinitions;
using PublicHoliday.HolidayDefinitions.Base;
using PublicHoliday.Dates;

namespace PublicHoliday.HolidayDefinitions.CountrySpecific.Canada
{
    /// <summary>Day after New Year (Quebec government closing day) - 2 January, two-holiday weekend shift.</summary>
    public class QuebecDayAfterNewYear : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public QuebecDayAfterNewYear() : base(HolidayKeys.DayAfterNewYear, "Day After New Year", 1, 2)
        {
            ObservedDateRule = HolidayCalculator.FixWeekendTwoHolidayAfter;
        }
    }

    /// <summary>
    /// National Patriots' Day - the Monday on or before 24 May (named Dollard Day before 2003).
    /// </summary>
    public class NationalPatriotDay : WeekdayOnOrBeforeHoliday
    {
        /// <summary>Creates the definition.</summary>
        public NationalPatriotDay() : base(HolidayKeys.NationalPatriotDay, "National Patriots' Day", 5, 24, DayOfWeek.Monday) { }

        /// <inheritdoc />
        protected override string HolidayKeyFor(int year, int index, int count)
        {
            return year > 2002 ? HolidayKeys.NationalPatriotDay : HolidayKeys.DollardDay;
        }
    }

    /// <summary>Quebec National Holiday (St-Jean-Baptiste) - 24 June, Saturday before / Sunday after shift.</summary>
    public class QuebecNationalHoliday : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public QuebecNationalHoliday() : base(HolidayKeys.NationalHolidayQuebec, "Quebec National Holiday", 6, 24)
        {
            ObservedDateRule = HolidayCalculator.FixWeekendSaturdayBeforeSundayAfter;
        }
    }

    /// <summary>
    /// Canada Day (Quebec government observance) - 1 July, Saturday before / Sunday after shift
    /// (named Dominion Day before 1982).
    /// </summary>
    public class QuebecCanadaDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public QuebecCanadaDay() : base(HolidayKeys.CanadaDay, "Canada Day", 7, 1)
        {
            ObservedDateRule = HolidayCalculator.FixWeekendSaturdayBeforeSundayAfter;
        }

        /// <inheritdoc />
        protected override string HolidayKeyFor(int year, int index, int count)
        {
            return year > 1981 ? HolidayKeys.CanadaDay : HolidayKeys.DominionDay;
        }
    }

    /// <summary>Day before Christmas - 24 December, two-holiday weekend shift (backwards).</summary>
    public class DayBeforeChristmas : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public DayBeforeChristmas() : base(HolidayKeys.DayBeforeChristmas, "Day Before Christmas", 12, 24)
        {
            ObservedDateRule = HolidayCalculator.FixWeekendTwoHolidayBefore;
        }
    }

    /// <summary>Day after Christmas - 26 December, two-holiday weekend shift.</summary>
    public class DayAfterChristmas : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public DayAfterChristmas() : base(HolidayKeys.DayAfterChristmas, "Day After Christmas", 12, 26)
        {
            ObservedDateRule = HolidayCalculator.FixWeekendTwoHolidayAfter;
        }
    }

    /// <summary>Day before New Year - 31 December, two-holiday weekend shift (backwards).</summary>
    public class DayBeforeNewYear : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public DayBeforeNewYear() : base(HolidayKeys.DayBeforeNewYear, "Day Before New Year", 12, 31)
        {
            ObservedDateRule = HolidayCalculator.FixWeekendTwoHolidayBefore;
        }
    }
}
