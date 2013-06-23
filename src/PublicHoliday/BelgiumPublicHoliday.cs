using System;
using System.Collections.Generic;

namespace PublicHoliday
{
    /// <summary>
    /// Finds Belgium public holidays. 
    /// Public holidays on Sundays are not deferred to following weekday automatically- 
    /// they may be taken at an arbitary date.
    /// </summary>
    public static class BelgiumPublicHoliday
    {

        #region Individual Holidays

        /// <summary>
        /// New Year's Day January 1 Nieuwjaar / Nouvel An 
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime NewYear(int year)
        {
            return new DateTime(year, 1, 1);
        }

        /// <summary>
        /// Easter Monday 1st Monday after Easter Paasmaandag / Lundi de Pâques
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime EasterMonday(int year)
        {
            DateTime hol = GetEaster(year);
            hol = hol.AddDays(1);
            return hol;
        }

        private static DateTime EasterMonday(DateTime easter)
        {
            return easter.AddDays(1);
        }

        //Labor Day May 1 Dag van de arbeid / Fête du Travail
        /// <summary>
        /// Mays the day.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public static DateTime MayDay(int year)
        {
            return new DateTime(year, 5, 1);
        }


        /// <summary>
        /// Ascension 6th Thursday after Easter- Hemelvaartsdag / Ascension
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime Ascension(int year)
        {
            DateTime hol = GetEaster(year);
            hol = hol.AddDays(4 + (7 * 5));
            return hol;
        }
        private static DateTime Ascension(DateTime easter)
        {
            return easter.AddDays(4 + (7 * 5));
        }

        /// <summary>
        /// Whit Monday - Pentecost Monday 7th Monday after Easter Pinkstermaandag / Lundi de Pentecôte
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime PentecostMonday(int year)
        {
            DateTime hol = GetEaster(year);
            hol = hol.AddDays((7 * 7) + 1);
            return hol;
        }
        private static DateTime PentecostMonday(DateTime easter)
        {
            return easter.AddDays(1 + (7 * 7));
        }

        /// <summary>
        /// National holiday July 21 Nationale feestdag / Fête nationale
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime National(int year)
        {
            return new DateTime(year, 7, 21);
        }

        /// <summary>
        /// Assumption of Mary August 15 Onze Lieve Vrouw hemelvaart / Assomption
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime Assumption(int year)
        {
            return new DateTime(year, 8, 15);
        }

        /// <summary>
        /// All Saints November 1 Allerheiligen / Toussaint 
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime AllSaints(int year)
        {
            return new DateTime(year, 11, 1);
        }

        /// <summary>
        /// Armistice Day November 11 Wapenstilstand / Jour de l'armistice
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime Armistice(int year)
        {
            return new DateTime(year, 11, 11);
        }

        /// <summary>
        /// Christmas December 25  Kerstmis / Noël
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime Christmas(int year)
        {
            return new DateTime(year, 12, 25);
        }
        #endregion

        /// <summary>
        /// Get a list of dates for all holidays in a year.
        /// </summary>
        /// <param name="year">The year</param>
        /// <returns>List of public holidays</returns>
        public static IList<DateTime> PublicHolidays(int year)
        {
            List<DateTime> bHols = new List<DateTime>();
            bHols.Add(NewYear(year));
            DateTime easter = GetEaster(year);
            bHols.Add(EasterMonday(easter));
            DateTime mayday = MayDay(year);
            DateTime ascension = Ascension(easter);
            if (ascension == mayday) ascension = ascension.AddSeconds(1); //ascension can fall on Mayday
            bHols.Add(mayday);
            bHols.Add(ascension);
            bHols.Add(PentecostMonday(easter));
            bHols.Add(National(year));

            bHols.Add(Assumption(year));
            bHols.Add(AllSaints(year));
            bHols.Add(Armistice(year));
            bHols.Add(Christmas(year));
            return bHols;
        }

