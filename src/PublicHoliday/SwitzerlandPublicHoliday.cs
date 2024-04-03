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
        /// <summary>
        /// Gets or sets the canton (ISO 3166-2:CH), + default All for all Canton.
        /// </summary>
        public Cantons Canton { get; set; }

        /// <summary>
        ///
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

        #region Individual Holidays

        /// <summary>
        /// New Year's Day January 1
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime NewYear(int year)
        {
            return new DateTime(year, 1, 1);
        }

        /// <summary>
        /// January 2, Berchtoldstag
        /// </summary>
        /// <param name="year"></param>
        /// <returns>Date of this holiday in given year</returns>
        public static DateTime SecondJanuary(int year)
        {
            return new DateTime(year, 1, 2);
        }

        /// <summary>
        /// Whether this cantons observes SecondJanuary
        /// </summary>
        /// <value>
        /// <c>true</c> if this canton observes SecondJanuary; otherwise, <c>false</c>.
        /// </value>
        public bool HasSecondJanuary => Array.IndexOf(new[] {
            Cantons.ALL, Cantons.AG, Cantons.BE, Cantons.FR, Cantons.GL, Cantons.JU, Cantons.NE, Cantons.OW, Cantons.SH, Cantons.SO, Cantons.TG, Cantons.VD, Cantons.ZG, Cantons.ZH }, Canton) > -1;


        /// <summary>
        /// Epiphany - 13 days after christmas
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime Epiphany(int year)
        {
            return new DateTime(year, 1, 6);
        }

        /// <summary>
        /// Whether this cantons observes Epiphany
        /// </summary>
        /// <value>
        /// <c>true</c> if this canton observes Epiphany; otherwise, <c>false</c>.
        /// </value>
        public bool HasEpiphany => Array.IndexOf(new[] {
            Cantons.ALL,
            Cantons.GR,
            Cantons.LU,
            Cantons.SZ,
            Cantons.TI,
            Cantons.UR,
        }, Canton) > -1;


        /// <summary>
        /// Republic Day Neuchatel - 1. March
        /// </summary>
        /// <param name="year">Republic Day of Neuchatel</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime RepublicDay(int year)
        {
            return new DateTime(year, 3, 1);
        }

        /// <summary>
        /// Whether this cantons observes RepublicDay
        /// </summary>
        /// <value>
        /// <c>true</c> if this canton observes RepublicDay; otherwise, <c>false</c>.
        /// </value>
        public bool HasRepublicDay => Array.IndexOf(new[] {
            Cantons.ALL,
            Cantons.NE,
        }, Canton) > -1;




        /// <summary>
        ///  St Joseph's Day - 19 March
        /// </summary>
        /// <param name="year">St Joseph's Day</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime StJosephDay(int year)
        {
            return new DateTime(year, 3, 19);
        }

        /// <summary>
        /// Whether this cantons observes St Joseph's Day
        /// </summary>
        /// <value>
        /// <c>true</c> if this canton observes St Joseph's Day; otherwise, <c>false</c>.
        /// </value>
        public bool HasStJosephDay => Array.IndexOf(new[] {
            Cantons.ALL,
            Cantons.GR,
            Cantons.NW,
            Cantons.SZ,
            Cantons.SO,
            Cantons.TI,
            Cantons.UR,
            Cantons.VS,
        }, Canton) > -1;
         


        /// <summary>
        /// Good Friday - Friday before Easter
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime GoodFriday(int year)
        {
            var hol = HolidayCalculator.GetEaster(year);
            hol = hol.AddDays(-2);
            return hol;
        }

        private static DateTime GoodFriday(DateTime easter)
        {
            return easter.AddDays(-2);
        }

        /// <summary>
        /// Whether this cantons observes GoodFriday
        /// </summary>
        /// <value>
        /// <c>true</c> if this canton observes GoodFriday; otherwise, <c>false</c>.
        /// </value>
        public bool HasGoodFriday => Array.IndexOf(new[] {
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
        }, Canton) > -1;


        /// <summary>
        /// Easter
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime Easter(int year)
        {
            return HolidayCalculator.GetEaster(year);
        }

        
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

        /// <summary>
        /// Whether this cantons observes Easter Monday
        /// </summary>
        /// <value>
        /// <c>true</c> if this canton observes Easter Monday; otherwise, <c>false</c>.
        /// </value>
        public bool HasEasterMonday => Array.IndexOf(new[] {
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
        }, Canton) > -1;


        /// <summary>
        /// Labour Day - Mai 1st
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime LabourDay(int year)
        {
            return new DateTime(year, 5, 1);
        }

        /// <summary>
        /// Whether this cantons observes Labour Day
        /// </summary>
        /// <value>
        /// <c>true</c> if this canton observes Labour Day; otherwise, <c>false</c>.
        /// </value>
        public bool HasLabourDay => Array.IndexOf(new[] {
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
        }, Canton) > -1;


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


        /// <summary>
        /// Whit Sunday - 7th Sunday after Easter
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime WhitSunday(int year)
        {
            var hol = HolidayCalculator.GetEaster(year);
            hol = hol.AddDays(7 * 7);
            return hol;
        }

        private static DateTime WhitSunday(DateTime easter)
        {
            return easter.AddDays(7 * 7);
        }


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

        /// <summary>
        /// Whether this cantons observes Whit Monday
        /// </summary>
        /// <value>
        /// <c>true</c> if this canton observes Whit Monday; otherwise, <c>false</c>.
        /// </value>
        public bool HasWhitMonday => Array.IndexOf(new[] {
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
        }, Canton) > -1;
        

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

        /// <summary>
        /// Whether this cantons observes Corpus Christi
        /// </summary>
        /// <value>
        /// <c>true</c> if this canton observes Corpus Christi; otherwise, <c>false</c>.
        /// </value>
        public bool HasCorpusChristi => Array.IndexOf(new[] {
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
        }, Canton) > -1;


        /// <summary>
        /// National Day - August 1st
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime NationalDay(int year)
        {
            return new DateTime(year, 8, 1);
        }


        /// <summary>
        /// Mariä Himmelfahrt - Assumption of Mary
        /// </summary>
        /// <param name="year"></param>
        public static DateTime Assumption(int year)
        {
            return new DateTime(year, 8, 15);
        }

        /// <summary>
        /// Whether this cantons observes Assumption of Mary
        /// </summary>
        /// <value>
        /// <c>true</c> if this canton observes Assumption of Mary; otherwise, <c>false</c>.
        /// </value>
        public bool HasAssumption => Array.IndexOf(new[] {
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
        }, Canton) > -1;



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

        /// <summary>
        /// Whether this cantons observes Geneva PrayDay
        /// </summary>
        /// <value>
        /// <c>true</c> if this canton observes Geneva PrayDay; otherwise, <c>false</c>.
        /// </value>
        public bool HasGenevaPrayDay => Array.IndexOf(new[] {
            Cantons.ALL,
            Cantons.GE,
        }, Canton) > -1;


        /// <summary>
        /// Allerheiligen - All Saints
        /// </summary>
        /// <param name="year"></param>
        public static DateTime AllSaints(int year)
        {
            return new DateTime(year, 11, 1);
        }

        /// <summary>
        /// Whether this canton observes Allerheiligen
        /// </summary>
        /// <value>
        /// <c>true</c> if this canton observes Allerheiligen; otherwise, <c>false</c>.
        /// </value>
        public bool HasAllSaints => Array.IndexOf(new[] {
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
        }, Canton) > -1;

        //
        /// <summary>
        /// Immaculate Conception
        /// </summary>
        /// <param name="year"></param>
        public static DateTime ImmaculateConception(int year)
        {
            return new DateTime(year, 12, 8);
        }

        /// <summary>
        /// Whether this canton observes Immaculate Conception
        /// </summary>
        /// <value>
        /// <c>true</c> if this canton observes Immaculate Conception; otherwise, <c>false</c>.
        /// </value>
        public bool HasImmaculateConception => Array.IndexOf(new[] {
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
        }, Canton) > -1;


        /// <summary>
        /// Christmas Eve - December 24
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime ChristmasEve(int year)
        {
            return new DateTime(year, 12, 24);
        }

        /// <summary>
        /// Christmas - December 25
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime Christmas(int year)
        {
            return new DateTime(year, 12, 25);
        }

        /// <summary>
        /// St Stephen's Day - December 26
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime SaintStephensDay(int year)
        {
            return new DateTime(year, 12, 26);
        }

        /// <summary>
        /// Whether this canton observes St Stephen's Day
        /// </summary>
        /// <value>
        /// <c>true</c> if this canton observes St Stephen's Day; otherwise, <c>false</c>.
        /// </value>
        public bool HasSaintStephensDay => Array.IndexOf(new[] {
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
        }, Canton) > -1;

        /// <summary>
        /// New Years Eve - December 31
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime NewYearsEve(int year)
        {
            return new DateTime(year, 12, 31);
        }

        #endregion


    
        /// <summary>
        /// Get a list of dates for all holidays in a year.
        /// </summary>
        /// <param name="year">The year</param>
        /// <returns>List of public holidays</returns>
        public override IList<DateTime> PublicHolidays(int year)
        {
            return PublicHolidayNames(year).Select(x => x.Key).OrderBy(x => x).ToList();
        }

        /// <summary>
        /// Public holiday names in German.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public override IDictionary<DateTime, string> PublicHolidayNames(int year)
        {
            DateTime easter = HolidayCalculator.GetEaster(year);

            var bHols = new Dictionary<DateTime, string> { { NewYear(year), "Neujahrstag"} };

            if (_hasSecondJanuary || HasSecondJanuary) 
                bHols.Add(SecondJanuary(year), "Berchtoldstag");

            if (HasEpiphany) 
                bHols.Add(Epiphany(year), "Epiphany");

            if (HasRepublicDay)
                bHols.Add(RepublicDay(year), "Republic Day");

            if (HasStJosephDay)
                bHols.Add(StJosephDay(year), "Saint Joseph's Day");

            if (HasGoodFriday) 
                bHols.Add(GoodFriday(easter), "Karfreitag");

            //bHols.Add(Easter(), "Ostern"); // ?? no !
            
            if (HasEasterMonday)
                bHols.Add(EasterMonday(easter), "Ostermontag");

            if (HasLabourDay || _hasLabourDay)
                bHols.Add(LabourDay(year), "Tag der Arbeit");

            bHols.Add(Ascension(easter), "Auffahrt");

            //bHols.Add(WhitSunday(easter), "Pfingsten"); // ?? no !

            if (HasWhitMonday)
                bHols.Add(WhitMonday(easter), "Pfingstmontag");

            if (_hasCorpusChristi || HasCorpusChristi) 
                bHols.Add(CorpusChristi(easter), "Fronleichnam");

            bHols.Add(NationalDay(year), "Bundesfeier");

            if (HasAssumption)
                bHols.Add(Assumption(year), "Assumption of Mary");

            if (HasGenevaPrayDay)
                bHols.Add(GenevaPrayDay(year), "Geneva PrayDay");

            if (HasAllSaints)
                bHols.Add(AllSaints(year), "Allerheiligen");

            if (HasImmaculateConception)
                bHols.Add(ImmaculateConception(year), "Immaculate Conception");

            bHols.Add(Christmas(year), "Weihnachten");

            if (HasSaintStephensDay)
                bHols.Add(SaintStephensDay(year), "Stephanstag");

            //if (_hasChristmasEve) bHols.Add(ChristmasEve(year), "Heiligabend"); // ?? no !
            //if (_hasNewYearsEve) bHols.Add(NewYearsEve(year), "Silvester"); // ?? no !

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


        // For constructor
        private bool _hasSecondJanuary = false;
        private bool _hasLabourDay = false;
        private bool _hasCorpusChristi = false;

        /// <summary>
        /// Constructor for two major Swiss variants: 
        /// </summary>
        /// <param name="hasSecondJanuary"></param>
        /// <param name="hasLaborDay"></param>
        /// <param name="hasCorpusChristi"></param>
        public SwitzerlandPublicHoliday(
            bool hasSecondJanuary = false,
            bool hasLaborDay = false,
            bool hasCorpusChristi = false,
            bool hasChristmasEve = false,
            bool hasNewYearsEve = false)
        {
            _hasSecondJanuary = hasSecondJanuary;
            _hasLabourDay = hasLaborDay;
            _hasCorpusChristi = hasCorpusChristi;
        }
    }
}
