using System;
using System.Collections.Generic;
using System.Linq;

namespace PublicHoliday
{
    /// <summary>
    /// Finds UK Bank (public) Holidays. Adjusted for weekends. For Scotland/NorthernIreland variations set <see cref="UkCountry"/>
    /// <description>
    /// UK Bank Holidays since 1971 Banking and Financial Dealings Act with additions and variations.
    /// See http://www.dti.gov.uk/employment/bank-public-holidays/index.html
    /// <para>Additions: 1974 New Years Day and 1978 May Day</para>
    /// <para>Variations: 1995 VE Day May Day, 2002 Golden Jubilee, 2011 Royal Wedding, 2012 Diamond Jubilee</para>
    /// <para>You can call by IsBankHoliday(date), get the specific holiday name
    /// ( <see cref="Christmas"/>), or a list of dates for the year (<see cref="BankHolidays"/>)</para>
    /// </description>
    /// </summary>
    public class UKBankHoliday : PublicHolidayBase
    {
        /// <summary>
        /// Country within the United Kingdom. Default is England (and Wales which is the same legal jurisdiction).
        /// Change for Scotland and NorthernIreland
        /// </summary>
        public UkCountries UkCountry { get; set; }

        /// <summary>
        /// The constituent countries of the United Kingdom. England and Wales are the same legal jurisdiction, but for clarity are shown separately.
        /// </summary>
        public enum UkCountries
        {
            /// <summary>
            /// England
            /// </summary>
            England = 0,

            /// <summary>
            /// Wales
            /// </summary>
            Wales,

            /// <summary>
            /// Scotland
            /// </summary>
            Scotland,

            /// <summary>
            /// Northern Ireland
            /// </summary>
            NorthernIreland
        }

        #region Individual Holidays

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
        /// Date of New Year bank holiday. This is 1974 on only but will return pre 1974 dates.
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime NewYear(int year)
        {
            //since 1974 only
            DateTime hol = new DateTime(year, 1, 1);
            hol = HolidayCalculator.FixWeekend(hol);
            return hol;
        }

        /// <summary>
        /// Scotland only. Normally January 2nd
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime NewYearHolidayScotland(int year)
        {
            DateTime hol = new DateTime(year, 1, 2);
            //if NewYears=Sun, it's shifted to Mon and 2nd also gets shifted
            bool isSundayOrMonday =
                hol.DayOfWeek == DayOfWeek.Sunday ||
                hol.DayOfWeek == DayOfWeek.Monday;
            hol = HolidayCalculator.FixWeekend(hol);
            if (isSundayOrMonday)
                hol = hol.AddDays(1);
            return hol;
        }

        /// <summary>
        /// Northern Ireland only. St Patrick's Day, on 17th of March or next Monday if on weekend.
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime StPatricksDay(int year)
        {
            var hol = new DateTime(year, 3, 17);
            hol = HolidayCalculator.FixWeekend(hol);
            return hol;
        }

        /// <summary>
        /// Scotland only. St Andrew's Day
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime StAndrews(int year)
        {
            DateTime hol = new DateTime(year, 11, 30);
            hol = HolidayCalculator.FixWeekend(hol);
            return hol;
        }

        /// <summary>
        /// Northern Ireland only. Battle of the Boyne (Orangemen’s Day) on 12th of July or next Monday if on weekend.
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime BattleOfTheBoyne(int year)
        {
            var hol = new DateTime(year, 7, 12);
            hol = HolidayCalculator.FixWeekend(hol);
            return hol;
        }

        /// <summary>
        /// Returns "Early Spring"/"May Day" holiday (first Monday in May). Created in 1978.
        /// </summary>
        /// <param name="year"></param>
        /// <returns>(Nullable)date for Early May Bank Holiday (null before 1978)</returns>
        public static DateTime? MayDay(int year)
        {
            //warning- should be null for < 1977
            if (year < 1978) return null;
            if (year == 1995)
                return new DateTime(1995, 5, 8); //1995 moved for 50th anniversary of VE day
            if (year == 2020)
                return new DateTime(2020, 5, 8); // 2020 moved for 75th anniversary of VE day

            DateTime hol = new DateTime(year, 5, 1);
            hol = HolidayCalculator.FindFirstMonday(hol);
            return hol;
        }

