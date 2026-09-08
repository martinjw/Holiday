using System;
using System.Collections.Generic;
using PublicHoliday.HolidayDefinitions;
using PublicHoliday.HolidayDefinitions.Christian;
using Christian = PublicHoliday.HolidayDefinitions.Christian;
using Common = PublicHoliday.HolidayDefinitions.Common;
using Local = PublicHoliday.HolidayDefinitions.CountrySpecific.France;
using PublicHoliday.HolidayDefinitions.Base;
using System.Globalization;
using PublicHoliday.Localization;

namespace PublicHoliday
{
    /// <summary>
    /// Finds France public holidays. 
    /// Public holidays on Sundays are not deferred to following weekday automatically- 
    /// they may be taken at an arbitrary date.
    /// https://fr.wikipedia.org/wiki/F%C3%AAtes_et_jours_f%C3%A9ri%C3%A9s_en_France#Tableau_r%C3%A9capitulatif
    /// </summary>
    public class FrancePublicHoliday : PublicHolidayBase
    {

        /// <summary>
        /// Culture whose language this calendar's holiday names are in: French.
        /// Used by <see cref="Holiday.GetName(CultureInfo)"/> when the requested
        /// culture has no translation.
        /// </summary>
        protected override CultureInfo CountryCulture => _defaultCulture;

        private static readonly CultureInfo _defaultCulture = SafeCulture.Get("fr-FR", "fr");
        #region Regions
        /// <summary>
        /// Gets or sets the regions/collectivities concerned with special public holidays
        /// </summary>
        public Regions Region
        {
            get { return _region; }
            set { _region = value; ClearHolidayCache(); }
        }
        private Regions _region;

        /// <summary>
        /// Metropolitan and overseas regions (départements et régions d'outre-mer) and collectivities (collectivité d'outre-mer)
        /// </summary>
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


        #endregion


        #region Individual Holidays

        #region New Year
        /// <summary>
        /// New Year's Day January 1 Nouvel An 
        /// </summary>
        public static DateTime NewYear(int year)
        {
            return new DateTime(year, 1, 1);
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
            return EasterCalculator.GoodFriday(EasterCalculator.GetEaster(year));
        }



        private readonly Regions[] RegionsWithGoodFriday = new[] {
            Regions.ALL,
            Regions.AlsaceMoselle,
            Regions.Guadeloupe,
            Regions.Martinique,
            Regions.PolynesieFrancaise,
        };

