namespace PublicHoliday.Localization
{
    /// <summary>
    /// Interface of ResourceProvider
    /// </summary>
    /// <typeparam name="T">Type of Resource</typeparam>
    internal interface IResourceProvider<T>
    {
        /// <summary>
        /// Get Resource
        /// </summary>
        /// <returns>Resources of type T</returns>
        T GetResource();
    }
}