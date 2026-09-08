using System;
using System.Collections.Generic;
using PublicHoliday.HolidayDefinitions;
using PublicHoliday.HolidayDefinitions.Christian;
using Christian = PublicHoliday.HolidayDefinitions.Christian;
using Common = PublicHoliday.HolidayDefinitions.Common;
using Local = PublicHoliday.HolidayDefinitions.CountrySpecific.Switzerland;
using PublicHoliday.HolidayDefinitions.Base;
using System.Globalization;
using PublicHoliday.Localization;
using PublicHoliday.Dates;

namespace PublicHoliday
{

    /// <summary>
    /// Switzerland's holiday calendar. Oliver Fritz, May 2018.
    /// Updated according to https://en.wikipedia.org/wiki/Public_holidays_in_Switzerland. Christophe Peugnet, April 2024
    /// </summary>
    public class SwitzerlandPublicHoliday : PublicHolidayBase
    {

        /// <summary>
        /// Culture whose language this calendar's holiday names are in: Swiss German, the largest of its four languages.
        /// Used by <see cref="Holiday.GetName(CultureInfo)"/> when the requested
        /// culture has no translation.
        /// </summary>
        protected override CultureInfo CountryCulture => _defaultCulture;

        private static readonly CultureInfo _defaultCulture = SafeCulture.Get("de-CH", "de");
        #region cantons
        /// <summary>
        /// Gets or sets the canton (ISO 3166-2:CH), + default All for all Canton.
        /// </summary>
        public Cantons Canton
        {
            get { return _canton; }
            set { _canton = value; ClearHolidayCache(); }
        }
        private Cantons _canton;

        /// <summary>
        /// List of cantons
        /// </summary>
        public enum Cantons
        {
            /// <summary>
            /// All cantons
            /// </summary>
            OnlyOfficial = 0,

            /// <summary>
            ///  Canton of Aargau
            /// </summary>
            AG = 1,

            /// <summary>
            ///  Appenzell Innerrhoden
            /// </summary>
            AI = 2,

            /// <summary>
            ///  Appenzell Ausserrhoden
            /// </summary>
            AR = 3,

            /// <summary>
            ///  Basel-Landschaft
            /// </summary>
            BL = 4,

            /// <summary>
            ///  Basel-Stadt
            /// </summary>
            BS = 5,

            /// <summary>
            ///  Canton of Bern
            /// </summary>
            BE,

            /// <summary>
            ///  Canton of Fribourg
            /// </summary>
            FR,

            /// <summary>
            ///  Canton of Geneva
            /// </summary>
            GE,

            /// <summary>
            ///  Canton of Glarus
            /// </summary>
            GL,

            /// <summary>
            ///  Grisons
            /// </summary>
            GR,

            /// <summary>
            ///  Canton of Jura
            /// </summary>
            JU,

            /// <summary>
            ///  Canton of Lucerne
            /// </summary>
            LU,

            /// <summary>
            ///  Canton of Neuchâtel
            /// </summary>
            NE,

            /// <summary>
            ///  Nidwalden
            /// </summary>
            NW,

            /// <summary>
            ///  Obwalden
            /// </summary>
            OW,

            /// <summary>
            ///  Canton of St. Gallen
            /// </summary>
            SG,

            /// <summary>
            ///  Canton of Schaffhausen
            /// </summary>
            SH,

            /// <summary>
            ///  Canton of Schwyz
            /// </summary>
            SZ,

            /// <summary>
            ///  Canton of Solothurn
            /// </summary>
            SO,

            /// <summary>
            ///  Thurgau
            /// </summary>
            TG,

            /// <summary>
            ///  Ticino
            /// </summary>
            TI,

            /// <summary>
            ///  Canton of Uri
            /// </summary>
            UR,

            /// <summary>
            ///  Valais
            /// </summary>
            VS,

            /// <summary>
            ///  Vaud
            /// </summary>
            VD,

            /// <summary>
            ///  Canton of Zug
            /// </summary>
            ZG,

            /// <summary>
            ///  Canton of Zürich
            /// </summary>
            ZH,

            /// <summary>
            ///  All Cantons
            /// </summary>
            ALL = 99,
        }

