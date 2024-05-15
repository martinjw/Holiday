using System;
using System.Collections.Generic;
using System.Linq;

namespace PublicHoliday
{
    /// <summary>
    /// Finds France public holidays. 
    /// Public holidays on Sundays are not deferred to following weekday automatically- 
    /// they may be taken at an arbitary date.
    /// https://fr.wikipedia.org/wiki/F%C3%AAtes_et_jours_f%C3%A9ri%C3%A9s_en_France#Tableau_r%C3%A9capitulatif
    /// </summary>
    public class FrancePublicHoliday : PublicHolidayBase
    {
       #region Regions
        /// <summary>
        /// Gets or sets the regions concerned with special public holidays
        /// </summary>
        public Regions Region { get; set; }

        public enum Regions
        {
            /// <summary>
            /// All regions
            /// </summary>
            OnlyOfficial = 0,

            /// <summary>
            ///  Alsace et Moselle
            /// </summary>
            AlsaceMoselle,

            /// <summary>
            ///  Guadeloupe
            /// </summary>
            Guadeloupe,

            /// <summary>
            ///  Guyane
            /// </summary>
            Guyane,

            /// <summary>
            ///  La Réunion
            /// </summary>
            Reunion,

            /// <summary>
            ///  Martinique
            /// </summary>
            Martinique,

            /// <summary>
            ///  Mayotte
            /// </summary>
            Mayotte,

            /// <summary>
            ///  Nouvelle-Calédonie
            /// </summary>
            NouvelleCaledonie,

            /// <summary>
            ///  Polynésie française
            /// </summary>
            PolynesieFrancaise,

            /// <summary>
            ///  Saint-Barthélemy
            /// </summary>
            SaintBarthelemy,

            /// <summary>
            ///  Saint-Martin
            /// </summary>
            SaintMartin,

            /// <summary>
            ///  Wallis-et-Futuna
            /// </summary>
            WallisEtFutuna,

            /// <summary>
            ///  All Regions
            /// </summary>
            ALL = 99,
        }

        private static readonly Dictionary<Regions, string> RegionsName = new Dictionary<Regions, string>
        {
            { Regions.AlsaceMoselle, "Alsace et Moselle" },
            { Regions.Guadeloupe, "Guadeloupe" },
            { Regions.Guyane, "Guyane" },
            { Regions.Reunion, "La Réunion" },
            { Regions.Martinique, "Martinique" },
            { Regions.Mayotte, "Mayotte" },
            { Regions.NouvelleCaledonie, "Nouvelle-Calédonie" },
            { Regions.PolynesieFrancaise, "Polynésie française" },
            { Regions.SaintBarthelemy, "Saint-Barthélemy" },
            { Regions.SaintMartin, "Saint-Martin" },
            { Regions.WallisEtFutuna, "Wallis-et-Futuna" },
        };

        private static string GetRegionName(Regions region)
        {
            if (RegionsName.TryGetValue(region, out string name))
            {
                return name;
            }
            else
            {
                return string.Empty;
            }
        }

        #endregion


        #region Individual Holidays

        #region New Year
        /// <summary>
        /// New Year's Day January 1 Nouvel An 
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
            return new Holiday(holiday, "New Year", "Nouvel An");
        }

        #endregion

        #region Good Friday

        /// <summary>
        /// Good Friday - Friday before Easter
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime GoodFriday(int year)
        {
            DateTime hol = HolidayCalculator.GetEaster(year);
            hol = hol.AddDays(-2);
            return hol;
        }

        private static DateTime GoodFriday(DateTime easter)
        {
            return easter.AddDays(-2);
        }

        private Holiday GoodFridayHoliday(DateTime easter)
        {
            DateTime holiday = GoodFriday(easter);

            var regionsName = new List<string>();

            foreach (Regions region in RegionsWithGoodFriday)
            {
                var name = GetRegionName(region);

                if (!string.IsNullOrEmpty(name))
                {
                    regionsName.Add(name);
                }
            }

            return new Holiday(holiday, "Good Friday", "Vendredi saint", regionsName.ToArray());
        }

        private readonly Regions[] RegionsWithGoodFriday = new[] {
            Regions.ALL,
            Regions.AlsaceMoselle,
            Regions.Guadeloupe,
            Regions.Martinique,
            Regions.PolynesieFrancaise,
        };

