using System;
using System.Collections.Generic;

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
    /// Federal nation-wide holidays only. Provincal holidays (eg Family Day in Feb) are excluded and are not observed by Federal employees.
    /// </remarks>
    public class CanadaPublicHoliday : PublicHolidayBase
    {
        /// <summary>
        /// The province
        /// </summary>
        public string Province { get; set; }

        #region Individual Holidays

        /// <summary>
        /// Date of New Year bank holiday.
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime NewYear(int year)
        {
            var hol = new DateTime(year, 1, 1);
            hol = HolidayCalculator.FixWeekend(hol);
            return hol;
        }

        /// <summary>
        /// Family day (3rd monday of February) (2nd monday for BC)
        /// </summary>
        /// <param name="year"></param>
        /// <param name="province"></param>
        /// <returns></returns>
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
        /// <param name="province"></param>
        /// <returns></returns>
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
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime StPatricksDay(int year)
        {
            var hol = new DateTime(year, 3, 17);
            hol = HolidayCalculator.FindNearestDayOfWeek(hol, DayOfWeek.Monday);
            return hol;
        }
        /// <summary>
        /// Determines if a province has st. Patricks day
        /// </summary>
        /// <param name="province"></param>
        /// <returns></returns>
        public static bool HasStPatricksDay(string province = null)
        {
            if (province == "NL")
                return true;
            else return false;
        }

        /// <summary>
        /// Good Friday (Friday before Easter)
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime GoodFriday(int year)
        {
            var hol = HolidayCalculator.GetEaster(year);
            hol = hol.AddDays(-2);
            return hol;
        }

        /// <summary>
        /// Easter Monday (Monday after Easter)
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime EasterMonday(int year)
        {
            var hol = HolidayCalculator.GetEaster(year);
            hol = hol.AddDays(1);
            return hol;
        }
        /// <summary>
        /// Determines if a province has Easter Monday
        /// </summary>
        /// <param name="province"></param>
        /// <returns></returns>
        public static bool HasEasterMonday(string province = null)
        {
            string[] provs = { "AB", "PE", null };
            if (Array.IndexOf(provs, province) > -1)
                return true;
            else return false;
        }
        /// <summary>
        /// Private overloads of GoodFriday and EasterMonday reusing Easter calculation
        /// </summary>
        private static DateTime GoodFriday(DateTime easter)
        {
            var hol = easter.AddDays(-2);
            return hol;
        }
        private static DateTime EasterMonday(DateTime easter)
        {
            var hol = easter.AddDays(1);
            return hol;
        }

        /// <summary>
        /// Saint George's day (April 23)
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime StGeorgesDay(int year)
        {
            var hol = new DateTime(year, 4, 23);
            hol = HolidayCalculator.FixWeekend(hol);
            return hol;
        }
        /// <summary>
        /// Determines if a province has Saint Georges day
        /// </summary>
        /// <param name="province"></param>
        /// <returns></returns>
        public static bool HasStGeorgesDay(string province = null)
        {
            if (province == "NL")
                return true;
            else return false;
        }

        /// <summary>
        /// Monday on or before May 24
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
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
        /// Determines if a province has Family day
        /// </summary>
        /// <param name="province"></param>
        /// <returns></returns>
        public static bool HasVictoriaDay(string province = null)
        {
            if (province != "NL")
                return true;
            else return false;
        }

        /// <summary>
        /// Aboriginal day (June 21)
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime AboriginalDay(int year)
        {
            var hol = new DateTime(year, 6, 21);
            hol = HolidayCalculator.FixWeekend(hol);
            return hol;
        }
        /// <summary>
        /// Determines if a province has Aboriginal day
        /// </summary>
        /// <param name="province"></param>
        /// <returns></returns>
        public static bool HasAboriginalDay(string province = null)
        {
            if (province == "NT")
                return true;
            else return false;
        }

        /// <summary>
        /// National holiday (June 24)
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime NationalHoliday(int year)
        {
            var hol = new DateTime(year, 6, 24);
            hol = HolidayCalculator.FixWeekend(hol);
            return hol;
        }
        /// <summary>
        /// Determines if a province has National holiday
        /// </summary>
        /// <param name="province"></param>
        /// <returns></returns>
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
        /// <param name="year"></param>
        /// <returns></returns>
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
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime OrangemensDay(int year)
        {
            var hol = new DateTime(year, 7, 12);
            hol = HolidayCalculator.FindNearestDayOfWeek(hol, DayOfWeek.Monday);
            return hol;
        }
        /// <summary>
        /// Determines if a province has Orangemen's day
        /// </summary>
        /// <param name="province"></param>
        /// <returns></returns>
        public static bool HasOrangemensDay(string province = null)
        {
            if (province == "NL")
                return true;
            else return false;
        }


        /// <summary>
        /// First Monday in August. Only available in certain provinces, under different names- Saskatchewan day,  Regatta Day 
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime CivicHoliday(int year)
        {
            var hol = new DateTime(year, 8, 1);
            hol = HolidayCalculator.FindFirstMonday(hol);
            return hol;
        }
        /// <summary>
        /// Determines if a province has a civic holiday
        /// </summary>
        /// <param name="province"></param>
        /// <returns></returns>
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
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime GoldCupParadeDay(int year)
        {
            var hol = new DateTime(year, 8, 1);
            hol = HolidayCalculator.FindOccurrenceOfDayOfWeek(hol, DayOfWeek.Friday, 3);
            return hol;
        }
        /// <summary>
        /// Determines if a province has Gold Cup Parade day
        /// </summary>
        /// <param name="province"></param>
        /// <returns></returns>
        public static bool HasGoldCupParadeDay(string province = null)
        {
            if (province == "PE")
                return true;
            else return false;
        }


        /// <summary>
        /// Discovery day (Third monday in August)
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime DiscoveryDay(int year)
        {
            var hol = new DateTime(year, 8, 1);
            hol = HolidayCalculator.FindOccurrenceOfDayOfWeek(hol, DayOfWeek.Monday, 3);
            return hol;
        }
        /// <summary>
        /// Determines if a province has Discovery day
        /// </summary>
        /// <param name="province"></param>
        /// <returns></returns>
        public static bool HasDiscoveryDay(string province = null)
        {
            if (province == "YT")
                return true;
            else return false;
        }


        /// <summary>
        /// First Monday in September
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime LabourDay(int year)
        {
            var hol = new DateTime(year, 9, 1);
            hol = HolidayCalculator.FindFirstMonday(hol);
            return hol;
        }

        /// <summary>
        /// Second Monday in October
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime Thanksgiving(int year)
        {
            var hol = new DateTime(year, 10, 8);
            hol = HolidayCalculator.FindFirstMonday(hol);
            return hol;
        }

        /// <summary>
        /// November 11
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime RemembranceDay(int year)
        {
            var hol = new DateTime(year, 11, 11);
            hol = HolidayCalculator.FixWeekend(hol);
            return hol;
        }
        /// <summary>
        /// Determines if a province has a Rememberance day
        /// </summary>
        /// <param name="province"></param>
        /// <returns></returns>
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
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime Christmas(int year)
        {
            DateTime hol = new DateTime(year, 12, 25);
            hol = HolidayCalculator.FixWeekend(hol);
            return hol;
        }

        /// <summary>
        /// Boxing Day
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime BoxingDay(int year)
        {
            DateTime hol = new DateTime(year, 12, 26);
            //if Xmas=Sun, it's shifted to Mon and 26 also gets shifted
            bool isSundayOrMonday =
                hol.DayOfWeek == DayOfWeek.Sunday ||
                hol.DayOfWeek == DayOfWeek.Monday;
            hol = HolidayCalculator.FixWeekend(hol);
            if (isSundayOrMonday)
                hol = hol.AddDays(1);
            return hol;
        }
        /// <summary>
        /// Determines if a province has a Boxing day
        /// </summary>
        /// <param name="province"></param>
        /// <returns></returns>
        public static bool HasBoxingDay(string province = null)
        {
            string[] provs = { "AB", "NB", "NS", "ON", "PE", null };
            if (Array.IndexOf(provs, province) > -1)
                return true;
            else return false;
        }

        #endregion

        /// <summary>
        /// Get a list of dates for all holidays in a year.
        /// </summary>
        /// <param name="year">The year</param>
        /// <returns>List of bank holidays</returns>
        public override IList<DateTime> PublicHolidays(int year)
        {
            return new List<DateTime>(PublicHolidayNames(year).Keys);
        }

        /// <summary>
        /// Get a list of dates for all holidays in a year.
        /// </summary>
        /// <param name="year">The year</param>
        /// <returns>Dictionary of bank holidays</returns>
        public override IDictionary<DateTime, string> PublicHolidayNames(int year)
        {
            var bHols = new Dictionary<DateTime, string>();
            bHols.Add(NewYear(year), "New Year");

            if (HasFamilyDay(year, Province))
                bHols.Add(FamilyDay(year, Province), "Family Day");

            if (HasStPatricksDay(Province))
                bHols.Add(StPatricksDay(year), "St. Patricks's Day");

            var easter = HolidayCalculator.GetEaster(year);
            bHols.Add(GoodFriday(easter), "Good Friday");

            if (HasEasterMonday(Province))
                bHols.Add(EasterMonday(easter), "Easter Monday");

            if (HasStGeorgesDay(Province))
                bHols.Add(StGeorgesDay(year), "Saint George's Day");

            if (HasVictoriaDay(Province))
                bHols.Add(VictoriaDay(year), "Victoria Day");

            if (HasAboriginalDay(Province))
                bHols.Add(AboriginalDay(year), "Aboriginal Day");

            if (HasNationalHoliday(Province))
                bHols.Add(NationalHoliday(year), "National Holiday");

            bHols.Add(CanadaDay(year), "Canada Day");

            if (HasOrangemensDay(Province))
                bHols.Add(OrangemensDay(year), "Orangemen's Day");

            if (HasCivicHoliday(Province))
                bHols.Add(CivicHoliday(year), "Civic Holiday");

            if (HasGoldCupParadeDay(Province))
                bHols.Add(GoldCupParadeDay(year), "Gold Cup Parade Day");

            if (HasDiscoveryDay(Province))
                bHols.Add(DiscoveryDay(year), "Discovery Day");

            bHols.Add(LabourDay(year), "Labour Day");
            bHols.Add(Thanksgiving(year), "Thanksgiving");

            if (HasRememberanceDay(Province))
                bHols.Add(RemembranceDay(year), "Remembrance Day");

            bHols.Add(Christmas(year), "Christmas");

            if (HasBoxingDay(Province))
                bHols.Add(BoxingDay(year), "Boxing Day");

            return bHols;
        }

        /// <summary>
        /// Check if a specific date is a public holiday.
        /// </summary>
        /// <param name="dt">The date you wish to check</param>
        /// <returns>
        /// True if date is a bank holiday (excluding weekends)
        /// </returns>
        public override bool IsPublicHoliday(DateTime dt)
        {
            return IsPublicHoliday(dt, null);
        }

        private bool IsPublicHoliday(DateTime dt, DateTime? easter)
        {
            int year = dt.Year;
            var date = dt.Date;

            return PublicHolidays(year).Contains(date);
        }

        /// <summary>
        /// Constructor with province option
        /// </summary>
        /// <param name="province"></param>
        public CanadaPublicHoliday(string province = null) : base()
        {
            Province = province;
            if (Province != null)
                Province = Province.ToUpper();
        }
    }
}