        private static readonly Dictionary<Cantons, string> CantonsName = new Dictionary<Cantons, string>
        {
            { Cantons.AG, "Aargau" },
            { Cantons.AI, "Appenzell Innerrhoden" },
            { Cantons.AR, "Appenzell Ausserrhoden" },
            { Cantons.BL, "Basel-Landschaft" },
            { Cantons.BS, "Basel-Stadt" },
            { Cantons.BE, "Bern" },
            { Cantons.FR, "Fribourg" },
            { Cantons.GE, "Geneva" },
            { Cantons.GL, "Glarus" },
            { Cantons.GR, "Grisons" },
            { Cantons.JU, "Jura" },
            { Cantons.LU, "Lucerne" },
            { Cantons.NE, "Neuchâtel" },
            { Cantons.NW, "Nidwalden" },
            { Cantons.OW, "Obwalden" },
            { Cantons.SG, "St. Gallen" },
            { Cantons.SH, "Schaffhausen" },
            { Cantons.SZ, "Schwyz" },
            { Cantons.SO, "Solothurn" },
            { Cantons.TG, "Thurgau" },
            { Cantons.TI, "Ticino" },
            { Cantons.UR, "Uri" },
            { Cantons.VS, "Valais" },
            { Cantons.VD, "Vaud" },
            { Cantons.ZG, "Zug" },
            { Cantons.ZH, "Zürich" },
        };

        private static string GetCantonName(Cantons canton)
        {
            if (CantonsName.TryGetValue(canton, out string name))
                return name;
            else
            {
                return string.Empty;
            }
        }

        #endregion

        #region Individual Holidays

        #region New Year
        /// <summary>
        /// New Year's Day January 1
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of this holiday in the given year.</returns>
        public static DateTime NewYear(int year)
        {
            return new DateTime(year, 1, 1);
        }

        private static Holiday NewYearHoliday(int year)
        {
            DateTime holiday = NewYear(year);
            return new Holiday(holiday, "New Year", "Neujahrstag") { HolidayKey = HolidayKeys.NewYear };
        }

        #endregion 

        #region Berchtold's Day
        /// <summary>
        /// January 2, Berchtoldstag
        /// </summary>
        /// <returns>Date of this holiday in given year</returns>
        public static DateTime SecondJanuary(int year)
        {
            return new DateTime(year, 1, 2);
        }

        private Holiday SecondJanuaryHoliday(int year)
        {
            DateTime holiday = SecondJanuary(year);

            var cantonsName = new List<string>();

            foreach (Cantons canton in CantonsWithSecondJanuary)
            {
                var name = GetCantonName(canton);

                if (!string.IsNullOrEmpty(name))
                    cantonsName.Add(name);
            }
            
            return new Holiday(holiday, "Berchtold's Day", "Berchtoldstag", cantonsName.ToArray()) { HolidayKey = HolidayKeys.Berchtold };
        }

        private readonly Cantons[] CantonsWithSecondJanuary = new[] {
            Cantons.ALL, 
            Cantons.AG, 
            Cantons.BE, 
            Cantons.FR, 
            Cantons.GL, 
            Cantons.JU, 
            Cantons.NE, 
            Cantons.OW, 
            Cantons.SH, 
            Cantons.SO, 
            Cantons.TG, 
            Cantons.VD, 
            Cantons.ZG, 
            Cantons.ZH };

        /// <summary>
        /// Whether this cantons observes SecondJanuary
        /// </summary>
        /// <value>
        /// <c>true</c> if this canton observes SecondJanuary; otherwise, <c>false</c>.
        /// </value>
        public bool HasSecondJanuary => Array.IndexOf(CantonsWithSecondJanuary, Canton) > -1;

        #endregion

        #region Epiphany

        /// <summary>
        /// Epiphany - 13 days after christmas
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of this holiday in the given year.</returns>
        public static DateTime Epiphany(int year)
        {
            return new DateTime(year, 1, 6);
        }

        private Holiday EpiphanyHoliday(int year)
        {
            DateTime holiday = Epiphany(year);

            var cantonsName = new List<string>();

            foreach (Cantons canton in CantonsWithEpiphany)
            {
                var name = GetCantonName(canton);

                if (!string.IsNullOrEmpty(name))
                    cantonsName.Add(name);
            }

            return new Holiday(holiday, "Epiphany", "Epiphanie", cantonsName.ToArray()) { HolidayKey = HolidayKeys.Epiphany };
        }

        private readonly Cantons[] CantonsWithEpiphany = new[] {
            Cantons.ALL,
            Cantons.GR,
            Cantons.LU,
            Cantons.SZ,
            Cantons.TI,
            Cantons.UR, 
        };

