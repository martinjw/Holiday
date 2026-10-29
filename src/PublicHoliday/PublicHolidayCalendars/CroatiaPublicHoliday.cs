using System;
using System.Collections.Generic;
using PublicHoliday.HolidayDefinitions;
using PublicHoliday.HolidayDefinitions.Christian;
using Christian = PublicHoliday.HolidayDefinitions.Christian;
using Common = PublicHoliday.HolidayDefinitions.Common;
using Local = PublicHoliday.HolidayDefinitions.CountrySpecific.Croatia;
using PublicHoliday.HolidayDefinitions.Base;
using System.Globalization;
using PublicHoliday.Localization;

namespace PublicHoliday
{
    /// <summary>
    /// Holidays in Croatia
    /// </summary>
    public class CroatiaPublicHoliday : PublicHolidayBase
    {

        /// <summary>
        /// Culture whose language this calendar's holiday names are in: Croatian.
        /// Used by <see cref="Holiday.GetName(CultureInfo)"/> when the requested
        /// culture has no translation.
        /// </summary>
        protected override CultureInfo CountryCulture => _defaultCulture;

        private static readonly CultureInfo _defaultCulture = SafeCulture.Get("hr-HR", "hr");
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
            return EasterCalculator.EasterMonday(EasterCalculator.GetEaster(year));
        }

        /// <summary>
        /// Tijelovo
        /// </summary>

        public static DateTime CorpusChristi(int year)
        {
            return EasterCalculator.CorpusChristi(EasterCalculator.GetEaster(year));
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
        public static DateTime NationalDay(int year)
        {
            return new DateTime(year, 05, 30);
        }

        /// <summary>
        /// Dan antifašističke borbe (Day of Anti-Fascist Struggle)
        /// </summary>

        public static DateTime DayOfAntiFacistStruggle(int year)
        {
            return new DateTime(year, 06, 22);
        }
        
        /// <summary>
        /// Dan pobjede i domovinske zahvalnosti i Dan hrvatskih branitelja (Victory and Homeland Thanksgiving Day and the Day of Croatian Defenders)
        /// </summary>

        public static DateTime VictoryHomelandThanksgivingDay(int year)
        {
            return new DateTime(year, 08,05);
        }

        /// <summary>
        /// Velika Gospa
        /// </summary>
        public static DateTime Assumption(int year)
        {
            return new DateTime(year, 8, 15);
        }


        /// <summary>
        /// Svi sveti
        /// </summary>

        public static DateTime AllSaints(int year)
        {
            return new DateTime(year, 11, 1);
        }
        
        /// <summary>
        /// Dan sjećanja na žrtve Domovinskog rata i Dan sjećanja na žrtvu Vukovara i Škabrnje
        ///  (Remembrance Day for the Victims of the Homeland War and Remembrance Day for the Victims of Vukovar and Škabrnja)
        /// </summary>

        public static DateTime RemembranceDayForVictimsOfHomelandWar(int year)
        {
            return new DateTime(year, 11, 18);
        }

        /// <summary>
        /// Božić
        /// </summary>
        public static DateTime Christmas(int year)
        {
            return new DateTime(year, 12, 25);
        }

        /// <summary>
        /// Sveti Stjepan
        /// </summary>
        public static DateTime StStephen(int year)
        {
            return new DateTime(year, 12, 26);
        }

        #endregion Individual Holidays

        /// <summary>
        /// Get a list of dates for all holidays in a year.
        /// </summary>
        //Corpus Christi can fall on Labour Day, National Day or Anti-Fascist Struggle Day;
        //same-day holidays stay distinct entries (names aggregated by the base class)
        private static readonly HolidayDefinition[] Definitions =
        {
            new Common.NewYear(),
            new Christian.Epiphany(),
            new Christian.EasterMonday(),
            new Christian.CorpusChristi(),
            new Common.LabourDay(),
            new Local.NationalDay(),
            new Local.AntiFascistStruggleDay(),
            new Local.VictoryDay(),
            new Christian.Assumption(),
            new Christian.AllSaints(),
            new Local.RemembranceDay(),
            new Christian.Christmas(),
            new Christian.SaintStephensDay(),
        };

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
