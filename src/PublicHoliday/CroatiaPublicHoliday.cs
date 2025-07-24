using System;
using System.Collections.Generic;
using System.Linq;

namespace PublicHoliday
{
    /// <summary>
    /// Holidays in Croatia
    /// </summary>
    public class CroatiaPublicHoliday : PublicHolidayBase
    {
        #region Individual Holidays

        /// <summary>
        /// Nova godina
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime NewYear(int year)
        {
            return new DateTime(year, 1, 1);
        }

        /// <summary>
        /// Bogojavljenje ili Sveta tri kralja
        /// </summary>
        /// <param name="year"></param>

        public static DateTime Epiphany(int year)
        {
            return new DateTime(year, 1, 6);
        }

        /// <summary>
        /// Uskrsni ponedjeljak
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
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
        
        /// <summary>
        /// Tijelovo
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
        /// Praznik rada
        /// </summary>
        /// <param name="year">The year.</param>
        public static DateTime LabourDay(int year)
        {
            return new DateTime(year, 5, 1);
        }
        
        /// <summary>
        /// Dan državnosti
        /// </summary>
        /// <param name="year"></param>
        public static DateTime NationalDay(int year)
        {
            return new DateTime(year, 05, 30);
        }

        /// <summary>
        /// Dan antifašističke borbe (Day of Anti-Fascist Struggle)
        /// </summary>
        /// <param name="year"></param>

        public static DateTime DayOfAntiFacistStruggle(int year)
        {
            return new DateTime(year, 06, 22);
        }
        
        /// <summary>
        /// Dan pobjede i domovinske zahvalnosti i Dan hrvatskih branitelja (Victory and Homeland Thanksgiving Day and the Day of Croatian Defenders)
        /// </summary>
        /// <param name="year"></param>

        public static DateTime VictoryHomelandThanksgivingDay(int year)
        {
            return new DateTime(year, 08,05);
        }

        /// <summary>
        /// Velika Gospa
        /// </summary>
        /// <param name="year"></param>
        public static DateTime Assumption(int year)
        {
            return new DateTime(year, 8, 15);
        }


        /// <summary>
        /// Svi sveti
        /// </summary>
        /// <param name="year"></param>

        public static DateTime AllSaints(int year)
        {
            return new DateTime(year, 11, 1);
        }
        
        /// <summary>
        /// Dan sjećanja na žrtve Domovinskog rata i Dan sjećanja na žrtvu Vukovara i Škabrnje
        ///  (Remembrance Day for the Victims of the Homeland War and Remembrance Day for the Victims of Vukovar and Škabrnja)
        /// </summary>
        /// <param name="year"></param>

        public static DateTime RemembranceDayForVictimsOfHomelandWar(int year)
        {
            return new DateTime(year, 11, 18);
        }

        /// <summary>
        /// Božić
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime Christmas(int year)
        {
            return new DateTime(year, 12, 25);
        }

        /// <summary>
        /// Sveti Stjepan
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime StStephen(int year)
        {
            return new DateTime(year, 12, 26);
        }

        #endregion Individual Holidays

        /// <summary>
        /// Get a list of dates for all holidays in a year.
        /// </summary>
        /// <param name="year">The year</param>
        /// <returns>List of public holidays</returns>
        public override IList<DateTime> PublicHolidays(int year)
        {
            return PublicHolidayNames(year).Select(x => x.Key.Date).OrderBy(x => x).ToList();
        }

        /// <summary>
        /// Public holiday names in German.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public override IDictionary<DateTime, string> PublicHolidayNames(int year)
        {
            var bHols = new Dictionary<DateTime, string> {
                { NewYear(year), "Nova godina" },
                { Epiphany(year), "Bogojavljenje ili Sveta tri kralja" } };
            DateTime easter = HolidayCalculator.GetEaster(year);
            bHols.Add(EasterMonday(easter), "Uskrsni ponedjeljak");
            bHols.Add(CorpusChristi(year), "Tijelovo");
            
            var mayday = LabourDay(year);
            if (CorpusChristi(year) == mayday) mayday = mayday.AddSeconds(1); //labour day can fall on corpus christi
            bHols.Add(mayday, "Praznik rada");
            
            var nationalDay = NationalDay(year);
            if (CorpusChristi(year) == nationalDay) nationalDay = nationalDay.AddSeconds(1); //national day can fall on corpus christi
            bHols.Add(nationalDay, "Dan državnosti");
            
            var dayOfAntiFacistStruggle = DayOfAntiFacistStruggle(year);
            if (CorpusChristi(year) == dayOfAntiFacistStruggle) dayOfAntiFacistStruggle = dayOfAntiFacistStruggle.AddSeconds(1); //day of antifacist struggle can fall on corpus christi
            bHols.Add(dayOfAntiFacistStruggle, "Dan antifašističke borbe");
            
            bHols.Add(VictoryHomelandThanksgivingDay(year), "Dan pobjede i domovinske zahvalnosti i Dan hrvatskih branitelja");
            bHols.Add(Assumption(year), "Velika Gospa");
            bHols.Add(AllSaints(year), "Svi sveti");
            bHols.Add(RemembranceDayForVictimsOfHomelandWar(year), "Dan sjećanja na žrtve Domovinskog rata i Dan sjećanja na žrtvu Vukovara i Škabrnje");
            bHols.Add(Christmas(year), "Božić");
            bHols.Add(StStephen(year), "Sveti Stjepan");
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
                    if (Epiphany(year) == date)
                        return true;
                    break;

                case 3:
                case 4:
                    if (EasterMonday(year) == date)
                        return true;
                    break;

                case 5:
                case 6:
                    if (LabourDay(year) == date)
                        return true;
                    if (NationalDay(year) == date)
                        return true; // May 1
                    if (DayOfAntiFacistStruggle(year) == date)
                        return true; // May 22
                    if (CorpusChristi(year) == date)
                        return true;
                    break;

                case 8:
                    if (Assumption(year) == date)
                        return true;
                    if (VictoryHomelandThanksgivingDay(year) == date)
                        return true; // Aug 5
                    break;

                case 11:
                    if (AllSaints(year) == date)
                        return true;
                    if (RemembranceDayForVictimsOfHomelandWar(year) == date)
                        return true; // Nov 18
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