        /// <summary>
        /// Whether this regions observes GoodFriday
        /// </summary>
        /// <value>
        /// <c>true</c> if this region observes GoodFriday; otherwise, <c>false</c>.
        /// </value>
        public bool HasGoodFriday => Array.IndexOf(RegionsWithGoodFriday, Region) > -1;

        #endregion

        #region Easter Monday

        /// <summary>
        /// Easter Monday 1st Monday after Easter - Lundi de Pâques
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

        private static Holiday EasterMondayHoliday(DateTime easter)
        {
            DateTime holiday = EasterMonday(easter);
            return new Holiday(holiday, "Easter Monday", "Lundi de Pâques");
        }

        #endregion

        #region Abolition of slavery in Mayotte

        /// <summary>
        /// Abolition of slavery in Mayotte the 27th of April
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime MayotteAbolitionSlavery(int year)
        {
            return new DateTime(year, 4, 27);
        }

        private Holiday MayotteAbolitionSlaveryHoliday(int year)
        {
            DateTime holiday = MayotteAbolitionSlavery(year);

            var regionsName = new List<string>();

            foreach (Regions region in RegionsWithMayotteAbolitionSlavery)
            {
                var name = GetRegionName(region);

                if (!string.IsNullOrEmpty(name))
                {
                    regionsName.Add(name);
                }
            }

            return new Holiday(holiday, "Abolition of slavery", "Abolition de l'esclavage", regionsName.ToArray());
        }

        private readonly Regions[] RegionsWithMayotteAbolitionSlavery = new[] {
            Regions.ALL,
            Regions.Mayotte,
        };

        /// <summary>
        /// Whether this regions observes Abolition of slavery in Mayotte
        /// </summary>
        /// <value>
        /// <c>true</c> if this region observes Abolition of slavery in Mayotte; otherwise, <c>false</c>.
        /// </value>
        public bool HasMayotteAbolitionSlavery => Array.IndexOf(RegionsWithMayotteAbolitionSlavery, Region) > -1;

        #endregion

        #region Peter Chanel Day

        /// <summary>
        /// Peter Chanel Day the 28th of April
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime PeterChanel(int year)
        {
            return new DateTime(year, 4, 28);
        }

        private Holiday PeterChanelHoliday(int year)
        {
            DateTime holiday = PeterChanel(year);

            var regionsName = new List<string>();

            foreach (Regions region in RegionsWithPeterChanel)
            {
                var name = GetRegionName(region);

                if (!string.IsNullOrEmpty(name))
                {
                    regionsName.Add(name);
                }
            }

            return new Holiday(holiday, "Peter Chanel day", "Saint-Pierre Chanel", regionsName.ToArray());
        }

        private readonly Regions[] RegionsWithPeterChanel = new[] {
            Regions.ALL,
            Regions.WallisEtFutuna,
        };

        /// <summary>
        /// Whether this regions observes Abolition of slavery in Mayotte
        /// </summary>
        /// <value>
        /// <c>true</c> if this region observes Abolition of slavery in Mayotte; otherwise, <c>false</c>.
        /// </value>
        public bool HasPeterChanel => Array.IndexOf(RegionsWithPeterChanel, Region) > -1;

        #endregion

        #region Labour Day

        //Labor Day May 1 - Fête du Travail
        /// <summary>
        /// Mays the day.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public static DateTime MayDay(int year)
        {
            return new DateTime(year, 5, 1);
        }

        private static Holiday LabourDayHoliday(int year)
        {
            DateTime holiday = MayDay(year);
            return new Holiday(holiday, "Labour day", "Fête du Travail");
        }

        #endregion

        #region Victory in Europe Day
        /// <summary>
        /// Victory in Europe Day, 8 May - Fête de la Victoire
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public static DateTime VictoryInEuropeDay(int year)
        {
            return new DateTime(year, 5, 8);
        }

        private static Holiday VictoryInEuropeDayHoliday(int year)
        {
            DateTime holiday = VictoryInEuropeDay(year);
            return new Holiday(holiday, "Victory Day", "Fête de la Victoire");
        }

        #endregion

