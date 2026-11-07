using System;
using System.Collections.Generic;
using System.Linq;
using PublicHoliday.HolidayDefinitions;
using PublicHoliday.HolidayDefinitions.Christian;
using Christian = PublicHoliday.HolidayDefinitions.Christian;
using Common = PublicHoliday.HolidayDefinitions.Common;
using Local = PublicHoliday.HolidayDefinitions.CountrySpecific.UnitedKingdom;
using PublicHoliday.HolidayDefinitions.Base;
using System.Globalization;
using PublicHoliday.Localization;
using PublicHoliday.Dates;

namespace PublicHoliday
{
    /// <summary>
    /// Finds UK Bank (public) Holidays. Adjusted for weekends. For Scotland/NorthernIreland variations set <see cref="UkCountry"/>
    /// <description>
    /// UK Bank Holidays since 1971 Banking and Financial Dealings Act with additions and variations.
    /// See http://www.dti.gov.uk/employment/bank-public-holidays/index.html
    /// <para>Additions: 1974 New Years Day and 1978 May Day</para>
    /// <para>Variations: 1995 VE Day May Day, 2002 Golden Jubilee, 2011 Royal Wedding, 2012 Diamond Jubilee</para>
    /// <para>You can call by IsBankHoliday(date), get the specific holiday name
    /// ( <see cref="Christmas"/>), or a list of dates for the year (<see cref="BankHolidays"/>)</para>
    /// </description>
    /// </summary>
    public class UKBankHoliday : PublicHolidayBase
    {

        /// <summary>
        /// Culture whose language this calendar's holiday names are in: British English.
        /// Used by <see cref="Holiday.GetName(CultureInfo)"/> when the requested
        /// culture has no translation.
        /// </summary>
        protected override CultureInfo CountryCulture => _defaultCulture;

        private static readonly CultureInfo _defaultCulture = SafeCulture.Get("en-GB", "en");
        /// <summary>
        /// Country within the United Kingdom. Default is England (and Wales which is the same legal jurisdiction).
        /// Change for Scotland and NorthernIreland
        /// </summary>
        public UkCountries UkCountry
        {
            get { return _ukCountry; }
            set { _ukCountry = value; ClearHolidayCache(); }
        }
        private UkCountries _ukCountry;

        /// <summary>
        /// The constituent countries of the United Kingdom. England and Wales are the same legal jurisdiction, but for clarity are shown separately.
        /// </summary>
        public enum UkCountries
        {
            /// <summary>
            /// England
            /// </summary>
            England = 0,

            /// <summary>
            /// Wales
            /// </summary>
            Wales,

            /// <summary>
            /// Scotland
            /// </summary>
            Scotland,

            /// <summary>
            /// Northern Ireland
            /// </summary>
            NorthernIreland
        }

        /// <summary>
        /// Builds a UK Bank Holiday calculator for one of the UK countries (England, Wales, Scotland, Northern Ireland)
        /// </summary>
        public UKBankHoliday(UkCountries ukCountry)
        {
            UkCountry = ukCountry;
        }

        /// <summary>
        /// Builds a UK Bank Holiday calculator for England (and Wales)
        /// </summary>
        public UKBankHoliday() : this(UkCountries.England)
        {
        }

        #region Individual Holidays

        /// <summary>
        /// Christmas day
        /// </summary>
        public static DateTime Christmas(int year)
        {
            // Always move a weekend date two days to avoid colliding with Boxing day.
            // If Boxing day is on Monday this means Xmas is after Boxing day.
            return Local.UnitedKingdomWeekendRule.SaturdayOrSundayPlusTwo(new DateTime(year, 12, 25));
        }

        /// <summary>
        /// Boxing Day
        /// </summary>
        public static DateTime BoxingDay(int year)
        {
            // If Sat, move 2 days to avoid weekend.
            // If Sun, also move 2 days as Xmas is moved to Mon.
            return Local.UnitedKingdomWeekendRule.SaturdayOrSundayPlusTwo(new DateTime(year, 12, 26));
        }

        /// <summary>
        /// Date of New Year bank holiday. This is 1974 on only but will return pre 1974 dates.
        /// </summary>
        public static DateTime NewYear(int year)
        {
            //since 1974 only
            return HolidayCalculator.FixWeekend(new DateTime(year, 1, 1));
        }

        /// <summary>
        /// Scotland only. Normally January 2nd
        /// </summary>
        public static DateTime NewYearHolidayScotland(int year)
        {
            return new Local.NewYearHolidayScotland().Build(year).First().ObservedDate;
        }

        /// <summary>
        /// Northern Ireland only. St Patrick's Day, on 17th of March or next Monday if on weekend.
        /// </summary>
        public static DateTime StPatricksDay(int year)
        {
            return HolidayCalculator.FixWeekend(new DateTime(year, 3, 17));
        }

        /// <summary>
        /// Scotland only. St Andrew's Day
        /// </summary>
        public static DateTime StAndrews(int year)
        {
            return HolidayCalculator.FixWeekend(new DateTime(year, 11, 30));
        }

        /// <summary>
        /// Northern Ireland only. Battle of the Boyne (Orangemen’s Day) on 12th of July or next Monday if on weekend.
        /// </summary>
        public static DateTime BattleOfTheBoyne(int year)
        {
            return HolidayCalculator.FixWeekend(new DateTime(year, 7, 12));
        }

