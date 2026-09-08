using System;
using System.Collections.Generic;
using PublicHoliday.HolidayDefinitions;
using PublicHoliday.HolidayDefinitions.Christian;
using Christian = PublicHoliday.HolidayDefinitions.Christian;
using Common = PublicHoliday.HolidayDefinitions.Common;
using Local = PublicHoliday.HolidayDefinitions.CountrySpecific.Australia;
using PublicHoliday.HolidayDefinitions.Base;
using System.Globalization;
using PublicHoliday.Localization;
using PublicHoliday.Dates;

// ReSharper disable InconsistentNaming

namespace PublicHoliday
{
    /// <summary>
    /// Holidays in Austria http://www.australia.gov.au/about-australia/special-dates-and-events/public-holidays
    /// </summary>
    /// <remarks>
    /// Missing because no fixed date:
    /// * For Victoria, AFL Grand Final Day
    /// * For Western Australia, Queen's Birthday (we assume end September BUT Governor may change)
    /// </remarks>
    public class AustraliaPublicHoliday : PublicHolidayBase
    {

        /// <summary>
        /// Culture whose language this calendar's holiday names are in: Australian English.
        /// Used by <see cref="Holiday.GetName(CultureInfo)"/> when the requested
        /// culture has no translation.
        /// </summary>
        protected override CultureInfo CountryCulture => _defaultCulture;

        private static readonly CultureInfo _defaultCulture = SafeCulture.Get("en-AU", "en");
        /// <summary>
        /// Gets or sets the state (ISO 3166-2:AU), + default All for all states.
        /// </summary>
        public States State
        {
            get { return _state; }
            set { _state = value; ClearHolidayCache(); }
        }
        private States _state;


        /// <summary>
        /// Set this true to include the NSW Bank holiday as a public holiday, 
        /// </summary>
        public bool IncludeNSWBankHoliday
        {
            get { return _includeNSWBankHoliday; }
            set { _includeNSWBankHoliday = value; ClearHolidayCache(); }
        }
        private bool _includeNSWBankHoliday;

        /// <summary>
        ///
        /// </summary>
        public enum States
        {
            /// <summary>
            /// All
            /// </summary>
            All = 0,

            /// <summary>
            /// Australian Capital Territory
            /// </summary>
            ACT,

            /// <summary>
            /// New South Wales
            /// </summary>
            NSW,

            /// <summary>
            /// Northern Territory
            /// </summary>
            NT,

            /// <summary>
            /// Queensland
            /// </summary>
            QLD,

            /// <summary>
            /// South Australia
            /// </summary>
            SA,

            /// <summary>
            /// Tasmania
            /// </summary>
            TAS,

            /// <summary>
            /// Victoria
            /// </summary>
            VIC,

            /// <summary>
            /// Western Australia
            /// </summary>
            WA,
        }

        #region Individual Holidays

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
        /// Australia Day January 26
        /// </summary>

        public static DateTime AustraliaDay(int year)
        {
            return HolidayCalculator.FixWeekend(new DateTime(year, 1, 26));
        }

        /// <summary>
        /// Good Friday (Friday before Easter)
        /// </summary>
        public static DateTime GoodFriday(int year)
        {
            var easter = EasterCalculator.GetEaster(year);
            return GoodFriday(easter);
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
            var easter = EasterCalculator.GetEaster(year);
            return EasterMonday(easter);
        }

        private static DateTime EasterMonday(DateTime easter)
        {
            return EasterCalculator.EasterMonday(easter);
        }

        /// <summary>
        /// Labour Day
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="state">The state.</param>
        /// <exception cref="ArgumentException">You must specify one of the states/territories - state</exception>
        /// <exception cref="ArgumentOutOfRangeException">state - No such state</exception>
        public static DateTime LabourDay(int year, States state)
        {
            switch (state)
            {
                case States.All:
                    throw new ArgumentException("You must specify one of the states/territories", nameof(state));
                case States.ACT:
                case States.NSW:
                case States.SA:
                    //Australian Capital Territory, New South Wales and South Australia = first Monday in October
                    return HolidayCalculator.FindNext(new DateTime(year, 10, 1), DayOfWeek.Monday);

                case States.NT:
                case States.QLD:
                    //Northern Territory and Queensland = May Day
                    return HolidayCalculator.FindNext(new DateTime(year, 5, 1), DayOfWeek.Monday);

                case States.TAS:
                case States.VIC:
                    //Victoria and Tasmania = second Monday in March ("Eight Hours Day").
                    return HolidayCalculator.FindNext(new DateTime(year, 3, 1), DayOfWeek.Monday).AddDays(7);

                case States.WA:
                    //Western Australia= first Monday in March
                    return HolidayCalculator.FindNext(new DateTime(year, 3, 1), DayOfWeek.Monday);

                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, "No such state");
            }
        }

