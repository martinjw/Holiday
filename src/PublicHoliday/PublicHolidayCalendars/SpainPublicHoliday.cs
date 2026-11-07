using System;
using System.Collections.Generic;
using PublicHoliday.HolidayDefinitions;
using PublicHoliday.HolidayDefinitions.Christian;
using Christian = PublicHoliday.HolidayDefinitions.Christian;
using Common = PublicHoliday.HolidayDefinitions.Common;
using Local = PublicHoliday.HolidayDefinitions.CountrySpecific.Spain;
using PublicHoliday.HolidayDefinitions.Base;
using System.Globalization;
using PublicHoliday.Localization;

namespace PublicHoliday
{
    /// <summary>
    /// Finds Spanish public holidays.
    /// Public holidays on Sundays are not deferred to following weekday automatically-
    /// they may be taken at an arbitary date.
    /// </summary>
    /// <remarks>
    /// - We don't infer bridge days for holidays on Tues/Thurs.
    /// - We don't have regional holidays
    /// </remarks>
    public class SpainPublicHoliday : PublicHolidayBase
    {

        /// <summary>
        /// Culture whose language this calendar's holiday names are in: European Spanish.
        /// Used by <see cref="Holiday.GetName(CultureInfo)"/> when the requested
        /// culture has no translation.
        /// </summary>
        protected override CultureInfo CountryCulture => _defaultCulture;

        private static readonly CultureInfo _defaultCulture = SafeCulture.Get("es-ES", "es");
        #region Individual Holidays

        /// <summary>
        /// New Year's Day January 1 Año Nuevo
        /// </summary>
        public static DateTime NewYear(int year)
        {
            return new DateTime(year, 1, 1);
        }

        /// <summary>
        /// Epiphany January 6 	Día de Reyes / Epifanía del Señor
        /// </summary>
        public static DateTime Epiphany(int year)
        {
            return new DateTime(year, 1, 6);
        }

        /// <summary>
        /// Good Friday (Friday before Easter) Viernes Santo
        /// </summary>
        public static DateTime GoodFriday(int year)
        {
            return EasterCalculator.GoodFriday(EasterCalculator.GetEaster(year));
        }

        /// <summary>
        /// Labor Day May 1 Día del Trabajador.
        /// </summary>
        /// <param name="year">The year.</param>
        public static DateTime MayDay(int year)
        {
            return new DateTime(year, 5, 1);
        }

        /// <summary>
        /// Assumption of Mary August 15- Asunción
        /// </summary>
        public static DateTime Assumption(int year)
        {
            return new DateTime(year, 8, 15);
        }

        /// <summary>
        /// National day, October 12 Fiesta Nacional de España
        /// </summary>
        /// <param name="year">The year.</param>
        public static DateTime NationalDay(int year)
        {
            return new DateTime(year, 10, 12);
        }

        /// <summary>
        /// All Saints November 1 Día de todos los Santos
        /// </summary>
        public static DateTime AllSaints(int year)
        {
            return new DateTime(year, 11, 1);
        }

        /// <summary>
        /// Constitution day, Dec 6 Día de la Constitución
        /// </summary>
        /// <param name="year">The year.</param>
        public static DateTime ConstitutionDay(int year)
        {
            return new DateTime(year, 12, 6);
        }

        /// <summary>
        /// Immaculate Conception, Dec 8 - Inmaculada Concepción
        /// </summary>
        /// <param name="year">The year.</param>
        public static DateTime ImmaculateConception(int year)
        {
            return new DateTime(year, 12, 8);
        }

        /// <summary>
        /// Christmas December 25  Navidad
        /// </summary>
        public static DateTime Christmas(int year)
        {
            return new DateTime(year, 12, 25);
        }

        #endregion Individual Holidays

        /// <summary>
        /// All Spanish national public holidays for the year (names in Spanish).
        /// </summary>
        private static readonly HolidayDefinition[] Definitions =
        {
            new Common.NewYear(),
            new Christian.Epiphany(),
            new Christian.GoodFriday(),
            new Common.LabourDay(),
            new Christian.Assumption(),
            new Local.NationalDay(),
            new Christian.AllSaints(),
            new Local.ConstitutionDay(),
            new Christian.ImmaculateConception(),
            new Christian.Christmas(),
        };

        /// <summary>
        /// All Spanish public holidays for the year (names in Spanish).
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