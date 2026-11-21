using System;
using PublicHoliday.Dates;

#if NETSTANDARD1_0_OR_GREATER || NET40_OR_GREATER || NETCOREAPP1_0_OR_GREATER
using System.Collections.Concurrent;
#endif

namespace PublicHoliday.HolidayDefinitions.Christian
{
    /// <summary>
    /// Computes Easter Sunday (western and Orthodox) and the movable feasts derived from it.
    /// This is holiday knowledge, deliberately kept out of the generic date-math in
    /// <see cref="HolidayCalculator"/>.
    /// </summary>
    internal static class EasterCalculator
    {
#if NETSTANDARD1_0_OR_GREATER || NET40_OR_GREATER || NETCOREAPP1_0_OR_GREATER
        private static readonly ConcurrentDictionary<int, DateTime> _cache = new ConcurrentDictionary<int, DateTime>();
#endif

        /// <summary>
        /// Work out the date for Easter Sunday for specified year
        /// </summary>
        /// <param name="year">The year as an integer</param>
        /// <returns>Returns a datetime of Easter Sunday.</returns>
        public static DateTime GetEaster(int year)
        {
#if NETSTANDARD1_3_OR_GREATER || NET40_OR_GREATER
            return _cache.GetOrAdd(year, y =>
            {
                return GetEasterPrivate(year);
            });
#else
            return GetEasterPrivate(year);
#endif
        }

        /// <summary>
        /// Work out the date for Easter Sunday for specified year
        /// </summary>
        /// <param name="year">The year as an integer</param>
        /// <returns>Returns a datetime of Easter Sunday.</returns>
        private static DateTime GetEasterPrivate(int year)
        {
            //should be
            //Easter Monday  28 Mar 2005  17 Apr 2006  9 Apr 2007  24 Mar 2008

            //Oudin's Algorithm - http://www.smart.net/~mmontes/oudin.html

            var g = year % 19;
            var c = year / 100;
            var h = (c - c / 4 - (8 * c + 13) / 25 + 19 * g + 15) % 30;
            var i = h - (h / 28) * (1 - (h / 28) * (29 / (h + 1)) * ((21 - g) / 11));
            var j = (year + year / 4 + i + 2 - c + c / 4) % 7;
            var p = i - j;
            var easterDay = 1 + (p + 27 + (p + 6) / 40) % 31;
            var easterMonth = 3 + (p + 26) / 30;

            return new DateTime(year, easterMonth, easterDay);
        }

        /// <summary>
        /// Work out the date for Orthodox Easter Sunday for specified year
        /// </summary>
        public static DateTime GetOrthodoxEaster(int year)
        {
            //Meeus' Julian algorithm gives Easter as a date in the Julian calendar
            var a = year % 4;
            var b = year % 7;
            var c = year % 19;
            var d = (19 * c + 15) % 30;
            var e = (2 * a + 4 * b - d + 34) % 7;
            var month = (d + e + 114) / 31;
            var day = (d + e + 114) % 31 + 1;

            //Julian to Gregorian: the gap is 13 days only in 1900-2099
            //(12 days in 1800-1899, 14 days in 2100-2199, ...)
            var julianToGregorianDays = year / 100 - year / 400 - 2;

            return new DateTime(year, month, day).AddDays(julianToGregorianDays);
        }

        /// <summary>
        /// Maundy/Holy Thursday - the Thursday before Easter (easter - 3 days).
        /// </summary>
        /// <param name="easter">Easter Sunday, from <see cref="GetEaster"/> or <see cref="GetOrthodoxEaster"/>.</param>
        public static DateTime MaundyThursday(DateTime easter)
        {
            return easter.AddDays(-3);
        }

        /// <summary>
        /// Good Friday - the Friday before Easter (easter - 2 days).
        /// </summary>
        /// <param name="easter">Easter Sunday, from <see cref="GetEaster"/> or <see cref="GetOrthodoxEaster"/>.</param>
        public static DateTime GoodFriday(DateTime easter)
        {
            return easter.AddDays(-2);
        }

        /// <summary>
        /// Easter Monday - the day after Easter (easter + 1 day).
        /// </summary>
        /// <param name="easter">Easter Sunday, from <see cref="GetEaster"/> or <see cref="GetOrthodoxEaster"/>.</param>
        public static DateTime EasterMonday(DateTime easter)
        {
            return easter.AddDays(1);
        }

        /// <summary>
        /// Ascension Day - 39 days after Easter (always a Thursday).
        /// </summary>
        /// <param name="easter">Easter Sunday, from <see cref="GetEaster"/> or <see cref="GetOrthodoxEaster"/>.</param>
        public static DateTime AscensionDay(DateTime easter)
        {
            return easter.AddDays(39);
        }

        /// <summary>
        /// Whit/Pentecost Sunday - 49 days after Easter.
        /// </summary>
        /// <param name="easter">Easter Sunday, from <see cref="GetEaster"/> or <see cref="GetOrthodoxEaster"/>.</param>
        public static DateTime WhitSunday(DateTime easter)
        {
            return easter.AddDays(49);
        }

        /// <summary>
        /// Whit/Pentecost Monday - 50 days after Easter.
        /// </summary>
        /// <param name="easter">Easter Sunday, from <see cref="GetEaster"/> or <see cref="GetOrthodoxEaster"/>.</param>
        public static DateTime WhitMonday(DateTime easter)
        {
            return easter.AddDays(50);
        }

        /// <summary>
        /// Corpus Christi - the Thursday after Trinity Sunday (60 days after Easter).
        /// </summary>
        /// <param name="easter">Easter Sunday, from <see cref="GetEaster"/> or <see cref="GetOrthodoxEaster"/>.</param>
        public static DateTime CorpusChristi(DateTime easter)
        {
            return easter.AddDays(60);
        }
    }
}
