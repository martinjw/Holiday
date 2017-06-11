using System;
using System.Collections.Generic;
using System.Linq;

namespace PublicHoliday
{
    /// <summary>
    /// Holidays in Czech Republic
    /// Based on czech holiday law
    /// also from historical "holiday law" during Czechoslovakia: 248/1946
    /// </summary>
    public class CzechRepublicPublicHoliday : PublicHolidayBase
    {
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
        /// <param name="year"></param>
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
            var hol = HolidayCalculator.GetEaster(year);
            hol = hol.AddDays(-2);
            return hol;
        }

        private static DateTime GoodFriday(DateTime easter)
        {
            return easter.AddDays(-2);
        }

        /// <summary>
        /// Pondělí Velikonoční - Easter Monday
        /// introduced in 1939, cancelled in 1946, then restored again in 1949
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
        /// <param name="year"></param>
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
        /// Pondělí Svatodušní - Pentecost
        /// <para>Christian historical holiday</para>
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

        /// <summary>
        /// Božího Těla - CorpusChristi
        /// <para>Christian historical holiday</para>
        /// </summary>
        /// <param name="year"></param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime CorpusChristi(int year)
        {
            var hol = HolidayCalculator.GetEaster(year);
            //first Thursday after Trinity Sunday (Pentecost + 1 week)
            hol = hol.AddDays((7 * 8) + 4);
            return hol;
        }
        private static DateTime CorpusChristi(DateTime easter)
        {
            return easter.AddDays((7 * 8) + 4);
        }


        /// <summary>
        /// Sv. apoštolů Petra a Pavla - Feast of Saints Peter and Paul
        /// <para>Christian historical holiday</para>
        /// </summary>
        /// <param name="year"></param>
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
        /// <param name="year"></param>
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
        /// <param name="year"></param>
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
        /// <param name="year"></param>
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
        /// <param name="year"></param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime ChristmasEve(int year)
        {
            return new DateTime(year, 12, 24);
        }

        /// <summary>
        /// První svátek vánoční - Christmas Day - 1st day of Christmas
        /// Literally, First Christmas Holiday
        /// </summary>
        /// <param name="year"></param>
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
        /// <param name="year"></param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime StStephenDay(int year)
        {
            return new DateTime(year, 12, 26);
        }

