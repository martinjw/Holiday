using System;
using System.Collections.Generic;
using System.Linq;
using PublicHoliday.HolidayDefinitions;
using Common = PublicHoliday.HolidayDefinitions.Common;
using Local = PublicHoliday.HolidayDefinitions.CountrySpecific.Japan;
using PublicHoliday.HolidayDefinitions.Base;
using System.Globalization;
using PublicHoliday.Localization;
using PublicHoliday.Dates;

namespace PublicHoliday
{
    /// <summary>
    /// Finds Japan public holidays. Adjusted for weekends.
    /// <description>
    /// Based on https://en.wikipedia.org/wiki/Public_holidays_in_Japan
    /// </description>
    /// </summary>
    public class JapanPublicHoliday : PublicHolidayBase
    {

        /// <summary>
        /// Culture whose language this calendar's holiday names are in: Japanese.
        /// Used by <see cref="Holiday.GetName(CultureInfo)"/> when the requested
        /// culture has no translation.
        /// </summary>
        protected override CultureInfo CountryCulture => _defaultCulture;

        private static readonly CultureInfo _defaultCulture = SafeCulture.Get("ja-JP", "ja");
        #region Individual Holidays

        /// <summary>
        /// Date of New Year bank holiday.
        /// </summary>
        public static DateTime NewYear(int year)
        {
            return Local.JapanWeekendRule.SundayToMonday(new DateTime(year, 1, 1));
        }

        /// <summary>
        /// Coming of Age Day (成人の日 Seijin no Hi)
        /// </summary>
        /// <param name="year">The year.</param>
        public static DateTime ComingOfAgeDay(int year)
        {
            //second Monday of January
            return HolidayCalculator.FindFirstMonday(new DateTime(year, 1, 1))
                .AddDays(7);
        }

        /// <summary>
        /// Foundation Day (建国記念の日 Kenkoku Kinen no Hi)
        /// </summary>
        /// <param name="year">The year.</param>
        public static DateTime FoundationDay(int year)
        {
            //Feb 11
            return Local.JapanWeekendRule.SundayToMonday(new DateTime(year, 2, 11));
        }

        /// <summary>
        /// Vernal Equinox Day (春分の日 Shunbun no Hi). *March 20 or 21, not fixed*
        /// </summary>
        /// <param name="year">The year.</param>
        public static DateTime VernalEquinoxDay(int year)
        {
            return new Local.VernalEquinoxDay().Build(year).First().ObservedDate;
        }

        /// <summary>
        /// Shōwa Day (昭和の日 Shōwa no Hi)
        /// </summary>
        /// <param name="year">The year.</param>
        public static DateTime ShowaDay(int year)
        {
            // using the ō character would causes compilation errors on some system
            //29 April
            return Local.JapanWeekendRule.SundayToMonday(new DateTime(year, 4, 29));
        }

        /// <summary>
        /// Constitution Memorial Day (憲法記念日 Kenpō Kinenbi)
        /// In Golden Week (Shōwa Day, Constitution Memorial Day, Greenery Day, Children's Day)
        /// a Sunday can push one holiday into another.
        /// </summary>
        /// <param name="year">The year.</param>
        public static DateTime ConstitutionMemorialDay(int year)
        {
            //3 May
            return Local.ConstitutionMemorialDay.Observed(new DateTime(year, 5, 3));
        }

        /// <summary>
        /// Greenery Day (みどりの日 Midori no Hi)
        /// </summary>
        /// <param name="year">The year.</param>
        public static DateTime GreeneryDay(int year)
        {
            //4 May
            return Local.GreeneryDay.Observed(new DateTime(year, 5, 4));
        }

        /// <summary>
        /// Children's Day (こどもの日 Kodomo no Hi)
        /// </summary>
        /// <param name="year">The year.</param>
        public static DateTime ChildrensDay(int year)
        {
            //5 May
            return Local.ChildrensDay.Observed(new DateTime(year, 5, 5));
        }

