using System;
using System.Collections.Generic;

// ReSharper disable InconsistentNaming

namespace PublicHoliday
{
    /// <summary>
    /// German Federal (German Unity Day) and State Public Holidays (excluding Sundays)
    /// </summary>
    public class GermanPublicHoliday : PublicHolidayBase
    {
        /// <summary>
        /// Gets or sets the state (ISO 3166-2:DE), + default All for all states.
        /// </summary>
        public States State { get; set; }

        /// <summary>
        ///
        /// </summary>
        public enum States
        {
            /// <summary>
            /// All states
            /// </summary>
            ALL = 0,

            /// <summary>
            /// Baden-Württemberg
            /// </summary>
            BW,

            /// <summary>
            /// Bayern, Bavaria
            /// </summary>
            BY,

            /// <summary>
            /// Berlin
            /// </summary>
            BE,

            /// <summary>
            /// Brandenburg
            /// </summary>
            BB,

            /// <summary>
            /// Bremen
            /// </summary>
            HB,

            /// <summary>
            /// Hamburg
            /// </summary>
            HH,

            /// <summary>
            /// Hessen, Hesse
            /// </summary>
            HE,

            /// <summary>
            /// Mecklenburg-Vorpommern
            /// </summary>
            MV,

            /// <summary>
            /// Niedersachsen, Lower Saxony
            /// </summary>
            NI,

            /// <summary>
            /// Nordrhein-Westfalen, North Rhine-Westphalia
            /// </summary>
            NW,

            /// <summary>
            /// Rheinland-Pfalz, Rhineland-Palatinate
            /// </summary>
            RP,

            /// <summary>
            /// Saarland
            /// </summary>
            SL,

            /// <summary>
            /// Sachsen, Saxony
            /// </summary>
            SN,

            /// <summary>
            /// Sachsen-Anhalt
            /// </summary>
            ST,

            /// <summary>
            /// Schleswig-Holstein
            /// </summary>
            SH,

            /// <summary>
            /// Thüringen
            /// </summary>
            TH,
        }

        /// <summary>
        /// Neujahrstag New Year's Day January 1
        /// </summary>
        /// <param name="year"></param>

        public static DateTime NewYear(int year)
        {
            return new DateTime(year, 1, 1);
        }

        /// <summary>
        /// Heilige Drei Könige Epiphany January 6
        /// </summary>
        /// <param name="year"></param>

        public static DateTime Epiphany(int year)
        {
            return new DateTime(year, 1, 6);
        }

        /// <summary>
        /// Whether this state observes epiphany.
        /// </summary>
        /// <value>
        /// <c>true</c> if this state observes epiphany; otherwise, <c>false</c>.
        /// </value>
        public bool HasEpiphany => Array.IndexOf(new[] { States.BW, States.BY, States.ST }, State) > -1;

        /// <summary>
        /// Karfreitag - Good Friday
        /// </summary>
        /// <param name="year"></param>
        public static DateTime GoodFriday(int year)
        {
            var hol = HolidayCalculator.GetEaster(year);
            hol = hol.AddDays(-2);
            return hol;
        }

        /// <summary>
        /// Ostermontag - Easter Monday
        /// </summary>
        /// <param name="year"></param>
        public static DateTime EasterMonday(int year)
        {
            var hol = HolidayCalculator.GetEaster(year);
            hol = hol.AddDays(1);
            return hol;
        }

        /// <summary>
        /// Tag der Arbeit - Labour Day
        /// </summary>
        /// <param name="year">The year.</param>

        public static DateTime MayDay(int year)
        {
            return new DateTime(year, 5, 1);
        }

        /// <summary>
        /// Christi Himmelfahrt - Ascension
        /// </summary>
        /// <param name="year"></param>

        public static DateTime Ascension(int year)
        {
            var hol = HolidayCalculator.GetEaster(year);
            hol = hol.AddDays(4 + (7 * 5));
            return hol;
        }

        /// <summary>
        /// Pfingstmontag - Pentecost
        /// </summary>
        /// <param name="year"></param>

        public static DateTime PentecostMonday(int year)
        {
            var hol = HolidayCalculator.GetEaster(year);
            hol = hol.AddDays((7 * 7) + 1);
            return hol;
        }

        /// <summary>
        /// Fronleichnam - CorpusChristi
        /// </summary>
        /// <param name="year"></param>

        public static DateTime CorpusChristi(int year)
        {
            var hol = HolidayCalculator.GetEaster(year);
            //first Thursday after Trinity Sunday (Pentecost + 1 week)
            hol = hol.AddDays((7 * 8) + 4);
            return hol;
        }