        #region Abolition of slavery in Martinique

        /// <summary>
        /// Abolition of slavery in Martinique the 22th of May
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime MartiniqueAbolitionSlavery(int year)
        {
            return new DateTime(year, 5, 22);
        }

        private Holiday MartiniqueAbolitionSlaveryHoliday(int year)
        {
            DateTime holiday = MartiniqueAbolitionSlavery(year);

            var regionsName = new List<string>();

            foreach (Regions region in RegionsWithMartiniqueAbolitionSlavery)
            {
                var name = GetRegionName(region);

                if (!string.IsNullOrEmpty(name))
                {
                    regionsName.Add(name);
                }
            }

            return new Holiday(holiday, "Abolition of slavery", "Abolition de l'esclavage", regionsName.ToArray());
        }

        private readonly Regions[] RegionsWithMartiniqueAbolitionSlavery = new[] {
            Regions.ALL,
            Regions.Martinique,
        };

        /// <summary>
        /// Whether this regions observes Abolition of slavery in Martinique
        /// </summary>
        /// <value>
        /// <c>true</c> if this region observes Abolition of slavery in Martinique; otherwise, <c>false</c>.
        /// </value>
        public bool HasMartiniqueAbolitionSlavery => Array.IndexOf(RegionsWithMartiniqueAbolitionSlavery, Region) > -1;

        #endregion

        #region Abolition of slavery in Guadeloupe

        /// <summary>
        /// Abolition of slavery in Guadeloupe the 27th of May
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime GuadeloupeAbolitionSlavery(int year)
        {
            return new DateTime(year, 5, 27);
        }

        private Holiday GuadeloupeAbolitionSlaveryHoliday(int year)
        {
            DateTime holiday = GuadeloupeAbolitionSlavery(year);

            var regionsName = new List<string>();

            foreach (Regions region in RegionsWithGuadeloupeAbolitionSlavery)
            {
                var name = GetRegionName(region);

                if (!string.IsNullOrEmpty(name))
                {
                    regionsName.Add(name);
                }
            }

            return new Holiday(holiday, "Abolition of slavery", "Abolition de l'esclavage", regionsName.ToArray());
        }

        private readonly Regions[] RegionsWithGuadeloupeAbolitionSlavery = new[] {
            Regions.ALL,
            Regions.Guadeloupe,
        };

        /// <summary>
        /// Whether this regions observes Abolition of slavery in Guadeloupe
        /// </summary>
        /// <value>
        /// <c>true</c> if this region observes Abolition of slavery in Guadeloupe; otherwise, <c>false</c>.
        /// </value>
        public bool HasGuadeloupeAbolitionSlavery => Array.IndexOf(RegionsWithGuadeloupeAbolitionSlavery, Region) > -1;

        #endregion

        #region Abolition of slavery in Saint-Martin

        /// <summary>
        /// Abolition of slavery in Saint-Martin the 28th of May
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime SaintMartinAbolitionSlavery(int year)
        {
            return new DateTime(year, 5, 28);
        }

        private Holiday SaintMartinAbolitionSlaveryHoliday(int year)
        {
            DateTime holiday = SaintMartinAbolitionSlavery(year);

            var regionsName = new List<string>();

            foreach (Regions region in RegionsWithSaintMartinAbolitionSlavery)
            {
                var name = GetRegionName(region);

                if (!string.IsNullOrEmpty(name))
                {
                    regionsName.Add(name);
                }
            }

            return new Holiday(holiday, "Abolition of slavery", "Abolition de l'esclavage", regionsName.ToArray());
        }

        private readonly Regions[] RegionsWithSaintMartinAbolitionSlavery = new[] {
            Regions.ALL,
            Regions.SaintMartin,
        };

        /// <summary>
        /// Whether this regions observes Abolition of slavery in Saint-Martin
        /// </summary>
        /// <value>
        /// <c>true</c> if this region observes Abolition of slavery in Saint-Martin; otherwise, <c>false</c>.
        /// </value>
        public bool HasSaintMartinAbolitionSlavery => Array.IndexOf(RegionsWithSaintMartinAbolitionSlavery, Region) > -1;

        #endregion