        /// <summary>
        /// The Spring/Last Monday in May holiday (replaced variable Whit Monday in 1971)
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime Spring(int year)
        {
            if (year == 2002) return new DateTime(2002, 6, 4); //Golden Jubilee of Elizabeth II
            if (year == 2012) return new DateTime(2012, 6, 4); //Queen's Diamond Jubilee
            if (year == 2022) return new DateTime(2022, 6, 2); //Queen's Platinum Jubilee
            DateTime hol = new DateTime(year, 5, 31);
            hol = HolidayCalculator.FindPrevious(hol, DayOfWeek.Monday);
            return hol;
        }

        /// <summary>
        /// Scotland only. Summer bank holiday (first Monday in August)
        /// </summary>
        /// <returns></returns>
        public static DateTime SummerScotland(int year)
        {
            var hol = new DateTime(year, 8, 1);
            hol = HolidayCalculator.FindFirstMonday(hol);
            return hol;
        }

        /// <summary>
        /// Summer bank holiday (last Monday in August). Not Scotland.
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime Summer(int year)
        {
            DateTime hol = new DateTime(year, 8, 25);
            hol = HolidayCalculator.FindFirstMonday(hol);
            return hol;
        }

        /// <summary>
        /// Good Friday (Friday before Easter)
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime GoodFriday(int year)
        {
            DateTime hol = HolidayCalculator.GetEaster(year);
            hol = hol.AddDays(-2);
            return hol;
        }

        /// <summary>
        /// Easter Monday (Monday after Easter). Not a legal holiday in Scotland, but observed by clearing banks since 1996
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime EasterMonday(int year)
        {
            DateTime hol = HolidayCalculator.GetEaster(year);
            hol = hol.AddDays(1);
            return hol;
        }

        /// <summary>
        /// Private overloads of GoodFriday and EasterMonday reusing Easter calculation
        /// </summary>
        private static DateTime GoodFriday(DateTime easter)
        {
            DateTime hol = easter.AddDays(-2);
            return hol;
        }

        private static DateTime EasterMonday(DateTime easter)
        {
            DateTime hol = easter.AddDays(1);
            return hol;
        }

        #endregion Individual Holidays

        /// <summary>
        /// Get a list of dates for all holidays in a year.
        /// </summary>
        /// <param name="year">The year</param>
        /// <returns>List of bank holidays</returns>
        public static IList<DateTime> BankHolidays(int year)
        {
            return new UKBankHoliday().PublicHolidayNames(year).Keys.ToList();
        }

        /// <summary>
        /// Get a list of dates for all holidays in a year.
        /// </summary>
        /// <param name="year">The year</param>
        /// <returns>Dictionary of bank holidays</returns>
        public override IDictionary<DateTime, string> PublicHolidayNames(int year)
        {
            var bHols = new SortedDictionary<DateTime, string>();
            if (year > 1973)
                bHols.Add(NewYear(year), "New Year"); //New Year only in 1974
            if (UkCountry == UkCountries.Scotland)
            {
                bHols.Add(NewYearHolidayScotland(year), "New Year Holiday");
                bHols.Add(SummerScotland(year), "Summer Holiday");
                bHols.Add(StAndrews(year), "St Andrew's Day");
            }
            if (UkCountry == UkCountries.NorthernIreland)
            {
                bHols.Add(StPatricksDay(year), "St Patrick's Day");
                bHols.Add(BattleOfTheBoyne(year), "Battle of the Boyne");
            }
            var easter = HolidayCalculator.GetEaster(year);
            bHols.Add(GoodFriday(easter), "Good Friday");
            if (UkCountry != UkCountries.Scotland)
            {
                bHols.Add(EasterMonday(easter), "Easter Monday");
            }

            if (year == 2011)
                bHols.Add(new DateTime(2011, 4, 29), "Royal Wedding"); //Royal Wedding

            var dt = MayDay(year);
            if (dt.HasValue)
                bHols.Add(dt.Value, "Early May");
            if (year == 2023)
                bHols.Add(new DateTime(2023,5,8), "Coronation of King Charles III");
            bHols.Add(Spring(year), "Spring");

            if (year == 2002)
                bHols.Add(new DateTime(2002, 6, 3), "Golden Jubilee"); //Golden Jubilee of Elizabeth II
            if (year == 2012)
                bHols.Add(new DateTime(2012, 6, 5), "Queen's Diamond Jubilee"); //Queen's Diamond Jubilee
            if (year == 2022)
                bHols.Add(new DateTime(2022, 6, 3), "Queen's Platinum Jubilee"); //Queen's Platinum Jubilee
            if (UkCountry != UkCountries.Scotland)
            {
                bHols.Add(Summer(year), "Summer");
            }

            if (year == 2022)
            {
                bHols.Add(new DateTime(2022,9,19), "State Funeral of Queen Elizabeth II");
            }
            bHols.Add(Christmas(year), "Christmas");
            bHols.Add(BoxingDay(year), "Boxing Day");
            return bHols;
        }

