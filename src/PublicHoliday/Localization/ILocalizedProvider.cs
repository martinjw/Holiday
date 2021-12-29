using System.Globalization;

namespace PublicHoliday.Localization
{
    /// <summary>
    /// Interface of LocalizedProvider of T
    /// </summary>
    /// <typeparam name="T">Type of localized</typeparam>
    internal interface ILocalizedProvider<T>
    {
        /// <summary>
        /// Default CultureInfo
        /// </summary>
        CultureInfo DefaultCultureInfo { get; set; }

        /// <summary>
        /// Search for the Id of text the localization and the CultureInfo / CultureInfo Invariant / Default CultureInfo.
        /// </summary>
        /// <param name="id">Id of text to search</param>
        /// <param name="culture"></param>
        /// <returns>Value find, else null</returns>
        T GetLocalized(string id, CultureInfo culture);

        /// <summary>
        /// Search for the Id of text the localization and the default CultureInfo.
        /// </summary>
        /// <param name="id">Id of text to search</param>
        /// <returns>Value find, else null</returns>
        T GetLocalized(string id);

        /// <summary>
        /// Search for the Id of text the localization and the CultureInfo / CultureInfo Invariant / Default CultureInfo.
        /// </summary>
        /// <param name="id">Id of text to search</param>
        /// <param name="culture">CultureInfo to search</param>
        /// <param name="value">Value find, else null</param>
        /// <returns>True if find a value for id, else False</returns>
        bool TryGetLocalized(string id, CultureInfo culture, out T value);

        /// <summary>
        /// Search for the Id of text the localization and the Default CultureInfo.
        /// </summary>
        /// <param name="id">Id of text to search</param>
        /// <param name="value">Value find, else null</param>
        /// <returns>True if find a value for id, else False</returns>
        bool TryGetLocalized(string id, out T value);
    }
}