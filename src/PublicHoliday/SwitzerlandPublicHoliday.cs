using System;
using System.Collections.Generic;
using System.Linq;

namespace PublicHoliday
{

    /// <summary>
    /// Switzerland's holiday calendar. Oliver Fritz, May 2018.
    /// Updated according to https://en.wikipedia.org/wiki/Public_holidays_in_Switzerland. Christophe Peugnet, April 2024
    /// </summary>
    public class SwitzerlandPublicHoliday : PublicHolidayBase
    {
        #region cantons
        /// <summary>
        /// Gets or sets the canton (ISO 3166-2:CH), + default All for all Canton.
        /// </summary>
        public Cantons Canton { get; set; }

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
            return new Holiday(holiday, "New Year", "Neujahrstag");
        }

        #endregion 

        #region Berchtold's Day
        /// <summary>
        /// January 2, Berchtoldstag
        /// </summary>
        /// <param name="year"></param>
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
                {
                    cantonsName.Add(name);
                }
            }
            
            return new Holiday(holiday, "Berchtold's Day", "Berchtoldstag", cantonsName.ToArray());
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
                {
                    cantonsName.Add(name);
                }
            }

            return new Holiday(holiday, "Epiphany", "Epiphanie", cantonsName.ToArray());
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
                {
                    cantonsName.Add(name);
                }
            }

            return new Holiday(holiday, "Republic Day", "Bundesfeier", cantonsName.ToArray());
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
                {
                    cantonsName.Add(name);
                }
            }

            return new Holiday(holiday, "Saint Joseph's Day", "Josefstag", cantonsName.ToArray());
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

            var cantonsName = new List<string>();

            foreach (Cantons canton in CantonsWithGoodFriday)
            {
                var name = GetCantonName(canton);

                if (!string.IsNullOrEmpty(name))
                {
                    cantonsName.Add(name);
                }
            }

            return new Holiday(holiday, "Good Friday", "Karfreitag", cantonsName.ToArray());
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
            var hol = HolidayCalculator.GetEaster(year);
            hol = hol.AddDays(1);
            return hol;
        }

        private static DateTime EasterMonday(DateTime easter)
        {
            return easter.AddDays(1);
        }

        private Holiday EasterMondayHoliday(DateTime easter)
        {
            DateTime holiday = EasterMonday(easter);

            var cantonsName = new List<string>();

            foreach (Cantons canton in CantonsWithEasterMonday)
            {
                var name = GetCantonName(canton);

                if (!string.IsNullOrEmpty(name))
                {
                    cantonsName.Add(name);
                }
            }

            return new Holiday(holiday, "Easter Monday", "Ostermontag", cantonsName.ToArray());
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
                {
                    cantonsName.Add(name);
                }
            }

            return new Holiday(holiday, "Labour Day", "Tag der Arbeit", cantonsName.ToArray());
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
            var hol = HolidayCalculator.GetEaster(year);
            hol = hol.AddDays(4 + (7 * 5));
            return hol;
        }

        private static DateTime Ascension(DateTime easter)
        {
            return easter.AddDays(4 + (7 * 5));
        }

        private static Holiday AscensionHoliday(DateTime easter)
        {
            DateTime holiday = Ascension(easter);
            return new Holiday(holiday, "Ascension Day", "Auffahrt");
        }

        #endregion

        #region Whit Monday

        /// <summary>
        /// Whit Monday - Monday after Whit Sunday
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime WhitMonday(int year)
        {
            var hol = HolidayCalculator.GetEaster(year);
            hol = hol.AddDays(7 * 7 + 1);
            return hol;
        }

        private static DateTime WhitMonday(DateTime easter)
        {
            return easter.AddDays(7 * 7 + 1);
        }

        private Holiday WhitMondayHoliday(DateTime easter)
        {
            DateTime holiday = WhitMonday(easter);

            var cantonsName = new List<string>();

            foreach (Cantons canton in CantonsWithWhitMonday)
            {
                var name = GetCantonName(canton);

                if (!string.IsNullOrEmpty(name))
                {
                    cantonsName.Add(name);
                }
            }

            return new Holiday(holiday, "Whit Monday", "Pfingstmontag", cantonsName.ToArray());
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
        /// <param name="year"></param>
        public static DateTime CorpusChristi(int year)
        {
            var hol = HolidayCalculator.GetEaster(year);
            //first Thursday after Trinity Sunday (Pentecost + 1 week)
            hol = hol.AddDays((7 * 8) + 4);
            return hol;
        }

        /// <summary>
        /// Fronleichnam - Corpus Christi
        /// </summary>
        /// <param name="easter"></param>
        /// <returns></returns>
        public static DateTime CorpusChristi(DateTime easter)
        {
            return easter.AddDays((7 * 8) + 4);
        }

        private Holiday CorpusChristiHoliday(DateTime easter)
        {
            DateTime holiday = CorpusChristi(easter);

            var cantonsName = new List<string>();

            foreach (Cantons canton in CantonsWithCorpusChristi)
            {
                var name = GetCantonName(canton);

                if (!string.IsNullOrEmpty(name))
                {
                    cantonsName.Add(name);
                }
            }

            return new Holiday(holiday, "Corpus Christi", "Fronleichnam", cantonsName.ToArray());
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
            return new Holiday(holiday, "National Day", "Bundesfeier");
        }

        #endregion

        #region Assumption of Mary

        /// <summary>
        /// Mariä Himmelfahrt - Assumption of Mary
        /// </summary>
        /// <param name="year"></param>
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
                {
                    cantonsName.Add(name);
                }
            }

            return new Holiday(holiday, "Assumption Day", "Mariä Himmelfahrt", cantonsName.ToArray());
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
        /// <param name="year"></param>
        public static DateTime GenevaPrayDay(int year)
        {
            var firstSundayOfSeptember = HolidayCalculator.FindOccurrenceOfDayOfWeek(new DateTime(year, 9, 1), DayOfWeek.Sunday, 1);
            return HolidayCalculator.FindPrevious(firstSundayOfSeptember, DayOfWeek.Thursday);
        }

        private Holiday GenevaPrayDayHoliday(int year)
        {
            DateTime holiday = GenevaPrayDay(year);

            var cantonsName = new List<string>();

            foreach (Cantons canton in CantonsWithGenevaPrayDay)
            {
                var name = GetCantonName(canton);

                if (!string.IsNullOrEmpty(name))
                {
                    cantonsName.Add(name);
                }
            }

            return new Holiday(holiday, "Geneva PrayDay", "Jeûne genevois", cantonsName.ToArray());
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
        /// <param name="year"></param>
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
                {
                    cantonsName.Add(name);
                }
            }

            return new Holiday(holiday, "All Saints Day", "Allerheiligen", cantonsName.ToArray());
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
        /// <param name="year"></param>
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
                {
                    cantonsName.Add(name);
                }
            }

            return new Holiday(holiday, "Immaculate Conception", "Unbefleckte Empfängnis", cantonsName.ToArray());
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
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime Christmas(int year)
        {
            return new DateTime(year, 12, 25);
        }

        private static Holiday ChristmasHoliday(int year)
        {
            DateTime holiday = Christmas(year);
            return new Holiday(holiday, "Christmas Day", "Weihnachten");
        }

        #endregion

        #region Saint Stephen's Day

        /// <summary>
        /// St Stephen's Day - December 26
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
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
                {
                    cantonsName.Add(name);
                }
            }

            return new Holiday(holiday, "St Stephen's Day", "Stephanstag", cantonsName.ToArray());
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
        /// Public holiday names in German.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public override IDictionary<DateTime, string> PublicHolidayNames(int year)
        {
            // avoids having to recalculate it each time for different public holidays :
            DateTime easter = HolidayCalculator.GetEaster(year);

            var bHols = new Dictionary<DateTime, string> { { NewYear(year), "Neujahrstag"} };

            if (_hasSecondJanuary || HasSecondJanuary) 
                bHols.Add(SecondJanuary(year), "Berchtoldstag");

            if (HasEpiphany) 
                bHols.Add(Epiphany(year), "Epiphany");

            if (HasRepublicDay)
                bHols.Add(RepublicDay(year), "Republic Day");

            if (HasStJosephDay)
                bHols.Add(StJosephDay(year), "Josefstag");

            if (HasGoodFriday) 
                bHols.Add(GoodFriday(easter), "Karfreitag");

            if (HasEasterMonday)
                bHols.Add(EasterMonday(easter), "Ostermontag");

            if (HasLabourDay || _hasLabourDay)
                bHols.Add(LabourDay(year), "Tag der Arbeit");

            bHols.Add(Ascension(easter), "Auffahrt");

            if (HasWhitMonday)
                bHols.Add(WhitMonday(easter), "Pfingstmontag");

            if (_hasCorpusChristi || HasCorpusChristi) 
                bHols.Add(CorpusChristi(easter), "Fronleichnam");

            bHols.Add(NationalDay(year), "Bundesfeier");

            if (HasAssumption)
                bHols.Add(Assumption(year), "Mariä Himmelfahrt");

            if (HasGenevaPrayDay)
                bHols.Add(GenevaPrayDay(year), "Geneva PrayDay");

            if (HasAllSaints)
                bHols.Add(AllSaints(year), "Allerheiligen");

            if (HasImmaculateConception)
                bHols.Add(ImmaculateConception(year), "Immaculate Conception");

            bHols.Add(Christmas(year), "Weihnachten");

            if (HasSaintStephensDay)
                bHols.Add(SaintStephensDay(year), "Stephanstag");

            return bHols;
        }


        /// <summary>
        /// Check if a specific date is a public holiday.
        /// Obviously the PublicHoliday list is more efficient for repeated checks
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
        public override IList<Holiday> PublicHolidaysInformation(int year)
        {
            // avoids having to recalculate it each time for different public holidays :
            var easter = HolidayCalculator.GetEaster(year);

            var bHols = new List<Holiday>
            {
                NewYearHoliday(year),
                SecondJanuaryHoliday(year),
                EpiphanyHoliday(year),
                RepublicDayHoliday(year),
                StJosephDayHoliday(year),
                GoodFridayHoliday(easter),
                EasterMondayHoliday(easter),
                LabourDayHoliday(year),
                AscensionHoliday(easter),
                WhitMondayHoliday(easter),
                CorpusChristiHoliday(easter),
                NationalDayHoliday(year),
                AssumptionHoliday(year),
                GenevaPrayDayHoliday(year),
                AllSaintsHoliday(year),
                ImmaculateConceptionHoliday(year),
                ChristmasHoliday(year),
                SaintStephensDayHoliday(year)
            };

            return bHols;
        }

        // For constructor
        private readonly bool _hasSecondJanuary = false;
        private readonly bool _hasLabourDay = false;
        private readonly bool _hasCorpusChristi = false;

        /// <summary>
        /// Constructor for two major Swiss variants: 
        /// </summary>
        /// <param name="hasSecondJanuary"></param>
        /// <param name="hasLaborDay"></param>
        /// <param name="hasCorpusChristi"></param>
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