        /// <summary>
        /// Whether this cantons observes Epiphany
        /// </summary>
        /// <value>
        /// <c>true</c> if this canton observes Epiphany; otherwise, <c>false</c>.
        /// </value>
        public bool HasEpiphany => Array.IndexOf(CantonsWithEpiphany, Canton) > -1;

        #endregion

        #region Republic Day
        /// <summary>
        /// Republic Day Neuchatel - 1. March
        /// </summary>
        /// <param name="year">Republic Day of Neuchatel</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime RepublicDay(int year)
        {
            return new DateTime(year, 3, 1);
        }

        private Holiday RepublicDayHoliday(int year)
        {
            DateTime holiday = RepublicDay(year);

            var cantonsName = new List<string>();

            foreach (Cantons canton in CantonsWithRepublicDay)
            {
                var name = GetCantonName(canton);

                if (!string.IsNullOrEmpty(name))
                    cantonsName.Add(name);
            }

            return new Holiday(holiday, "Republic Day", "Instauration de la République", cantonsName.ToArray()) { HolidayKey = HolidayKeys.NeuchatelRepublicDay };
        }

        private readonly Cantons[] CantonsWithRepublicDay = new[] {
            Cantons.ALL,
            Cantons.NE,
        };

        /// <summary>
        /// Whether this cantons observes RepublicDay
        /// </summary>
        /// <value>
        /// <c>true</c> if this canton observes RepublicDay; otherwise, <c>false</c>.
        /// </value>
        public bool HasRepublicDay => Array.IndexOf(CantonsWithRepublicDay, Canton) > -1;

        #endregion

        #region St Joseph's Day

        /// <summary>
        ///  St Joseph's Day - 19 March
        /// </summary>
        /// <param name="year">St Joseph's Day</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime StJosephDay(int year)
        {
            return new DateTime(year, 3, 19);
        }

        private Holiday StJosephDayHoliday(int year)
        {
            DateTime holiday = StJosephDay(year);

            var cantonsName = new List<string>();

            foreach (Cantons canton in CantonsWithStJosephDay)
            {
                var name = GetCantonName(canton);

                if (!string.IsNullOrEmpty(name))
                    cantonsName.Add(name);
            }

            return new Holiday(holiday, "Saint Joseph's Day", "Josefstag", cantonsName.ToArray()) { HolidayKey = HolidayKeys.StJoseph };
        }

        private readonly Cantons[] CantonsWithStJosephDay = new[] {
            Cantons.ALL,
            Cantons.GR,
            Cantons.NW,
            Cantons.SZ,
            Cantons.SO,
            Cantons.TI,
            Cantons.UR,
            Cantons.VS,
        };

        /// <summary>
        /// Whether this cantons observes St Joseph's Day
        /// </summary>
        /// <value>
        /// <c>true</c> if this canton observes St Joseph's Day; otherwise, <c>false</c>.
        /// </value>
        public bool HasStJosephDay => Array.IndexOf(CantonsWithStJosephDay, Canton) > -1;

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

        private static DateTime GoodFriday(DateTime easter)
        {
            return EasterCalculator.GoodFriday(easter);
        }

        private Holiday GoodFridayHoliday(DateTime easter)
        {
            DateTime holiday = GoodFriday(easter);

            var cantonsName = new List<string>();

            foreach (Cantons canton in CantonsWithGoodFriday)
            {
                var name = GetCantonName(canton);

                if (!string.IsNullOrEmpty(name))
                    cantonsName.Add(name);
            }

            return new Holiday(holiday, "Good Friday", "Karfreitag", cantonsName.ToArray()) { HolidayKey = HolidayKeys.GoodFriday };
        }

        private readonly Cantons[] CantonsWithGoodFriday = new[] {
            Cantons.ALL,
            Cantons.AG,
            Cantons.AI,
            Cantons.AR,
            Cantons.BL,
            Cantons.BS,
            Cantons.BE,
            Cantons.FR,
            Cantons.GE,
            Cantons.GL,
            Cantons.GR,
            Cantons.JU,
            Cantons.LU,
            Cantons.NE,
            Cantons.NW,
            Cantons.OW,
            Cantons.SG,
            Cantons.SH,
            Cantons.SZ,
            Cantons.SO,
            Cantons.TG,
            Cantons.UR,
            Cantons.VD,
            Cantons.ZG,
            Cantons.ZH,
        };

        /// <summary>
        /// Whether this cantons observes GoodFriday
        /// </summary>
        /// <value>
        /// <c>true</c> if this canton observes GoodFriday; otherwise, <c>false</c>.
        /// </value>
        public bool HasGoodFriday => Array.IndexOf(CantonsWithGoodFriday, Canton) > -1;

