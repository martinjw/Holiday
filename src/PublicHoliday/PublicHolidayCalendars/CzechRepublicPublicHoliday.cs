using System;
using System.Collections.Generic;
using PublicHoliday.HolidayDefinitions;
using PublicHoliday.HolidayDefinitions.Christian;
using Christian = PublicHoliday.HolidayDefinitions.Christian;
using Common = PublicHoliday.HolidayDefinitions.Common;
using CS = PublicHoliday.HolidayDefinitions.CountrySpecific.Czechoslovakia;
using Local = PublicHoliday.HolidayDefinitions.CountrySpecific.CzechRepublic;
using PublicHoliday.HolidayDefinitions.Base;
using System.Globalization;
using PublicHoliday.Localization;

namespace PublicHoliday
{
    /// <summary>
    /// Holidays in Czech Republic
    /// Based on czech holiday law
    /// also from historical "holiday law" during Czechoslovakia: 248/1946
    /// </summary>
    public class CzechRepublicPublicHoliday : PublicHolidayBase
    {

        /// <summary>
        /// Culture whose language this calendar's holiday names are in: Czech.
        /// Used by <see cref="Holiday.GetName(CultureInfo)"/> when the requested
        /// culture has no translation.
        /// </summary>
        protected override CultureInfo CountryCulture => _defaultCulture;

        private static readonly CultureInfo _defaultCulture = SafeCulture.Get("cs-CZ", "cs");
        #region Individual Holidays

        /// <summary>
        /// Nový rok - New Year's Day
        /// In 1994 there is another holiday this day, but this is still valid
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime NewYear(int year)
        {
            return new DateTime(year, 1, 1);
        }

        /// <summary>
        /// Den obnovy samostatného českého státu - Day of the establishment of independent Czech state
        /// Czechoslovakia split into the Czech Republic and Slovakia
        /// since 1994, but New Year's day is also valid in Czech Republic
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime EstablishmentDay(int year)
        {
            return new DateTime(year, 1, 1);
        }

        /// <summary>
        /// Svátek Tří králů - Epiphany (The Three Magi)
        /// Christian holiday in old times
        /// until 1951, since 1952 is not a holiday in Czech republic
        /// </summary>
        /// <returns>Date of in the given year.</returns>
        public static DateTime Epiphany(int year)
        {
            return new DateTime(year, 1, 6);
        }

        /// <summary>
        /// Velký pátek - Good Friday
        /// Valid between 1947 and 1951 (including), then cancelled and was introduced again since 2016
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime GoodFriday(int year)
        {
            return EasterCalculator.GoodFriday(EasterCalculator.GetEaster(year));
        }

        /// <summary>
        /// Pondělí Velikonoční - Easter Monday
        /// introduced in 1939, cancelled in 1946, then restored again in 1949
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime EasterMonday(int year)
        {
            return EasterCalculator.EasterMonday(EasterCalculator.GetEaster(year));
        }

        /// <summary>
        /// Svátek práce - International Workers' Day
        /// since 1952
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime WorkersDay(int year)
        {
            return new DateTime(year, 5, 1);
        }

        /// <summary>
        /// Den osvobození - Day of victory over fascism
        /// The end of World War II in Europe; initially celebrated one day later
        /// valid since 1992
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime VictoryWWIIDay(int year)
        {
            return new DateTime(year, 5, 8);
        }

        /// <summary>
        /// Výročí osvobození Československa Sovětskou armádou - Day of liberation of Czechoslovakia by Soviet army
        /// The end of World War II in Europe; initially celebrated on this day (because in Moscow time it was on 9th May)
        /// introduced in 1952, valid until 1991
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime LiberationDay(int year)
        {
            return new DateTime(year, 5, 9);
        }

        /// <summary>
        /// Nanebevstoupení Páně - Ascension
        /// <para>Christian historical holiday</para>
        /// </summary>
        /// <returns>Date of in the given year.</returns>
        public static DateTime Ascension(int year)
        {
            return EasterCalculator.AscensionDay(EasterCalculator.GetEaster(year));
        }

        /// <summary>
        /// Pondělí Svatodušní - Pentecost
        /// <para>Christian historical holiday</para>
        /// </summary>
        public static DateTime PentecostMonday(int year)
        {
            return EasterCalculator.WhitMonday(EasterCalculator.GetEaster(year));
        }

        /// <summary>
        /// Božího Těla - CorpusChristi
        /// <para>Christian historical holiday</para>
        /// </summary>
        /// <returns>Date of in the given year.</returns>
        public static DateTime CorpusChristi(int year)
        {
            return EasterCalculator.CorpusChristi(EasterCalculator.GetEaster(year));
        }

