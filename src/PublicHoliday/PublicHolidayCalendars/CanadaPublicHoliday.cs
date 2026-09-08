using System;
using System.Collections.Generic;
using PublicHoliday.HolidayDefinitions;
using PublicHoliday.HolidayDefinitions.Christian;
using Christian = PublicHoliday.HolidayDefinitions.Christian;
using Common = PublicHoliday.HolidayDefinitions.Common;
using Local = PublicHoliday.HolidayDefinitions.CountrySpecific.Canada;
using PublicHoliday.HolidayDefinitions.Base;
using System.Globalization;
using PublicHoliday.Localization;
using PublicHoliday.Dates;

namespace PublicHoliday
{
    /// <summary>
    /// Finds Canada federal public (statutory) Holidays. Adjusted for weekends.
    /// <description>
    /// Federally regulated workers are entitled to nine paid statutory holidays every year –
    /// New Year’s Day, Good Friday, Victoria Day, Canada Day, Labour Day, Thanksgiving Day, Remembrance Day, Christmas Day, and Boxing Day.
    /// See http://www.hrsdc.gc.ca/eng/labour/overviews/employment_standards/holidays.shtml
    /// <para>When New Year’s Day, Canada Day, Remembrance Day, Christmas Day or Boxing Day fall on a Saturday or Sunday that are not normal work days, workers are entitled to a holiday with pay on the working day immediately before or after the holiday</para>
    /// <para>There are additional regional and provincal dates, and not all federal holidays may be observed by private businesses. Banks follow the federal holidays, however.</para>
    /// </description>
    /// </summary>
    /// <remarks>
    /// Federal nation-wide holidays only. Provincial holidays (eg Family Day in Feb) are excluded and are not observed by Federal employees.
    /// </remarks>
    public class CanadaPublicHoliday : PublicHolidayBase
    {

        /// <summary>
        /// Culture whose language this calendar's holiday names are in: Canadian English.
        /// Used by <see cref="Holiday.GetName(CultureInfo)"/> when the requested
        /// culture has no translation.
        /// </summary>
        protected override CultureInfo CountryCulture => _defaultCulture;

        private static readonly CultureInfo _defaultCulture = SafeCulture.Get("en-CA", "en");
        /// <summary>
        /// The province
        /// </summary>
        public string Province
        {
            get { return _province; }
            set { _province = value; ClearHolidayCache(); }
        }
        private string _province;

        #region Individual Holidays

        /// <summary>
        /// Date of New Year bank holiday.
        /// </summary>
        public static DateTime NewYear(int year)
        {
            var hol = new DateTime(year, 1, 1);
            hol = HolidayCalculator.FixWeekend(hol);
            return hol;
        }

        /// <summary>
        /// Family day (3rd monday of February) (2nd monday for BC)
        /// </summary>
        public static DateTime FamilyDay(int year, string province = null)
        {
            var hol = new DateTime(year, 2, 1);
            //Starting in 2019, the B.C. Family Day holiday will be on the third Monday of February, moving it in line with other provinces in Canada.
            //#32 thanks @ericyang97
            if (province == "BC" && year < 2019)
                hol = HolidayCalculator.FindOccurrenceOfDayOfWeek(hol, DayOfWeek.Monday, 2);
            else
                hol = HolidayCalculator.FindOccurrenceOfDayOfWeek(hol, DayOfWeek.Monday, 3);

            return hol;
        }

        /// <summary>
        /// Determines if a province has Family day
        /// </summary>
        public static bool HasFamilyDay(int year, string province = null)
        {
            var provs = new List<string> { "AB", "BC", "MB", "NS", "ON", "PE", "SK" };
            if(year >= 2018) provs.Add("NB"); //New Brunswick added Family Day in 2018
            if (provs.Contains(province))
                return true;
            else return false;
        }

        /// <summary>
        /// St. Patricks day (March 17)
        /// </summary>
        public static DateTime StPatricksDay(int year)
        {
            var hol = new DateTime(year, 3, 17);
            hol = HolidayCalculator.FindNearestDayOfWeek(hol, DayOfWeek.Monday);
            return hol;
        }
        /// <summary>
        /// Determines if a province has st. Patricks day
        /// </summary>
        public static bool HasStPatricksDay(string province = null)
        {
            if (province == "NL")
                return true;
            else return false;
        }

        /// <summary>
        /// Good Friday (Friday before Easter)
        /// </summary>
        public static DateTime GoodFriday(int year)
        {
            return EasterCalculator.GoodFriday(EasterCalculator.GetEaster(year));
        }

        /// <summary>
        /// Easter Monday (Monday after Easter)
        /// </summary>
        public static DateTime EasterMonday(int year)
        {
            return EasterCalculator.EasterMonday(EasterCalculator.GetEaster(year));
        }
        /// <summary>
        /// Determines if a province has Easter Monday
        /// </summary>
        public static bool HasEasterMonday(string province = null)
        {
            string[] provs = { "AB", "PE", null };
            if (Array.IndexOf(provs, province) > -1)
                return true;
            else return false;
        }