        /// <summary>
        /// Get a list of dates for all holidays in a year.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public override IList<DateTime> PublicHolidays(int year)
        {
            return BankHolidays(year);
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
            return IsBankHoliday(dt);
        }

        /// <summary>
        /// Check if a specific date is a bank holiday.
        /// Obviously the BankHoliday list is more efficient for repeated checks
        /// </summary>
        /// <param name="dt">The date you wish to check</param>
        /// <returns>True if date is a bank holiday (excluding weekends)</returns>
        public virtual bool IsBankHoliday(DateTime dt)
        {
            int year = dt.Year;
            var date = dt.Date;

            switch (dt.Month)
            {
                case 1:
                    if ((year > 1973) && (NewYear(year) == date))
                        return true;
                    if (UkCountry == UkCountries.Scotland && NewYearHolidayScotland(year) == date)
                        return true;
                    break;

                case 3:
                case 4:
                    if (UkCountry == UkCountries.NorthernIreland && StPatricksDay(year) == date)
                        return true;
                    //only Mondays and Fridays are bank holidays
                    if (dt.DayOfWeek != DayOfWeek.Monday &&
                        dt.DayOfWeek != DayOfWeek.Friday)
                        return false;
                    //easter can be in March or April
                    var easterDate = HolidayCalculator.GetEaster(year);
                    if (GoodFriday(easterDate) == date)
                        return true;
                    if (UkCountry != UkCountries.Scotland && EasterMonday(easterDate) == date)
                        return true;
                    break;

                case 5:
                    if (dt.DayOfWeek != DayOfWeek.Monday && year != 2020)
                        return false;
                    if (MayDay(year) == date)
                        return true;
                    if (Spring(year) == date)
                        return true;
                    break;

                case 7:
                    if (UkCountry == UkCountries.NorthernIreland && BattleOfTheBoyne(year) == date)
                        return true;
                    break;

                case 8:
                    if (dt.DayOfWeek != DayOfWeek.Monday)
                        return false;
                    if (UkCountry == UkCountries.Scotland && SummerScotland(year) == date)
                        return true;
                    if (UkCountry != UkCountries.Scotland && Summer(year) == date)
                        return true;
                    break;

                case 11:
                    if (UkCountry == UkCountries.Scotland && StAndrews(year) == date)
                        return true;
                    break;

                case 12:
                    if (Christmas(year) == date)
                        return true;
                    if (BoxingDay(year) == date)
                        return true;
                    break;
            }
            if ((year == 2002) &&
               (dt.Month == 6) &&
               ((dt.Day == 3) || (dt.Day == 4)))
                return true; //Golden Jubilee of Elizabeth II
            if ((year == 2011) &&
               (dt.Month == 4) &&
               ((dt.Day == 29)))
                return true; //Royal Wedding
            if ((year == 2012) &&
               (dt.Month == 6) &&
               ((dt.Day == 5)))
                return true; //Queen's Diamond Jubilee
            if (year == 2022 && dt.Month == 6 && (dt.Day == 2 || dt.Day == 3))
                return true; //Queen's Platinum Jubilee
            if (year == 2022 && dt.Month == 9 && dt.Day == 19)
                return true; //State Funeral of Queen Elizabeth II
            if (year == 2023 && dt.Month == 5 && dt.Day == 8)
                return true; //Coronation of King Charles III

            return false;
        }
    }
}