        #region Ascension
        /// <summary>
        /// Ascension 6th Thursday after Easter- Ascension
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime Ascension(int year)
        {
            var hol = HolidayCalculator.GetEaster(year);
            hol = hol.AddDays(4 + (7 * 5)).AddSeconds(1);;
            return hol;
        }
        private static DateTime Ascension(DateTime easter)
        {
            return easter.AddDays(4 + (7 * 5)).AddSeconds(1); ;
        }

        private static Holiday AscensionHoliday(DateTime easter)
        {
            DateTime holiday = Ascension(easter);
            return new Holiday(holiday, "Ascension Day", "Jeudi de l'Ascension");
        }

        #endregion

        #region Pentecost Monday
        /// <summary>
        /// Whit Monday - Pentecost Monday 7th Monday after Easter - Lundi de Pentecôte
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
        private static Holiday PentecostMondayHoliday(DateTime easter)
        {
            DateTime holiday = PentecostMonday(easter);
            return new Holiday(holiday, "Pentecost Monday", "Lundi de Pentecôte");
        }

        #endregion

        #region Abolition of slavery in Guyane

        /// <summary>
        /// Abolition of slavery in Guyane the 10th of June
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime GuyaneAbolitionSlavery(int year)
        {
            return new DateTime(year, 6, 10);
        }

        private Holiday GuyaneAbolitionSlaveryHoliday(int year)
        {
            DateTime holiday = GuyaneAbolitionSlavery(year);

            var regionsName = new List<string>();

            foreach (Regions region in RegionsWithGuyaneAbolitionSlavery)
            {
                var name = GetRegionName(region);

                if (!string.IsNullOrEmpty(name))
                {
                    regionsName.Add(name);
                }
            }

            return new Holiday(holiday, "Abolition of slavery", "Abolition de l'esclavage", regionsName.ToArray());
        }

        private readonly Regions[] RegionsWithGuyaneAbolitionSlavery = new[] {
            Regions.ALL,
            Regions.Guyane,
        };

        /// <summary>
        /// Whether this regions observes Abolition of slavery in Guyane
        /// </summary>
        /// <value>
        /// <c>true</c> if this region observes Abolition of slavery in Guyane; otherwise, <c>false</c>.
        /// </value>
        public bool HasGuyaneAbolitionSlavery => Array.IndexOf(RegionsWithGuyaneAbolitionSlavery, Region) > -1;

        #endregion

        #region Autonomy Day

        /// <summary>
        /// Autonomy Day In French Polynesia the 29th of June
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime AutonomyDay(int year)
        {
            return new DateTime(year, 6, 29);
        }

        private Holiday AutonomyDayHoliday(int year)
        {
            DateTime holiday = AutonomyDay(year);

            var regionsName = new List<string>();

            foreach (Regions region in RegionsWithAutonomyDay)
            {
                var name = GetRegionName(region);

                if (!string.IsNullOrEmpty(name))
                {
                    regionsName.Add(name);
                }
            }

            return new Holiday(holiday, "Autonomy Day", "Fête de l'autonomie", regionsName.ToArray());
        }

        private readonly Regions[] RegionsWithAutonomyDay = new[] {
            Regions.ALL,
            Regions.PolynesieFrancaise,
        };

        /// <summary>
        /// Whether this regions observes Autonomy Day
        /// </summary>
        /// <value>
        /// <c>true</c> if this region observes Autonomy Day; otherwise, <c>false</c>.
        /// </value>
        public bool HasAutonomyDay => Array.IndexOf(RegionsWithAutonomyDay, Region) > -1;

        #endregion

        #region Bastille Day
        /// <summary>
        /// Fête nationale française, 14 July
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime National(int year)
        {
            return new DateTime(year, 7, 14);
        }

        private static Holiday BastilleDayHoliday(int year)
        {
            DateTime holiday = National(year);
            return new Holiday(holiday, "Bastille Day", "Fête nationale");
        }

        #endregion

        #region Victor Schoelcher's Feast

        /// <summary>
        /// Victor Schoelcher's Feast the 21th of July
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime VictorSchoelcherDay(int year)
        {
            return new DateTime(year, 7, 21);
        }

