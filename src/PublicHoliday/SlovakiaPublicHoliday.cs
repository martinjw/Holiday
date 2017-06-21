using System;
using System.Collections.Generic;
using System.Linq;

namespace PublicHoliday
{
    /// <summary>
    /// Holidays in Slovakia
    /// English translations and remarks used from: https://en.wikipedia.org/wiki/Public_holidays_in_Slovakia
    /// Slovak names used also from other sites
    /// verified from "holiday law": Zákon č. 241/1993 Z. z. Zákon Národnej rady Slovenskej republiky o štátnych sviatkoch, dňoch pracovného pokoja a pamätných dňoch
    /// available here: http://www.zakonypreludi.sk/zz/1993-241
    /// also from historical "holiday law" during Czechoslovakia 
    /// </summary>
    public class SlovakiaPublicHoliday : PublicHolidayBase
    {
        #region Individual Holidays

        /// <summary>
        /// Nový rok - New Year's Day
        /// until 1993, since 1994 there is a different public holiday
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime NewYear(int year)
        {
            return new DateTime(year, 1, 1);
        }

        /// <summary>
        /// Deň vzniku Slovenskej republiky - Day of the Establishment of the Slovak Republic
        /// Czechoslovakia split into the Czech Republic and Slovakia
        /// since 1994, before 1993 the name was New Year's Day
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime EstablishmentDay(int year)
        {
            return new DateTime(year, 1, 1);
        }

        /// <summary>
        /// Zjavenie Pána (Traja králi) - Epiphany (The Three Magi)
        /// </summary>
        /// <param name="year"></param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime Epiphany(int year)
        {
            return new DateTime(year, 1, 6);
        }

        /// <summary>
        /// Veľký piatok - Good Friday
        /// valid since 1994, before that only Easter Monday was a public holiday
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
        /// Veľkonočný pondelok - Easter Monday
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
        /// Sviatok práce - International Workers' Day
        /// historical sources say it was introduced in 1919, in this class it will be valid for all years
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime WorkersDay(int year)
        {
            return new DateTime(year, 5, 1);
        }

        /// <summary>
        /// Deň víťazstva nad fašizmom - Day of victory over fascism
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
        /// Výročie oslobodenia Československa Sovietskou armádou - Day of liberation of Czechoslovakia by Soviet army
        /// The end of World War II in Europe; initially celebrated on this day (because in Moscow time it was on 9th May)
        /// introduced in 1952 (by law 93/1951), valid until 1991
        /// source: Zákon č. 93/1951 Zb.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime LiberationDay(int year)
        {
            return new DateTime(year, 5, 9);
        }

        /// <summary>
        /// Sviatok svätého Cyrila a Metoda - St. Cyril and Methodius Day
        /// Slavic missionaries Cyril (Constantine) and Metod (Methodius) came to Great Moravia (see also Glagolitic alphabet)
        /// during the communist era it was cancelled (since 1952), reintroduced again in 1990
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime CyrilAndMethodius(int year)
        {
            return new DateTime(year, 7, 5);
        }

        /// <summary>
        /// Výročie Slovenského národného povstania (SNP) - Slovak National Uprising anniversary
        /// The Slovaks rose up against Nazi Germany
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime SNP(int year)
        {
            return new DateTime(year, 8, 29);
        }

        /// <summary>
        /// Deň Ústavy Slovenskej republiky - Day of the Constitution of the Slovak Republic
        /// The constitution of (future) independent Slovakia was adopted in Bratislava
        /// introduced by law since 1994
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime ConstitutionDay(int year)
        {
            return new DateTime(year, 9, 1);
        }

        /// <summary>
        /// Sviatok Panny Márie Sedembolestnej, patrónky Slovenska - Day of Our Lady of the Seven Sorrows, patron saint of Slovakia
        /// The Patron saint of Slovakia is Our Lady of the Seven Sorrows
        /// introduced in law since 1994
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime LadySevenSorrows(int year)
        {
            return new DateTime(year, 9, 15);
        }