        #endregion

        #region Easter Monday

        /// <summary>
        /// Easter Monday 1st Monday after Easter
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime EasterMonday(int year)
        {
            return EasterCalculator.EasterMonday(EasterCalculator.GetEaster(year));
        }

        private static DateTime EasterMonday(DateTime easter)
        {
            return EasterCalculator.EasterMonday(easter);
        }

        private Holiday EasterMondayHoliday(DateTime easter)
        {
            DateTime holiday = EasterMonday(easter);

            var cantonsName = new List<string>();

            foreach (Cantons canton in CantonsWithEasterMonday)
            {
                var name = GetCantonName(canton);

                if (!string.IsNullOrEmpty(name))
                    cantonsName.Add(name);
            }

            return new Holiday(holiday, "Easter Monday", "Ostermontag", cantonsName.ToArray()) { HolidayKey = HolidayKeys.EasterMonday };
        }

        private readonly Cantons[] CantonsWithEasterMonday = new[] {
            Cantons.ALL,
            Cantons.AG,
            Cantons.AI,
            Cantons.AR,
            Cantons.BL,
            Cantons.BS,
            Cantons.BE,
            Cantons.FR,
            Cantons.GE,
            Cantons.GL,
            Cantons.GR,
            Cantons.JU,
            Cantons.LU,
            Cantons.NE,
            Cantons.NW,
            Cantons.OW,
            Cantons.SG,
            Cantons.SH,
            Cantons.SZ,
            Cantons.SO,
            Cantons.TG,
            Cantons.TI,
            Cantons.UR,
            Cantons.VD,
            Cantons.ZG,
            Cantons.ZH,
        };

        /// <summary>
        /// Whether this cantons observes Easter Monday
        /// </summary>
        /// <value>
        /// <c>true</c> if this canton observes Easter Monday; otherwise, <c>false</c>.
        /// </value>
        public bool HasEasterMonday => Array.IndexOf(CantonsWithEasterMonday, Canton) > -1;

        #endregion

        #region Labour Day

        /// <summary>
        /// Labour Day - Mai 1st
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime LabourDay(int year)
        {
            return new DateTime(year, 5, 1);
        }

        private Holiday LabourDayHoliday(int year)
        {
            DateTime holiday = LabourDay(year);

            var cantonsName = new List<string>();

            foreach (Cantons canton in CantonsWithLabourDay)
            {
                var name = GetCantonName(canton);

                if (!string.IsNullOrEmpty(name))
                    cantonsName.Add(name);
            }

            return new Holiday(holiday, "Labour Day", "Tag der Arbeit", cantonsName.ToArray()) { HolidayKey = HolidayKeys.LabourDay };
        }

        private readonly Cantons[] CantonsWithLabourDay = new[] {
            Cantons.ALL,
            Cantons.AR,
            Cantons.BL,
            Cantons.BS,
            Cantons.FR,
            Cantons.JU,
            Cantons.NE,
            Cantons.SH,
            Cantons.SO,
            Cantons.TG,
            Cantons.TI,
            Cantons.ZH,
        };

        /// <summary>
        /// Whether this cantons observes Labour Day
        /// </summary>
        /// <value>
        /// <c>true</c> if this canton observes Labour Day; otherwise, <c>false</c>.
        /// </value>
        public bool HasLabourDay => Array.IndexOf(CantonsWithLabourDay, Canton) > -1;

        #endregion

        #region Ascension

        /// <summary>
        /// Ascension 6th Thursday after Easter
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime Ascension(int year)
        {
            return EasterCalculator.AscensionDay(EasterCalculator.GetEaster(year));
        }

        private static DateTime Ascension(DateTime easter)
        {
            return EasterCalculator.AscensionDay(easter);
        }

        private static Holiday AscensionHoliday(DateTime easter)
        {
            DateTime holiday = Ascension(easter);
            return new Holiday(holiday, "Ascension Day", "Auffahrt") { HolidayKey = HolidayKeys.SwissAscension };
        }

        #endregion

        #region Whit Monday

        /// <summary>
        /// Whit Monday - Monday after Whit Sunday
        /// </summary>
        public static DateTime WhitMonday(int year)
        {
            return EasterCalculator.WhitMonday(EasterCalculator.GetEaster(year));
        }

        private static DateTime WhitMonday(DateTime easter)
        {
            return EasterCalculator.WhitMonday(easter);
        }