        /// <summary>
        /// ANZAC day, 25th April
        /// </summary>

        public static DateTime AnzacDay(int year)
        {
            return new DateTime(year, 4, 25);
        }

        /// <summary>
        /// ANZAC day, 25th April, adjusted if on weekends (specific states only)
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="state">The state.</param>

        public static DateTime AnzacDay(int year, States state)
        {
            if (state == States.ACT || state == States.NT || state == States.SA || state == States.WA)
                return HolidayCalculator.FixWeekend(new DateTime(year, 4, 25));
            return new DateTime(year, 4, 25);
        }

        /// <summary>
        /// Canberra Day, 2nd Monday of March
        /// </summary>
        /// <param name="year">The year.</param>
        public static DateTime CanberraDay(int year)
        {
            var secondMonday = HolidayCalculator.FindNext(new DateTime(year, 3, 1), DayOfWeek.Monday).AddDays(7);
            return year < 2008 ? secondMonday.AddDays(7) : secondMonday;
        }

        /// <summary>
        /// Western Australia Day, 1st Monday of June
        /// </summary>
        /// <param name="year">The year.</param>
        public static DateTime WesternAustraliaDay(int year)
        {
            return HolidayCalculator.FindNext(new DateTime(year, 6, 1), DayOfWeek.Monday);
        }

        /// <summary>
        /// Picnic Day (Northern Territory only), first Monday of August
        /// </summary>

        public static DateTime PicnicDay(int year)
        {
            //only Northern Territory
            return HolidayCalculator.FindNext(new DateTime(year, 8, 1), DayOfWeek.Monday);
        }

        /// <summary>
        /// Bank Holiday (NSW only), first Monday of August
        /// </summary>

        public static DateTime BankHoliday(int year)
        {
            //only NSW financial services and banking sectors
            return HolidayCalculator.FindNext(new DateTime(year, 8, 1), DayOfWeek.Monday);
        }


        /// <summary>
        /// Family  and community day, Australian Capital Territory.
        /// </summary>
        /// <param name="year">The year.</param>
        public static DateTime? FamilyAndCommunityDay(int year)
        {
            //first declared in 2007
            if (year < 2007) return null;
            if (year <= 2009)
                return HolidayCalculator.FindNext(new DateTime(year, 11, 1), DayOfWeek.Tuesday);
            //2010+ first Monday of the September/October school holidays
            //if coincides with Labour day, moves to 2nd Monday
            var facDay = HolidayCalculator.FindNext(new DateTime(year, 9, 25), DayOfWeek.Monday);
            if (facDay == HolidayCalculator.FindNext(new DateTime(year, 10, 1), DayOfWeek.Monday))
                facDay = facDay.AddDays(7);
            return facDay;
        }

        /// <summary>
        /// King's Birthday (varies by state)  (before 2023 <see cref="QueenBirthday"/>)
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="state">The state.</param>
        /// <exception cref="ArgumentException">You must specify one of the states/territories - state</exception>
        public static DateTime KingBirthday(int year, States state)
        {
            return QueenBirthday(year, state);
        }