        /// <summary>
        /// Public holiday names in Dutch.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public static IDictionary<DateTime, string> PublicHolidayNLNames(int year)
        {
            Dictionary<DateTime, string> bHols = new Dictionary<DateTime, string>();
            bHols.Add(NewYear(year), "Nieuwjaar");
            DateTime easter = GetEaster(year);
            bHols.Add(EasterMonday(easter), "Paasmaandag");
            DateTime mayday = MayDay(year);
            DateTime ascension = Ascension(easter);
            if (ascension == mayday) ascension = ascension.AddSeconds(1); //ascension can fall on Mayday
            bHols.Add(mayday, "Dag van de arbeid");
            bHols.Add(ascension, "Hemelvaartsdag");
            bHols.Add(PentecostMonday(easter), "Pinkstermaandag");
            bHols.Add(National(year), "Nationale feestdag");

            bHols.Add(Assumption(year), "Onze Lieve Vrouw hemelvaart");
            bHols.Add(AllSaints(year), "Allerheiligen");
            bHols.Add(Armistice(year), "Wapenstilstand");
            bHols.Add(Christmas(year), "Kerstmis");
            return bHols;
        }

        /// <summary>
        /// Public holiday names in French.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public static IDictionary<DateTime, string> PublicHolidayFRNames(int year)
        {

            Dictionary<DateTime, string> bHols = new Dictionary<DateTime, string>();
            bHols.Add(NewYear(year), "Nouvel An");
            DateTime easter = GetEaster(year);
            bHols.Add(EasterMonday(easter), "Lundi de Pâques");
            DateTime mayday = MayDay(year);
            bHols.Add(mayday, "Fête du Travail");
            DateTime ascension = Ascension(easter);
            if (ascension == mayday) ascension = ascension.AddSeconds(1); //ascension can fall on Mayday
            bHols.Add(ascension, "Ascension");
            bHols.Add(PentecostMonday(easter), "Lundi de Pentecôte");
            bHols.Add(National(year), "Fête nationale");

            bHols.Add(Assumption(year), "Assomption");
            bHols.Add(AllSaints(year), "Toussaint");
            bHols.Add(Armistice(year), "Jour de l'armistice");
            bHols.Add(Christmas(year), "Noël");
            return bHols;
        }

        /// <summary>
        /// Check if a specific date is a public holiday.
        /// Obviously the PublicHoliday list is more efficient for repeated checks
        /// Note holidays can fall on weekends and there is no fixed moving of such dates.
        /// </summary>
        /// <param name="dt">The date you wish to check</param>
        /// <returns>True if date is a public holiday</returns>
        public static bool IsPublicHoliday(DateTime dt)
        {
            int year = dt.Year;

            switch (dt.Month)
            {
                case 1:
                    if (NewYear(year) == dt)
                        return true;
                    break;
                case 3:
                case 4:
                    if (EasterMonday(year) == dt)
                        return true;
                    break;
                case 5:
                    if (MayDay(year) == dt)
                        return true;
                    if (Ascension(year) == dt)
                        return true; //usually in May (may 25, 2006)
                    if (PentecostMonday(year) == dt)
                        return true; // May 20 2004
                    break;
                case 6:
                    if (Ascension(year) == dt)
                        return true; //Ascension was June 1 2000
                    if (PentecostMonday(year) == dt)
                        return true; // June 12 2006
                    break;
                case 7:
                    if (National(year) == dt)
                        return true; //21st July
                    break;
                case 8:
                    if (Assumption(year) == dt)
                        return true; //August 15, fixed
                    break;
                case 11:
                    if (AllSaints(year) == dt)
                        return true;
                    if (Armistice(year) == dt)
                        return true;
                    break;
                case 12:
                    if (Christmas(year) == dt)
                        return true;
                    break;
            }
            return false;
        }

        /// <summary>
        /// Work out the date for Easter Sunday for specified year
        /// </summary>
        /// <param name="year">The year as an integer</param>
        /// <returns>Returns a datetime of Easter Sunday.</returns>
        private static DateTime GetEaster(int year)
        {
            int g, c, h, i, j, p;
            int easterMonth;
            int easterDay;

            //should be
            //Easter Monday  28 Mar 2005  17 Apr 2006  9 Apr 2007  24 Mar 2008

            //Oudin's Algorithm - http://www.smart.net/~mmontes/oudin.html
            g = year % 19;
            c = year / 100;
            h = (c - c / 4 - (8 * c + 13) / 25 + 19 * g + 15) % 30;
            i = h - (h / 28) * (1 - (h / 28) * (29 / (h + 1)) * ((21 - g) / 11));
            j = (year + year / 4 + i + 2 - c + c / 4) % 7;
            p = i - j;
            easterDay = (int)1 + (p + 27 + (p + 6) / 40) % 31;
            easterMonth = (int)3 + (p + 26) / 30;

            return new DateTime(year, easterMonth, easterDay);
        }
    }
}