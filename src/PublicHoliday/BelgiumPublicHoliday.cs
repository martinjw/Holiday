using System;
using System.Collections.Generic;

namespace PublicHoliday
{
    /// <summary>
    /// Finds Belgium public holidays. 
    /// Public holidays on Sundays are not deferred to following weekday automatically- 
    /// they may be taken at an arbitary date.
    /// </summary>
    /// <remarks>
    /// Strictly Easter Sunday is also a public holiday
    /// </remarks>
    public class BelgiumPublicHoliday : PublicHolidayBase
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
            var hol = HolidayCalculator.GetEaster(year);
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
            var hol = HolidayCalculator.GetEaster(year);
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
            var hol = HolidayCalculator.GetEaster(year);
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
        public override IList<DateTime> PublicHolidays(int year)
        {
            var bHols = new List<DateTime>();
            bHols.Add(NewYear(year));
            DateTime easter = HolidayCalculator.GetEaster(year);
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
        public override IDictionary<DateTime, string> PublicHolidayNames(int year)
        {
            var bHols = new Dictionary<DateTime, string>();
            bHols.Add(NewYear(year), "Nieuwjaar");
            DateTime easter = HolidayCalculator.GetEaster(year);
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
        public virtual IDictionary<DateTime, string> PublicHolidayNamesFrench(int year)
        {

            var bHols = new Dictionary<DateTime, string>();
            bHols.Add(NewYear(year), "Nouvel An");
            DateTime easter = HolidayCalculator.GetEaster(year);
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
        public override bool IsPublicHoliday(DateTime dt)
        {
            var year = dt.Year;
            var date = dt.Date;

            switch (dt.Month)
            {
                case 1:
                    if (NewYear(year) == date)
                        return true;
                    break;
                case 3:
                case 4:
                    if (EasterMonday(year) == date)
                        return true;
                    break;
                case 5:
                    if (MayDay(year) == date)
                        return true;
                    if (Ascension(year) == date)
                        return true; //usually in May (may 25, 2006)
                    if (PentecostMonday(year) == date)
                        return true; // May 20 2004
                    break;
                case 6:
                    if (Ascension(year) == date)
                        return true; //Ascension was June 1 2000
                    if (PentecostMonday(year) == date)
                        return true; // June 12 2006
                    break;
                case 7:
                    if (National(year) == date)
                        return true; //21st July
                    break;
                case 8:
                    if (Assumption(year) == date)
                        return true; //August 15, fixed
                    break;
                case 11:
                    if (AllSaints(year) == date)
                        return true;
                    if (Armistice(year) == date)
                        return true;
                    break;
                case 12:
                    if (Christmas(year) == date)
                        return true;
                    break;
            }
            return false;
        }
    }
}