        /// <summary>
        /// Saint George's day (April 23)
        /// </summary>
        public static DateTime StGeorgesDay(int year)
        {
            var hol = new DateTime(year, 4, 23);
            hol = HolidayCalculator.FixWeekend(hol);
            return hol;
        }
        /// <summary>
        /// Determines if a province has Saint Georges day
        /// </summary>
        public static bool HasStGeorgesDay(string province = null)
        {
            if (province == "NL")
                return true;
            else return false;
        }

        /// <summary>
        /// Monday on or before May 24
        /// </summary>
        public static DateTime VictoriaDay(int year)
        {
            var hol = new DateTime(year, 5, 24);
            //skip back to previous Monday
            while (hol.DayOfWeek != DayOfWeek.Monday)
            {
                hol = hol.AddDays(-1);
            }
            return hol;
        }
        /// <summary>
        /// Determines if a province has Victoria day
        /// </summary>
        public static bool HasVictoriaDay(string province = null)
        {
            if (province != "NL")
                return true;
            else return false;
        }

        /// <summary>
        /// Aboriginal day (June 21)
        /// </summary>
        public static DateTime AboriginalDay(int year)
        {
            var hol = new DateTime(year, 6, 21);
            hol = HolidayCalculator.FixWeekend(hol);
            return hol;
        }
        /// <summary>
        /// Determines if a province has Aboriginal day
        /// </summary>
        public static bool HasAboriginalDay(string province = null)
        {
            if (province == "NT")
                return true;
            else return false;
        }

        /// <summary>
        /// National holiday (June 24)
        /// </summary>
        public static DateTime NationalHoliday(int year)
        {
            var hol = new DateTime(year, 6, 24);
            hol = HolidayCalculator.FixWeekend(hol);
            return hol;
        }
        /// <summary>
        /// Determines if a province has National holiday
        /// </summary>
        public static bool HasNationalHoliday(string province = null)
        {
            string[] provs = { "NL", "QC", "YT" };
            if (Array.IndexOf(provs, province) > -1)
                return true;
            else return false;
        }

        /// <summary>
        /// Canada day, 1 July or following Monday 
        /// </summary>
        public static DateTime CanadaDay(int year)
        {
            var hol = new DateTime(year, 7, 1);
            //hol = HolidayCalculator.FindFirstMonday(hol);
            hol = HolidayCalculator.FixWeekend(hol);
            return hol;
        }

        /// <summary>
        /// Orangemen's day (July 12)
        /// </summary>
        public static DateTime OrangemensDay(int year)
        {
            var hol = new DateTime(year, 7, 12);
            hol = HolidayCalculator.FindNearestDayOfWeek(hol, DayOfWeek.Monday);
            return hol;
        }
        /// <summary>
        /// Determines if a province has Orangemen's day
        /// </summary>
        public static bool HasOrangemensDay(string province = null)
        {
            if (province == "NL")
                return true;
            else return false;
        }


        /// <summary>
        /// First Monday in August. Only available in certain provinces, under different names- Saskatchewan day,  Regatta Day 
        /// </summary>
        public static DateTime CivicHoliday(int year)
        {
            var hol = new DateTime(year, 8, 1);
            hol = HolidayCalculator.FindFirstMonday(hol);
            return hol;
        }
        /// <summary>
        /// Determines if a province has a civic holiday
        /// </summary>
        public static bool HasCivicHoliday(string province = null)
        {
            string[] notProvs = { "ON", "PE", "QC" };
            if (Array.IndexOf(notProvs, province) == -1)
                return true;
            else return false;
        }

        /// <summary>
        /// Gold Cup Parade day (Third friday in August)
        /// </summary>
        public static DateTime GoldCupParadeDay(int year)
        {
            var hol = new DateTime(year, 8, 1);
            hol = HolidayCalculator.FindOccurrenceOfDayOfWeek(hol, DayOfWeek.Friday, 3);
            return hol;
        }
        /// <summary>
        /// Determines if a province has Gold Cup Parade day
        /// </summary>
        public static bool HasGoldCupParadeDay(string province = null)
        {
            if (province == "PE")
                return true;
            else return false;
        }


        /// <summary>
        /// Discovery day (Third monday in August)
        /// </summary>
        public static DateTime DiscoveryDay(int year)
        {
            var hol = new DateTime(year, 8, 1);
            hol = HolidayCalculator.FindOccurrenceOfDayOfWeek(hol, DayOfWeek.Monday, 3);
            return hol;
        }
        /// <summary>
        /// Determines if a province has Discovery day
        /// </summary>
        public static bool HasDiscoveryDay(string province = null)
        {
            if (province == "YT")
                return true;
            else return false;
        }


        /// <summary>
        /// First Monday in September
        /// </summary>
        public static DateTime LabourDay(int year)
        {
            var hol = new DateTime(year, 9, 1);
            hol = HolidayCalculator.FindFirstMonday(hol);
            return hol;
        }