        /// <summary>
        /// Whether this region observes GoodFriday
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
        public static DateTime EasterMonday(int year)
        {
            return EasterCalculator.EasterMonday(EasterCalculator.GetEaster(year));
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


        private readonly Regions[] RegionsWithMayotteAbolitionSlavery = new[] {
            Regions.ALL,
            Regions.Mayotte,
        };

        /// <summary>
        /// Whether this region observes Abolition of slavery in Mayotte
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


        private readonly Regions[] RegionsWithPeterChanel = new[] {
            Regions.ALL,
            Regions.WallisEtFutuna,
        };

        /// <summary>
        /// Whether this region observes Abolition of slavery in Mayotte
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
        public static DateTime MayDay(int year)
        {
            return new DateTime(year, 5, 1);
        }


        #endregion

        #region Victory in Europe Day
        /// <summary>
        /// Victory in Europe Day, 8 May - Fête de la Victoire
        /// </summary>
        /// <param name="year">The year.</param>
        public static DateTime VictoryInEuropeDay(int year)
        {
            return new DateTime(year, 5, 8);
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


        private readonly Regions[] RegionsWithMartiniqueAbolitionSlavery = new[] {
            Regions.ALL,
            Regions.Martinique,
        };

        /// <summary>
        /// Whether this region observes Abolition of slavery in Martinique
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


        private readonly Regions[] RegionsWithGuadeloupeAbolitionSlavery = new[] {
            Regions.ALL,
            Regions.Guadeloupe,
        };

        /// <summary>
        /// Whether this region observes Abolition of slavery in Guadeloupe
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


        private readonly Regions[] RegionsWithSaintMartinAbolitionSlavery = new[] {
            Regions.ALL,
            Regions.SaintMartin,
        };

        /// <summary>
        /// Whether this region observes Abolition of slavery in Saint-Martin
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
        public static DateTime Ascension(int year)
        {
            return EasterCalculator.AscensionDay(EasterCalculator.GetEaster(year));
        }


        #endregion

        #region Pentecost Monday
        /// <summary>
        /// Whit Monday - Pentecost Monday 7th Monday after Easter - Lundi de Pentecôte
        /// </summary>
        public static DateTime PentecostMonday(int year)
        {
            return EasterCalculator.WhitMonday(EasterCalculator.GetEaster(year));
        }


        /// <summary>
        /// By default Pentecost Monday is a holiday, but it can be a working day for some companies. Set this to false to make it a working day.
        /// </summary>
        public bool HasPentecostMonday
        {
            get { return _hasPentecostMonday; }
            set { _hasPentecostMonday = value; ClearHolidayCache(); }
        }
        private bool _hasPentecostMonday = true;

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


        private readonly Regions[] RegionsWithGuyaneAbolitionSlavery = new[] {
            Regions.ALL,
            Regions.Guyane,
        };

        /// <summary>
        /// Whether this region observes Abolition of slavery in Guyane
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


        private readonly Regions[] RegionsWithAutonomyDay = new[] {
            Regions.ALL,
            Regions.PolynesieFrancaise,
        };

        /// <summary>
        /// Whether this region observes Autonomy Day
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
        public static DateTime National(int year)
        {
            return new DateTime(year, 7, 14);
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


        private readonly Regions[] RegionsWithVictorSchoelcherDay = new[] {
            Regions.ALL,
            Regions.Guadeloupe,
            Regions.Martinique,
        };

        /// <summary>
        /// Whether this region observes Victor Schoelcher's Feast
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


        private readonly Regions[] RegionsWithTerritoryFestivalDay = new[] {
            Regions.ALL,
            Regions.WallisEtFutuna,
        };

        /// <summary>
        /// Whether this region observes Territory Festival
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
        public static DateTime Assumption(int year)
        {
            return new DateTime(year, 8, 15);
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


        private readonly Regions[] RegionsWithCitizenshipDay = new[] {
            Regions.ALL,
            Regions.NouvelleCaledonie,
        };

        /// <summary>
        /// Whether this region observes Citizenship Day
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


        private readonly Regions[] RegionsWithSaintBarthelemyAbolitionSlavery = new[] {
            Regions.ALL,
            Regions.SaintBarthelemy,
        };

        /// <summary>
        /// Whether this region observes Abolition of slavery in Saint-Barthélemy
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
        public static DateTime AllSaints(int year)
        {
            return new DateTime(year, 11, 1);
        }


        #endregion

        #region Armistice
        /// <summary>
        /// Armistice Day November 11- Jour de l'armistice
        /// </summary>
        public static DateTime Armistice(int year)
        {
            return new DateTime(year, 11, 11);
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


        private readonly Regions[] RegionsWithLaReunionAbolitionSlavery = new[] {
            Regions.ALL,
            Regions.Reunion,
        };

        /// <summary>
        /// Whether this region observes Abolition of slavery in La Réunion
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
        public static DateTime Christmas(int year)
        {
            return new DateTime(year, 12, 25);
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


        private readonly Regions[] RegionsWithSaintStephenDay = new[] {
            Regions.ALL,
            Regions.AlsaceMoselle,
        };

        /// <summary>
        /// Whether this region observes Saint Stephen's Day
        /// </summary>
        /// <value>
        /// <c>true</c> if this region observes Saint Stephen's Day; otherwise, <c>false</c>.
        /// </value>
        public bool HasSaintStephenDay => Array.IndexOf(RegionsWithSaintStephenDay, Region) > -1;

        #endregion

        #endregion

        private IEnumerable<HolidayDefinition> GetDefinitions()
        {
            //a movable feast (Ascension, Whit Monday) can land on a fixed holiday (VE Day 1997,
            //May Day 2008, a regional abolition day); same-day holidays stay distinct entries
            //(names aggregated by the base class)
            yield return new Common.NewYear();
            if (HasGoodFriday)
                yield return new Christian.GoodFriday();
            yield return new Christian.EasterMonday();
            if (HasMayotteAbolitionSlavery)
                yield return new Local.MayotteAbolitionSlavery();
            if (HasPeterChanel)
                yield return new Local.PeterChanelDay();
            yield return new Common.LabourDay();
            yield return new Common.VictoryInEuropeDay();
            if (HasMartiniqueAbolitionSlavery)
                yield return new Local.MartiniqueAbolitionSlavery();
            if (HasGuadeloupeAbolitionSlavery)
                yield return new Local.GuadeloupeAbolitionSlavery();
            if (HasSaintMartinAbolitionSlavery)
                yield return new Local.SaintMartinAbolitionSlavery();
            yield return new Christian.Ascension();
            if (HasPentecostMonday)
                yield return new Christian.WhitMonday();
            if (HasGuyaneAbolitionSlavery)
                yield return new Local.GuyaneAbolitionSlavery();
            if (HasAutonomyDay)
                yield return new Local.AutonomyDay();
            yield return new Local.BastilleDay();
            if (HasVictorSchoelcherDay)
                yield return new Local.VictorSchoelcherDay();
            if (HasTerritoryFestivalDay)
                yield return new Local.TerritoryFestivalDay();
            yield return new Christian.Assumption();
            if (HasCitizenshipDay)
                yield return new Local.CitizenshipDay();
            if (HasSaintBarthelemyAbolitionSlavery)
                yield return new Local.SaintBarthelemyAbolitionSlavery();
            yield return new Christian.AllSaints();
            yield return new Common.Armistice();
            if (HasLaReunionAbolitionSlavery)
                yield return new Local.LaReunionAbolitionSlavery();
            yield return new Christian.Christmas();
            if (HasSaintStephenDay)
                yield return new Christian.SaintStephensDay();
        }

        /// <summary>
        /// The full holiday set for the configured <see cref="Region"/>, each carrying its
        /// localization id so <see cref="Holiday.GetName(System.Globalization.CultureInfo)"/>
        /// resolves culture-aware names.
        /// </summary>
        /// <param name="year">The given year</param>
        protected override IList<Holiday> PublicHolidaysComplete(int year)
        {
            var list = new List<Holiday>();
            foreach (var definition in GetDefinitions())
            {
                list.AddRange(definition.Build(year));
            }
            return list;
        }
    }
}