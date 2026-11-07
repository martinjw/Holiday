using System;
using System.Collections.Generic;
using PublicHoliday.HolidayDefinitions;
using PublicHoliday.HolidayDefinitions.Christian;
using Christian = PublicHoliday.HolidayDefinitions.Christian;
using Common = PublicHoliday.HolidayDefinitions.Common;
using Local = PublicHoliday.HolidayDefinitions.CountrySpecific.NewZealand;
using PublicHoliday.HolidayDefinitions.Base;
using System.Globalization;
using PublicHoliday.Localization;
using PublicHoliday.Dates;

namespace PublicHoliday
{
    /// <summary>
    /// New Zealand Public Holidays: https://www.govt.nz/browse/work/public-holidays-and-work-2/public-holidays-and-anniversary-dates/
    /// </summary>
    public class NewZealandPublicHoliday : PublicHolidayBase
    {

        /// <summary>
        /// Culture whose language this calendar's holiday names are in: New Zealand English.
        /// Used by <see cref="Holiday.GetName(CultureInfo)"/> when the requested
        /// culture has no translation.
        /// </summary>
        protected override CultureInfo CountryCulture => _defaultCulture;

        private static readonly CultureInfo _defaultCulture = SafeCulture.Get("en-NZ", "en");
        /// <summary>
        /// Gets or sets the provincial district
        /// </summary>
        public ProvincialDistricts ProvincialDistrict
        {
            get { return _provincialDistrict; }
            set { _provincialDistrict = value; ClearHolidayCache(); }
        }
        private ProvincialDistricts _provincialDistrict;

        /// <summary>
        /// For determining provincial district anniversary days
        /// </summary>
        public enum ProvincialDistricts
        {
            /// <summary>
            /// All of NZ
            /// </summary>
            ALL = 0,

            /// <summary>
            /// Northland
            /// </summary>
            NORTHLAND = 1,

            /// <summary>
            /// Auckland
            /// </summary>
            AUCKLAND = 2,

            /// <summary>
            /// Taranaki
            /// </summary>
            TARANAKI = 3,

            /// <summary>
            /// Hawkes' Bay
            /// </summary>
            HAWKES_BAY = 4,

            /// <summary>
            /// Wellington
            /// </summary>
            WELLINGTON = 5,

            /// <summary>
            /// Marlborough
            /// </summary>
            MARLBOROUGH = 6,

            /// <summary>
            /// Nelson
            /// </summary>
            NELSON = 7,

            /// <summary>
            /// Canterbury
            /// </summary>
            CANTERBURY = 8,

            /// <summary>
            /// South Canterbury
            /// </summary>
            SOUTH_CANTERBURY = 9,

            /// <summary>
            /// Westland
            /// </summary>
            WESTLAND = 10,

            /// <summary>
            /// Otago
            /// </summary>
            OTAGO = 11,

            /// <summary>
            /// Southland
            /// </summary>
            SOUTHLAND = 12,

            /// <summary>
            /// Chatham Islands
            /// </summary>
            CHATHAM_ISLANDS = 13
        }

        /// <summary>
        /// New Year's Day
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime NewYear(int year)
        {
            return HolidayCalculator.FixWeekend(new DateTime(year, 1, 1));
        }

        /// <summary>
        /// Day After New Year's Day
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime DayAfterNewYear(int year)
        {
            var ny = NewYear(year); //may be shifted to Monday, so we have to add a day
            return HolidayCalculator.FixWeekend(ny.AddDays(1));
        }

        /// <summary>
        /// Waitangi Day - 6th February
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime WaitangiDay(int year)
        {
            return HolidayCalculator.FixWeekend(new DateTime(year, 2, 6));
        }

        /// <summary>
        /// Good Friday (Friday before Easter)
        /// </summary>
        public static DateTime GoodFriday(int year)
        {
            return EasterCalculator.GoodFriday(EasterCalculator.GetEaster(year));
        }

        private static DateTime GoodFriday(DateTime easter)
        {
            return EasterCalculator.GoodFriday(easter);
        }

