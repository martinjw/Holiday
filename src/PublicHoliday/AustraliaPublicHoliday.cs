using System;
using System.Collections.Generic;
using System.Linq;
// ReSharper disable InconsistentNaming

namespace PublicHoliday
{
    /// <summary>
    /// Holidays in Austria http://www.australia.gov.au/about-australia/special-dates-and-events/public-holidays
    /// </summary>
    /// <remarks>
    /// Missing because no fixed date: 
    /// * For Victoria, AFL Grand Final Day
    /// * For Western Australia, Queen's Birthday (we assume end September BUT Governor may change)
    /// </remarks>
    public class AustraliaPublicHoliday : PublicHolidayBase
    {
        /// <summary>
        /// Gets or sets the state (ISO 3166-2:AU), + default All for all states.
        /// </summary>
        public States State { get; set; }

        /// <summary>
        ///
        /// </summary>
        public enum States
        {
            /// <summary>
            /// All
            /// </summary>
            All = 0,
            /// <summary>
            /// Australian Capital Territory
            /// </summary>
            ACT,
            /// <summary>
            /// New South Wales
            /// </summary>
            NSW,
            /// <summary>
            /// Northern Territory
            /// </summary>
            NT,
            /// <summary>
            /// Queensland
            /// </summary>
            QLD,
            /// <summary>
            /// South Australia
            /// </summary>
            SA,
            /// <summary>
            /// Tasmania
            /// </summary>
            TAS,
            /// <summary>
            /// Victoria
            /// </summary>
            VIC,
            /// <summary>
            /// Western Australia
            /// </summary>
            WA,
        }
        #region Individual Holidays

        /// <summary>
        /// New Year's Day
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime NewYear(int year)
        {
            return HolidayCalculator.FixWeekend(new DateTime(year, 1, 1));
        }

        /// <summary>
        /// Australia Day January 26
        /// </summary>
        /// <param name="year"></param>

        public static DateTime AustraliaDay(int year)
        {
            return HolidayCalculator.FixWeekend(new DateTime(year, 1, 26));
        }

        /// <summary>
        /// Good Friday (Friday before Easter)
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime GoodFriday(int year)
        {
            var easter = HolidayCalculator.GetEaster(year);
            return GoodFriday(easter);
        }
        private static DateTime GoodFriday(DateTime easter)
        {
            return easter.AddDays(-2);
        }

        /// <summary>
        /// Easter Monday
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime EasterMonday(int year)
        {
            var easter = HolidayCalculator.GetEaster(year);
            return EasterMonday(easter);
        }

        private static DateTime EasterMonday(DateTime easter)
        {
            return easter.AddDays(1);
        }

        /// <summary>
        /// Labour Day
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="state">The state.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">You must specify one of the states/territories - state</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">state - No such state</exception>
        public static DateTime LabourDay(int year, States state)
        {
            switch (state)
            {
                case States.All:
                    throw new ArgumentException("You must specify one of the states/territories", nameof(state));
                case States.ACT:
                case States.NSW:
                case States.SA:
                    //Australian Capital Territory, New South Wales and South Australia = first Monday in October
                    return HolidayCalculator.FindNext(new DateTime(year, 10, 1), DayOfWeek.Monday);
                case States.NT:
                case States.QLD:
                    //Northern Territory and Queensland = May Day
                    return HolidayCalculator.FindNext(new DateTime(year, 5, 1), DayOfWeek.Monday);
                case States.TAS:
                case States.VIC:
                    //Victoria and Tasmania = second Monday in March ("Eight Hours Day").
                    return HolidayCalculator.FindNext(new DateTime(year, 3, 1), DayOfWeek.Monday).AddDays(7);
                case States.WA:
                    //Western Australia= first Monday in March
                    return HolidayCalculator.FindNext(new DateTime(year, 3, 1), DayOfWeek.Monday);
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, "No such state");
            }
        }

        /// <summary>
        /// ANZAC day, 25th April
        /// </summary>
        /// <param name="year"></param>

        public static DateTime AnzacDay(int year)
        {
            return new DateTime(year, 4, 25);
        }

        /// <summary>
        /// ANZAC day, 25th April, adjusted if on weekends (specific states only)
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="state">The state.</param>
        /// <returns></returns>

