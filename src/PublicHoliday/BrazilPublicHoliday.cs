using System;
using System.Collections.Generic;

namespace PublicHoliday
{
    /// <summary>
    /// Public holidays for Brazil
    /// </summary>
    public class BrazilPublicHoliday : PublicHolidayBase
    {
        /// <summary>
        /// New Year's Day (Ano Novo) - January 1st
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime AnoNovo(int year)
        {
            return new DateTime(year, 1, 1);
        }
        /// <summary>
        /// Carnival(Carnaval) - Even though carnaval takes 5 days. Brazil national holidays for carnival are monday and tuesday.
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime CarnavalDayOne(int year)
        {
            return HolidayCalculator.GetEaster(year).AddDays(-48);
        }
        /// <summary>
        /// Carnival(Carnaval) - Even though carnaval takes 5 days. Brazil national holidays for carnival are monday and tuesday.
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime CarnavalDayTwo(int year)
        {
            return HolidayCalculator.GetEaster(year).AddDays(-47);
        }
        /// <summary>
        /// Good Friday(Sexta-feira Santa) - Date varies(the Friday before Easter Sunday, observed by Christians)
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime SextaFeiraSanta(int year)
        {
            return HolidayCalculator.GetFirstFridayBeforeDate(HolidayCalculator.GetEaster(year));
        }
        /// <summary>
        /// Tiradentes Day(Dia de Tiradentes) - April 21st(commemorating the execution of Joaquim José da Silva Xavier, a leading figure in the Brazilian independence movement)
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime Tiradentes(int year)
        {
            return new DateTime(year, 4, 21);
        }
        /// <summary>
        /// Labor Day(Dia do Trabalho) - May 1st
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime DiaDoTrabalho(int year)
        {
            return new DateTime(year, 5, 1);
        }
        /// <summary>
        /// Corpus Christi - Date varies(celebrated on the Thursday after Trinity Sunday, honoring the Eucharist)
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime CorpusChristi(int year)
        {
            // Calculate the date of Trinity Sunday (8 weeks after Easter)
            DateTime trinitySunday = HolidayCalculator.GetEaster(year).AddDays(56);

            // Find the Thursday after Trinity Sunday
            DateTime corpusChristiDate = trinitySunday.AddDays((int)DayOfWeek.Thursday - (int)trinitySunday.DayOfWeek);

            return corpusChristiDate;
        }
        /// <summary>
        /// Independence Day(Dia da Independência) - September 7th(commemorating Brazil's declaration of independence from Portugal in 1822)
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime DiaDaIndependencia(int year)
        {
            return new DateTime(year, 9, 7);
        }
        /// <summary>
        /// Our Lady of Aparecida Day (Dia de Nossa Senhora Aparecida) - October 12th(honoring Brazil's patron saint, Our Lady of Aparecida)
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime NossaSenhoraAparecida(int year)
        {
            return new DateTime(year, 10, 12);
        }
        /// <summary>
        /// All Souls' Day (Dia de Finados) - November 2nd (a day to honor and remember the deceased)
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime DiaDosFinados(int year)
        {
            return new DateTime(year, 11, 2);
        }
        /// <summary>
        /// Republic Day (Dia da República) - November 15th(commemorating the establishment of the Brazilian republic in 1889)
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime DiaDaRepublica(int year)
        {
            return new DateTime(year, 11, 15);
        }
        /// <summary>
        /// Christmas Day(Natal) - December 25th
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime Natal(int year)
        {
            return new DateTime(year, 12, 25);
        }
        /// <summary>
        /// Check if a specific date is a public holiday.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public override bool IsPublicHoliday(DateTime dt)
        {
            switch (dt.Month)
            {
                case 1:
                    return AnoNovo(dt.Year) == dt;
                case 2:
                    if (dt.DayOfWeek == DayOfWeek.Monday)
                    {
                        return CarnavalDayOne(dt.Year) == dt;
                    }
                    else if (dt.DayOfWeek == DayOfWeek.Tuesday)
                    {
                        return CarnavalDayTwo(dt.Year) == dt;
                    }
                    break;
                case 3:
                    if (dt.DayOfWeek == DayOfWeek.Monday)
                    {
                        return CarnavalDayOne(dt.Year) == dt;
                    }
                    else if (dt.DayOfWeek == DayOfWeek.Tuesday)
                    {
                        return CarnavalDayTwo(dt.Year) == dt;
                    }
                    else if (dt.DayOfWeek == DayOfWeek.Friday)
                    {
                        return SextaFeiraSanta(dt.Year) == dt;
                    }
                    break;
                case 4:
                    return ((dt.DayOfWeek == DayOfWeek.Friday) && (SextaFeiraSanta(dt.Year) == dt)) || Tiradentes(dt.Year) == dt;
                case 5:
                    return DiaDoTrabalho(dt.Year) == dt || ((dt.DayOfWeek == DayOfWeek.Thursday) && (CorpusChristi(dt.Year) == dt));
                case 6:
                    return ((dt.DayOfWeek == DayOfWeek.Thursday) && (CorpusChristi(dt.Year) == dt));
                case 9:
                    return DiaDaIndependencia(dt.Year) == dt;
                case 10:
                    return NossaSenhoraAparecida(dt.Year) == dt;
                case 11:
                    return DiaDosFinados(dt.Year) == dt || DiaDaRepublica(dt.Year) == dt;
                case 12:
                    return Natal(dt.Year) == dt;
            }

            return false;
        }
        /// <summary>
        /// Public holiday names in Portuguese.
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public override IDictionary<DateTime, string> PublicHolidayNames(int year)
        {
            return new Dictionary<DateTime, string>() {
                { AnoNovo(year), "Ano Novo" },
                { CarnavalDayOne(year), "Carnaval" },
                { CarnavalDayTwo(year), "Carnaval Terça-Feira Gorda" },
                { SextaFeiraSanta(year), "Sexta Feira Santa" },
                { Tiradentes(year), "Dia de Tiradentes" },
                { DiaDoTrabalho(year), "Dia do Trabalho" },
                { CorpusChristi(year), "Corpus Christi" },
                { DiaDaIndependencia(year), "Dia da Independência" },
                { NossaSenhoraAparecida(year), "Nossa Senhora Aparecida" },
                { DiaDosFinados(year), "Dia dos Finados" },
                { DiaDaRepublica(year), "Dia da República" },
                { Natal(year), "Natal" },
            };
        }
        /// <summary>
        /// Get a list of dates for all holidays in a year.
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public override IList<DateTime> PublicHolidays(int year)
        {
            return new List<DateTime>
            {
                AnoNovo(year),
                CarnavalDayOne(year),
                CarnavalDayTwo(year),
                SextaFeiraSanta(year),
                Tiradentes(year),
                DiaDoTrabalho(year),
                CorpusChristi(year),
                DiaDaIndependencia(year),
                NossaSenhoraAparecida(year),
                DiaDosFinados(year),
                DiaDaRepublica(year),
                Natal(year),
            };
        }
    }
}
