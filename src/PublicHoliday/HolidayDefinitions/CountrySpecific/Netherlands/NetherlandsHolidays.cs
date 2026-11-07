using System;
using System.Collections.Generic;
using PublicHoliday.HolidayDefinitions;
using PublicHoliday.HolidayDefinitions.Base;

namespace PublicHoliday.HolidayDefinitions.CountrySpecific.Netherlands
{
    /// <summary>
    /// King's Day (Koningsdag, before 2014 Queen's Day/Koninginnedag): 27 April since 2014,
    /// 30 April 1949-2013, 31 August before 1949. Moves to the Saturday before when it falls
    /// on a Sunday.
    /// </summary>
    public class KingsDay : HolidayDefinition
    {
        /// <summary>Creates the definition.</summary>
        public KingsDay() : base(HolidayKeys.KingsDayNL, "King's Day") { }

        /// <inheritdoc />
        protected override IEnumerable<DateTime> GetDates(int year)
        {
            var date = new DateTime(year, 4, 27);
            if (year < 1949)
                date = new DateTime(year, 8, 31);
            else if (year < 2014)
                date = new DateTime(year, 4, 30);

            if (date.DayOfWeek == DayOfWeek.Sunday)
                date = date.AddDays(-1);

            yield return date;
        }
    }

    /// <summary>
    /// Liberation Day (Bevrijdingsdag) - 5 May. Introduced in 1945 every 5 years, annual since
    /// 1990; optionally only in lustrum (multiple-of-5) years from 2020 (sector-dependent).
    /// </summary>
    public class LiberationDay : HolidayDefinition
    {
        private readonly bool _onlyAtLustrum;

        /// <summary>Creates the definition.</summary>
        /// <param name="onlyAtLustrum">True to observe only in lustrum years from 2020 onwards.</param>
        public LiberationDay(bool onlyAtLustrum = false) : base(HolidayKeys.LiberationDayNL, "Liberation Day")
        {
            _onlyAtLustrum = onlyAtLustrum;
        }

        /// <inheritdoc />
        protected override IEnumerable<DateTime> GetDates(int year)
        {
            if (year >= 2020 && _onlyAtLustrum)
            {
                if (year % 5 == 0) yield return new DateTime(year, 5, 5);
                yield break;
            }
            if (year >= 1990) //annual since 1990
            {
                yield return new DateTime(year, 5, 5);
                yield break;
            }
            if (year >= 1945 && year % 5 == 0) //introduced in 1945, every 5 years
            {
                yield return new DateTime(year, 5, 5);
            }
        }
    }
}