        private Holiday WhitMondayHoliday(DateTime easter)
        {
            DateTime holiday = WhitMonday(easter);

            var cantonsName = new List<string>();

            foreach (Cantons canton in CantonsWithWhitMonday)
            {
                var name = GetCantonName(canton);

                if (!string.IsNullOrEmpty(name))
                    cantonsName.Add(name);
            }

            return new Holiday(holiday, "Whit Monday", "Pfingstmontag", cantonsName.ToArray()) { HolidayKey = HolidayKeys.PentecostMonday };
        }

        private readonly Cantons[] CantonsWithWhitMonday = new[] {
            Cantons.ALL,
            Cantons.AG,
            Cantons.AI,
            Cantons.AR,
            Cantons.BL,
            Cantons.BS,
            Cantons.BE,
            Cantons.FR,
            Cantons.GE,
            Cantons.GL,
            Cantons.GR,
            Cantons.JU,
            Cantons.LU,
            Cantons.NE,
            Cantons.NW,
            Cantons.OW,
            Cantons.SG,
            Cantons.SH,
            Cantons.SZ,
            Cantons.SO,
            Cantons.TG,
            Cantons.TI,
            Cantons.UR,
            Cantons.VD,
            Cantons.ZG,
            Cantons.ZH,
        };

        /// <summary>
        /// Whether this cantons observes Whit Monday
        /// </summary>
        /// <value>
        /// <c>true</c> if this canton observes Whit Monday; otherwise, <c>false</c>.
        /// </value>
        public bool HasWhitMonday => Array.IndexOf(CantonsWithWhitMonday, Canton) > -1;

        #endregion

        #region Corpus Christi

        /// <summary>
        /// Fronleichnam - Corpus Christi
        /// </summary>
        public static DateTime CorpusChristi(int year)
        {
            return EasterCalculator.CorpusChristi(EasterCalculator.GetEaster(year));
        }

        /// <summary>
        /// Fronleichnam - Corpus Christi
        /// </summary>
        public static DateTime CorpusChristi(DateTime easter)
        {
            return EasterCalculator.CorpusChristi(easter);
        }

        private Holiday CorpusChristiHoliday(DateTime easter)
        {
            DateTime holiday = CorpusChristi(easter);

            var cantonsName = new List<string>();

            foreach (Cantons canton in CantonsWithCorpusChristi)
            {
                var name = GetCantonName(canton);

                if (!string.IsNullOrEmpty(name))
                    cantonsName.Add(name);
            }

            return new Holiday(holiday, "Corpus Christi", "Fronleichnam", cantonsName.ToArray()) { HolidayKey = HolidayKeys.CorpusChristi };
        }

        private readonly Cantons[] CantonsWithCorpusChristi = new[] {
            Cantons.ALL,
            Cantons.AG,
            Cantons.AI,
            Cantons.FR,
            Cantons.JU,
            Cantons.LU,
            Cantons.NW,
            Cantons.OW,
            Cantons.SZ,
            Cantons.SO,
            Cantons.TI,
            Cantons.UR,
            Cantons.VS,
            Cantons.ZG,
        };

        /// <summary>
        /// Whether this cantons observes Corpus Christi
        /// </summary>
        /// <value>
        /// <c>true</c> if this canton observes Corpus Christi; otherwise, <c>false</c>.
        /// </value>
        public bool HasCorpusChristi => Array.IndexOf(CantonsWithCorpusChristi, Canton) > -1;

        #endregion

        #region Swiss National Day

        /// <summary>
        /// National Day - August 1st
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime NationalDay(int year)
        {
            return new DateTime(year, 8, 1);
        }

        private static Holiday NationalDayHoliday(int year)
        {
            DateTime holiday = NationalDay(year);
            return new Holiday(holiday, "National Day", "Bundesfeier") { HolidayKey = HolidayKeys.SwissNationalDay };
        }

        #endregion

        #region Assumption of Mary

        /// <summary>
        /// Mariä Himmelfahrt - Assumption of Mary
        /// </summary>
        public static DateTime Assumption(int year)
        {
            return new DateTime(year, 8, 15);
        }

        private Holiday AssumptionHoliday(int year)
        {
            DateTime holiday = Assumption(year);

            var cantonsName = new List<string>();

            foreach (Cantons canton in CantonsWithAssumption)
            {
                var name = GetCantonName(canton);

                if (!string.IsNullOrEmpty(name))
                    cantonsName.Add(name);
            }

            return new Holiday(holiday, "Assumption Day", "Mariä Himmelfahrt", cantonsName.ToArray()) { HolidayKey = HolidayKeys.Assumption };
        }

