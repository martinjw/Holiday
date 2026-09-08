using System;
using System.Collections.Generic;
using PublicHoliday.HolidayDefinitions;
using PublicHoliday.HolidayDefinitions.Base;
using PublicHoliday.Dates;

namespace PublicHoliday.HolidayDefinitions.CountrySpecific.SouthAfrica
{
    /// <summary>Human Rights Day - 21 March (Sunday shifts to Monday).</summary>
    public class HumanRightsDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public HumanRightsDay() : base(HolidayKeys.HumanRightsDayZA, "Human Rights Day", 3, 21)
        {
            ObservedDateRule = HolidayCalculator.FixWeekendSundayAfter;
        }
    }

    /// <summary>Freedom Day - 27 April (Sunday shifts to Monday).</summary>
    public class FreedomDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public FreedomDay() : base(HolidayKeys.FreedomDayZA, "Freedom Day", 4, 27)
        {
            ObservedDateRule = HolidayCalculator.FixWeekendSundayAfter;
        }
    }

    /// <summary>Youth Day - 16 June (Sunday shifts to Monday).</summary>
    public class YouthDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public YouthDay() : base(HolidayKeys.YouthDayZA, "Youth Day", 6, 16)
        {
            ObservedDateRule = HolidayCalculator.FixWeekendSundayAfter;
        }
    }

    /// <summary>National Women's Day - 9 August (Sunday shifts to Monday).</summary>
    public class NationalWomensDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public NationalWomensDay() : base(HolidayKeys.WomensDayZA, "National Women's Day", 8, 9)
        {
            ObservedDateRule = HolidayCalculator.FixWeekendSundayAfter;
        }
    }

    /// <summary>Heritage Day - 24 September (Sunday shifts to Monday).</summary>
    public class HeritageDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public HeritageDay() : base(HolidayKeys.HeritageDayZA, "Heritage Day", 9, 24)
        {
            ObservedDateRule = HolidayCalculator.FixWeekendSundayAfter;
        }
    }

    /// <summary>Day of Reconciliation - 16 December (Sunday shifts to Monday).</summary>
    public class ReconciliationDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public ReconciliationDay() : base(HolidayKeys.ReconciliationDayZA, "Day of Reconciliation", 12, 16)
        {
            ObservedDateRule = HolidayCalculator.FixWeekendSundayAfter;
        }
    }

    /// <summary>
    /// Christmas Day - 25 December. Normally does not shift (Boxing Day takes the Monday), but
    /// in 2022 the President proclaimed it observed on 26 December (25th was a Sunday).
    /// </summary>
    public class ChristmasDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public ChristmasDay() : base(HolidayKeys.Christmas, "Christmas Day", 12, 25)
        {
            ObservedDateRule = Observed;
        }

        private static DateTime Observed(DateTime date)
        {
            //presidential proclamation: https://twitter.com/PresidencyZA/status/1600748006986452994
            return date.Year == 2022 ? new DateTime(2022, 12, 26) : date;
        }
    }

    /// <summary>
    /// Day of Goodwill - 26 December (Sunday shifts to Monday); in 2022 observed on
    /// 27 December because Christmas was observed on the 26th.
    /// </summary>
    public class DayOfGoodwill : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public DayOfGoodwill() : base(HolidayKeys.DayOfGoodwillZA, "Day of Goodwill", 12, 26)
        {
            ObservedDateRule = Observed;
        }

        private static DateTime Observed(DateTime date)
        {
            if (date.Year == 2022) return new DateTime(2022, 12, 27);
            return HolidayCalculator.FixWeekendSundayAfter(date);
        }
    }

    /// <summary>Rugby World Cup celebration - one-off, 15 December 2023.</summary>
    public class RugbyWorldCupCelebration : OneOffHoliday
    {
        /// <summary>Creates the definition.</summary>
        public RugbyWorldCupCelebration() : base(HolidayKeys.RugbyWorldCupZA, "Rugby World Cup celebration", new DateTime(2023, 12, 15)) { }
    }

    /// <summary>Election day - one-off, 29 May 2024.</summary>
    public class ElectionDay2024 : OneOffHoliday
    {
        /// <summary>Creates the definition.</summary>
        public ElectionDay2024() : base(HolidayKeys.ElectionDayZA2024, "Election day", new DateTime(2024, 5, 29)) { }
    }
}