        public static DateTime AnzacDay(int year, States state)
        {
            if (state == States.ACT || state == States.NT || state == States.SA || state == States.WA)
            {
                return HolidayCalculator.FixWeekend(new DateTime(year, 4, 25));
            }
            return new DateTime(year, 4, 25);
        }

        /// <summary>
        /// Canberra Day, 2nd Monday of March
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public static DateTime CanberraDay(int year)
        {
            var secondMonday = HolidayCalculator.FindNext(new DateTime(year, 3, 1), DayOfWeek.Monday).AddDays(7);
            return year < 2008 ? secondMonday.AddDays(7) : secondMonday;
        }

        /// <summary>
        /// Western Australia Day, 1st Monday of June
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public static DateTime WesternAustraliaDay(int year)
        {
            return HolidayCalculator.FindNext(new DateTime(year, 6, 1), DayOfWeek.Monday);
        }
        /// <summary>
        /// Picnic Day (Northern Territory only), first Monday of August
        /// </summary>
        /// <param name="year"></param>

        public static DateTime PicnicDay(int year)
        {
            //only Northern Territory
            return HolidayCalculator.FindNext(new DateTime(year, 8, 1), DayOfWeek.Monday);
        }

        /// <summary>
        /// Family  and community day, Australian Capital Territory.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public static DateTime? FamilyAndCommunityDay(int year)
        {
            //first declared in 2007
            if (year < 2007) return null;
            if (year >= 2007 && year <= 2009)
                return HolidayCalculator.FindNext(new DateTime(year, 11, 1), DayOfWeek.Tuesday);
            //2010+ first Monday of the September/October school holidays
            //if coincides with Labour day, moves to 2nd Monday
            var facDay = HolidayCalculator.FindNext(new DateTime(year, 9, 25), DayOfWeek.Monday);
            if (facDay == HolidayCalculator.FindNext(new DateTime(year, 10, 1), DayOfWeek.Monday))
                facDay = facDay.AddDays(7);
            return facDay;
        }
        /// <summary>
        /// Queen's Birthday (varies by state)
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="state">The state.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">You must specify one of the states/territories - state</exception>