        private readonly Cantons[] CantonsWithAssumption = new[] {
            Cantons.ALL,
            Cantons.AI,
            Cantons.FR,
            Cantons.JU,
            Cantons.LU,
            Cantons.NW,
            Cantons.OW,
            Cantons.SZ,
            Cantons.SO,
            Cantons.TI,
            Cantons.UR,
            Cantons.VS,
            Cantons.ZG,
        };

        /// <summary>
        /// Whether this cantons observes Assumption of Mary
        /// </summary>
        /// <value>
        /// <c>true</c> if this canton observes Assumption of Mary; otherwise, <c>false</c>.
        /// </value>
        public bool HasAssumption => Array.IndexOf(CantonsWithAssumption, Canton) > -1;

        #endregion

        #region Geneva fast

        /// <summary>
        /// Geneva PrayDay
        /// Thursday after First Sunday in September
        /// </summary>
        public static DateTime GenevaPrayDay(int year)
        {
            var firstSundayOfSeptember = HolidayCalculator.FindOccurrenceOfDayOfWeek(new DateTime(year, 9, 1), DayOfWeek.Sunday, 1);
            return HolidayCalculator.FindNext(firstSundayOfSeptember, DayOfWeek.Thursday);
        }

        private Holiday GenevaPrayDayHoliday(int year)
        {
            DateTime holiday = GenevaPrayDay(year);

            var cantonsName = new List<string>();

            foreach (Cantons canton in CantonsWithGenevaPrayDay)
            {
                var name = GetCantonName(canton);

                if (!string.IsNullOrEmpty(name))
                    cantonsName.Add(name);
            }

            return new Holiday(holiday, "Geneva Fast", "Jeûne genevois", cantonsName.ToArray()) { HolidayKey = HolidayKeys.GenevaPrayDay };
        }

        private readonly Cantons[] CantonsWithGenevaPrayDay = new[] {
            Cantons.ALL,
            Cantons.GE,
        };

        /// <summary>
        /// Whether this cantons observes Geneva PrayDay
        /// </summary>
        /// <value>
        /// <c>true</c> if this canton observes Geneva PrayDay; otherwise, <c>false</c>.
        /// </value>
        public bool HasGenevaPrayDay => Array.IndexOf(CantonsWithGenevaPrayDay, Canton) > -1;

        #endregion

        #region All Saints

        /// <summary>
        /// Allerheiligen - All Saints
        /// </summary>
        public static DateTime AllSaints(int year)
        {
            return new DateTime(year, 11, 1);
        }

        private Holiday AllSaintsHoliday(int year)
        {
            DateTime holiday = AllSaints(year);

            var cantonsName = new List<string>();

            foreach (Cantons canton in CantonsWithAllSaints)
            {
                var name = GetCantonName(canton);

                if (!string.IsNullOrEmpty(name))
                    cantonsName.Add(name);
            }

            return new Holiday(holiday, "All Saints Day", "Allerheiligen", cantonsName.ToArray()) { HolidayKey = HolidayKeys.AllSaints };
        }

        private readonly Cantons[] CantonsWithAllSaints = new[] {
            Cantons.ALL,
            Cantons.AG,
            Cantons.AI,
            Cantons.FR,
            Cantons.GL,
            Cantons.JU,
            Cantons.LU,
            Cantons.NW,
            Cantons.OW,
            Cantons.SG,
            Cantons.SZ,
            Cantons.SO,
            Cantons.TI,
            Cantons.UR,
            Cantons.VS,
            Cantons.ZG,
        };

        /// <summary>
        /// Whether this canton observes Allerheiligen
        /// </summary>
        /// <value>
        /// <c>true</c> if this canton observes Allerheiligen; otherwise, <c>false</c>.
        /// </value>
        public bool HasAllSaints => Array.IndexOf(CantonsWithAllSaints, Canton) > -1;

        #endregion

        #region Immaculate Conception

        /// <summary>
        /// Immaculate Conception
        /// </summary>
        public static DateTime ImmaculateConception(int year)
        {
            return new DateTime(year, 12, 8);
        }

        private Holiday ImmaculateConceptionHoliday(int year)
        {
            DateTime holiday = ImmaculateConception(year);

            var cantonsName = new List<string>();

            foreach (Cantons canton in CantonsWithImmaculateConception)
            {
                var name = GetCantonName(canton);

                if (!string.IsNullOrEmpty(name))
                    cantonsName.Add(name);
            }

            return new Holiday(holiday, "Immaculate Conception", "Unbefleckte Empfängnis", cantonsName.ToArray()) { HolidayKey = HolidayKeys.ImmaculateConception };
        }

