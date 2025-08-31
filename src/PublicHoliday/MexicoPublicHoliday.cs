using System;
using System.Collections.Generic;

namespace PublicHoliday
{
    /// <summary>
    /// Public holidays for Mexico
    /// </summary>
    public class MexicoPublicHoliday : PublicHolidayBase
    {
        /// <summary>
        /// New Year's Day (Año nuevo) - January 1st
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime NewYear(int year)
        {
            return new DateTime(year, 1, 1, 0, 0, 0, DateTimeKind.Local);
        }

        /// <summary>
        /// First Monday in February – Constitution Day (Celebración de la promulgación el 5 de febrero)
        /// celebrated on the first Monday of February
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime ConstitutionDay(int year)
        {
            return HolidayCalculator.GetDayOfWeekInMonth(year, 2, DayOfWeek.Monday, 1);
        }

        /// <summary>
        /// Benito Juárez's Birthday (Celebración del cumpleaños de Juárez, 21 de marzo) 
        /// celebrated on the third Monday of March
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime BenitoJuarezsBirthday(int year)
        {
            return HolidayCalculator.GetDayOfWeekInMonth(year, 3, DayOfWeek.Monday, 3);
        }

        /// <summary>
        /// Labor Day(Día laboral) - May 1st
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime LaborDay(int year)
        {
            return new DateTime(year, 5, 1, 0, 0, 0, DateTimeKind.Local);
        }

        /// <summary>
        /// Independence Day(Día de la Independencia) - May 1st
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
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
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime MexicanRevolutionDay(int year)
        {
            return HolidayCalculator.GetDayOfWeekInMonth(year, 11, DayOfWeek.Monday, 3);
        }

        /// <summary>
        /// Christmas Day(Navidad) - December 25th
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime Christmas(int year)
        {
            return new DateTime(year, 12, 25, 0, 0, 0, DateTimeKind.Local);
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
                    return NewYear(dt.Year) == dt;
                case 2:
                    if (dt.DayOfWeek == DayOfWeek.Monday)
                    {
                        return ConstitutionDay(dt.Year) == dt;
                    }
                    break;
                case 3:
                    if (dt.DayOfWeek == DayOfWeek.Monday)
                    {
                        return BenitoJuarezsBirthday(dt.Year) == dt;
                    }
                    break;
                case 5:
                    return LaborDay(dt.Year) == dt;
                case 9:
                    return IndependenceDay(dt.Year) == dt;
                case 10:
                    DateTime date = GetPresidentialInaugurationHoliday(dt.Year, out bool isInauguration);
                    return (date == dt && isInauguration);
                case 11:
                    if (dt.DayOfWeek == DayOfWeek.Monday)
                    {
                        return MexicanRevolutionDay(dt.Year) == dt;
                    }
                    break;
                case 12:
                    return Christmas(dt.Year) == dt;
            }

            return false;
        }

        /// <summary>
        /// Public holiday names in Spanish.
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public override IDictionary<DateTime, string> PublicHolidayNames(int year)
        {
            return new Dictionary<DateTime, string>() {
                { NewYear(year), "Año Nuevo" },
                { ConstitutionDay(year), "Día de la Constitución" },
                { BenitoJuarezsBirthday(year), "Natalício de Benito Juárez" },
                { LaborDay(year), "Día laboral" },
                { IndependenceDay(year), "Día de la Independencia" },
                { GetPresidentialInaugurationHoliday(year, out  _),"Presidential Inauguration Holiday"},
                { MexicanRevolutionDay(year), "Día de la Revolució" },
                { Christmas(year), "Navidad" },
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
                NewYear(year),
                ConstitutionDay(year),
                BenitoJuarezsBirthday(year),
                LaborDay(year),
                IndependenceDay(year),
                GetPresidentialInaugurationHoliday(year, out _),
                MexicanRevolutionDay(year),
                Christmas(year),
            };
        }
    }
}
