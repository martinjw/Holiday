using System;
using System.Collections.Generic;
using PublicHoliday.HolidayDefinitions;
using PublicHoliday.HolidayDefinitions.Christian;
using Christian = PublicHoliday.HolidayDefinitions.Christian;
using Common = PublicHoliday.HolidayDefinitions.Common;
using Local = PublicHoliday.HolidayDefinitions.CountrySpecific.Brazil;
using PublicHoliday.HolidayDefinitions.Base;
using System.Globalization;
using PublicHoliday.Localization;
using PublicHoliday.Dates;

namespace PublicHoliday
{
    /// <summary>
    /// Public holidays for Brazil
    /// </summary>
    public class BrazilPublicHoliday : PublicHolidayBase
    {

        /// <summary>
        /// Culture whose language this calendar's holiday names are in: Brazilian Portuguese.
        /// Used by <see cref="Holiday.GetName(CultureInfo)"/> when the requested
        /// culture has no translation.
        /// </summary>
        protected override CultureInfo CountryCulture => _defaultCulture;

        private static readonly CultureInfo _defaultCulture = SafeCulture.Get("pt-BR", "pt");
        /// <summary>
        /// New Year's Day (Ano Novo) - January 1st
        /// </summary>
        public static DateTime AnoNovo(int year)
        {
            return new DateTime(year, 1, 1);
        }
        /// <summary>
        /// Carnival(Carnaval) - Even though carnaval takes 5 days. Brazil national holidays for carnival are monday and tuesday.
        /// </summary>
        public static DateTime CarnavalDayOne(int year)
        {
            return EasterCalculator.GetEaster(year).AddDays(-48);
        }
        /// <summary>
        /// Carnival(Carnaval) - Even though carnaval takes 5 days. Brazil national holidays for carnival are monday and tuesday.
        /// </summary>
        public static DateTime CarnavalDayTwo(int year)
        {
            return EasterCalculator.GetEaster(year).AddDays(-47);
        }
        /// <summary>
        /// Good Friday(Sexta-feira Santa) - Date varies(the Friday before Easter Sunday, observed by Christians)
        /// </summary>
        public static DateTime SextaFeiraSanta(int year)
        {
            return HolidayCalculator.GetFirstFridayBeforeDate(EasterCalculator.GetEaster(year));
        }
        /// <summary>
        /// Tiradentes Day(Dia de Tiradentes) - April 21st(commemorating the execution of Joaquim José da Silva Xavier, a leading figure in the Brazilian independence movement)
        /// </summary>
        public static DateTime Tiradentes(int year)
        {
            return new DateTime(year, 4, 21);
        }
        /// <summary>
        /// Labor Day(Dia do Trabalho) - May 1st
        /// </summary>
        public static DateTime DiaDoTrabalho(int year)
        {
            return new DateTime(year, 5, 1);
        }
        /// <summary>
        /// Corpus Christi - Date varies(celebrated on the Thursday after Trinity Sunday, honoring the Eucharist)
        /// </summary>
        public static DateTime CorpusChristi(int year)
        {
            return EasterCalculator.CorpusChristi(EasterCalculator.GetEaster(year));
        }
        /// <summary>
        /// Independence Day(Dia da Independência) - September 7th(commemorating Brazil's declaration of independence from Portugal in 1822)
        /// </summary>
        public static DateTime DiaDaIndependencia(int year)
        {
            return new DateTime(year, 9, 7);
        }
        /// <summary>
        /// Our Lady of Aparecida Day (Dia de Nossa Senhora Aparecida) - October 12th(honoring Brazil's patron saint, Our Lady of Aparecida)
        /// </summary>
        public static DateTime NossaSenhoraAparecida(int year)
        {
            return new DateTime(year, 10, 12);
        }
        /// <summary>
        /// All Souls' Day (Dia de Finados) - November 2nd (a day to honor and remember the deceased)
        /// </summary>
        public static DateTime DiaDosFinados(int year)
        {
            return new DateTime(year, 11, 2);
        }
        /// <summary>
        /// Republic Day (Dia da República) - November 15th(commemorating the establishment of the Brazilian republic in 1889)
        /// </summary>
        public static DateTime DiaDaRepublica(int year)
        {
            return new DateTime(year, 11, 15);
        }
        /// <summary>
        /// Christmas Day(Natal) - December 25th
        /// </summary>
        public static DateTime Natal(int year)
        {
            return new DateTime(year, 12, 25);
        }
        /// <summary>
        /// All Brazilian national public holidays for the year (names in Portuguese).
        /// </summary>
        //Good Friday can fall on Tiradentes Day (21 April, e.g. 2000, 2011);
        //same-day holidays stay distinct entries (names aggregated by the base class)
        private static readonly HolidayDefinition[] Definitions =
        {
            new Common.NewYear(),
            new Local.CarnivalMonday(),
            new Local.CarnivalTuesday(),
            new Christian.GoodFriday(),
            new Local.Tiradentes(),
            new Common.LabourDay(),
            new Christian.CorpusChristi(),
            new Local.IndependenceDay(),
            new Local.OurLadyAparecida(),
            new Local.AllSoulsDay(),
            new Local.RepublicDay(),
            new Christian.Christmas(),
        };

        /// <summary>
        /// All Brazilian public holidays for the year (names in Portuguese).
        /// </summary>
        /// <param name="year">The year.</param>
        protected override IList<Holiday> PublicHolidaysComplete(int year)
        {
            var list = new List<Holiday>();
            foreach (var definition in Definitions)
            {
                list.AddRange(definition.Build(year));
            }
            return list;
        }
    }
}