        /// <summary>
        /// 30th September from 2021 onwards
        /// </summary>
        public static DateTime? NationalDayForTruthAndReconciliation(int year)
        {
            if (year < 2021) return null;
            var hol = new DateTime(year, 9, 30);
            hol = HolidayCalculator.FixWeekend(hol);
            return hol;
        }

        /// <summary>
        /// Second Monday in October
        /// </summary>
        public static DateTime Thanksgiving(int year)
        {
            var hol = new DateTime(year, 10, 8);
            hol = HolidayCalculator.FindFirstMonday(hol);
            return hol;
        }

        /// <summary>
        /// November 11
        /// </summary>
        public static DateTime RemembranceDay(int year)
        {
            var hol = new DateTime(year, 11, 11);
            hol = HolidayCalculator.FixWeekend(hol);
            return hol;
        }
        /// <summary>
        /// Determines if a province has a Rememberance day
        /// </summary>
        public static bool HasRememberanceDay(string province = null)
        {
            string[] notProvs = { "MB", "ON", "QC" };
            if (Array.IndexOf(notProvs, province) == -1)
                return true;
            else return false;
        }

        /// <summary>
        /// Christmas day
        /// </summary>
        public static DateTime Christmas(int year)
        {
            DateTime hol = new DateTime(year, 12, 25);
            hol = HolidayCalculator.FixWeekend(hol);
            return hol;
        }

        /// <summary>
        /// Boxing Day
        /// </summary>
        public static DateTime BoxingDay(int year)
        {
            DateTime hol = new DateTime(year, 12, 26);
            //this holiday is not shifted, even if Sat or Sun. If Christmas is a Sun, will be observed on the same date
            //bool isSundayOrMonday =
            //    hol.DayOfWeek == DayOfWeek.Sunday ||
            //    hol.DayOfWeek == DayOfWeek.Monday;
            //hol = HolidayCalculator.FixWeekend(hol);
            //if (isSundayOrMonday)
            //    hol = hol.AddDays(1);
            return hol;
        }
        /// <summary>
        /// Determines if a province has a Boxing day
        /// </summary>
        public static bool HasBoxingDay(string province = null)
        {
            string[] provs = { "AB", "NB", "NS", "ON", "PE", null };
            if (Array.IndexOf(provs, province) > -1)
                return true;
            return false;
        }

        #endregion

        private IEnumerable<HolidayDefinition> GetDefinitions()
        {
            var province = Province;
            yield return new Common.NewYear { ObservedDateRule = HolidayCalculator.FixWeekend };
            //FamilyDay's AppliesInYear covers both the province membership and NB's from-2018 gate
            yield return new Local.FamilyDay(province) { AppliesInYear = y => HasFamilyDay(y, province) };
            if (HasStPatricksDay(province))
                yield return new Local.StPatricksDay();
            yield return new Christian.GoodFriday();
            if (HasEasterMonday(province))
                yield return new Christian.EasterMonday();
            if (HasStGeorgesDay(province))
                yield return new Local.StGeorgesDay();
            if (HasVictoriaDay(province))
                yield return new Local.VictoriaDay();
            if (HasAboriginalDay(province))
                yield return new Local.AboriginalDay();
            if (HasNationalHoliday(province))
                yield return new Local.NationalHoliday();
            yield return new Local.CanadaDay();
            if (HasOrangemensDay(province))
                yield return new Local.OrangemensDay();
            if (HasCivicHoliday(province))
                yield return new Local.CivicHoliday();
            if (HasGoldCupParadeDay(province))
                yield return new Local.GoldCupParadeDay();
            if (HasDiscoveryDay(province))
                yield return new Local.DiscoveryDay();
            yield return new Local.LabourDay();
            yield return new Local.TruthAndReconciliationDay();
            yield return new Local.Thanksgiving();
            if (HasRememberanceDay(province))
                yield return new Local.RemembranceDay();
            yield return new Local.ChristmasDay();
            //observed Christmas can shift onto 26 December while Boxing Day does not shift;
            //both stay distinct entries (same-day names are aggregated by the base class)
            if (HasBoxingDay(province))
                yield return new Local.BoxingDay();
            yield return new Local.QueenElizabethFuneral();
        }

        /// <summary>
        /// Federal and provincial (for the configured <see cref="Province"/>) holidays for the year.
        /// </summary>
        /// <param name="year">The year</param>
        protected override IList<Holiday> PublicHolidaysComplete(int year)
        {
            var list = new List<Holiday>();
            foreach (var definition in GetDefinitions())
            {
                list.AddRange(definition.Build(year));
            }
            return list;
        }

        /// <summary>
        /// Constructor with province option
        /// </summary>
        public CanadaPublicHoliday(string province = null) : base()
        {
            Province = province;
            if (Province != null)
                Province = Province.ToUpper();
        }
    }
}

