using System;
using System.Collections.Generic;
using PublicHoliday.HolidayDefinitions;
using PublicHoliday.HolidayDefinitions.Christian;
using Christian = PublicHoliday.HolidayDefinitions.Christian;
using Common = PublicHoliday.HolidayDefinitions.Common;
using Local = PublicHoliday.HolidayDefinitions.CountrySpecific.Germany;
using PublicHoliday.HolidayDefinitions.Base;
using System.Globalization;
using PublicHoliday.Localization;
using PublicHoliday.Dates;

// ReSharper disable InconsistentNaming

namespace PublicHoliday
{
    /// <summary>
    /// German Federal (German Unity Day) and State Public Holidays (excluding Sundays)
    /// </summary>
    public class GermanPublicHoliday : PublicHolidayBase
    {

        /// <summary>
        /// Culture whose language this calendar's holiday names are in: German.
        /// Used by <see cref="Holiday.GetName(CultureInfo)"/> when the requested
        /// culture has no translation.
        /// </summary>
        protected override CultureInfo CountryCulture => _defaultCulture;

        private static readonly CultureInfo _defaultCulture = SafeCulture.Get("de-DE", "de");
        /// <summary>
        /// Gets or sets the state (ISO 3166-2:DE), + default All for all states.
        /// </summary>
        public States State
        {
            get { return _state; }
            set { _state = value; ClearHolidayCache(); }
        }
        private States _state;

        /// <summary>
        ///
        /// </summary>
        public enum States
        {
            /// <summary>
            /// All states
            /// </summary>
            ALL = 0,

            /// <summary>
            /// Baden-Württemberg
            /// </summary>
            BW,

            /// <summary>
            /// Bayern, Bavaria
            /// </summary>
            BY,

            /// <summary>
            /// Berlin
            /// </summary>
            BE,

            /// <summary>
            /// Brandenburg
            /// </summary>
            BB,

            /// <summary>
            /// Bremen
            /// </summary>
            HB,

            /// <summary>
            /// Hamburg
            /// </summary>
            HH,

            /// <summary>
            /// Hessen, Hesse
            /// </summary>
            HE,

            /// <summary>
            /// Mecklenburg-Vorpommern
            /// </summary>
            MV,

            /// <summary>
            /// Niedersachsen, Lower Saxony
            /// </summary>
            NI,

            /// <summary>
            /// Nordrhein-Westfalen, North Rhine-Westphalia
            /// </summary>
            NW,

            /// <summary>
            /// Rheinland-Pfalz, Rhineland-Palatinate
            /// </summary>
            RP,

            /// <summary>
            /// Saarland
            /// </summary>
            SL,

            /// <summary>
            /// Sachsen, Saxony
            /// </summary>
            SN,

            /// <summary>
            /// Sachsen-Anhalt
            /// </summary>
            ST,

            /// <summary>
            /// Schleswig-Holstein
            /// </summary>
            SH,

            /// <summary>
            /// Thüringen
            /// </summary>
            TH,
        }

        /// <summary>
        /// Neujahrstag New Year's Day January 1
        /// </summary>

        public static DateTime NewYear(int year)
        {
            return new DateTime(year, 1, 1);
        }

        /// <summary>
        /// Heilige Drei Könige Epiphany January 6
        /// </summary>

        public static DateTime Epiphany(int year)
        {
            return new DateTime(year, 1, 6);
        }

        /// <summary>
        /// Whether this state observes epiphany.
        /// </summary>
        /// <value>
        /// <c>true</c> if this state observes epiphany; otherwise, <c>false</c>.
        /// </value>
        public bool HasEpiphany => Array.IndexOf(new[] { States.BW, States.BY, States.ST }, State) > -1;

        /// <summary>
        /// Karfreitag - Good Friday
        /// </summary>
        public static DateTime GoodFriday(int year)
        {
            return EasterCalculator.GoodFriday(EasterCalculator.GetEaster(year));
        }

        /// <summary>
        /// Ostersonntag - Easter Sunday
        /// </summary>
        public static DateTime EasterSunday(int year)
        {
            var hol = EasterCalculator.GetEaster(year);
            return hol;
        }

        /// <summary>
        /// Whether this state observes Ostersonntag.
        /// </summary>
        /// <value>
        /// <c>true</c> if this state observes Ostersonntag; otherwise, <c>false</c>.
        /// </value>
        public bool HasEasterSunday => States.BB == State;

