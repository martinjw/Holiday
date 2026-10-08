using PublicHoliday.HolidayDefinitions;
using PublicHoliday.HolidayDefinitions.Christian;
using System;
using System.Collections.Generic;
using Christian = PublicHoliday.HolidayDefinitions.Christian;
using Common = PublicHoliday.HolidayDefinitions.Common;
using Local = PublicHoliday.HolidayDefinitions.CountrySpecific.Hungary;
using PublicHoliday.HolidayDefinitions.Base;
using System.Globalization;
using PublicHoliday.Localization;

namespace PublicHoliday
{
    /// <summary>
    /// Holidays in Hungary
    /// Based on Hungarian Labor Code (Munka törvénykönyve)
    /// </summary>
    public class HungaryPublicHoliday : PublicHolidayBase
    {

        /// <summary>
        /// Culture whose language this calendar's holiday names are in: Hungarian.
        /// Used by <see cref="Holiday.GetName(CultureInfo)"/> when the requested
        /// culture has no translation.
        /// </summary>
        protected override CultureInfo CountryCulture => _defaultCulture;

        private static readonly CultureInfo _defaultCulture = SafeCulture.Get("hu-HU", "hu");
        #region Individual Holidays

        /// <summary>
        /// Újév - New Year's Day
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime NewYear(int year) => new DateTime(year, 1, 1);

        /// <summary>
        /// 1848-as forradalom ünnepe - National Day
        /// Commemorates the Hungarian Revolution of 1848. 
        /// It was reinstated as an official state holiday after the fall of communism.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime NationalDay1848(int year) => new DateTime(year, 3, 15);

        /// <summary>
        /// Nagypéntek - Good Friday
        /// Introduced as a public holiday in Hungary since 2017
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime GoodFriday(int year) => EasterCalculator.GoodFriday(EasterCalculator.GetEaster(year));

        /// <summary>
        /// Húsvéthétfő - Easter Monday
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime EasterMonday(int year) => EasterCalculator.EasterMonday(EasterCalculator.GetEaster(year));

        /// <summary>
        /// Munka ünnepe - International Workers' Day
        /// Valid throughout the modern era.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime WorkersDay(int year) => new DateTime(year, 5, 1);

        /// <summary>
        /// Pünkösdhétfő - Pentecost Monday
        /// Re-introduced as a public holiday after the political changes in the early 1990s.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime PentecostMonday(int year) => EasterCalculator.WhitMonday(EasterCalculator.GetEaster(year));

        /// <summary>
        /// Államalapítás ünnepe - State Foundation Day
        /// Commemorates Saint Stephen I, the first King of Hungary. 
        /// During the communist era (1950-1989), it was celebrated as the Day of the Constitution or Day of the New Bread.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime SaintStephenDay(int year) => new DateTime(year, 8, 20);

        /// <summary>
        /// 1956-os forradalom ünnepe - National Day
        /// Commemorates the Revolution of 1956 and the proclamation of the Republic of Hungary in 1989.
        /// Official holiday since 1991.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime Revolution1956Day(int year) => new DateTime(year, 10, 23);

        /// <summary>
        /// Mindenszentek - All Saints' Day
        /// Reinstated as a public holiday in 2000.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime AllSaints(int year) => new DateTime(year, 11, 1);

        /// <summary>
        /// Karácsony - Christmas Day
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime ChristmasDay(int year) => new DateTime(year, 12, 25);

        /// <summary>
        /// Karácsony másnapja - Second Day of Christmas
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime StStephenDay(int year) => new DateTime(year, 12, 26);

        #endregion Individual Holidays

        /// <summary>
        /// The holiday definitions composing this calendar.
        /// </summary>
        private static readonly HolidayDefinition[] Definitions =
        {
            new Common.NewYear(),
            new Local.NationalDay1848(),
            new Christian.GoodFriday { AppliesInYear = GoodFridayFrom2017 },
            new Christian.EasterMonday(),
            new Common.LabourDay(),
            new Christian.WhitMonday(),
            new Local.StateFoundationDay(),
            new Local.Revolution1956Day(),
            new Christian.AllSaints(),
            new Christian.Christmas(),
            new Christian.SaintStephensDay(),
        };

        private static bool GoodFridayFrom2017(int year) => year >= 2017;

        /// <summary>
        /// All public holidays of the year, built from the definitions.
        /// </summary>
        /// <param name="year">The year</param>
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