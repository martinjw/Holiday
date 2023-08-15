using PublicHoliday.Localization;
using System;
using System.Globalization;

namespace PublicHoliday
{
    /// <summary>
    /// A holiday
    /// </summary>
    public class Holiday
    {

        internal static LocalizedProviderString LocalizedProviderString = new LocalizedProviderString(new ResourceProviderXDocument());

        /// <summary>
        /// Constructs the holiday
        /// </summary>
        /// <param name="date">The date of the current holiday</param>
        /// <param name="observedDate">The date the current holiday is observed on</param>
        public Holiday(DateTime date, DateTime observedDate)
        {
            HolidayDate = date;
            ObservedDate = observedDate;
        }

        /// <summary>
        /// Constructs the holiday
        /// </summary>
        /// <param name="date">The date of the current holiday</param>
        /// <param name="observedDate">The date the current holiday is observed on</param>
        /// <param name="idtexttocalization">The Id of text for the Localization</param>
        public Holiday(DateTime date, DateTime observedDate, string idtexttocalization)
        {
            HolidayDate = date;
            ObservedDate = observedDate;
            IdTextLocalization = idtexttocalization;
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
        /// Id of text for the localization
        /// </summary>
        public string IdTextLocalization { get; set; }

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
            return $"{GetName()} {ObservedDate:yyyy-MM-dd} {HolidayDate:yyyy-MM-dd}";
        }
    }
}