        #endregion Individual Holidays

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
        /// Public holiday names in Czech.
        /// Names are used directly from law (245/2000, 93/1951 and the older ones)
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public override IDictionary<DateTime, string> PublicHolidayNames(int year)
        {
            // citation of laws and changes about public holidays since 1925

            // 65/1925 Sb., od 15.4.1925
            // § 1
            // Posavadní předpisy o svátcích platí s výhradou ustanovení § 4 pro tyto dny: 1.leden, 6.leden, Nanebevstoupení Páně, 
            // Božího Těla, 29.červen, 15.srpen, 1.listopad, 8.prosinec a 25.prosinec.

            // 63/1939 Sb. ze dne 9.3.1939,
            // Posavadní předpisy o svátcích platí s výhradou ustanovení § 4 pro tyto dny: Nový rok, Sv. tří králů, pondělí velikonoční, 
            // Nanebevstoupení Páně, pondělí svatodušní, Božího Těla, Sv. apoštolů Petra a Pavla, Nanebevzetí Panny Marie, 
            // Všech Svatých, Neposkvrněného Početí Panny Marie, Hod Boží vánoční a druhý svátek vánoční."
            // New in 1939: Easter Monday
            //      pondělí svatodušní

            // od 1946, december 20, platnost od: 30.12.1946
            // Státně uznanými svátky jsou: Nový rok (1. leden), Sv. tří králů (6. leden), Velký pátek, Nanebevstoupení Páně, Božího Těla, 
            // Sv. apoštolů Petra a Pavla (29. červen), Nanebevzetí Panny Marie (15. srpen), Všech Svatých (1. listopad), 
            // Neposkvrněného Početí Panny Marie (8. prosinec), Hod Boží vánoční (25. prosinec) a druhý svátek vánoční (26. prosinec)
            // New in 1947: Good Friday
            // Cancelled: Easter Monday, Pentecost Monday, 

            // ZÁKON ZE DNE 7.4.1948, JÍMŽ SE MĚNÍ A DOPLŇUJE ZÁKON O ÚPRAVĚ SVÁTKOVÉHO PRÁVA
            // 28.4.1948 | Sbírka:  78/1948 Sb. | Částka:  32/1948
            //
            // "Státně uznanými svátky jsou: Nový rok (1. leden), Sv. tří králů (6. leden), 
            // Velký pátek, pondělí velikonoční, Nanebevstoupení Páně, pondělí svatodušní, Božího Těla, 
            // Sv. apoštolů Petra a Pavla (29. červen), Nanebevzetí Panny Marie (15. srpen), Všech Svatých (1. listopad), 
            // Neposkvrněného Početí Panny Marie (8. prosinec), Hod Boží vánoční (25. prosinec) a druhý svátek vánoční (26. prosinec)".
            // New in 1948: Easter Monday (since 1949), Pentecost Monday (since 1948)

            // Zákon ze dne 2.listopadu 1951 o státním svátku, o dnech pracovního klidu a o památných a významných dnech
            // od 6.12.1951
            // Státní svátek
            // Devátý květen, výročí osvobození Československa Sovětskou armádou, se prohlašuje za státní svátek republiky Československé.
            // (2) Ostatní dny pracovního klidu vedle nedělí jsou:
            // a) 1.leden(Nový rok),
            // b) pondělí velikonoční,
            // c) 1.květen(Svátek práce),
            // d) 28.říjen(Den znárodnění),
            // e) 25.prosinec(první svátek vánoční),
            // f) 26.prosinec(druhý svátek vánoční).
            // New since 1952: May 01, May 09, Oct 28
            // Cancelled since 1952: Epiphany, Good Friday, Nanebevstoupení Páně, pondělí svatodušní, Božího Těla, Sv. apoštolů Petra a Pavla (29. červen), Nanebevzetí Panny Marie (15. srpen), 
            //            Všech Svatých (1. listopad), Neposkvrněného Početí Panny Marie (8. prosinec) 

            // 56. Zákon ze dne 11.června 1975, kterým se mění zákon č. 93 / 1951 Sb., o státním svátku, o dnech pracovního klidu a o památných a významných dnech
            // od 23.6.1975
            // "(1) Státní svátek 9. květen je dnem pracovního klidu.
            // (2) Ostatní dny pracovního klidu vedle nedělí jsou:
            // a) 1.leden(Nový rok),
            // b) pondělí velikonoční,
            // c) 1.květen(Svátek práce),
            // d) 25.prosinec(první svátek vánoční),
            // e) 26.prosinec(druhý svátek vánoční).",
            // New: none
            // Cancelled: Den znárodnění (since 1975)

            // since 21.09.1988
            // Státní svátky: Devátý květen, výročí osvobození Československa Sovětskou armádou, a dvacátý osmý říjen, 
            // den vzniku samostatného československého státu, se prohlašují za státní svátky Československé socialistické republiky.".
            // New: den vzniku samostatného československého státu (valid since 1988)

            // since 10.05.1990
            // Dny 9. květen, den osvobození od fašismu, 5. červenec, den slovanských věrozvěstů Cyrila a Metoděje a 28. říjen, 
            // den vzniku samostatného československého státu se prohlašují za státní svátky České a Slovenské Federativní Republiky.".
            // (2) Ostatními dny pracovního klidu vedle nedělí jsou:
            // a) 1.leden(Nový rok),
            // b) pondělí velikonoční,
            // c) 1.květen(Svátek práce),
            // d) 24.prosinec(Štědrý den),
            // e) 25.prosinec(1.svátek vánoční),
            // f) 26.prosinec(2.svátek vánoční).".
            // New since 1990: Cyril and Methodus, Christmas Eve
            // Cancelled: none

            // since 31.05.1991
            // V § 1 se slova "9. květen" nahrazují slovy "8. květen".
            // Valid from 1992 (May 09 changed to May 08)

            //  ZÁKON ZE DNE 29.6.2000 O STÁTNÍCH SVÁTCÍCH, O OSTATNÍCH SVÁTCÍCH, O VÝZNAMNÝCH DNECH A O DNECH PRACOVNÍHO KLIDU
            // 9.8.2000 | Sbírka:  245 / 2000 Sb. | Částka:  73 / 2000

            // Státní svátky
            // Dny 1.leden - Den obnovy samostatného českého státu, 8.květen - Den osvobození, 5.červenec - Den slovanských věrozvěstů Cyrila a Metoděje, 
            // 6.červenec - Den upálení mistra Jana Husa, 28.září - Den české státnosti, 28.říjen - Den vzniku samostatného československého státu a 
            // 17.listopad - Den boje za svobodu a demokracii se prohlašují za státní svátky České republiky(dále jen "státní svátek").
            // Ostatní svátky
            // Ostatními svátky jsou 1.leden - Nový rok, Velikonoční pondělí, 1.květen - Svátek práce, 
            // 24.prosinec - Štědrý den, 25.prosinec - 1.svátek vánoční a 26.prosinec - 2.svátek vánoční(dále jen "ostatní svátek").

            // New: Den obnovy samostatného českého státu (different name as well), Den upálení mistra Jana Husa (6 July), 28.září - Den české státnosti, 17 Nov
            // Cancelled: None

            // od 21.12.2015
            // 359 ZÁKON ze dne 2.prosince 2015, kterým se mění zákon č. 245 / 2000 Sb., o státních svátcích, o ostatních svátcích, 
            // o významných dnech a o dnech pracovního klidu, ve znění pozdějších předpisů
            // V § 2 zákona č. 245/2000 Sb., o státních svátcích, o ostatních svátcích, o významných dnech a o dnech pracovního klidu, 
            // se za slova „1. leden - Nový rok,“ vkládají slova „Velký pátek,“.
            // New: Good Friday (since 2016)
            // Cancelled: None


            var bHols = new Dictionary<DateTime, string>();
            if (year < 2001)
                bHols.Add(NewYear(year), "Nový Rok"); // New Year only until 2000
            else
                bHols.Add(EstablishmentDay(year), "Den obnovy samostatného českého státu"); // Establishment day since 1994

            // only before 1952
            if (year <= 1951)
                bHols.Add(Epiphany(year), "Svátek Tří králů"); // Epiphany, before the communist era

            DateTime easter = HolidayCalculator.GetEaster(year);

            
            if (year >= 2016 || (year >= 1947 && year <= 1951))
                bHols.Add(GoodFriday(easter), "Velký Pátek"); // Good Friday

            if ((year >= 1939 && year <= 1946) || year >= 1949)
                bHols.Add(EasterMonday(easter), "Pondělí Velikonoční"); // Easter Monday


            // these are mostly older public holidays before the communism times, mostly Christian holidays
            if (year <= 1951)
                bHols.Add(Ascension(easter), "Svátek Nanebevstoupení Páně"); // Ascension

            if ((year >= 1939 && year <= 1946) || (year >= 1948 && year <= 1951))
                bHols.Add(PentecostMonday(easter), "Pondělí Svatodušní"); // Pentecost Monday

            if (year <= 1951)
                bHols.Add(CorpusChristi(easter), "Svátek Božího Těla"); // Corpus Christi

            if (year <= 1951)
                bHols.Add(SaintPeterAndPaul(year), "Svátek Sv.apoštolů Petra a Pavla"); // SaintPeterAndPaul

            if (year <= 1951)
                bHols.Add(Assumption(year), "Svátek Nanebevzetí Panny Marie"); // Assumption


            // those are now the newer holidays
            if (year >= 1952)
                bHols.Add(WorkersDay(year), "Svátek práce"); // Workers' Day

            if (year >= 1992)
                bHols.Add(VictoryWWIIDay(year), "Den osvobození"); // Victory over fascizm, since 1992

            // Day of liberation of Czechoslovakia by Soviet army, until 1991, in 1991 was renamed to Victory over fascizm,
            // but only in 1992 it was moved to May 08 instead of May 09, so we will tolerate this name change in one year
            if (year >= 1952 && year <= 1991)
                bHols.Add(LiberationDay(year), "Výročí osvobození Československa Sovětskou armádou");

            // introduced in 1990
            if (year >= 1990)
                bHols.Add(CyrilAndMethodius(year), "Den slovanských věrozvěstů Cyrila a Metoděje"); // Cyril and Methodius, only from 1990

            // introduced in 2001
            if (year >= 2001)
                bHols.Add(BurningJanHus(year), "Den upálení mistra Jana Husa"); // Burning at Stake of Jan Hus

            // 28.září - Den české státnosti
            if (year >= 2000)
                bHols.Add(CzechStatehoodDay(year), "Den české státnosti"); // Czech Statehood Day

            if (year >= 1952 && year <= 1974)
                bHols.Add(NationalizationDay(year), "Den znárodnění"); // Nationalization Day, old public holiday several years in the communist era

            if (year >= 1988)
                bHols.Add(IndependentCzechoSlovakiaDay(year), "Den vzniku samostatného československého státu"); // Day of Independent CzechoSlovakia, since 1988

            if (year <= 1951)
                bHols.Add(AllSaints(year), "Svátek Všech Svatých"); // All Saint's Day, not since the communist era

            if (year >= 2000)
                bHols.Add(FreedomDemocracyDay(year), "Den boje za svobodu a demokracii"); // Struggle for Freedom and Democracy Day (Velvet revolution)

            if (year <= 1951)
                bHols.Add(ImmaculateConception(year), "Svátek Neposkvrněného Početí Panny Marie"); // Immaculate Conception


            if (year >= 1990)
                bHols.Add(ChristmasEve(year), "Štědrý den"); // Christmas Eve

            bHols.Add(ChristmasDay(year), "První svátek vánoční");

            if (year >= 1939)
                bHols.Add(StStephenDay(year), "Druhý svátek vánoční");
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
            var year = dt.Year;
            var date = dt.Date;

            switch (dt.Month)
            {
                case 1:
                    if (year <= 2000 && NewYear(year) == date)
                        return true;
                    if (year >= 2001 && EstablishmentDay(year) == date)
                        return true;
                    if ((year <= 1951) && Epiphany(year) == date)
                        return true;
                    break;

                case 3:
                case 4:
                    if ((year >= 2016 || (year >= 1947 && year <= 1951)) && GoodFriday(year) == date)
                        return true;
                    if (((year >= 1939 && year <= 1946) || year >= 1949) && EasterMonday(year) == date)
                        return true;
                    break;

                case 5:
                    if ((year >= 1952) && WorkersDay(year) == date)
                        return true;
                    if ((year >= 1992) && VictoryWWIIDay(year) == date)
                        return true;
                    if ((year >= 1952 && year <= 1991) && LiberationDay(year) == date)
                        return true;
                    if ((year <= 1951) && Ascension(year) == date)
                        return true;
                    if (((year >= 1939 && year <= 1946) || (year >= 1948 && year <= 1951)) && PentecostMonday(year) == date)
                        return true;
                    if ((year <= 1951) && CorpusChristi(year) == date)
                        return true;
                    break;

                case 6:
                    if ((year <= 1951) && Ascension(year) == date)
                        return true;
                    if (((year >= 1939 && year <= 1946) || (year >= 1948 && year <= 1951)) && PentecostMonday(year) == date)
                        return true;
                    if ((year <= 1951) && CorpusChristi(year) == date)
                        return true;
                    if ((year <= 1951) && SaintPeterAndPaul(year) == date)
                        return true;
                    break;

                case 7:
                    if ((year >= 1990) && CyrilAndMethodius(year) == date)
                        return true;
                    if ((year >= 2001) && BurningJanHus(year) == date)
                        return true;
                    break;
                    
                case 8:
                    if ((year <= 1951) && Assumption(year) == date)
                        return true;
                    break;

                case 9:
                    if ((year >= 2000) && CzechStatehoodDay(year) == date)
                        return true;
                    break;

                case 10:
                    if ((year >= 1952 && year <= 1974) && NationalizationDay(year) == date)
                        return true;
                    if ((year >= 1988) && IndependentCzechoSlovakiaDay(year) == date)
                        return true;
                    break;

                case 11:
                    if ((year <= 1951) && AllSaints(year) == date)
                        return true;
                    if ((year >= 2000) && FreedomDemocracyDay(year) == date)
                        return true;
                    break;

                case 12:
                    if ((year <= 1951) && ImmaculateConception(year) == date)
                        return true;
                    if ((year >= 1990) && ChristmasEve(year) == date)
                        return true;
                    if (ChristmasDay(year) == date)
                        return true;
                    if ((year >= 1939) && StStephenDay(year) == date)
                        return true;
                    break;
            }

            return false;
        }
    }
}