        /// <summary>
        /// Ostermontag - Easter Monday
        /// </summary>
        public static DateTime EasterMonday(int year)
        {
            return EasterCalculator.EasterMonday(EasterCalculator.GetEaster(year));
        }

        /// <summary>
        /// Tag der Arbeit - Labour Day
        /// </summary>
        /// <param name="year">The year.</param>

        public static DateTime MayDay(int year)
        {
            return new DateTime(year, 5, 1);
        }

        /// <summary>
        /// Christi Himmelfahrt - Ascension
        /// </summary>

        public static DateTime Ascension(int year)
        {
            return EasterCalculator.AscensionDay(EasterCalculator.GetEaster(year));
        }

        /// <summary>
        /// Pfingstsonntag - Pentecost Sunday
        /// </summary>
        public static DateTime PentecostSunday(int year)
        {
            return EasterCalculator.WhitSunday(EasterCalculator.GetEaster(year));
        }

        /// <summary>
        /// Whether this state observes Pfingstsonntag.
        /// </summary>
        /// <value>
        /// <c>true</c> if this state observes Pfingstsonntag; otherwise, <c>false</c>.
        /// </value>
        public bool HasPentecostSunday => States.BB == State;

        /// <summary>
        /// Pfingstmontag - Pentecost
        /// </summary>

        public static DateTime PentecostMonday(int year)
        {
            return EasterCalculator.WhitMonday(EasterCalculator.GetEaster(year));
        }

        /// <summary>
        /// Fronleichnam - CorpusChristi
        /// </summary>

        public static DateTime CorpusChristi(int year)
        {
            return EasterCalculator.CorpusChristi(EasterCalculator.GetEaster(year));
        }

        /// <summary>
        /// Whether this state observes Fronleichnam.
        /// </summary>
        /// <value>
        /// <c>true</c> if this state observes Fronleichnam; otherwise, <c>false</c>.
        /// </value>
        public bool HasCorpusChristi => Array.IndexOf(new[] { States.BW, States.BY, States.HE, States.NW, States.RP, States.SL }, State) > -1;

        /// <summary>
        /// Mariä Himmelfahrt - Assumption of Mary
        /// </summary>
        public static DateTime Assumption(int year)
        {
            return new DateTime(year, 8, 15);
        }

        private bool? _hasAssumption;
        /// <summary>
        /// Whether this state observes Mariä Himmelfahrt.
        /// </summary>
        /// <value>
        /// <c>true</c> if this state observes Mariä Himmelfahrt; otherwise, <c>false</c>.
        /// </value>
        public bool HasAssumption
        {
            get
            {
                //if they set manually, override the state default
                if(_hasAssumption.HasValue) return _hasAssumption.Value;
                return States.SL == State || States.BY == State;
            }
            set { _hasAssumption = value; ClearHolidayCache(); }
        }

        /// <summary>
        /// Kindertag - World Children's Day
        /// </summary>
        public static DateTime WorldChildrensDay(int year)
        {
            return new DateTime(year, 9, 20);
        }

        /// <summary>
        /// Whether this state observes Kindertag
        /// </summary>
        public bool HasWorldChildrensDay(int year)
        {
            return year >= 2019 && State == States.TH;
        }


        /// <summary>
        /// Tag der Deutschen Einheit - German Unity
        /// </summary>
        public static DateTime GermanUnity(int year)
        {
            return new DateTime(year, 10, 3);
        }

        /// <summary>
        /// Reformationstag - Reformation
        /// </summary>
        public static DateTime Reformation(int year)
        {
            return new DateTime(year, 10, 31);
        }

        /// <summary>
        /// Whether this state observes Reformationstag
        /// </summary>
        /// <value>
        /// <c>true</c> if this state observes Reformationstag; otherwise, <c>false</c>.
        /// </value>
        public bool HasReformation => Array.IndexOf(new[] { States.BB, States.MV, States.SN, States.ST, States.TH, States.HB, States.HH, States.NI, States.SH }, State) > -1;

        /// <summary>
        /// Allerheiligen - All Saints
        /// </summary>

        public static DateTime AllSaints(int year)
        {
            return new DateTime(year, 11, 1);
        }

        /// <summary>
        /// Whether this state observes Allerheiligen
        /// </summary>
        /// <value>
        /// <c>true</c> if this state observes Allerheiligen; otherwise, <c>false</c>.
        /// </value>
        public bool HasAllSaints => Array.IndexOf(new[] { States.BW, States.BY, States.NW, States.RP, States.SL }, State) > -1;