        /// <summary>
        /// Whether this state observes Fronleichnam.
        /// </summary>
        /// <value>
        /// <c>true</c> if this state observes Fronleichnam; otherwise, <c>false</c>.
        /// </value>
        public bool HasCorpusChristi => Array.IndexOf(new[] { States.BW, States.BY, States.HE, States.NW, States.RP, States.SL }, State) > -1;

        /// <summary>
        /// Mariä Himmelfahrt - Assumption of Mary
        /// </summary>
        /// <param name="year"></param>
        public static DateTime Assumption(int year)
        {
            return new DateTime(year, 8, 15);
        }

        /// <summary>
        /// Whether this state observes Mariä Himmelfahrt.
        /// </summary>
        /// <value>
        /// <c>true</c> if this state observes Mariä Himmelfahrt; otherwise, <c>false</c>.
        /// </value>
        public bool HasAssumption => States.SL == State;

        /// <summary>
        /// Kindertag - World Children's Day
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime WorldChildrensDay(int year)
        {
            return new DateTime(year, 9, 20);
        }

        /// <summary>
        /// Whether this state observes Kindertag
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public bool HasWorldChildrensDay(int year)
        {
            return (year >= 2019 && State == States.TH);
        }


        /// <summary>
        /// Tag der Deutschen Einheit - German Unity
        /// </summary>
        /// <param name="year"></param>
        public static DateTime GermanUnity(int year)
        {
            return new DateTime(year, 10, 3);
        }

        /// <summary>
        /// Reformationstag - Reformation
        /// </summary>
        /// <param name="year"></param>
        public static DateTime Reformation(int year)
        {
            return new DateTime(year, 10, 31);
        }

        /// <summary>
        /// Whether this state observes Reformationstag
        /// </summary>
        /// <value>
        /// <c>true</c> if this state observes Reformationstag; otherwise, <c>false</c>.
        /// </value>
        public bool HasReformation => Array.IndexOf(new[] { States.BB, States.MV, States.SN, States.ST, States.TH, States.HB, States.HH, States.NI, States.SH }, State) > -1;

        /// <summary>
        /// Allerheiligen - All Saints
        /// </summary>
        /// <param name="year"></param>

        public static DateTime AllSaints(int year)
        {
            return new DateTime(year, 11, 1);
        }

        /// <summary>
        /// Whether this state observes Allerheiligen
        /// </summary>
        /// <value>
        /// <c>true</c> if this state observes Allerheiligen; otherwise, <c>false</c>.
        /// </value>
        public bool HasAllSaints => Array.IndexOf(new[] { States.BW, States.BY, States.NW, States.RP, States.SL }, State) > -1;

        /// <summary>
        /// Buß- und Bettag - Repentance and Prayer
        /// </summary>
        /// <param name="year"></param>
        public static DateTime Repentance(int year)
        {
            var firstAdvent = HolidayCalculator.FindPrevious(Christmas(year), DayOfWeek.Sunday).AddDays(-28);
            var wednesday = HolidayCalculator.FindPrevious(firstAdvent, DayOfWeek.Wednesday);
            return wednesday;
        }

        /// <summary>
        /// Whether this state observes Buß- und Bettag
        /// </summary>
        /// <value>
        /// <c>true</c> if this state observes Buß- und Bettag; otherwise, <c>false</c>.
        /// </value>
        public bool HasRepentance => States.SN == State;

        /// <summary>
        /// Weihnachtstag - Christmas
        /// </summary>
        /// <param name="year"></param>

        public static DateTime Christmas(int year)
        {
            return new DateTime(year, 12, 25);
        }

        /// <summary>
        /// Zweiter Weihnachtsfeiertag- St Stephens
        /// </summary>
        /// <param name="year"></param>

        public static DateTime StStephen(int year)
        {
            return new DateTime(year, 12, 26);
        }

        /// <summary>
        /// Whether this state observes Womens Day/Weltfrauentag (March 8)
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public bool HasWomensDay(int year) => State == States.BE && year >= 2019;

        /// <summary>
        /// International Women's Day/ Weltfrauentag
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime WomensDay(int year)
        {
            return new DateTime(year, 3, 8);
        }

        /// <summary>
        /// List of federal and state holidays (for defined <see cref="State"/>)
        /// </summary>
        /// <param name="year">The year.</param>