        /// <summary>
        /// Queen's Birthday (varies by state)  (from 2023 <see cref="KingBirthday"/>; retained for API backwards compatibility)
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="state">The state.</param>
        /// <exception cref="ArgumentException">You must specify one of the states/territories - state</exception>
        public static DateTime QueenBirthday(int year, States state)
        {
            switch (state)
            {
                case States.All:
                    throw new ArgumentException("You must specify one of the states/territories", nameof(state));
                case States.ACT:
                case States.NSW:
                case States.NT:
                case States.SA:
                case States.TAS:
                case States.VIC:
                    //second Monday in June
                    return HolidayCalculator.FindNext(new DateTime(year, 6, 1), DayOfWeek.Monday).AddDays(7);

                case States.QLD:
                    //first Monday in October
                    if (year >= 2016 || year == 2012)
                        return HolidayCalculator.FindNext(new DateTime(year, 10, 1), DayOfWeek.Monday);
                    //before 2016 was in June
                    return HolidayCalculator.FindNext(new DateTime(year, 6, 1), DayOfWeek.Monday).AddDays(7);

                case States.WA:
                    //last Monday of September or first of October. No firm rule, all recent dates are September
                    return HolidayCalculator.FindPrevious(new DateTime(year, 9, 30), DayOfWeek.Monday);

                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, "Invalid state");
            }
        }

        /// <summary>
        /// Melbourne Cup (most of Victoria)- first Tuesday of November
        /// </summary>
        public static DateTime MelbourneCup(int year)
        {
            return HolidayCalculator.FindNext(new DateTime(year, 11, 1), DayOfWeek.Tuesday);
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
        public static DateTime BoxingDay(int year)
        {
            DateTime hol = new DateTime(year, 12, 26);
            //if Xmas=Sun, it's shifted to Mon and 26 also gets shifted
            bool isSundayOrMonday =
                hol.DayOfWeek == DayOfWeek.Sunday ||
                hol.DayOfWeek == DayOfWeek.Monday;
            hol = HolidayCalculator.FixWeekend(hol);
            if (isSundayOrMonday)
                hol = hol.AddDays(1);
            return hol;
        }

        #endregion Individual Holidays

        private IEnumerable<HolidayDefinition> GetDefinitions()
        {
            var state = State;
            yield return new Common.NewYear { ObservedDateRule = HolidayCalculator.FixWeekend };
            yield return new Local.AustraliaDay();
            yield return new Christian.GoodFriday();
            yield return new Christian.EasterMonday();
            if (state == States.ACT)
                yield return new Local.CanberraDay();
            yield return new Local.AnzacDay(state == States.ACT || state == States.NT || state == States.SA || state == States.WA);
            if (state == States.NT)
                yield return new Local.PicnicDay();
            if (state == States.WA)
                yield return new Local.WesternAustraliaDay();
            if (state != States.All)
            {
                yield return new StateLabourDayDefinition(state);
                yield return new MonarchsBirthdayDefinition(state);
            }
            if (state == States.ACT)
                yield return new Local.FamilyAndCommunityDay();
            if (state == States.VIC)
                yield return new Local.MelbourneCup();
            if (state == States.NSW && IncludeNSWBankHoliday)
                yield return new Local.BankHoliday();
            yield return new Local.NationalDayOfMourning2022();
            yield return new Local.ChristmasDay();
            if (state == States.SA)
                yield return new Local.BoxingDay { HolidayKey = HolidayKeys.ProclamationDaySA, EnglishName = "Proclamation Day" };
            else
                yield return new Local.BoxingDay();
        }

        /// <summary>
        /// Labour Day for one state, delegating to <see cref="LabourDay(int, States)"/>
        /// (the rule varies per state: March, May or October Mondays).
        /// </summary>
        private sealed class StateLabourDayDefinition : HolidayDefinition
        {
            private readonly States _state;

            public StateLabourDayDefinition(States state) : base(HolidayKeys.LabourDay, "Labour Day")
            {
                _state = state;
            }

            protected override IEnumerable<DateTime> GetDates(int year)
            {
                yield return LabourDay(year, _state);
            }
        }

        /// <summary>
        /// The Monarch's Birthday for one state, delegating to <see cref="QueenBirthday"/>
        /// (June, September or October Mondays depending on state); Queen's Birthday until 2022,
        /// King's Birthday from 2023.
        /// </summary>
        private sealed class MonarchsBirthdayDefinition : HolidayDefinition
        {
            private readonly States _state;

            public MonarchsBirthdayDefinition(States state) : base(HolidayKeys.KingsBirthdayAU, "King's Birthday")
            {
                _state = state;
            }

            protected override IEnumerable<DateTime> GetDates(int year)
            {
                yield return QueenBirthday(year, _state);
            }

            protected override string LocalNameFor(int year, int index, int count)
            {
                return year < 2023 ? "Queen's Birthday" : "King's Birthday";
            }

            protected override string HolidayKeyFor(int year, int index, int count)
            {
                return year < 2023 ? HolidayKeys.QueensBirthdayAU : HolidayKeys.KingsBirthdayAU;
            }
        }

        /// <summary>
        /// All public holidays for the configured <see cref="State"/> for the year.
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