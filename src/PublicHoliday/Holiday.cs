using PublicHoliday.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace PublicHoliday
{
    /// <summary>
    /// A holiday
    /// </summary>
    public class Holiday
    {

        internal static LocalizedProviderString LocalizedProviderString = new LocalizedProviderString(new ResourceProviderXDocument());
        private readonly string _localName;

        /// <summary>
        /// Constructs the holiday with a date and invariant name
        /// </summary>
        /// <param name="date"></param>
        /// <param name="englishName"></param>
        public Holiday(DateTime date, string englishName)
        {
            HolidayDate = date;
            ObservedDate = HolidayDate;
            EnglishName = englishName;
            IsPublic = true;
        }

        /// <summary>
        /// Constructs the holiday with a date, invariant name and localized name
        /// </summary>
        /// <param name="date"></param>
        /// <param name="englishName"></param>
        /// <param name="localName"></param>
        public Holiday(DateTime date, string englishName, string localName)
        {
            HolidayDate = date;
            ObservedDate = HolidayDate;
            EnglishName = englishName;
            _localName = localName;
            IsPublic = true;
        }

        /// <summary>
        /// Constructs the holiday
        /// </summary>
        /// <param name="date">The date of the current holiday</param>
        /// <param name="observedDate">The date the current holiday is observed on</param>
        public Holiday(DateTime date, DateTime observedDate)
        {
            HolidayDate = date;
            ObservedDate = observedDate;
            IsPublic = true;
        }

        /// <summary>
        /// Constructs the holiday
        /// </summary>
        /// <param name="date">The date of the current holiday</param>
        /// <param name="observedDate">The date the current holiday is observed on</param>
        /// <param name="idTextLocalization">The Id of text for the Localization</param>
        public Holiday(DateTime date, DateTime observedDate, string idTextLocalization)
        {
            HolidayDate = date;
            ObservedDate = observedDate;
            IdTextLocalization = idTextLocalization;
            IsPublic = true;
        }

        /// <summary>
        /// Constructs the holiday
        /// </summary>
        /// <param name="date">The date of the current holiday</param>
        /// <param name="observedDate">The date the current holiday is observed on</param>
        /// <param name="englishName"></param>
        /// <param name="localName"></param>
        /// <param name="regions">Names of regions of the country where this holiday exists</param>
        public Holiday(DateTime date, string englishName, string localName, string[] regions)
        {
            HolidayDate = date;
            ObservedDate = HolidayDate;
            EnglishName = englishName;
            _localName = localName;
            IsPublic = false;
            Regions = regions;
        }

        /// <summary>
        /// The date the Holiday is actually observed on
        /// </summary>
        public DateTime ObservedDate { get; set; }

        /// <summary>
        /// Date for the current holiday
        /// </summary>
        public DateTime HolidayDate { get; set; }

        /// <summary>
        /// English name of holiday. Use <see cref="Name"/> for local name
        /// </summary>
        public string EnglishName { get; set; }

        /// <summary>
        /// Localized name. May be <see cref="EnglishName"/>
        /// </summary>
        public string Name
        {
            get
            {
                if (!string.IsNullOrEmpty(_localName)) return _localName;
                if (!string.IsNullOrEmpty(EnglishName)) return EnglishName;
                return GetName();
            }
        }

        /// <summary>
        /// Id of text for the localization
        /// </summary>
        public string IdTextLocalization { get; set; }

        /// <summary>
        /// Is the holiday a public holiday for all region
        /// </summary>
        public bool IsPublic { get; set; }

        /// <summary>
        /// Names of regions of the country where this holiday exists
        /// </summary>
        public string[] Regions { get; set; }

        /// <summary>
        /// Name from CultureInfo for the current holiday
        /// If not find Empty
        /// </summary>
        public string GetName(CultureInfo culture)
        {
            return LocalizedProviderString.GetLocalized(IdTextLocalization, culture);
        }

        /// <summary>
        /// Name for the current holiday
        /// If not find Empty
        /// </summary>
        public string GetName()
        {
            return LocalizedProviderString.GetLocalized(IdTextLocalization);
        }

        /// <summary>
        /// Gets the year component of the observed date
        /// </summary>
        public int Year => ObservedDate.Year;

        /// <summary>
        /// Gets the month component of the observed date
        /// </summary>
        public int Month => ObservedDate.Month;

        /// <summary>
        /// Gets the day component of the observed date
        /// </summary>
        public int Day => ObservedDate.Day;

        /// <summary>
        /// Gets the day of the week of the observed date
        /// </summary>
        public DayOfWeek DayOfWeek => ObservedDate.DayOfWeek;

        /// <summary>
        /// Implicitly casts a holiday as its observed date
        /// </summary>
        /// <param name="h">The holiday</param>
        public static implicit operator DateTime(Holiday h)
        {
            return h.ObservedDate;
        }

        /// <summary>
        /// The holiday name and date(s)
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Name} {ObservedDate:yyyy-MM-dd} {HolidayDate:yyyy-MM-dd}";
        }
    }

#if !NET6_0_OR_GREATER
    internal static class LinqExtensions
    {
        /// <summary>
        /// Implementation of net 6 DistinctBy for older versions of .net
        /// </summary>
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector)
        {
            var keys = new HashSet<TKey>();
            foreach (var element in source)
            {
                if (keys.Contains(keySelector(element))) continue;
                keys.Add(keySelector(element));
                yield return element;
            }
        }
    }
#endif

}