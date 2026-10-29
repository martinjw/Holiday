using System;
using System.Collections.Generic;
using PublicHoliday.HolidayDefinitions;
using PublicHoliday.HolidayDefinitions.Base;
using PublicHoliday.Dates;

namespace PublicHoliday.HolidayDefinitions.CountrySpecific.Finland
{
    /// <summary>
    /// Midsummer Day (Juhannuspäivä): the Saturday between 20 and 26 June since 1955; fixed
    /// 24 June before that.
    /// </summary>
    public class MidsummerDay : HolidayDefinition
    {
        internal const int InSaturdaySince = 1955;

        /// <summary>Creates the definition.</summary>
        public MidsummerDay() : base(HolidayKeys.MidsummerDayFI, "Midsummer Day") { }

        /// <inheritdoc />
        protected override IEnumerable<DateTime> GetDates(int year)
        {
            yield return year >= InSaturdaySince
                ? HolidayCalculator.FindNext(new DateTime(year, 6, 20), DayOfWeek.Saturday)
                : new DateTime(year, 6, 24);
        }
    }

    /// <summary>
    /// Midsummer Eve (Juhannusaatto): the day before <see cref="MidsummerDay"/>. A non-official
    /// holiday observed in some labor agreements.
    /// </summary>
    public class MidsummerEve : HolidayDefinition
    {
        /// <summary>Creates the definition.</summary>
        public MidsummerEve() : base(HolidayKeys.MidsummerEveFI, "Midsummer Eve") { }

        /// <inheritdoc />
        protected override IEnumerable<DateTime> GetDates(int year)
        {
            yield return year >= MidsummerDay.InSaturdaySince
                ? HolidayCalculator.FindNext(new DateTime(year, 6, 20), DayOfWeek.Saturday).AddDays(-1)
                : new DateTime(year, 6, 23);
        }
    }

    /// <summary>
    /// All Saints' Day (Pyhäinpäivä): the Saturday between 31 October and 6 November since 1955;
    /// fixed 1 November before that.
    /// </summary>
    public class AllSaintsDay : HolidayDefinition
    {
        private const int InSaturdaySince = 1955;

        /// <summary>Creates the definition.</summary>
        public AllSaintsDay() : base(HolidayKeys.AllSaints, "All Saints' Day") { }

        /// <inheritdoc />
        protected override IEnumerable<DateTime> GetDates(int year)
        {
            yield return year >= InSaturdaySince
                ? HolidayCalculator.FindNext(new DateTime(year, 10, 31), DayOfWeek.Saturday)
                : new DateTime(year, 11, 1);
        }
    }

    /// <summary>Independence Day - 6 December, public holiday since 1919.</summary>
    public class IndependenceDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public IndependenceDay() : base(HolidayKeys.IndependenceDayFI, "Independence Day", 12, 6)
        {
            AppliesInYear = From1919;
        }

        private static bool From1919(int year)
        {
            return year >= 1919;
        }
    }
}