        /// <summary>
        /// Returns "Early Spring"/"May Day" holiday (first Monday in May). Created in 1978.
        /// </summary>
        /// <returns>(Nullable)date for Early May Bank Holiday (null before 1978)</returns>
        public static DateTime? MayDay(int year)
        {
            //warning- should be null for < 1977
            if (year < 1978) return null;
            return new Local.EarlyMayBankHoliday().Build(year).First().ObservedDate;
        }

        /// <summary>
        /// The Spring/Last Monday in May holiday (replaced variable Whit Monday in 1971)
        /// </summary>
        public static DateTime Spring(int year)
        {
            return new Local.SpringBankHoliday().Build(year).First().ObservedDate;
        }

        /// <summary>
        /// Scotland only. Summer bank holiday (first Monday in August)
        /// </summary>
        public static DateTime SummerScotland(int year)
        {
            return HolidayCalculator.FindFirstMonday(new DateTime(year, 8, 1));
        }

        /// <summary>
        /// Summer bank holiday (last Monday in August). Not Scotland.
        /// </summary>
        public static DateTime Summer(int year)
        {
            return HolidayCalculator.FindFirstMonday(new DateTime(year, 8, 25));
        }

        /// <summary>
        /// Good Friday (Friday before Easter)
        /// </summary>
        public static DateTime GoodFriday(int year)
        {
            return EasterCalculator.GoodFriday(EasterCalculator.GetEaster(year));
        }

        /// <summary>
        /// Easter Monday (Monday after Easter). Not a legal holiday in Scotland, but observed by clearing banks since 1996
        /// </summary>
        public static DateTime EasterMonday(int year)
        {
            return EasterCalculator.EasterMonday(EasterCalculator.GetEaster(year));
        }

        #endregion Individual Holidays

        /// <summary>
        /// Get a list of dates for all holidays in a year.
        /// </summary>
        /// <param name="year">The year</param>
        /// <returns>List of bank holidays</returns>
        public static IList<DateTime> BankHolidays(int year)
        {
            return new UKBankHoliday().PublicHolidays(year);
        }

        private IEnumerable<HolidayDefinition> GetDefinitions()
        {
            yield return new Common.NewYear { ObservedDateRule = HolidayCalculator.FixWeekend, AppliesInYear = Since1974 };
            if (UkCountry == UkCountries.Scotland)
            {
                yield return new Local.NewYearHolidayScotland();
            }
            if (UkCountry == UkCountries.NorthernIreland)
            {
                yield return new Christian.StPatricksDay { ObservedDateRule = HolidayCalculator.FixWeekend };
            }
            yield return new Christian.GoodFriday();
            if (UkCountry != UkCountries.Scotland)
            {
                yield return new Christian.EasterMonday();
            }
            yield return new Local.RoyalWedding2011();
            yield return new Local.EarlyMayBankHoliday();
            yield return new Local.CoronationCharlesIII();
            yield return new Local.SpringBankHoliday();
            yield return new Local.GoldenJubilee();
            yield return new Local.DiamondJubilee();
            yield return new Local.PlatinumJubilee();
            if (UkCountry == UkCountries.NorthernIreland)
            {
                yield return new Local.BattleOfTheBoyne();
            }
            if (UkCountry == UkCountries.Scotland)
            {
                yield return new Local.SummerBankHolidayScotland();
                yield return new Local.WorldCup2026Scotland();
            }
            else
            {
                yield return new Local.SummerBankHoliday();
            }
            yield return new Local.QueenElizabethFuneral();
            if (UkCountry == UkCountries.Scotland)
            {
                yield return new Local.StAndrewsDay();
            }
            yield return new Christian.Christmas { ObservedDateRule = Local.UnitedKingdomWeekendRule.SaturdayOrSundayPlusTwo };
            yield return new Local.BoxingDay();
        }

        private static bool Since1974(int year)
        {
            return year > 1973;
        }

        /// <summary>
        /// All bank holidays of the year for the configured <see cref="UkCountry"/>.
        /// </summary>
        /// <param name="year">The year</param>
        /// <returns>Every holiday with actual and observed dates</returns>
        protected override IList<Holiday> PublicHolidaysComplete(int year)
        {
            var list = new List<Holiday>();
            foreach (var definition in GetDefinitions())
            {
                list.AddRange(definition.Build(year));
            }
            return list;
        }

        /// <summary>
        /// Check if a specific date is a public holiday.
        /// </summary>
        /// <param name="dt">The date you wish to check</param>
        /// <returns>
        /// True if date is a bank holiday (excluding weekends)
        /// </returns>
        public override bool IsPublicHoliday(DateTime dt)
        {
            return IsPublicHolidayFromComplete(dt);
        }

        /// <summary>
        /// Check if a specific date is a bank holiday.
        /// Obviously the BankHoliday list is more efficient for repeated checks
        /// </summary>
        /// <param name="dt">The date you wish to check</param>
        /// <returns>True if date is a bank holiday (excluding weekends)</returns>
        public virtual bool IsBankHoliday(DateTime dt)
        {
            return IsPublicHoliday(dt);
        }
    }
}