        /// <summary>
        /// Easter Monday
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime EasterMonday(int year)
        {
            return EasterCalculator.EasterMonday(EasterCalculator.GetEaster(year));
        }

        private static DateTime EasterMonday(DateTime easter)
        {
            return EasterCalculator.EasterMonday(easter);
        }

        /// <summary>
        /// ANZAC day, 25th April.
        /// Unless it falls on a weekend and then it becomes a Monday holiday.
        /// </summary>

        public static DateTime AnzacDay(int year)
        {
            var anzac = new DateTime(year, 4, 25);
            return year >= 2015 ? HolidayCalculator.FixWeekend(anzac) : anzac;
        }

        /// <summary>
        /// Queen's Birthday - first Monday in June (from 2023 <see cref="KingBirthday"/>; retained for API backwards compatibility)
        /// </summary>
        /// <param name="year">The year.</param>

        public static DateTime QueenBirthday(int year)
        {
            return HolidayCalculator.FindNext(new DateTime(year, 6, 1), DayOfWeek.Monday);
        }

        /// <summary>
        /// King's Birthday - first Monday in June (before 2023 <see cref="QueenBirthday"/>)
        /// </summary>
        /// <param name="year">The year.</param>
        public static DateTime KingBirthday(int year)
        {
            return QueenBirthday(year);
        }

        /// <summary>
        /// Labour Day - 4th Monday in October
        /// </summary>
        /// <param name="year">The year.</param>

        public static DateTime LabourDay(int year)
        {
            return HolidayCalculator.FindNext(new DateTime(year, 10, 1), DayOfWeek.Monday).AddDays(7 * 3);
        }

        /// <summary>
        /// Christmas
        /// </summary>
        public static DateTime Christmas(int year)
        {
            return HolidayCalculator.FixWeekend(new DateTime(year, 12, 25));
        }

        /// <summary>
        /// Boxing Day
        /// </summary>
        /// <remarks>
        /// If boxing day lands on a Sunday then the public holiday must be observed on the following Tuesday.
        /// So xmas and boxing days can be both Saturday and Sunday, followed by public holidays for both Monday and Tuesday.
        /// </remarks>
        public static DateTime BoxingDay(int year)
        {
            var xmas = Christmas(year); // May be shifted to Monday, so we have to add a day.
            return HolidayCalculator.FixWeekend(xmas.AddDays(1));
        }

        /// <summary>
        /// Matariki - https://www.beehive.govt.nz/release/matariki-holiday-dates-next-thirty-years-announced
        /// </summary>
        /// <param name="year">The year to check</param>
        /// <returns>The date of Matariki, if there is one defined</returns>
        public static DateTime? Matariki(int year)
        {
            DateTime date;
            return Local.Matariki.Dates.TryGetValue(year, out date) ? date : (DateTime?)null;
        }

