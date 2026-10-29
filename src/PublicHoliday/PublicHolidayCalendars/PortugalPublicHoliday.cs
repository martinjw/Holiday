using System;
using System.Collections.Generic;
using PublicHoliday.HolidayDefinitions;
using PublicHoliday.HolidayDefinitions.Christian;
using Christian = PublicHoliday.HolidayDefinitions.Christian;
using Common = PublicHoliday.HolidayDefinitions.Common;
using Local = PublicHoliday.HolidayDefinitions.CountrySpecific.Portugal;
using PublicHoliday.HolidayDefinitions.Base;
using System.Globalization;
using PublicHoliday.Localization;

namespace PublicHoliday
{
    /// <summary>
    /// Portugal public holidays. Set <see cref="Region"/> for autonomous regions.
    /// </summary>
    public class PortugalPublicHoliday : PublicHolidayBase
    {

        /// <summary>
        /// Culture whose language this calendar's holiday names are in: European Portuguese.
        /// Used by <see cref="Holiday.GetName(CultureInfo)"/> when the requested
        /// culture has no translation.
        /// </summary>
        protected override CultureInfo CountryCulture => _defaultCulture;

        private static readonly CultureInfo _defaultCulture = SafeCulture.Get("pt-PT", "pt");
        #region Regions
        /// <summary>
        /// Gets or sets the regions/collectivities concerned with special public holidays
        /// </summary>
        /// <remarks>
        /// Strictly Easter Sunday is also a public holiday
        /// </remarks>
        public Regions Region
        {
            get { return _region; }
            set { _region = value; ClearHolidayCache(); }
        }
        private Regions _region;

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
                return name;

            return string.Empty;
        }

        #endregion

        #region Individual Holidays

        #region New Year
        /// <summary>
        /// New Year's Day - January 1 - Ano Novo
        /// </summary>
        public static DateTime NewYear(int year)
        {
            return new DateTime(year, 1, 1);
        }


        #endregion

        #region Carnival
        /// <summary>
        /// Carnival - March 4 - Carnaval
        /// </summary>
        public static DateTime Carnival(int year)
        {
            DateTime easter = Easter(year);
            return Carnival(easter);
        }

        private static DateTime Carnival(DateTime easter)
        {
            return easter.AddDays(-47);
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
            return EasterCalculator.GoodFriday(Easter(year));
        }



        #endregion

        #region Easter

        /// <summary>
        /// Easter - Páscoa
        /// </summary>
        /// <param name="year">The year.</param>
        public static DateTime Easter(int year)
        {
            return EasterCalculator.GetEaster(year);
        }


        #endregion

        #region Freedom day
        /// <summary>
        /// Freedom day - Avril 25 - Dia da Liberdade
        /// </summary>
        public static DateTime FreedomDay(int year)
        {
            return new DateTime(year, 4, 25);
        }


        #endregion

        #region Labour Day

        /// <summary>
        /// Labour Day - May 1 - Dia do Trabalhador
        /// </summary>
        /// <param name="year">The year.</param>
        public static DateTime LabourDay(int year)
        {
            return new DateTime(year, 5, 1);
        }


        #endregion

        #region Pentecost Monday
        /// <summary>
        /// Azores Days - Pentecost Monday 7th Monday after Easter - Dia dos Açores
        /// </summary>
        public static DateTime AzoresDay(int year)
        {
            var easter = Easter(year);
            return AzoresDay(easter);
        }

        private static DateTime AzoresDay(DateTime easter)
        {
            return EasterCalculator.WhitMonday(easter);
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
        public static DateTime CorpusChristi(int year)
        {
            DateTime easter = Easter(year);
            return CorpusChristi(easter);
        }

        private static DateTime CorpusChristi(DateTime easter)
        {
            return EasterCalculator.CorpusChristi(easter);
        }


        #endregion

        #region Madeira Autonomy Day
        /// <summary>
        /// Madeira Autonomy Day - July 1 - Dia da Madeira
        /// </summary>
        public static DateTime MadeiraAutonomyDay(int year)
        {
            return new DateTime(year, 7, 1);
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
        public static DateTime PortugalDay(int year)
        {
            return new DateTime(year, 6, 10);
        }


        #endregion

        #region Assumption

        /// <summary>
        /// Assumption of Mary - August 15 - Assunção de Nossa Senhora
        /// </summary>
        public static DateTime Assumption(int year)
        {
            return new DateTime(year, 8, 15);
        }


        #endregion

        #region Republic Day

        /// <summary>
        /// Republic Day - October 5 - Implantação da República
        /// </summary>
        /// <param name="year">The year.</param>
        public static DateTime RepublicDay(int year)
        {
            return new DateTime(year, 10, 5);
        }


        #endregion

        #region All Saints
        /// <summary>
        /// All Saints November 1 - Dia de Todos-os-Santos 
        /// </summary>
        public static DateTime AllSaints(int year)
        {
            return new DateTime(year, 11, 1);
        }


        #endregion

        #region Independence Restoration Day

        /// <summary>
        /// Independence Restoration Day - December 1 - Restauração da Independência
        /// </summary>
        /// <param name="year">The year.</param>
        public static DateTime IndependenceRestorationDay(int year)
        {
            return new DateTime(year, 12, 1);
        }


        #endregion

        #region Immaculate Conception Day

        /// <summary>
        /// Immaculate Conception Day - December 8 - Imaculada Conceição
        /// </summary>
        /// <param name="year">The year.</param>
        public static DateTime ImmaculateConception(int year)
        {
            return new DateTime(year, 12, 8);
        }


        #endregion

        #region Christmas
        /// <summary>
        /// Christmas December 25  - Noël
        /// </summary>
        public static DateTime Christmas(int year)
        {
            return new DateTime(year, 12, 25);
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

        //Freedom Day can fall on Easter (2038); Portugal Day on Corpus Christi (1993, 2004);
        //same-day holidays stay distinct entries (names aggregated by the base class)
        private static readonly HolidayDefinition[] Definitions =
        {
            new Common.NewYear(),
            new Local.Carnival(),
            new Christian.GoodFriday(),
            new Christian.EasterSunday(),
            new Local.FreedomDay(),
            new Common.LabourDay(),
            new Local.AzoresDay(),
            new Christian.CorpusChristi(),
            new Local.PortugalDay(),
            new Local.MadeiraAutonomyDay(),
            new Christian.Assumption(),
            new Local.RepublicDay(),
            new Christian.AllSaints(),
            new Local.IndependenceRestorationDay(),
            new Christian.ImmaculateConception(),
            new Christian.Christmas(),
            new Local.FirstOctaveDay(),
        };

        /// <summary>
        /// The full holiday set for the year. With <see cref="Region"/> set, the selected
        /// region's holidays are included as public; otherwise the region-only holidays are
        /// flagged via <see cref="Holiday.IsPublic"/> / <see cref="Holiday.Regions"/>.
        /// </summary>
        /// <param name="year">The given year</param>
        protected override IList<Holiday> PublicHolidaysComplete(int year)
        {
            var regionName = GetRegionName(Region);
            var list = new List<Holiday>();
            foreach (var definition in Definitions)
            {
                list.AddRange(regionName.Length == 0 ? definition.Build(year) : definition.Build(year, regionName));
            }
            return list;
        }
    }
}