        /// <summary>
        /// Sv. apoštolů Petra a Pavla - Feast of Saints Peter and Paul
        /// <para>Christian historical holiday</para>
        /// </summary>
        /// <returns>Date of in the given year.</returns>
        public static DateTime SaintPeterAndPaul(int year)
        {
            return new DateTime(year, 6, 29);
        }

        /// <summary>
        /// Den slovanských věrozvěstů Cyrila a Metoděje - St. Cyril and Methodius Day
        /// Slavic missionaries Cyril (Constantine) and Metod (Methodius) came to Great Moravia (see also Glagolitic alphabet)
        /// introduced in 1990
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime CyrilAndMethodius(int year)
        {
            return new DateTime(year, 7, 5);
        }

        /// <summary>
        /// Burning at Stake of Jan Hus
        /// <para>Introduced in 2000 (by law after this holiday), valid since 2001</para>
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime BurningJanHus(int year)
        {
            return new DateTime(year, 7, 6);
        }

        /// <summary>
        /// Nanebevzetí Panny Marie - Assumption of Mary
        /// <para>Christian historical holiday</para>
        /// </summary>
        /// <returns>Date of in the given year.</returns>
        public static DateTime Assumption(int year)
        {
            return new DateTime(year, 8, 15);
        }

        /// <summary>
        /// Den české státnosti - Czech Statehood Day
        /// introduced in 2000 (245/2000 Sb.)
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime CzechStatehoodDay(int year)
        {
            return new DateTime(year, 9, 28);
        }

        /// <summary>
        /// Den znárodnění - Nationalization Day
        /// Old public holiday during the communist era: 1952-1974
        /// introduced in 1952 (by 93/1951 Sb.), cancelled in 1975 (last holiday was 1974)
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime NationalizationDay(int year)
        {
            return new DateTime(year, 10, 28);
        }

        /// <summary>
        /// Den vzniku samostatného československého státu - Day of Establishment of Independent Czecho-Slovak state
        /// introduced in 1988
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime IndependentCzechoSlovakiaDay(int year)
        {
            return new DateTime(year, 10, 28);
        }

        /// <summary>
        /// Svátek Všech Svatých - All Saints’ Day
        /// Cancelled since 1952
        /// </summary>
        /// <returns>Date of in the given year.</returns>
        public static DateTime AllSaints(int year)
        {
            return new DateTime(year, 11, 1);
        }

        /// <summary>
        /// Den boje za svobodu a demokracii - Struggle for Freedom and Democracy Day
        /// Commemorating the student demonstration against Nazi occupation in 1939,
        /// and especially the demonstration in 1989 in Bratislava and Prague
        /// considered to mark the beginning of the Velvet Revolution.
        /// valid since 2000, since the new law (245/2000 Sb.) was introduced , replacing the old law 93/1951 Sb.
        /// </summary>
        /// <returns>Date of in the given year.</returns>
        public static DateTime FreedomDemocracyDay(int year)
        {
            return new DateTime(year, 11, 17);
        }

        /// <summary>
        /// Sv. Neposkvrněného Početí Panny Marie - Immaculate Conception
        /// <para>Historical holiday</para>
        /// </summary>
        /// <para>Christian historical holiday</para>
        /// <returns>Date of in the given year.</returns>
        public static DateTime ImmaculateConception(int year)
        {
            return new DateTime(year, 12, 8);
        }

        /// <summary>
        /// Štědrý den - Christmas Eve
        /// Valid since 1990, before that it was not a public holiday
        /// </summary>
        /// <returns>Date of in the given year.</returns>
        public static DateTime ChristmasEve(int year)
        {
            return new DateTime(year, 12, 24);
        }

        /// <summary>
        /// První svátek vánoční - Christmas Day - 1st day of Christmas
        /// Literally, First Christmas Holiday
        /// </summary>
        /// <returns>Date of in the given year.</returns>
        public static DateTime ChristmasDay(int year)
        {
            return new DateTime(year, 12, 25);
        }

        /// <summary>
        /// Druhý svátek vánoční - St. Stephen's Day - 2nd day of Christmas
        /// Literally, Second Christmas Holiday
        /// in the older law it was named as "Hod Boží vánoční"
        /// </summary>
        /// <returns>Date of in the given year.</returns>
        public static DateTime StStephenDay(int year)
        {
            return new DateTime(year, 12, 26);
        }

        #endregion Individual Holidays