        /// <summary>
        /// Deň znárodnenia - Nationalization Day
        /// Old public holiday during the communist era: 1952-1974
        /// introduced in 1952 (by law 93/1951), cancelled in 1975 (last holiday was 1974)
        /// source: Zákon č. 93/1951 Zb.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime NationalizationDay(int year)
        {
            return new DateTime(year, 10, 28);
        }

        /// <summary>
        /// Deň vzniku samostatného česko-slovenského štátu - Day of Establishment of Independent Czecho-Slovak state
        /// Old public holiday during the communist era and few years after Velvet revolution: 1988-1993
        /// introduced in 1988 (by modification of law 93/1951, by: Opatrenie č. 141/1988 Zb. valid from 21st September 1988)
        /// cancelled in 1994 by introducing a new law (last holiday was in 1993)
        /// source: Zákon č. 93/1951 Zb.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime IndependentCzechoSlovakiaDay(int year)
        {
            return new DateTime(year, 10, 28);
        }


        /// <summary>
        /// Sviatok všetkých svätých - All Saints’ Day
        /// Cemeteries are visited on or around this day
        /// introduced by law in 1994, before that it was cancelled during the communist era but probably was a public holiday in older times before the communism era
        /// in this class it will be valid until 1951, since 1994 and won't be present between 1951 and 1993
        /// </summary>
        /// <param name="year"></param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime AllSaints(int year)
        {
            return new DateTime(year, 11, 1);
        }

        /// <summary>
        /// Deň boja za slobodu a demokraciu - Struggle for Freedom and Democracy Day
        /// Commemorating the student demonstration against Nazi occupation in 1939, 
        /// and especially the demonstration in 1989 in Bratislava and Prague 
        /// considered to mark the beginning of the Velvet Revolution.
        /// valid since 2001 -  law 241/1993 updated by 442/2001, since 15th of November 2001
        /// (Zákon, ktorým sa mení a dopĺňa zákon Národnej rady Slovenskej republiky č. 241/1993 Z. z. o štátnych sviatkoch, 
        ///  dňoch pracovného pokoja a pamätných dňoch v znení neskorších predpisov)
        /// </summary>
        /// <param name="year"></param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime FreedomDemocracyDay(int year)
        {
            return new DateTime(year, 11, 17);
        }

        /// <summary>
        /// Štedrý deň - Christmas Eve
        /// In Slovakia, Christmas presents are opened in the evening on Christmas Eve
        /// Valid since 1990, in older years it was not a public holiday
        /// source: 93/1951 Zb. (modification by 167/1990 Zb.) and 241/1993 Z.z.
        /// </summary>
        /// <param name="year"></param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime ChristmasEve(int year)
        {
            return new DateTime(year, 12, 24);
        }

        /// <summary>
        /// Prvý sviatok vianočný - Christmas Day - 1st day of Christmas
        /// Literally, First Christmas Holiday
        /// </summary>
        /// <param name="year"></param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime ChristmasDay(int year)
        {
            return new DateTime(year, 12, 25);
        }