        public static DateTime QueenBirthday(int year, States state)
        {
            switch (state)
            {
                case States.All:
                    throw new ArgumentException("You must specify one of the states/territories", nameof(state));
                case States.ACT:
                case States.NSW:
                case States.NT:
                case States.SA:
                case States.TAS:
                case States.VIC:
                    //second Monday in June
                    return HolidayCalculator.FindNext(new DateTime(year, 6, 1), DayOfWeek.Monday).AddDays(7);
                case States.QLD:
                    //first Monday in October
                    if (year >= 2016 || year == 2012)
                    {
                        return HolidayCalculator.FindNext(new DateTime(year, 10, 1), DayOfWeek.Monday);
                    }
                    //before 2016 was in June
                    return HolidayCalculator.FindNext(new DateTime(year, 6, 1), DayOfWeek.Monday).AddDays(7);
                case States.WA:
                    //last Monday of September or first of October. No firm rule, all recent dates are September
                    return HolidayCalculator.FindPrevious(new DateTime(year, 9, 30), DayOfWeek.Monday);
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, "Invalid state");
            }
        }

        /// <summary>
        /// Melbourne Cup (most of Victoria)- first Tuesday of November
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime MelbourneCup(int year)
        {
            return HolidayCalculator.FindNext(new DateTime(year, 11, 1), DayOfWeek.Tuesday);
        }

        /// <summary>
        /// Christmas
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime Christmas(int year)
        {
            return HolidayCalculator.FixWeekend(new DateTime(year, 12, 25));
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

        #endregion Individual Holidays

        /// <summary>
        /// Get a list of dates for all holidays in a year.
        /// </summary>
        /// <param name="year">The year</param>
        /// <returns>List of public holidays</returns>
        public override IList<DateTime> PublicHolidays(int year)
        {
            return PublicHolidayNames(year).Select(x => x.Key).OrderBy(x => x).ToList();
        }

        /// <summary>
        /// Public holiday names in Lëtzebuergesch.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public override IDictionary<DateTime, string> PublicHolidayNames(int year)
        {
            //sorted dictionary as these may not be in order...
            var bHols = new SortedDictionary<DateTime, string>
            {
                {NewYear(year), "New Year"},
                {AustraliaDay(year), "Australia Day"}
            };
            var easter = HolidayCalculator.GetEaster(year);
            bHols.Add(GoodFriday(easter), "Good Friday");
            bHols.Add(EasterMonday(easter), "Easter Monday");
            if (State == States.ACT)
            {
                bHols.Add(CanberraDay(year), "Canberra Day");
            }
            bHols.Add(AnzacDay(year, State), "ANZAC Day");
            if (State == States.NT)
            {
                bHols.Add(PicnicDay(year), "Picnic Day");
            }
            if (State == States.WA)
            {
                bHols.Add(WesternAustraliaDay(year), "Western Australia Day");
            }
            if (State != States.All)
            {
                bHols.Add(LabourDay(year, State), "Labour Day");
                bHols.Add(QueenBirthday(year, State), "Queen's Birthday");
            }
            if (State == States.ACT)
            {
                var fac = FamilyAndCommunityDay(year);
                if (fac.HasValue) bHols.Add(fac.Value, "Family And Community Day");
            }
            if (State == States.VIC)
            {
                bHols.Add(MelbourneCup(year), "Melbourne Cup");
            }
            bHols.Add(Christmas(year), "Christmas Day");
            bHols.Add(BoxingDay(year), State == States.SA ? "Proclamation Day" : "Boxing Day");
            return bHols;
        }

        /// <summary>
        /// Check if a specific date is a public holiday.
        /// Obviously the PublicHoliday list is more efficient for repeated checks
        /// Note holidays can fall on weekends and there is no fixed moving of such dates.
        /// </summary>
        /// <param name="dt">The date you wish to check</param>
        /// <returns>True if date is a public holiday</returns>
        public override bool IsPublicHoliday(DateTime dt)
        {
            var year = dt.Year;
            var date = dt.Date;

            switch (dt.Month)
            {
                case 1:
                    if (NewYear(year) == date)
                        return true;
                    if (AustraliaDay(year) == date)
                        return true;
                    break;

                case 3:
                case 4:
                    if (State == States.TAS || State == States.WA || State == States.VIC)
                    {
                        if (LabourDay(year, State) == date)
                            return true;
                    }
                    if (State == States.ACT && CanberraDay(year) == date)
                        return true;
                    if (GoodFriday(year) == date)
                        return true;
                    if (EasterMonday(year) == date)
                        return true;
                    if (AnzacDay(year, State) == date)
                        return true;
                    break;

                case 5:
                    if (State == States.NT || State == States.QLD)
                    {
                        if (LabourDay(year, State) == date)
                            return true;
                    }
                    break;

                case 6:
                    switch (State)
                    {
                        case States.ACT:
                        case States.NSW:
                        case States.NT:
                        case States.SA:
                        case States.TAS:
                        case States.VIC:
                        case States.QLD: //some years
                            if (QueenBirthday(year, State) == date)
                                return true;
                            break;
                        case States.WA:
                            if (WesternAustraliaDay(year) == date)
                                return true;
                            break;
                    }
                    break;

                case 8:
                    if (State == States.NT && PicnicDay(year) == date)
                        return true;
                    break;
                case 9:
                    if (State == States.WA)
                    {
                        if (QueenBirthday(year, State) == date)
                            return true;
                    }

                    break;
                case 10:
                    if (State == States.ACT || State == States.NSW || State == States.SA)
                    {
                        if (LabourDay(year, State) == date)
                            return true;
                    }
                    if (State == States.QLD || State == States.WA)
                    {
                        if (QueenBirthday(year, State) == date)
                            return true;
                    }

                    break;

                case 11:
                    if (State == States.VIC && MelbourneCup(year) == date)
                        return true;
                    break;

                case 12:
                    if (Christmas(year) == date)
                        return true;
                    if (BoxingDay(year) == date)
                        return true;
                    break;
            }
            if (State == States.ACT)
            {
                //variable months
                if (FamilyAndCommunityDay(year) == date) return true;
            }

            return false;
        }
    }
}