        /// <summary>
        /// Marine Day (海の日 Umi no Hi)
        /// </summary>
        /// <param name="year">The year.</param>
        public static DateTime MarineDay(int year)
        {
            //3rd Monday in July
            return HolidayCalculator.FindFirstMonday(new DateTime(year, 7, 1)).AddDays(14);
        }

        /// <summary>
        /// Mountain Day (山の日 Yama no Hi)
        /// </summary>
        /// <param name="year">The year.</param>
        public static DateTime? MountainDay(int year)
        {
            if (year < 2016) return null;
            //11 August, from 2016 onwards
            return Local.JapanWeekendRule.SundayToMonday(new DateTime(year, 8, 11));
        }

        /// <summary>
        /// Respect for the Aged Day (敬老の日 Keirō no Hi)
        /// </summary>
        /// <param name="year">The year.</param>
        public static DateTime RespectForTheAgedDay(int year)
        {
            //Third Monday of September
            return HolidayCalculator.FindFirstMonday(new DateTime(year, 9, 1)).AddDays(14);
        }

        /// <summary>
        /// Autumnal Equinox Day (秋分の日 Shūbun no Hi)
        /// </summary>
        /// <param name="year">The year.</param>
        public static DateTime AutumnalEquinoxDay(int year)
        {
            return new Local.AutumnalEquinoxDay().Build(year).First().ObservedDate;
        }

        /// <summary>
        /// Health and Sports Day (体育の日 Taiiku no Hi)
        /// </summary>
        /// <param name="year">The year.</param>
        public static DateTime HealthAndSportsDay(int year)
        {
            //Second Monday of October
            return HolidayCalculator.FindFirstMonday(new DateTime(year, 10, 1)).AddDays(7);
        }

        /// <summary>
        /// Culture Day (文化の日 Bunka no Hi)
        /// </summary>
        /// <param name="year">The year.</param>
        public static DateTime CultureDay(int year)
        {
            //November 3
            return Local.JapanWeekendRule.SundayToMonday(new DateTime(year, 11, 3));
        }

        /// <summary>
        /// Labour Thanksgiving Day (勤労感謝の日 Kinrō Kansha no Hi)
        /// </summary>
        /// <param name="year">The year.</param>
        public static DateTime LabourThanksgivingDay(int year)
        {
            //November 23
            return Local.JapanWeekendRule.SundayToMonday(new DateTime(year, 11, 23));
        }

        /// <summary>
        /// The Emperor's Birthday (天皇誕生日 Tennō Tanjōbi)
        /// </summary>
        /// <param name="year">The year.</param>
        public static DateTime EmperorsBirthday(int year)
        {
            if (year >= 2020)
                //23 February Emperor Naruhito 徳仁 2020 –
                return Local.JapanWeekendRule.SundayToMonday(new DateTime(year, 2, 23));
            //23 December Emperor Akihito 明仁 1989–2018
            return Local.JapanWeekendRule.SundayToMonday(new DateTime(year, 12, 23));
        }

        #endregion Individual Holidays

        private static readonly HolidayDefinition[] Definitions =
        {
            new Common.NewYear { ObservedDateRule = Local.JapanWeekendRule.SundayToMonday },
            new Local.ComingOfAgeDay(),
            new Local.FoundationDay(),
            new Local.VernalEquinoxDay(),
            new Local.ShowaDay(),
            new Local.ConstitutionMemorialDay(),
            new Local.GreeneryDay(),
            new Local.ChildrensDay(),
            new Local.MarineDay(),
            new Local.MountainDay(),
            new Local.RespectForTheAgedDay(),
            new Local.AutumnalEquinoxDay(),
            new Local.HealthAndSportsDay(),
            new Local.CultureDay(),
            new Local.LabourThanksgivingDay(),
            new Local.EmperorsBirthday(),
        };

        /// <summary>
        /// All Japanese public holidays for the year. The definitions implement the
        /// substitute-holiday shifting (Sunday moves to Monday; Golden Week holidays cascade),
        /// so same-day collisions should not occur - if one ever does, the entries stay
        /// distinct (names aggregated by the base class).
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
