using System;
using System.Collections.Generic;
using System.Linq;

namespace PublicHoliday
{
    public class PortugalPublicHoliday : PublicHolidayBase
    {
        #region Regions
        /// <summary>
        /// Gets or sets the regions/collectivities concerned with special public holidays
        /// </summary>
        /// <remarks>
        /// Strictly Easter Sunday is also a public holiday
        /// </remarks>
        public Regions Region { get; set; }

        /// <summary>
        /// Continental Portugal and autonomous regions (região Autónoma)
        /// </summary>
        public enum Regions
        {
            /// <summary>
            /// All regions
            /// </summary>
            OnlyOfficial = 0,

            /// <summary>
            ///  Madeira
            /// </summary>
            Madeira,

            /// <summary>
            ///  Açores
            /// </summary>
            Acores
        }

        private static readonly Dictionary<Regions, string> RegionsName = new Dictionary<Regions, string>
        {
            { Regions.Madeira, "Madeira" },
            { Regions.Acores, "Açores" },
        };

        private static string GetRegionName(Regions region)
        {
            if (RegionsName.TryGetValue(region, out string name))
            {
                return name;
            }

            return string.Empty;
        }

        #endregion

        #region Individual Holidays

        #region New Year
        /// <summary>
        /// New Year's Day - January 1 - Ano Novo
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime NewYear(int year)
        {
            return new DateTime(year, 1, 1);
        }

        private static Holiday NewYearHoliday(int year)
        {
            DateTime holiday = NewYear(year);
            return new Holiday(holiday, "New Year", "Ano Novo");
        }

        #endregion

        #region Carnival
        /// <summary>
        /// Carnival - March 4 - Carnaval
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime Carnival(int year)
        {
            DateTime easter = Easter(year);
            return Carnival(easter);
        }

        private static DateTime Carnival(DateTime easter)
        {
            return easter.AddDays(-47);
        }

        private static Holiday CarnivalHoliday(int year)
        {
            DateTime holiday = Carnival(year);
            return new Holiday(holiday, "Carnival", "Carnaval");
        }

        #endregion

        #region Good Friday

        /// <summary>
        /// Good Friday - Friday before Easter - Sexta-feira Santa
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime GoodFriday(int year)
        {
            DateTime easter = Easter(year);
            easter = easter.AddDays(-2);
            return easter;
        }

        private static DateTime GoodFriday(DateTime easter)
        {
            return easter.AddDays(-2);
        }

        private Holiday GoodFridayHoliday(DateTime easter)
        {
            DateTime holiday = GoodFriday(easter);
            return new Holiday(holiday, "Good Friday", "Sexta-feira Santa");
        }

        #endregion

        #region Easter

        /// <summary>
        /// Easter - Páscoa
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public static DateTime Easter(int year)
        {
            return HolidayCalculator.GetEaster(year);
        }

        private Holiday EasterHoliday(int year)
        {
            DateTime holiday = Easter(year);
            return new Holiday(holiday, "Easter", "Domingo de Páscoa");
        }

        #endregion

        #region Freedom day
        /// <summary>
        /// Freedom day - Avril 25 - Dia da Liberdade
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime FreedomDay(int year)
        {
            return new DateTime(year, 4, 25);
        }

        private static Holiday FreedomDayHoliday(int year)
        {
            DateTime holiday = FreedomDay(year);
            return new Holiday(holiday, "Freedom Day", "Dia da Liberdade");
        }

        #endregion

        #region Labour Day

        /// <summary>
        /// Labour Day - May 1 - Dia do Trabalhador
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public static DateTime LabourDay(int year)
        {
            return new DateTime(year, 5, 1);
        }

        private static Holiday LabourDayHoliday(int year)
        {
            DateTime holiday = LabourDay(year);
            return new Holiday(holiday, "Labour Day", "Dia do Trabalhador");
        }

        #endregion