        private readonly Cantons[] CantonsWithImmaculateConception = new[] {
            Cantons.ALL,
            Cantons.AG,
            Cantons.AI,
            Cantons.FR,
            Cantons.GR,
            Cantons.LU,
            Cantons.NW,
            Cantons.OW,
            Cantons.SZ,
            Cantons.SO,
            Cantons.TI,
            Cantons.UR,
            Cantons.VS,
            Cantons.ZG,
        };

        /// <summary>
        /// Whether this canton observes Immaculate Conception
        /// </summary>
        /// <value>
        /// <c>true</c> if this canton observes Immaculate Conception; otherwise, <c>false</c>.
        /// </value>
        public bool HasImmaculateConception => Array.IndexOf(CantonsWithImmaculateConception, Canton) > -1;

        #endregion

        #region Christmas

        /// <summary>
        /// Christmas - December 25
        /// </summary>
        public static DateTime Christmas(int year)
        {
            return new DateTime(year, 12, 25);
        }

        private static Holiday ChristmasHoliday(int year)
        {
            DateTime holiday = Christmas(year);
            return new Holiday(holiday, "Christmas Day", "Weihnachten") { HolidayKey = HolidayKeys.Christmas };
        }

        #endregion

        #region Saint Stephen's Day

        /// <summary>
        /// St Stephen's Day - December 26
        /// </summary>
        public static DateTime SaintStephensDay(int year)
        {
            return new DateTime(year, 12, 26);
        }

        private Holiday SaintStephensDayHoliday(int year)
        {
            DateTime holiday = SaintStephensDay(year);

            var cantonsName = new List<string>();

            foreach (Cantons canton in CantonsWithSaintStephensDay)
            {
                var name = GetCantonName(canton);

                if (!string.IsNullOrEmpty(name))
                    cantonsName.Add(name);
            }

            return new Holiday(holiday, "St Stephen's Day", "Stephanstag", cantonsName.ToArray()) { HolidayKey = HolidayKeys.SaintStephensDay };
        }

        private readonly Cantons[] CantonsWithSaintStephensDay = new[] {
            Cantons.ALL,
            Cantons.AG,
            Cantons.AI,
            Cantons.AR,
            Cantons.BL,
            Cantons.BS,
            Cantons.BE,
            Cantons.FR,
            Cantons.GL,
            Cantons.GR,
            Cantons.LU,
            Cantons.NE,
            Cantons.NW,
            Cantons.OW,
            Cantons.SG,
            Cantons.SH,
            Cantons.SZ,
            Cantons.SO,
            Cantons.TG,
            Cantons.TI,
            Cantons.UR,
            Cantons.ZG,
            Cantons.ZH,
        };

        /// <summary>
        /// Whether this canton observes St Stephen's Day
        /// </summary>
        /// <value>
        /// <c>true</c> if this canton observes St Stephen's Day; otherwise, <c>false</c>.
        /// </value>
        public bool HasSaintStephensDay => Array.IndexOf(CantonsWithSaintStephensDay, Canton) > -1;

        #endregion

        #endregion


        private string[] NamesOf(Cantons[] cantons)
        {
            var names = new List<string>();
            foreach (var canton in cantons)
            {
                var name = GetCantonName(canton);
                if (!string.IsNullOrEmpty(name)) names.Add(name);
            }
            return names.ToArray();
        }