        /// <summary>
        /// Druhý sviatok vianočný - St. Stephen's Day - 2nd day of Christmas
        /// Literally, Second Christmas Holiday
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
        /// Public holiday names in Slovakian.
        /// Names identical from source: http://kalendar.azet.sk/sviatky/
        /// for historical sources names are from other sources (mainly from historic law)
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public override IDictionary<DateTime, string> PublicHolidayNames(int year)
        {
            var bHols = new Dictionary<DateTime, string>();
            if (year < 1994)
                bHols.Add(NewYear(year), "Nový rok"); // New Year only until 1993
            else
                bHols.Add(EstablishmentDay(year), "Deň vzniku Slovenskej republiky"); // Establishment day since 1994

            if (year >= 1994 || year <= 1951)
                bHols.Add(Epiphany(year), "Zjavenie Pána (Traja králi)"); // Epiphany, not in the communist era

            DateTime easter = HolidayCalculator.GetEaster(year);
            if (year >= 1994 || year <= 1951)
                bHols.Add(GoodFriday(easter), "Veľký piatok"); // Good Friday, not in the communist era

            bHols.Add(EasterMonday(easter), "Veľkonočný pondelok"); // Easter Monday

            bHols.Add(WorkersDay(year), "Sviatok práce"); // Workers' Day

            if ((year >= 1992 && year<=1993) || year >= 1997)
                bHols.Add(VictoryWWIIDay(year), "Deň víťazstva nad fašizmom"); // Victory over fascizm, since 1992
            if (year >= 1952 && year<=1991)
                bHols.Add(LiberationDay(year), "Výročie oslobodenia Československa Sovietskou armádou"); // Day of liberation of Czechoslovakia by Soviet army, until 1991

            if (year >= 1990 || year <= 1951)
                bHols.Add(CyrilAndMethodius(year), "Sviatok svätého Cyrila a Metoda"); // Cyril and Methodius, not in the communist era

            if (year >= 1994)
                bHols.Add(SNP(year), "Výročie SNP"); // SNP

            if (year >= 1994)
                bHols.Add(ConstitutionDay(year), "Deň Ústavy Slovenskej republiky"); // Day of the Constitution of the Slovak Republic

            if (year >= 1994 || year <= 1951)
                bHols.Add(LadySevenSorrows(year), "Sedembolestná Panna Mária"); // Our Lady of the Seven Sorrows, not in the communist era

            if (year >= 1952 && year <= 1974)
                bHols.Add(NationalizationDay(year), "Deň znárodnenia"); // Nationalization Day, old public holiday several years in the communist era

            if (year >= 1988 && year <= 1993)
                bHols.Add(IndependentCzechoSlovakiaDay(year), "Deň vzniku samostatného česko-slovenského štátu"); // Day of Independent CzechoSlovakia, short time old public holiday 

            if (year >= 1994 || year <= 1951)
                bHols.Add(AllSaints(year), "Sviatok všetkých svätých"); // All Saint's Day, not in the communist era

            if (year >= 2001)
                bHols.Add(FreedomDemocracyDay(year), "Deň boja za slobodu a demokraciu"); // Struggle for Freedom and Democracy Day (Velvet revolution)

            if (year >= 1990)
                bHols.Add(ChristmasEve(year), "Štedrý deň"); // Christmas Eve

            bHols.Add(ChristmasDay(year), "Prvý sviatok vianočný");
            bHols.Add(StStephenDay(year), "Druhý sviatok vianočný");
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
                    if (year < 1994 && NewYear(year) == date)
                        return true;
                    if (year >= 1994 && EstablishmentDay(year) == date)
                        return true;
                    if ((year >= 1994 || year <= 1951) && Epiphany(year) == date)
                        return true;
                    break;

                case 3:
                case 4:
                    if ((year >= 1994 || year <= 1951) && GoodFriday(year) == date)
                        return true;
                    if (EasterMonday(year) == date)
                        return true;
                    break;

                case 5:
                    if (WorkersDay(year) == date)
                        return true;
                    if (((year >= 1992 && year <= 1993) || year >= 1997) && VictoryWWIIDay(year) == date)
                        return true;
                    if ((year >= 1952 && year <= 1991) && LiberationDay(year) == date)
                        return true;                        
                    break;

                case 7:
                    if ((year >= 1990 || year <= 1951) && CyrilAndMethodius(year) == date)
                        return true;
                    break;

                case 8:
                    if ((year >= 1994) && SNP(year) == date)
                        return true;
                    break;

                case 9:
                    if ((year >= 1994) && ConstitutionDay(year) == date)
                        return true;
                    if ((year >= 1994 || year <= 1951) && LadySevenSorrows(year) == date)
                        return true;
                    break;

                case 10:
                    if ((year >= 1952 && year <= 1974) && NationalizationDay(year) == date)
                        return true;
                    if ((year >= 1988 && year <= 1993) && IndependentCzechoSlovakiaDay(year) == date)
                        return true;
                    break;

                case 11:
                    if ((year >= 1994 || year <= 1951) && AllSaints(year) == date)
                        return true;
                    if ((year >= 2001) && FreedomDemocracyDay(year) == date)
                        return true;
                    break;

                case 12:
                    if ((year >= 1990) && ChristmasEve(year) == date)
                        return true;
                    if (ChristmasDay(year) == date)
                        return true;
                    if (StStephenDay(year) == date)
                        return true;
                    break;
            }

            return false;
        }
    }
}