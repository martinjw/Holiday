using System;
using System.Collections.Generic;
using PublicHoliday.HolidayDefinitions;
using PublicHoliday.HolidayDefinitions.Christian;
using Christian = PublicHoliday.HolidayDefinitions.Christian;
using Common = PublicHoliday.HolidayDefinitions.Common;
using Local = PublicHoliday.HolidayDefinitions.CountrySpecific.Netherlands;
using PublicHoliday.HolidayDefinitions.Base;
using System.Globalization;
using PublicHoliday.Localization;

namespace PublicHoliday
{
    /// <summary>
    /// Holiday calendar for the Netherlands
    /// </summary>
    /// <remarks>
    /// Easter Sunday is a public holiday in the Netherlands, but it is always Sunday (not a normal working day). To include it in <c>PublicHolidays</c> set <see cref="IncludeEasterSunday"/> to true.
    /// </remarks>
    public class DutchPublicHoliday : PublicHolidayBase
	{

		/// <summary>
		/// Culture whose language this calendar's holiday names are in: Dutch.
		/// Used by <see cref="Holiday.GetName(CultureInfo)"/> when the requested
		/// culture has no translation.
		/// </summary>
		protected override CultureInfo CountryCulture => _defaultCulture;

		private static readonly CultureInfo _defaultCulture = SafeCulture.Get("nl-NL", "nl");
		private readonly bool _liberationDayOnlyAtLustrum = false;

		#region Individual Holidays

		/// <summary>
		/// New Year's Day January 1 - Nieuwjaarsdag
		/// </summary>
		/// <param name="year">The year.</param>
		/// <returns>Date of in the given year.</returns>
		public static DateTime NewYear(int year)
		{
			return new DateTime(year, 1, 1);
		}

		/// <summary>
		/// "Good Friday" / "Goede Vrijdag"
		/// </summary>
		/// <remarks>It depends on the company if Good Friday is a free holiday</remarks>
		public static DateTime GoodFriday(int year)
		{
			return EasterCalculator.GoodFriday(EasterCalculator.GetEaster(year));
		}

        /// <summary>
        /// Easter Sunday / Eerste paasdag
        /// </summary>
        public static DateTime EasterSunday(int year)
        {
            var hol = EasterCalculator.GetEaster(year);
            return hol;
        }

        /// <summary>
        /// Include Easter Sunday as a public holiday.
        /// </summary>
        /// <value>
        /// Set to <c>true</c> to see Easter Sunday in <c>PublicHolidays</c> and <c>PublicHolidayNames</c>.
        /// </value>
        public bool IncludeEasterSunday
        {
            get { return _includeEasterSunday; }
            set { _includeEasterSunday = value; ClearHolidayCache(); }
        }
        private bool _includeEasterSunday;
        /// <summary>
        /// Easter Monday 1st Monday after Easter - Paasmaandag
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime EasterMonday(int year)
		{
			return EasterCalculator.EasterMonday(EasterCalculator.GetEaster(year));
		}

		

		/// <summary>
		/// Kingsday/Queensday - Koningsdag/Koninginnendag
		/// </summary>
		/// <param name="year">The year.</param>
		/// <returns>Date of in the given year.</returns>
		public static DateTime KingsDay(int year)
		{
			var date = new DateTime(year, 4, 27);
			if (year < 1949)
				date = new DateTime(year, 8, 31);
			else if (year < 2014)
			{
				date = new DateTime(year, 4, 30);
			}

			if (date.DayOfWeek == DayOfWeek.Sunday)
				date = date.AddDays(-1);

			return date;
		}

		/// <summary>
		/// Liberation Day May 5 - Bevrijdingsdag
		/// </summary>
		/// <param name="year">The year.</param>
		/// <param name="onlyAtLustrum">Specify if LiberationDay has to be a holiday only at lustrum years</param>
		/// <returns>Date of in the given year.</returns>
		public static DateTime? LiberationDay(int year, bool onlyAtLustrum = false)
		{
			if (year >= 2020 && onlyAtLustrum) // since 2020 it depends on the sector
			{
				if (year % 5 == 0)
					return new DateTime(year, 5, 5);
				return null;
			}

			if (year >= 1990) //annual since 1990
				return new DateTime(year, 5, 5);

			if (year >= 1945) //introduced in 1945 every 5 years
			{
				if (year % 5 == 0)
					return new DateTime(year, 5, 5);
			}
			return null;
		}

		/// <summary>
		/// Ascension 6th Thursday after Easter - Hemelvaartsdag
		/// </summary>
		/// <param name="year">The year.</param>
		/// <returns>Date of in the given year.</returns>
		public static DateTime Ascension(int year)
		{
			return EasterCalculator.AscensionDay(EasterCalculator.GetEaster(year));
		}

		

		/// <summary>
		/// Whit Monday - Pentecost Monday 7th Monday after Easter - Pinkstermaandag
		/// </summary>
		public static DateTime PentecostMonday(int year)
		{
			return EasterCalculator.WhitMonday(EasterCalculator.GetEaster(year));
		}

		

		/// <summary>
		/// Christmas - December 25 - Eerste Kerstdag
		/// </summary>
		public static DateTime Christmas(int year)
		{
			return new DateTime(year, 12, 25);
		}

		/// <summary>
		/// Boxing Day - December 26 - Tweede Kerstdag
		/// </summary>
		public static DateTime BoxingDay(int year)
		{
			return new DateTime(year, 12, 26);
		}

		#endregion

		/// <summary>
		/// Default - includes Liberation Day as default
		/// </summary>
		public DutchPublicHoliday()
		{
		}

		/// <summary>
		/// Specify whether to include Liberation Day only at lustrum years
		/// </summary>
		public DutchPublicHoliday(bool liberationDayOnlyAtLustrum)
		{
			_liberationDayOnlyAtLustrum = liberationDayOnlyAtLustrum;
		}

		private IEnumerable<HolidayDefinition> GetDefinitions()
		{
			yield return new Common.NewYear();
			if (IncludeEasterSunday)
				yield return new Christian.EasterSunday();
			yield return new Christian.EasterMonday();
			yield return new Local.KingsDay();
			yield return new Local.LiberationDay(_liberationDayOnlyAtLustrum);
			yield return new Christian.Ascension();
			yield return new Christian.WhitMonday();
			yield return new Christian.Christmas();
			yield return new Christian.SaintStephensDay();
		}

		/// <summary>
		/// All Dutch public holidays for the year.
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
