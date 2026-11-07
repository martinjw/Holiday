using System;
using System.Collections.Generic;
using PublicHoliday.HolidayDefinitions;
using PublicHoliday.HolidayDefinitions.Christian;
using Christian = PublicHoliday.HolidayDefinitions.Christian;
using Common = PublicHoliday.HolidayDefinitions.Common;
using Local = PublicHoliday.HolidayDefinitions.CountrySpecific.SouthAfrica;
using PublicHoliday.HolidayDefinitions.Base;
using System.Globalization;
using PublicHoliday.Localization;
using PublicHoliday.Dates;

namespace PublicHoliday
{
    /// <summary>
    /// Holidays in South Africa https://www.gov.za/about-sa/public-holidays
    /// </summary>
    /// <remarks>
    /// Missing because no fixed date: 
    /// </remarks>
    public class SouthAfricaPublicHoliday : PublicHolidayBase
    {

        /// <summary>
        /// Culture whose language this calendar's holiday names are in: South African English.
        /// Used by <see cref="Holiday.GetName(CultureInfo)"/> when the requested
        /// culture has no translation.
        /// </summary>
        protected override CultureInfo CountryCulture => _defaultCulture;

        private static readonly CultureInfo _defaultCulture = SafeCulture.Get("en-ZA", "en");
        #region Individual Holidays

        /// <summary>
        /// New Year's Day
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime NewYear(int year)
        {
            return HolidayCalculator.FixWeekendSundayAfter(new DateTime(year, 1, 1));
        }

        /// <summary>
        /// Human Rights Day March 21
        /// </summary>

        public static DateTime HumanRightsDay(int year)
        {
            return HolidayCalculator.FixWeekendSundayAfter(new DateTime(year, 3, 21));
        }

        /// <summary>
        /// Good Friday (Friday before Easter)
        /// </summary>
        public static DateTime GoodFriday(int year)
        {
            var easter = EasterCalculator.GetEaster(year);
            return GoodFriday(easter);
        }
        private static DateTime GoodFriday(DateTime easter)
        {
            return EasterCalculator.GoodFriday(easter);
        }

        /// <summary>
        /// Easter Monday/Family Day
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime EasterMonday(int year)
        {
            var easter = EasterCalculator.GetEaster(year);
            return EasterMonday(easter);
        }

        private static DateTime EasterMonday(DateTime easter)
        {
            return EasterCalculator.EasterMonday(easter);
        }

        /// <summary>
        /// Freedom Day April 27
        /// </summary>

        public static DateTime FreedomDay(int year)
        {
            return HolidayCalculator.FixWeekendSundayAfter(new DateTime(year, 4, 27));
        }


        /// <summary>
        /// International Labour Day/Workers' Day May 1
        /// </summary>
        /// <param name="year">The year.</param>
        /// 
        public static DateTime LabourDay(int year)
        {
            return HolidayCalculator.FixWeekendSundayAfter(new DateTime(year, 5, 1));
        }

        /// <summary>
        /// Soweto Day/Youth Day June 16
        /// </summary>

        public static DateTime YouthDay(int year)
        {
            return HolidayCalculator.FixWeekendSundayAfter(new DateTime(year, 6, 16));
        }

        /// <summary>
        /// National Women's Day August 9
        /// </summary>

        public static DateTime NationalWomensDay(int year)
        {
            return HolidayCalculator.FixWeekendSundayAfter(new DateTime(year, 8, 9));
        }

        /// <summary>
        /// Heritage Day September 24
        /// </summary>

        public static DateTime HeritageDay(int year)
        {
            return HolidayCalculator.FixWeekendSundayAfter(new DateTime(year, 9, 24));
        }

        /// <summary>
        /// Day of Reconciliation September 24
        /// </summary>

        public static DateTime ReconciliationDay(int year)
        {
            return HolidayCalculator.FixWeekendSundayAfter(new DateTime(year, 12, 16));
        }

        /// <summary>
        /// Christmas
        /// </summary>
        public static DateTime Christmas(int year)
        {
            //South African president announced that Christmas day will be observed 26 Dec 2022 and Boxing day will be observed 27 Dec 2022 due to christmas falling on a Sunday
            //Source: https://twitter.com/PresidencyZA/status/1600748006986452994?ref_src=twsrc%5Etfw
            if (year == 2022)
                return new DateTime(year, 12, 26);

            //Christmas does not shift when it falls on a Sunday due to boxing day being on the Monday then.
            return new DateTime(year, 12, 25);
        }

        /// <summary>
        /// Boxing Day
        /// </summary>
        public static DateTime BoxingDay(int year)
        {
            //South African president announced that Christmas day will be observed 26 Dec 2022 and Boxing day will be observed 27 Dec 2022 due to christmas falling on a Sunday
            //Source: https://twitter.com/PresidencyZA/status/1600748006986452994?ref_src=twsrc%5Etfw
            if (year == 2022)
                return new DateTime(year, 12, 27);
            return HolidayCalculator.FixWeekendSundayAfter(new DateTime(year, 12, 26));
        }

        #endregion Individual Holidays

        /// <summary>
        /// All South African public holidays for the year.
        /// </summary>
        //Good Friday can be the same day as Human Rights Day;
        //same-day holidays stay distinct entries (names aggregated by the base class)
        private static readonly HolidayDefinition[] Definitions =
        {
            new Common.NewYear { ObservedDateRule = HolidayCalculator.FixWeekendSundayAfter },
            new Local.HumanRightsDay(),
            new Christian.GoodFriday(),
            new Christian.EasterMonday { HolidayKey = HolidayKeys.FamilyDayZA, EnglishName = "Family Day" },
            new Local.FreedomDay(),
            new Common.LabourDay { HolidayKey = HolidayKeys.WorkersDayZA,  EnglishName = "Workers' Day", ObservedDateRule = HolidayCalculator.FixWeekendSundayAfter },
            new Local.YouthDay(),
            new Local.NationalWomensDay(),
            new Local.HeritageDay(),
            new Local.ReconciliationDay(),
            new Local.RugbyWorldCupCelebration(),
            new Local.ElectionDay2024(),
            new Local.ChristmasDay(),
            new Local.DayOfGoodwill(),
        };

        /// <summary>
        /// All South African public holidays for the year.
        /// </summary>
        /// <param name="year">The year.</param>
        protected override IList<Holiday> PublicHolidaysComplete(int year)
        {
            var list = new List<Holiday>();
            foreach (var definition in Definitions)
            {
                list.AddRange(definition.Build(year));
            }
            return list;
        }

    }
}