        #region Pentecost Monday
        /// <summary>
        /// Azores Days - Pentecost Monday 7th Monday after Easter - Dia dos Açores
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime AzoresDay(int year)
        {
            var easter = Easter(year);
            return AzoresDay(easter);
        }

        private static DateTime AzoresDay(DateTime easter)
        {
            return easter.AddDays(1 + (7 * 7));
        }

        private Holiday AzoresDayHoliday(DateTime easter)
        {
            DateTime holiday = AzoresDay(easter);

            var regionsName = new List<string>();

            foreach (Regions region in RegionsWithAzoresDay)
            {
                var name = GetRegionName(region);

                if (!string.IsNullOrEmpty(name))
                {
                    regionsName.Add(name);
                }
            }

            return new Holiday(holiday, "Azores Day", "Dia dos Açores", regionsName.ToArray());
        }

        private readonly Regions[] RegionsWithAzoresDay = new[] {
            Regions.Acores
        };

        /// <summary>
        /// Whether this region observes First Octave Day
        /// </summary>
        /// <value>
        /// <c>true</c> if this region observes First Octave Day; otherwise, <c>false</c>.
        /// </value>
        public bool HasAzoresDay => Array.IndexOf(RegionsWithAzoresDay, Region) > -1;

        #endregion

        #region Corpus Christi

        /// <summary>
        /// Corpus Christi - Date varies(celebrated on the Thursday after Trinity Sunday, honoring the Eucharist) - Corpo de Deus
        /// </summary>
        /// <param name="easter">The year.</param>
        /// <returns></returns>
        public static DateTime CorpusChristi(int year)
        {
            DateTime easter = Easter(year);
            return CorpusChristi(easter);
        }

        private static DateTime CorpusChristi(DateTime easter)
        {
            // Calculate the date of Trinity Sunday (8 weeks after Easter)
            DateTime trinitySunday = easter.AddDays(56);

            // Find the Thursday after Trinity Sunday
            DateTime corpusChristiDate = trinitySunday.AddDays((int)DayOfWeek.Thursday - (int)trinitySunday.DayOfWeek);

            return corpusChristiDate;
        }

        private static Holiday CorpusChristiHoliday(DateTime easter)
        {
            DateTime holiday = CorpusChristi(easter);
            return new Holiday(holiday, "Corpus Christi", "Corpo de Deus");
        }

        #endregion

        #region Madeira Autonomy Day
        /// <summary>
        /// Madeira Autonomy Day - July 1 - Dia da Madeira
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime MadeiraAutonomyDay(int year)
        {
            return new DateTime(year, 7, 1);
        }

        private Holiday MadeiraAutonomyDayHoliday(int year)
        {
            DateTime holiday = MadeiraAutonomyDay(year);

            var regionsName = new List<string>();

            foreach (Regions region in RegionsWithMadeiraAutonomyDay)
            {
                var name = GetRegionName(region);

                if (!string.IsNullOrEmpty(name))
                {
                    regionsName.Add(name);
                }
            }

            return new Holiday(holiday, "Madeira Autonomy Day", "Dia da Madeira", regionsName.ToArray());
        }

        private readonly Regions[] RegionsWithMadeiraAutonomyDay = new[] {
            Regions.Madeira
        };

        /// <summary>
        /// Whether this region observes Madeira Autonomy Day
        /// </summary>
        /// <value>
        /// <c>true</c> if this region observes Madeira Autonomy Day; otherwise, <c>false</c>.
        /// </value>
        public bool HasMadeiraAutonomyDay => Array.IndexOf(RegionsWithMadeiraAutonomyDay, Region) > -1;

        #endregion

        #region Portugal Day

        /// <summary>
        /// Portugal Day - June 10 - Dia de Portugal, de Camões e das Comunidades Portuguesas
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public static DateTime PortugalDay(int year)
        {
            return new DateTime(year, 6, 10);
        }