        private IEnumerable<HolidayDefinition> GetDefinitions()
        {
            yield return new Common.NewYear { EnglishName = "New Year" };
            if (_hasSecondJanuary || HasSecondJanuary)
                yield return new Local.BerchtoldsDay { Regions = NamesOf(CantonsWithSecondJanuary) };
            if (HasEpiphany)
                yield return new Christian.Epiphany { Regions = NamesOf(CantonsWithEpiphany) };
            if (HasRepublicDay)
                yield return new Local.NeuchatelRepublicDay { Regions = NamesOf(CantonsWithRepublicDay) };
            if (HasStJosephDay)
                yield return new Local.StJosephDay { Regions = NamesOf(CantonsWithStJosephDay) };
            if (HasGoodFriday)
                yield return new Christian.GoodFriday { Regions = NamesOf(CantonsWithGoodFriday) };
            if (HasEasterMonday)
                yield return new Christian.EasterMonday { Regions = NamesOf(CantonsWithEasterMonday) };
            if (HasLabourDay || _hasLabourDay)
                yield return new Common.LabourDay { Regions = NamesOf(CantonsWithLabourDay) };
            //Ascension can fall on 1 May (Labour Day, e.g. 2008); both stay distinct entries
            yield return new Local.SwissAscension();
            if (HasWhitMonday)
                yield return new Christian.WhitMonday { Regions = NamesOf(CantonsWithWhitMonday) };
            if (_hasCorpusChristi || HasCorpusChristi)
                yield return new Christian.CorpusChristi { Regions = NamesOf(CantonsWithCorpusChristi) };
            yield return new Local.SwissNationalDay();
            if (HasAssumption)
                yield return new Christian.Assumption { EnglishName = "Assumption Day", Regions = NamesOf(CantonsWithAssumption) };
            if (HasGenevaPrayDay)
                yield return new Local.GenevaPrayDay { Regions = NamesOf(CantonsWithGenevaPrayDay) };
            if (HasAllSaints)
                yield return new Christian.AllSaints { EnglishName = "All Saints Day", Regions = NamesOf(CantonsWithAllSaints) };
            if (HasImmaculateConception)
                yield return new Christian.ImmaculateConception { Regions = NamesOf(CantonsWithImmaculateConception) };
            yield return new Christian.Christmas { EnglishName = "Christmas Day" };
            if (HasSaintStephensDay)
                yield return new Christian.SaintStephensDay { Regions = NamesOf(CantonsWithSaintStephensDay) };
        }

        /// <summary>
        /// The full holiday set for the configured <see cref="Canton"/>, each carrying its
        /// localization id so <see cref="Holiday.GetName(System.Globalization.CultureInfo)"/>
        /// resolves culture-aware names. Canton-specific holidays carry the canton names in
        /// <see cref="Holiday.Regions"/> (with <see cref="Holiday.IsPublic"/> false) as metadata;
        /// every entry applies to the configured canton selection by construction, which is why
        /// the list/name/check methods below include them.
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

        /// <summary>
        /// Get a list of dates for all holidays in a year for the configured <see cref="Canton"/>.
        /// </summary>
        /// <param name="year">The year</param>
        /// <returns>List of public holidays</returns>
        public override IList<DateTime> PublicHolidays(int year)
        {
            var dates = new List<DateTime>();
            foreach (var holiday in PublicHolidaysInformation(year))
            {
                var date = holiday.ObservedDate.Date;
                if (!dates.Contains(date)) dates.Add(date);
            }
            dates.Sort();
            return dates;
        }

        /// <summary>
        /// Public holiday names (in the local language) for the configured <see cref="Canton"/>.
        /// </summary>
        /// <param name="year">The year.</param>
        public override IDictionary<DateTime, string[]> PublicHolidayNames(int year)
        {
            var names = new SortedDictionary<DateTime, List<string>>();
            foreach (var holiday in PublicHolidaysInformation(year))
            {
                var date = holiday.ObservedDate.Date;
                List<string> existing;
                if (!names.TryGetValue(date, out existing))
                {
                    existing = new List<string>();
                    names.Add(date, existing);
                }
                existing.Add(holiday.Name);
            }
            var result = new SortedDictionary<DateTime, string[]>();
            foreach (var pair in names)
            {
                result.Add(pair.Key, pair.Value.ToArray());
            }
            return result;
        }

        /// <summary>
        /// Check if a specific date is a public holiday in the configured <see cref="Canton"/>.
        /// </summary>
        /// <param name="dt">The date you wish to check</param>
        /// <returns>True if date is a public holiday</returns>
        public override bool IsPublicHoliday(DateTime dt)
        {
            var date = dt.Date;
            foreach (var holiday in PublicHolidaysInformation(dt.Year))
            {
                if (holiday.ObservedDate.Date == date) return true;
            }
            return false;
        }

        // For constructor
        private readonly bool _hasSecondJanuary = false;
        private readonly bool _hasLabourDay = false;
        private readonly bool _hasCorpusChristi = false;

        /// <summary>
        /// Constructor for two major Swiss variants: 
        /// </summary>
        public SwitzerlandPublicHoliday(
            bool hasSecondJanuary = false,
            bool hasLaborDay = false,
            bool hasCorpusChristi = false)
        {
            _hasSecondJanuary = hasSecondJanuary;
            _hasLabourDay = hasLaborDay;
            _hasCorpusChristi = hasCorpusChristi;
        }
    }
}