        public override IList<DateTime> PublicHolidays(int year)
        {
            var bHols = new List<DateTime> { NewYear(year) };
            if (HasEpiphany) bHols.Add(Epiphany(year));
            if (HasWomensDay(year)) bHols.Add(WomensDay(year));
            bHols.Add(GoodFriday(year));
            bHols.Add(EasterMonday(year));
            bHols.Add(MayDay(year));
            bHols.Add(Ascension(year));
            bHols.Add(PentecostMonday(year));
            if (HasCorpusChristi) bHols.Add(CorpusChristi(year));
            if (HasAssumption) bHols.Add(Assumption(year));
            if (HasWorldChildrensDay(2019)) bHols.Add(WorldChildrensDay(2019));
            bHols.Add(GermanUnity(year));
            //All states observe Reformation in 2017, 500th anniversary
            if (HasReformation || year == 2017) bHols.Add(Reformation(year));
            if (HasAllSaints) bHols.Add(AllSaints(year));
            if (HasRepentance) bHols.Add(Repentance(year));
            bHols.Add(Christmas(year));
            bHols.Add(StStephen(year));
            return bHols;
        }

        /// <summary>
        /// Get a list of dates with names for all holidays in a year.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>
        /// Dictionary of bank holidays
        /// </returns>
        public override IDictionary<DateTime, string> PublicHolidayNames(int year)
        {
            var bHols = new Dictionary<DateTime, string> { { NewYear(year), "Neujahrstag" } };
            if (HasEpiphany) bHols.Add(Epiphany(year), "Heilige Drei Könige");
            if (HasWomensDay(year)) bHols.Add(WomensDay(year), "Weltfrauentag");
            bHols.Add(GoodFriday(year), "Karfreitag");
            bHols.Add(EasterMonday(year), "Ostermontag");
            bHols.Add(MayDay(year), "Tag der Arbeit");
            bHols.Add(Ascension(year), "Christi Himmelfahrt");
            bHols.Add(PentecostMonday(year), "Pfingstmontag");
            if (HasCorpusChristi) bHols.Add(CorpusChristi(year), "Fronleichnam");
            if (HasAssumption) bHols.Add(Assumption(year), "Mariä Himmelfahrt");
            if (HasWorldChildrensDay(2019)) bHols.Add(WorldChildrensDay(2019), "Kindertag");
            bHols.Add(GermanUnity(year), "Tag der Deutschen Einheit");
            if (HasReformation || year == 2017) bHols.Add(Reformation(year), "Reformationstag");
            if (HasAllSaints) bHols.Add(AllSaints(year), "Allerheiligen");
            if (HasRepentance) bHols.Add(Repentance(year), "Buß- und Bettag");
            bHols.Add(Christmas(year), "Weihnachtstag");
            bHols.Add(StStephen(year), "Zweiter Weihnachtsfeiertag");
            return bHols;
        }

        /// <summary>
        /// Determines whether date is a public holiday.
        /// </summary>
        /// <param name="dt">The date.</param>
        /// <returns>
        ///   <c>true</c> if is public holiday; otherwise, <c>false</c>.
        /// </returns>
        public override bool IsPublicHoliday(DateTime dt)
        {
            var year = dt.Year;
            var date = dt.Date;

            switch (dt.Month)
            {
                case 1:
                    if (NewYear(year) == date)
                        return true;
                    if (HasEpiphany && Epiphany(year) == date)
                        return true;
                    break;

                case 3:
                case 4:
                    if (HasWomensDay(year) && WomensDay(year) == date)
                        return true;
                    if (GoodFriday(year) == date)
                        return true;
                    if (EasterMonday(year) == date)
                        return true;
                    break;

                case 5:
                case 6:
                    if (MayDay(year) == date)
                        return true;
                    if (Ascension(year) == date)
                        return true;
                    if (PentecostMonday(year) == date)
                        return true;
                    if (HasCorpusChristi && CorpusChristi(year) == date)
                        return true;
                    break;

                case 8:
                    if (HasAssumption && Assumption(year) == date)
                        return true;
                    break;

                case 9:
                    if (HasWorldChildrensDay(year) && WorldChildrensDay(year) == date)
                        return true;
                    break;

                case 10:
                    if (GermanUnity(year) == date)
                        return true;
                    //All states observe Reformation in 2017, 500th anniversary
                    if ((HasReformation || year == 2017) && Reformation(year) == date)
                        return true;
                    break;

                case 11:
                    if (HasAllSaints && AllSaints(year) == date)
                        return true;
                    if (HasRepentance && Repentance(year) == date)
                        return true;
                    break;

                case 12:
                    if (Christmas(year) == date)
                        return true;
                    if (StStephen(year) == date)
                        return true;
                    break;
            }

            return false;
        }
    }
}