        /// <summary>
        /// Buß- und Bettag - Repentance and Prayer
        /// </summary>
        public static DateTime Repentance(int year)
        {
            //Second Wednesday before the First Advent
            //first advent =  last Thursday of November + 3 days
            var firstAdvent = HolidayCalculator.FindPrevious(new DateTime(year, 11, 30), DayOfWeek.Thursday).AddDays(3);
            var wednesday = HolidayCalculator.FindPrevious(firstAdvent.AddDays(-7), DayOfWeek.Wednesday);
            return wednesday;
        }

        /// <summary>
        /// Whether this state observes Buß- und Bettag
        /// </summary>
        /// <value>
        /// <c>true</c> if this state observes Buß- und Bettag; otherwise, <c>false</c>.
        /// </value>
        public bool HasRepentance => States.SN == State;

        /// <summary>
        /// Weihnachtstag - Christmas
        /// </summary>

        public static DateTime Christmas(int year)
        {
            return new DateTime(year, 12, 25);
        }

        /// <summary>
        /// Zweiter Weihnachtsfeiertag- St Stephens
        /// </summary>

        public static DateTime StStephen(int year)
        {
            return new DateTime(year, 12, 26);
        }

        /// <summary>
        /// Whether this state observes Womens Day/Weltfrauentag (March 8)
        /// </summary>
        public bool HasWomensDay(int year) => State == States.BE && year >= 2019 || State == States.MV && year >= 2023;

        /// <summary>
        /// International Women's Day/ Weltfrauentag
        /// </summary>
        public static DateTime WomensDay(int year)
        {
            return new DateTime(year, 3, 8);
        }

        /// <summary>
        /// Liberation Day/ Tag der Befreiung
        /// </summary>
        public static DateTime LiberationDay(int year)
        {
            return new DateTime(year, 5, 8);
        }

        /// <summary>
        /// Whether this state observes Liberation Day/Tag der Befreiung (May 8)
        /// </summary>
        public bool HasLiberationDay(int year) => State == States.BE && year == 2025;

        /// <summary>
        /// East German Uprising Memorial Day / Gedenktag an den Volksaufstand in der DDR
        /// </summary>
        public static DateTime EastGermanUprisingMemorialDay(int year)
        {
            return new DateTime(year, 6, 17);
        }

        /// <summary>
        /// Whether this state observes East German Uprising Memorial Day / Gedenktag an den Volksaufstand in der DDR (June 17)
        /// </summary>
        public bool HasEastGermanUprisingMemorialDay(int year) => State == States.BE && year == 2028;

        /// <summary>
        /// Federal and state (for the configured <see cref="State"/>) holidays with names in German.
        /// </summary>
        private IEnumerable<HolidayDefinition> GetDefinitions()
        {
            yield return new Common.NewYear();
            if (HasEpiphany)
                yield return new Christian.Epiphany();
            yield return new Common.WomensDay { AppliesInYear = HasWomensDay };
            yield return new Christian.GoodFriday();
            if (HasEasterSunday)
                yield return new Christian.EasterSunday();
            yield return new Christian.EasterMonday();
            yield return new Common.LabourDay();
            yield return new Local.LiberationDay2025 { AppliesInYear = HasLiberationDay };
            yield return new Christian.Ascension();
            if (HasPentecostSunday)
                yield return new Christian.WhitSunday();
            yield return new Christian.WhitMonday();
            if (HasCorpusChristi)
                yield return new Christian.CorpusChristi();
            yield return new Local.EastGermanUprisingMemorialDay2028 { AppliesInYear = HasEastGermanUprisingMemorialDay };
            if (HasAssumption)
                yield return new Christian.Assumption();
            yield return new Local.WorldChildrensDay { AppliesInYear = HasWorldChildrensDay };
            yield return new Local.GermanUnityDay();
            //all states observed Reformation Day in 2017, the 500th anniversary
            yield return new Christian.ReformationDay { AppliesInYear = ObservesReformation };
            if (HasAllSaints)
                yield return new Christian.AllSaints();
            if (HasRepentance)
                yield return new Local.RepentanceDay();
            yield return new Christian.Christmas();
            yield return new Christian.SaintStephensDay();
        }

        private bool ObservesReformation(int year)
        {
            return HasReformation || year == 2017;
        }

        /// <summary>
        /// Federal and state (for the configured <see cref="State"/>) holidays with names in German.
        /// </summary>
        /// <param name="year">The year.</param>
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