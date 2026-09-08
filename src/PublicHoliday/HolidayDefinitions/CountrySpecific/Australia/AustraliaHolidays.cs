using System;
using System.Collections.Generic;
using PublicHoliday.HolidayDefinitions;
using PublicHoliday.HolidayDefinitions.Base;
using PublicHoliday.Dates;

namespace PublicHoliday.HolidayDefinitions.CountrySpecific.Australia
{
    /// <summary>Australia Day - 26 January (weekend shifts to Monday).</summary>
    public class AustraliaDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public AustraliaDay() : base(HolidayKeys.AustraliaDay, "Australia Day", 1, 26)
        {
            ObservedDateRule = HolidayCalculator.FixWeekend;
        }
    }

    /// <summary>
    /// ANZAC Day - 25 April. In ACT, NT, SA and WA a weekend date shifts to Monday; elsewhere
    /// it stays where it falls. Constructed with the shift flag by the calendar.
    /// </summary>
    public class AnzacDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        /// <param name="shiftWeekend">True to move a Saturday/Sunday ANZAC Day to Monday (ACT/NT/SA/WA).</param>
        public AnzacDay(bool shiftWeekend) : base(HolidayKeys.AnzacDay, "ANZAC Day", 4, 25)
        {
            if (shiftWeekend)
            {
                ObservedDateRule = HolidayCalculator.FixWeekend;
            }
        }
    }

    /// <summary>Canberra Day (ACT) - 2nd Monday of March (3rd Monday before 2008).</summary>
    public class CanberraDay : HolidayDefinition
    {
        /// <summary>Creates the definition.</summary>
        public CanberraDay() : base(HolidayKeys.CanberraDayAU, "Canberra Day") { }

        /// <inheritdoc />
        protected override IEnumerable<DateTime> GetDates(int year)
        {
            var secondMonday = HolidayCalculator.FindNext(new DateTime(year, 3, 1), DayOfWeek.Monday).AddDays(7);
            yield return year < 2008 ? secondMonday.AddDays(7) : secondMonday;
        }
    }

    /// <summary>Western Australia Day - first Monday of June.</summary>
    public class WesternAustraliaDay : NthWeekdayHoliday
    {
        /// <summary>Creates the definition.</summary>
        public WesternAustraliaDay() : base(HolidayKeys.WesternAustraliaDay, "Western Australia Day", 6, DayOfWeek.Monday, 1) { }
    }

    /// <summary>Picnic Day (NT) - first Monday of August.</summary>
    public class PicnicDay : NthWeekdayHoliday
    {
        /// <summary>Creates the definition.</summary>
        public PicnicDay() : base(HolidayKeys.PicnicDayAU, "Picnic Day", 8, DayOfWeek.Monday, 1) { }
    }

    /// <summary>Bank Holiday (NSW financial sector) - first Monday of August.</summary>
    public class BankHoliday : NthWeekdayHoliday
    {
        /// <summary>Creates the definition.</summary>
        public BankHoliday() : base(HolidayKeys.BankHolidayNSW, "Bank Holiday", 8, DayOfWeek.Monday, 1) { }
    }

    /// <summary>
    /// Family and Community Day (ACT), 2007-2017: first Tuesday of November until 2009, then the
    /// first Monday of the Sep/Oct school holidays (moved a week when it hits Labour Day).
    /// </summary>
    public class FamilyAndCommunityDay : HolidayDefinition
    {
        /// <summary>Creates the definition.</summary>
        public FamilyAndCommunityDay() : base(HolidayKeys.FamilyCommunityDayAU, "Family And Community Day") { }

        /// <inheritdoc />
        protected override IEnumerable<DateTime> GetDates(int year)
        {
            if (year < 2007) yield break;
            if (year <= 2009)
            {
                yield return HolidayCalculator.FindNext(new DateTime(year, 11, 1), DayOfWeek.Tuesday);
                yield break;
            }
            var facDay = HolidayCalculator.FindNext(new DateTime(year, 9, 25), DayOfWeek.Monday);
            if (facDay == HolidayCalculator.FindNext(new DateTime(year, 10, 1), DayOfWeek.Monday))
                facDay = facDay.AddDays(7);
            yield return facDay;
        }
    }

    /// <summary>Melbourne Cup (VIC) - first Tuesday of November.</summary>
    public class MelbourneCup : NthWeekdayHoliday
    {
        /// <summary>Creates the definition.</summary>
        public MelbourneCup() : base(HolidayKeys.MelbourneCupAU, "Melbourne Cup", 11, DayOfWeek.Tuesday, 1) { }
    }

    /// <summary>Christmas Day - 25 December (weekend shifts to Monday).</summary>
    public class ChristmasDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public ChristmasDay() : base(HolidayKeys.Christmas, "Christmas Day", 12, 25)
        {
            ObservedDateRule = HolidayCalculator.FixWeekend;
        }
    }

    /// <summary>
    /// Boxing Day - 26 December; cascades behind the observed Christmas Day over a weekend.
    /// In South Australia named Proclamation Day (the calendar overrides key and name).
    /// </summary>
    public class BoxingDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public BoxingDay() : base(HolidayKeys.BoxingDay, "Boxing Day", 12, 26)
        {
            ObservedDateRule = Observed;
        }

        private static DateTime Observed(DateTime date)
        {
            bool isSundayOrMonday = date.DayOfWeek == DayOfWeek.Sunday || date.DayOfWeek == DayOfWeek.Monday;
            var observed = HolidayCalculator.FixWeekend(date);
            return isSundayOrMonday ? observed.AddDays(1) : observed;
        }
    }

    /// <summary>National Day of Mourning for Queen Elizabeth II - one-off, 22 September 2022.</summary>
    public class NationalDayOfMourning2022 : OneOffHoliday
    {
        /// <summary>Creates the definition.</summary>
        public NationalDayOfMourning2022() : base(HolidayKeys.NationalDayOfMourningAU2022, "National Day of Mourning", new DateTime(2022, 9, 22)) { }
    }
}