        private static Holiday PortugalDayHoliday(int year)
        {
            DateTime holiday = PortugalDay(year);
            return new Holiday(holiday, "Portugal Day", "Dia de Portugal, de Camões e das Comunidades Portuguesas");
        }

        #endregion

        #region Assumption

        /// <summary>
        /// Assumption of Mary - August 15 - Assunção de Nossa Senhora
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime Assumption(int year)
        {
            return new DateTime(year, 8, 15);
        }

        private static Holiday AssumptionHoliday(int year)
        {
            DateTime holiday = Assumption(year);
            return new Holiday(holiday, "Assumption", "Assunção de Nossa Senhora");
        }

        #endregion

        #region Republic Day

        /// <summary>
        /// Republic Day - October 5 - Implantação da República
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public static DateTime  RepublicDay(int year)
        {
            return new DateTime(year, 10, 5);
        }

        private static Holiday RepublicDayHoliday(int year)
        {
            DateTime holiday = RepublicDay(year);
            return new Holiday(holiday, "Republic Day", "Implantação da República");
        }

        #endregion

        #region All Saints
        /// <summary>
        /// All Saints November 1 - Dia de Todos-os-Santos 
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime AllSaints(int year)
        {
            return new DateTime(year, 11, 1);
        }

        private static Holiday AllSaintsHoliday(int year)
        {
            DateTime holiday = AllSaints(year);
            return new Holiday(holiday, "All Saints'Day", "Dia de Todos-os-Santos");
        }

        #endregion

        #region Independence Restoration Day

        /// <summary>
        /// Independence Restoration Day - December 1 - Restauração da Independência
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public static DateTime  IndependenceRestorationDay(int year)
        {
            return new DateTime(year, 12, 1);
        }

        private static Holiday IndependenceRestorationDayHoliday(int year)
        {
            DateTime holiday = IndependenceRestorationDay(year);
            return new Holiday(holiday, "Independence Restoration Day", "Restauração da Independência");
        }

        #endregion

        #region Immaculate Conception Day

        /// <summary>
        /// Immaculate Conception Day - December 8 - Imaculada Conceição
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public static DateTime  ImmaculateConception(int year)
        {
            return new DateTime(year, 12, 8);
        }

        private static Holiday ImmaculateConceptionHoliday(int year)
        {
            DateTime holiday = ImmaculateConception(year);
            return new Holiday(holiday, "Immaculate Conception Day", "Imaculada Conceição");
        }

        #endregion

        #region Christmas
        /// <summary>
        /// Christmas December 25  - Noël
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime Christmas(int year)
        {
            return new DateTime(year, 12, 25);
        }

        private static Holiday ChristmasHoliday(int year)
        {
            DateTime holiday = Christmas(year);
            return new Holiday(holiday, "Christmas", "Natal");
        }
        #endregion

        #region First Octave Day

        /// <summary>
        /// First Octave day the 26th of december. Only in Madeira region from 2022
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime FirstOctaveDay(int year)
        {
            // from 2022 only, in Madeira only
            return new DateTime(year, 12, 26);
        }

        private Holiday FirstOctaveHoliday(int year)
        {
            DateTime holiday = FirstOctaveDay(year);

            var regionsName = new List<string>();

            foreach (Regions region in RegionsWithFirstOctaveDay)
            {
                var name = GetRegionName(region);

                if (!string.IsNullOrEmpty(name))
                {
                    regionsName.Add(name);
                }
            }

            return new Holiday(holiday, "First Octave", "Primeira Oitava", regionsName.ToArray());
        }

        private readonly Regions[] RegionsWithFirstOctaveDay = new[] {
            Regions.Madeira
        };

        /// <summary>
        /// Whether this region observes First Octave Day
        /// </summary>
        /// <value>
        /// <c>true</c> if this region observes First Octave Day; otherwise, <c>false</c>.
        /// </value>
        public bool HasFirstOctaveDay => Array.IndexOf(RegionsWithFirstOctaveDay, Region) > -1;

