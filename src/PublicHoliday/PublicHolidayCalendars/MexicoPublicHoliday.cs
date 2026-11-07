using System;
using System.Collections.Generic;
using PublicHoliday.HolidayDefinitions;
using Christian = PublicHoliday.HolidayDefinitions.Christian;
using Common = PublicHoliday.HolidayDefinitions.Common;
using Local = PublicHoliday.HolidayDefinitions.CountrySpecific.Mexico;
using PublicHoliday.HolidayDefinitions.Base;
using System.Globalization;
using PublicHoliday.Localization;
using PublicHoliday.Dates;

namespace PublicHoliday
{
    /// <summary>
    /// Public holidays for Mexico
    /// </summary>
    public class MexicoPublicHoliday : PublicHolidayBase
    {

        /// <summary>
        /// Culture whose language this calendar's holiday names are in: Mexican Spanish.
        /// Used by <see cref="Holiday.GetName(CultureInfo)"/> when the requested
        /// culture has no translation.
        /// </summary>
        protected override CultureInfo CountryCulture => _defaultCulture;

        private static readonly CultureInfo _defaultCulture = SafeCulture.Get("es-MX", "es");
        /// <summary>
        /// New Year's Day (Año nuevo) - January 1st
        /// </summary>
        public static DateTime NewYear(int year)
        {
            return new DateTime(year, 1, 1, 0, 0, 0, DateTimeKind.Local);
        }

        /// <summary>
        /// First Monday in February – Constitution Day (Celebración de la promulgación el 5 de febrero)
        /// celebrated on the first Monday of February
        /// </summary>
        public static DateTime ConstitutionDay(int year)
        {
            return HolidayCalculator.GetDayOfWeekInMonth(year, 2, DayOfWeek.Monday, 1);
        }

        /// <summary>
        /// Benito Juárez's Birthday (Celebración del cumpleaños de Juárez, 21 de marzo) 
        /// celebrated on the third Monday of March
        /// </summary>
        public static DateTime BenitoJuarezsBirthday(int year)
        {
            return HolidayCalculator.GetDayOfWeekInMonth(year, 3, DayOfWeek.Monday, 3);
        }

        /// <summary>
        /// Labor Day(Día laboral) - May 1st
        /// </summary>
        public static DateTime LaborDay(int year)
        {
            return new DateTime(year, 5, 1, 0, 0, 0, DateTimeKind.Local);
        }

        /// <summary>
        /// Independence Day(Día de la Independencia) - May 1st
        /// </summary>
        public static DateTime IndependenceDay(int year)
        {
            return new DateTime(year, 9, 16, 0, 0, 0, DateTimeKind.Local);
        }

        /// <summary>
        /// Returns the presidential inauguration holiday for a given year in Mexico.
        /// the presidential inauguration in Mexico takes place every 6 years
        /// If it's not a year of inauguration, returns the "would-be" date and a flag as false.
        /// </summary>
        public static DateTime GetPresidentialInaugurationHoliday(int year, out bool isPresidentialInaugurationYear)
        {
            const int startYear = 2024;
            isPresidentialInaugurationYear = year >= startYear && (year - startYear) % 6 == 0;
            return new DateTime(year, 10, 1, 0, 0, 0, DateTimeKind.Local);
        }

        /// <summary>
        /// Mexican Revolution Day (Día de la Revolución, originally November 20)
        /// comemorado na terceira segunda-feira de novembro
        /// </summary>
        public static DateTime MexicanRevolutionDay(int year)
        {
            return HolidayCalculator.GetDayOfWeekInMonth(year, 11, DayOfWeek.Monday, 3);
        }

        /// <summary>
        /// Christmas Day(Navidad) - December 25th
        /// </summary>
        public static DateTime Christmas(int year)
        {
            return new DateTime(year, 12, 25, 0, 0, 0, DateTimeKind.Local);
        }


        /// <summary>
        /// All Mexican public holidays for the year (names in Spanish).
        /// </summary>
        private static readonly HolidayDefinition[] Definitions =
        {
            new Common.NewYear(),
            new Local.ConstitutionDay(),
            new Local.BenitoJuarezBirthday(),
            new Common.LabourDay(),
            new Local.IndependenceDay(),
            new Local.PresidentialInauguration(),
            new Local.RevolutionDay(),
            new Christian.Christmas(),
        };

        /// <summary>
        /// All Mexican public holidays for the year (names in Spanish).
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
