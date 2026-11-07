using System.Globalization;

namespace PublicHoliday
{
    /// <summary>
    /// Set-up helpers that read as one expression.
    /// </summary>
    public static class CalendarExtensions
    {
        /// <summary>
        /// The same calendar, answering in <paramref name="culture"/>, so
        /// <see cref="Holiday.Name"/> is in that language without passing a culture to every call.
        /// Returns the calendar itself, and keeps its type, so it combines with a region:
        /// <code>
        /// new CanadaPublicHoliday("QC").WithCulture("fr-CA");
        /// PublicHolidayFactory.GetPublicHolidayForCountry("BE").WithCulture(CultureInfo.CurrentUICulture);
        /// new BelgiumPublicHoliday().WithCulture("fr-BE");
        /// new AustraliaPublicHoliday { State = AustraliaPublicHoliday.States.NSW }.WithCulture("en-AU");
        /// </code>
        /// </summary>
        /// <param name="calendar">The calendar. Not null.</param>
        /// <param name="culture">A culture name, e.g. "fr-CA"; null or empty leaves the country's
        /// own language in place.</param>
        public static T WithCulture<T>(this T calendar, string culture) where T : IPublicHolidays
        {
            return calendar.WithCulture(string.IsNullOrEmpty(culture) ? null : new CultureInfo(culture));
        }

        /// <summary>
        /// The same calendar, answering in <paramref name="culture"/>. See
        /// <see cref="WithCulture{T}(T, string)"/>.
        /// </summary>
        /// <param name="calendar">The calendar. Not null.</param>
        /// <param name="culture">The culture to answer in; null leaves the country's own language
        /// in place.</param>
        public static T WithCulture<T>(this T calendar, CultureInfo culture) where T : IPublicHolidays
        {
            if (culture != null)
            {
                calendar.Culture = culture;
            }
            return calendar;
        }
    }
}