        #endregion

        #endregion

        /// <summary>
        /// Get a list of dates for all holidays in a year.
        /// </summary>
        /// <param name="year">The year</param>
        /// <returns>List of public holidays</returns>
        public override IList<DateTime> PublicHolidays(int year)
        {
            return PublicHolidayNames(year).Select(x => x.Key)
                .OrderBy(x => x)
                .ToList();
        }

        /// <summary>
        /// Public holiday names in Portuguese.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public override IDictionary<DateTime, string> PublicHolidayNames(int year)
        {
            // avoids having to recalculate it each time for different public holidays :
            DateTime easter = Easter(year);

            var bHols = new Dictionary<DateTime, string>
            {
                { NewYear(year), "Ano Novo" },
                { Carnival(year), "Carnaval" },
                { GoodFriday(easter), "Sexta-feira Santa" },
                { easter, "Domingo de Páscoa" }
            };
            var freedomDay = FreedomDay(year);
            if (freedomDay == easter)
            {
                //falls on Easter in 2038 
                freedomDay = freedomDay.AddSeconds(1);
            }
            bHols.Add(freedomDay, "Dia da Liberdade");
            bHols.Add(LabourDay(year), "Dia do Trabalhador");
            if (HasAzoresDay)
            {
                bHols.Add(AzoresDay(year), "Dia dos Açores");
            }
            bHols.Add(CorpusChristi(year), "Corpo de Deus");
            var portugalDay = PortugalDay(year);
            if (bHols.ContainsKey(portugalDay))
            {
                //falls on CorpusChristi in 1993, 2004
                portugalDay = portugalDay.AddSeconds(1);
            }
            bHols.Add(portugalDay, "Dia de Portugal, de Camões e das Comunidades Portuguesas");
            if (HasMadeiraAutonomyDay)
            {
                bHols.Add(MadeiraAutonomyDay(year), "Dia da Madeira");
            }
            bHols.Add(Assumption(year), "Assunção de Nossa Senhora");
            bHols.Add(RepublicDay(year), "Implantação da República");
            bHols.Add(AllSaints(year), "Dia de Todos-os-Santos");
            bHols.Add(IndependenceRestorationDay(year), "Restauração da Independência");
            bHols.Add(ImmaculateConception(year), "Imaculada Conceição");
            bHols.Add(Christmas(year), "Natal");
            if (year >= 2002 && HasFirstOctaveDay)
            {
                bHols.Add(FirstOctaveDay(year), "Primeira Oitava");
            }
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
            return PublicHolidays(dt.Year).Contains(dt.Date);
        }

        /// <summary>
        /// Gets the list of all public holidays with details of the cantons in the Holiday object, 
        /// if it's public the variable isPublic is set to true.
        /// </summary>
        /// <param name="year">The given year</param>
        /// <returns></returns>
        public IList<Holiday> PublicHolidaysComplete(int year)
        {
            // avoids having to recalculate it each time for different public holidays :
            var easterHoliday = EasterHoliday(year);
            var easter = easterHoliday.HolidayDate;

            var bHols = new List<Holiday>
            {
                NewYearHoliday(year),
                CarnivalHoliday(year),
                GoodFridayHoliday(easter),
                easterHoliday,
                FreedomDayHoliday(year),
                LabourDayHoliday(year),
                AzoresDayHoliday(easter),
                CorpusChristiHoliday(easter),
                MadeiraAutonomyDayHoliday(year),
                PortugalDayHoliday(year),
                AssumptionHoliday(year),
                RepublicDayHoliday(year),
                AllSaintsHoliday(year),
                IndependenceRestorationDayHoliday(year),
                ImmaculateConceptionHoliday(year),
                ChristmasHoliday(year),
                FirstOctaveHoliday(year),
            };

            return bHols.OrderBy(d => d.Day).ToList();
        }
    }
}