        private Holiday VictorSchoelcherDayHoliday(int year)
        {
            DateTime holiday = VictorSchoelcherDay(year);

            var regionsName = new List<string>();

            foreach (Regions region in RegionsWithVictorSchoelcherDay)
            {
                var name = GetRegionName(region);

                if (!string.IsNullOrEmpty(name))
                {
                    regionsName.Add(name);
                }
            }

            return new Holiday(holiday, "Victor Schoelcher's Feast", "Fête de Victor Schœlcher", regionsName.ToArray());
        }

        private readonly Regions[] RegionsWithVictorSchoelcherDay = new[] {
            Regions.ALL,
            Regions.Guadeloupe,
            Regions.Martinique,
        };

        /// <summary>
        /// Whether this regions observes Victor Schoelcher's Feast
        /// </summary>
        /// <value>
        /// <c>true</c> if this region observes Victor Schoelcher's Feast; otherwise, <c>false</c>.
        /// </value>
        public bool HasVictorSchoelcherDay => Array.IndexOf(RegionsWithVictorSchoelcherDay, Region) > -1;

        #endregion

        #region Territory Festival

        /// <summary>
        /// Territory Festival the 29th of July
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime TerritoryFestivalDay(int year)
        {
            return new DateTime(year, 7, 29);
        }

        private Holiday TerritoryFestivalDayHoliday(int year)
        {
            DateTime holiday = TerritoryFestivalDay(year);

            var regionsName = new List<string>();

            foreach (Regions region in RegionsWithTerritoryFestivalDay)
            {
                var name = GetRegionName(region);

                if (!string.IsNullOrEmpty(name))
                {
                    regionsName.Add(name);
                }
            }

            return new Holiday(holiday, "Territory Festival", "Fête du territoire", regionsName.ToArray());
        }

        private readonly Regions[] RegionsWithTerritoryFestivalDay = new[] {
            Regions.ALL,
            Regions.WallisEtFutuna,
        };

        /// <summary>
        /// Whether this regions observes Territory Festival
        /// </summary>
        /// <value>
        /// <c>true</c> if this region observes Territory Festival; otherwise, <c>false</c>.
        /// </value>
        public bool HasTerritoryFestivalDay => Array.IndexOf(RegionsWithTerritoryFestivalDay, Region) > -1;

        #endregion

        #region Assumption