        /// <summary>
        /// Determine provincial anniversary day
        /// </summary>
        /// <param name="year">The requested year</param>
        /// <param name="district">The requested provincial district</param>
        /// <returns>The anniversary day</returns>
        public static DateTime? ProvincialAnniversary(int year, ProvincialDistricts district)
        {
            switch (district)
            {
                case ProvincialDistricts.ALL:
                    return null;

                case ProvincialDistricts.AUCKLAND:
                case ProvincialDistricts.NORTHLAND:
                    return HolidayCalculator.FindNearestDayOfWeek(new DateTime(year, 1, 29), DayOfWeek.Monday);

                case ProvincialDistricts.CANTERBURY:
                    var firstTuesdayInNovember =
                        HolidayCalculator.FindNext(new DateTime(year, 11, 1), DayOfWeek.Tuesday);
                    return HolidayCalculator.FindNext(firstTuesdayInNovember.AddDays(7), DayOfWeek.Friday);

                case ProvincialDistricts.CHATHAM_ISLANDS:
                    return HolidayCalculator.FindNearestDayOfWeek(new DateTime(year, 11, 30), DayOfWeek.Monday);

                case ProvincialDistricts.HAWKES_BAY:
                    return HolidayCalculator.FindPrevious(LabourDay(year), DayOfWeek.Friday);

                case ProvincialDistricts.MARLBOROUGH:
                    return HolidayCalculator.FindNext(LabourDay(year).AddDays(1), DayOfWeek.Monday);

                case ProvincialDistricts.NELSON:
                    return HolidayCalculator.FindNearestDayOfWeek(new DateTime(year, 2, 1), DayOfWeek.Monday);

                case ProvincialDistricts.OTAGO:
                    var easterMonday = EasterMonday(year);
                    var nearestMonday =
                        HolidayCalculator.FindNearestDayOfWeek(new DateTime(year, 3, 23), DayOfWeek.Monday);
                    return nearestMonday.Equals(easterMonday) ? nearestMonday.AddDays(1) : nearestMonday;

                case ProvincialDistricts.SOUTH_CANTERBURY:
                    if (year == 2022) return new DateTime(2022, 11, 11); // moved due to QEII Memorial Day
                    return HolidayCalculator.FindOccurrenceOfDayOfWeek(new DateTime(year, 9, 1), DayOfWeek.Monday, 4);

                case ProvincialDistricts.SOUTHLAND:
                    return EasterMonday(year).AddDays(1);

                case ProvincialDistricts.TARANAKI:
                    return HolidayCalculator.FindOccurrenceOfDayOfWeek(new DateTime(year, 3, 1), DayOfWeek.Monday, 2);

                case ProvincialDistricts.WELLINGTON:
                    return HolidayCalculator.FindNearestDayOfWeek(new DateTime(year, 1, 22), DayOfWeek.Monday);

                case ProvincialDistricts.WESTLAND:
                    return HolidayCalculator.FindNearestDayOfWeek(new DateTime(year, 12, 1), DayOfWeek.Monday);

                default:
                    return null;
            }
        }

        /// <summary>
        /// All public holidays for the configured <see cref="ProvincialDistrict"/> for the year.
        /// </summary>
        private IEnumerable<HolidayDefinition> GetDefinitions()
        {
            var district = ProvincialDistrict;
            yield return new Common.NewYear { ObservedDateRule = HolidayCalculator.FixWeekend };
            yield return new Local.DayAfterNewYear();
            yield return new Local.WaitangiDay();
            yield return new Christian.GoodFriday();
            yield return new Christian.EasterMonday();
            if (district != ProvincialDistricts.ALL)
                yield return new AnniversaryDayDefinition(district);
            //ANZAC Day can share the day with Good Friday or Easter Monday (e.g. 2011);
            //same-day holidays stay distinct entries (names aggregated by the base class)
            yield return new Local.AnzacDay();
            yield return new Local.MonarchsBirthday();
            yield return new Local.QueenElizabethMemorialDay();
            yield return new Local.LabourDay();
            yield return new Local.Matariki();
            yield return new Local.ChristmasDay();
            yield return new Local.BoxingDay();
        }

        /// <summary>
        /// The provincial Anniversary Day for one district, delegating to
        /// <see cref="ProvincialAnniversary"/> (each district has its own bespoke rule).
        /// </summary>
        private sealed class AnniversaryDayDefinition : HolidayDefinition
        {
            private readonly ProvincialDistricts _district;

            public AnniversaryDayDefinition(ProvincialDistricts district) : base(HolidayKeys.AnniversaryDayNZ, "Anniversary Day")
            {
                _district = district;
            }

            protected override IEnumerable<DateTime> GetDates(int year)
            {
                var date = ProvincialAnniversary(year, _district);
                if (date.HasValue) yield return date.Value;
            }
        }

        /// <summary>
        /// All public holidays for the configured <see cref="ProvincialDistrict"/> for the year.
        /// </summary>
        /// <param name="year">The year.</param>
        protected override IList<Holiday> PublicHolidaysComplete(int year)
        {
            var list = new List<Holiday>();
            foreach (var definition in GetDefinitions())
            {
                list.AddRange(definition.Build(year));
            }
            return list;
        }

    }
}