        // Year gates below follow the citation trail of the Czech(oslovak) holiday laws since 1925:
        // 65/1925 Sb. (Epiphany, Ascension, Corpus Christi, Sts Peter and Paul, Assumption,
        //   All Saints, Immaculate Conception, Christmas Day), 63/1939 Sb. (adds Easter Monday,
        //   Pentecost Monday, St Stephen's Day), 248/1946 Sb. (adds Good Friday; drops Easter and
        //   Pentecost Mondays), 78/1948 Sb. (restores Pentecost Monday 1948, Easter Monday 1949),
        // 93/1951 Sb. (communist era from 1952: adds Workers' Day, Soviet Liberation Day 9 May,
        //   Nationalization Day 28 Oct; cancels the church holidays and Good Friday),
        // 56/1975 Sb. (cancels Nationalization Day after 1974), 141/1988 Sb. (28 Oct becomes Day
        //   of the Independent Czecho-Slovak State from 1988), 167/1990 Sb. (adds Cyril and
        //   Methodius, Christmas Eve), 218/1991 Sb. (moves the liberation day from 9 to 8 May from
        //   1992), 245/2000 Sb. (renames 1 Jan, adds Jan Hus Day 2001, Statehood Day and
        //   17 Nov from 2000), 359/2015 Sb. (restores Good Friday from 2016).
        private static readonly HolidayDefinition[] Definitions =
        {
            new Common.NewYear { AppliesInYear = Until2000 },
            new Local.CzechStateEstablishmentDay { AppliesInYear = Since2001 },
            new Christian.Epiphany { AppliesInYear = UntilCommunistEra },
            new Christian.GoodFriday { AppliesInYear = GoodFridayYears },
            new Christian.EasterMonday { AppliesInYear = EasterMondayYears },
            new Christian.Ascension { AppliesInYear = UntilCommunistEra },
            new Christian.WhitMonday { AppliesInYear = PentecostMondayYears },
            new Christian.CorpusChristi { AppliesInYear = UntilCommunistEra },
            new Christian.SaintPeterAndPaul { AppliesInYear = UntilCommunistEra },
            new Christian.Assumption { AppliesInYear = UntilCommunistEra },
            new Common.LabourDay { AppliesInYear = Since1952 },
            new Common.VictoryInEuropeDay { AppliesInYear = Since1992 },
            new CS.SovietLiberationDay(),
            new CS.CyrilAndMethodiusDay { AppliesInYear = Since1990 },
            new Local.JanHusDay { AppliesInYear = Since2001 },
            new Local.CzechStatehoodDay { AppliesInYear = Since2000 },
            new CS.NationalizationDay(),
            new CS.IndependentCzechoslovakStateDay { AppliesInYear = Since1988 },
            new Christian.AllSaints { AppliesInYear = UntilCommunistEra },
            new CS.FreedomAndDemocracyDay { AppliesInYear = Since2000 },
            new Christian.ImmaculateConception { AppliesInYear = UntilCommunistEra },
            new Christian.ChristmasEve { AppliesInYear = Since1990 },
            new Christian.Christmas(),
            new Christian.SaintStephensDay { AppliesInYear = Since1939 },
        };

        private static bool UntilCommunistEra(int year) { return year <= 1951; }
        private static bool Since1939(int year) { return year >= 1939; }
        private static bool Since1952(int year) { return year >= 1952; }
        private static bool Since1988(int year) { return year >= 1988; }
        private static bool Since1990(int year) { return year >= 1990; }
        private static bool Since1992(int year) { return year >= 1992; }
        private static bool Since2000(int year) { return year >= 2000; }
        private static bool Since2001(int year) { return year >= 2001; }
        private static bool Until2000(int year) { return year <= 2000; }

        private static bool GoodFridayYears(int year)
        {
            // 248/1946 Sb. until the communist era; restored by 359/2015 Sb.
            return year >= 2016 || (year >= 1947 && year <= 1951);
        }

        private static bool EasterMondayYears(int year)
        {
            // introduced 1939, cancelled 1947-1948, restored 1949
            return (year >= 1939 && year <= 1946) || year >= 1949;
        }

        private static bool PentecostMondayYears(int year)
        {
            // introduced 1939, cancelled 1947, restored 1948, cancelled again from 1952
            return (year >= 1939 && year <= 1946) || (year >= 1948 && year <= 1951);
        }

        /// <summary>
        /// All public holidays of the year, with Czech names as used directly in the law
        /// (245/2000, 93/1951 and the older ones).
        /// </summary>
        /// <param name="year">The year</param>
        /// <returns>Every holiday of the year</returns>
        protected override IList<Holiday> PublicHolidaysComplete(int year)
        {
            var list = new List<Holiday>();
            foreach (var definition in Definitions)
            {
                list.AddRange(definition.Build(year));
            }
            return list;
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
            return IsPublicHolidayFromComplete(dt);
        }
    }
}