        /// <summary>
        /// Assumption of Mary August 15 - Assomption
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
            return new Holiday(holiday, "Assumption", "Assomption");
        }

        #endregion

        #region Citizenship Day

        /// <summary>
        /// Citizenship Day the 24th of September
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime CitizenshipDay(int year)
        {
            return new DateTime(year, 9, 24);
        }

        private Holiday CitizenshipDayHoliday(int year)
        {
            DateTime holiday = CitizenshipDay(year);

            var regionsName = new List<string>();

            foreach (Regions region in RegionsWithCitizenshipDay)
            {
                var name = GetRegionName(region);

                if (!string.IsNullOrEmpty(name))
                {
                    regionsName.Add(name);
                }
            }

            return new Holiday(holiday, "Citizenship Day", "Fête de la citoyenneté", regionsName.ToArray());
        }

        private readonly Regions[] RegionsWithCitizenshipDay = new[] {
            Regions.ALL,
            Regions.NouvelleCaledonie,
        };

        /// <summary>
        /// Whether this regions observes Citizenship Day
        /// </summary>
        /// <value>
        /// <c>true</c> if this region observes Citizenship Day; otherwise, <c>false</c>.
        /// </value>
        public bool HasCitizenshipDay => Array.IndexOf(RegionsWithCitizenshipDay, Region) > -1;

        #endregion

        #region Abolition of slavery in Saint-Barthélemy

        /// <summary>
        /// Abolition of slavery in Saint-Barthélemy the 9th of october
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime SaintBarthelemyAbolitionSlavery(int year)
        {
            return new DateTime(year, 10, 9);
        }

        private Holiday SaintBarthelemyAbolitionSlaveryHoliday(int year)
        {
            DateTime holiday = SaintBarthelemyAbolitionSlavery(year);

            var regionsName = new List<string>();

            foreach (Regions region in RegionsWithSaintBarthelemyAbolitionSlavery)
            {
                var name = GetRegionName(region);

                if (!string.IsNullOrEmpty(name))
                {
                    regionsName.Add(name);
                }
            }

            return new Holiday(holiday, "Abolition of slavery", "Abolition de l'esclavage", regionsName.ToArray());
        }

        private readonly Regions[] RegionsWithSaintBarthelemyAbolitionSlavery = new[] {
            Regions.ALL,
            Regions.SaintBarthelemy,
        };

        /// <summary>
        /// Whether this regions observes Abolition of slavery in Saint-Barthélemy
        /// </summary>
        /// <value>
        /// <c>true</c> if this region observes Abolition of slavery in Saint-Barthélemy; otherwise, <c>false</c>.
        /// </value>
        public bool HasSaintBarthelemyAbolitionSlavery => Array.IndexOf(RegionsWithSaintBarthelemyAbolitionSlavery, Region) > -1;

        #endregion

        #region All Saints
        /// <summary>
        /// All Saints November 1 - Toussaint 
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
            return new Holiday(holiday, "All Saints'Day", "Toussaint");
        }

        #endregion

        #region Armistice
        /// <summary>
        /// Armistice Day November 11- Jour de l'armistice
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime Armistice(int year)
        {
            return new DateTime(year, 11, 11);
        }

        private static Holiday ArmisticeHoliday(int year)
        {
            DateTime holiday = Armistice(year);
            return new Holiday(holiday, "Armistice", "Armistice");
        }

        #endregion

        #region Abolition of slavery in La Réunion

        /// <summary>
        /// Abolition of slavery in La Réunion the 20th of december
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime LaReunionAbolitionSlavery(int year)
        {
            return new DateTime(year, 12, 20);
        }

        private Holiday LaReunionAbolitionSlaveryHoliday(int year)
        {
            DateTime holiday = LaReunionAbolitionSlavery(year);

            var regionsName = new List<string>();

            foreach (Regions region in RegionsWithLaReunionAbolitionSlavery)
            {
                var name = GetRegionName(region);

                if (!string.IsNullOrEmpty(name))
                {
                    regionsName.Add(name);
                }
            }

            return new Holiday(holiday, "Abolition of slavery", "Abolition de l'esclavage", regionsName.ToArray());
        }

        private readonly Regions[] RegionsWithLaReunionAbolitionSlavery = new[] {
            Regions.ALL,
            Regions.Reunion,
        };

        /// <summary>
        /// Whether this regions observes Abolition of slavery in La Réunion
        /// </summary>
        /// <value>
        /// <c>true</c> if this region observes Abolition of slavery in La Réunion; otherwise, <c>false</c>.
        /// </value>
        public bool HasLaReunionAbolitionSlavery => Array.IndexOf(RegionsWithLaReunionAbolitionSlavery, Region) > -1;

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
            return new Holiday(holiday, "Christmas", "Noël");
        }
        #endregion

        #region Saint Stephen's Day

        /// <summary>
        /// Saint Stephen's Day the 26th of december
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime SaintStephenDay(int year)
        {
            return new DateTime(year, 12, 26);
        }

        private Holiday SaintStephenDayHoliday(int year)
        {
            DateTime holiday = SaintStephenDay(year);

            var regionsName = new List<string>();

            foreach (Regions region in RegionsWithSaintStephenDay)
            {
                var name = GetRegionName(region);

                if (!string.IsNullOrEmpty(name))
                {
                    regionsName.Add(name);
                }
            }

            return new Holiday(holiday, "Saint Stephen's Day", "Saint-Étienne", regionsName.ToArray());
        }

        private readonly Regions[] RegionsWithSaintStephenDay = new[] {
            Regions.ALL,
            Regions.AlsaceMoselle,
        };

        /// <summary>
        /// Whether this regions observes Saint Stephen's Day
        /// </summary>
        /// <value>
        /// <c>true</c> if this region observes Saint Stephen's Day; otherwise, <c>false</c>.
        /// </value>
        public bool HasSaintStephenDay => Array.IndexOf(RegionsWithSaintStephenDay, Region) > -1;

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
        /// Public holiday names in French.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public override IDictionary<DateTime, string> PublicHolidayNames(int year)
        {
            // avoids having to recalculate it each time for different public holidays :
            DateTime easter = HolidayCalculator.GetEaster(year);

            var bHols = new Dictionary<DateTime, string>();

            bHols.Add(NewYear(year), "Nouvel An");

            if (HasGoodFriday)
                bHols.Add(GoodFriday(easter), "Vendredi saint");

            bHols.Add(EasterMonday(easter), "Lundi de Pâques");

            if (HasMayotteAbolitionSlavery)
                bHols.Add(MayotteAbolitionSlavery(year), "Abolition de l'esclavage à Mayotte");

            if (HasPeterChanel)
                bHols.Add(PeterChanel(year), "Saint-Pierre Chanel");

            bHols.Add(MayDay(year), "Fête du Travail");

            bHols.Add(VictoryInEuropeDay(year), "Fête de la Victoire");

            if (HasMartiniqueAbolitionSlavery)
                bHols.Add(MartiniqueAbolitionSlavery(year), "Abolition de l'esclavage en Martinique");

            if (HasGuadeloupeAbolitionSlavery)  
                bHols.Add(GuadeloupeAbolitionSlavery(year), "Abolition de l'esclavage en Guadeloupe");

            if (HasSaintMartinAbolitionSlavery)
                bHols.Add(SaintMartinAbolitionSlavery(year), "Abolition de l'esclavage à Saint-Martin");

            bHols.Add(Ascension(easter), "Jeudi de l'Ascension");

            bHols.Add(PentecostMonday(easter), "Lundi de Pentecôte");

            if (HasGuyaneAbolitionSlavery)
                bHols.Add(GuyaneAbolitionSlavery(year), "Abolition de l'esclavage en Guyane");

            if (HasAutonomyDay)
                bHols.Add(AutonomyDay(year), "Fête de l'autonomie");

            bHols.Add(National(year), "Fête nationale");

            if (HasVictorSchoelcherDay)
                bHols.Add(VictorSchoelcherDay(year), "Fête de Victor Schœlcher");

            if (HasTerritoryFestivalDay)
                bHols.Add(TerritoryFestivalDay(year), "Fête du territoire");

            bHols.Add(Assumption(year), "Assomption");

            if (HasCitizenshipDay)
                bHols.Add(CitizenshipDay(year), "Fête de la citoyenneté");

            if (HasSaintBarthelemyAbolitionSlavery)
                bHols.Add(SaintBarthelemyAbolitionSlavery(year), "Abolition de l'esclavage à Saint-Barthélemy");

            bHols.Add(AllSaints(year), "Toussaint");

            bHols.Add(Armistice(year), "Jour de l'armistice");

            if (HasLaReunionAbolitionSlavery)
                bHols.Add(LaReunionAbolitionSlavery(year), "Abolition de l'esclavage à La Réunion");

            bHols.Add(Christmas(year), "Noël");

            if (HasSaintStephenDay)
                bHols.Add(SaintStephenDay(year), "Saint-Étienne");

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
            DateTime easter = HolidayCalculator.GetEaster(year);

            var bHols = new List<Holiday>
            {
                NewYearHoliday(year),
                GoodFridayHoliday(easter),
                EasterMondayHoliday(easter),
                MayotteAbolitionSlaveryHoliday(year),
                PeterChanelHoliday(year),
                LabourDayHoliday(year),
                VictoryInEuropeDayHoliday(year),
                MartiniqueAbolitionSlaveryHoliday(year),
                GuadeloupeAbolitionSlaveryHoliday(year),
                SaintMartinAbolitionSlaveryHoliday(year),
                AscensionHoliday(easter),
                PentecostMondayHoliday(easter),
                GuyaneAbolitionSlaveryHoliday(year),
                AutonomyDayHoliday(year),
                BastilleDayHoliday(year),
                VictorSchoelcherDayHoliday(year),
                TerritoryFestivalDayHoliday(year),
                AssumptionHoliday(year),
                CitizenshipDayHoliday(year),
                SaintBarthelemyAbolitionSlaveryHoliday(year),
                AllSaintsHoliday(year),
                ArmisticeHoliday(year),
                LaReunionAbolitionSlaveryHoliday(year),
                ChristmasHoliday(year),
                SaintStephenDayHoliday(year),
            };

            return bHols;
        }
    }
}