using System;
using System.Globalization;
using System.Resources;

namespace PublicHoliday.Localization
{
    /// <summary>
    /// An <see cref="IHolidayNameProvider"/> over your own .resx, so supplying holiday names in a language the
    /// library does not ship is one line of set-up:
    /// <code>
    /// // MyHolidayNames.resx / MyHolidayNames.pl.resx, rows named after the holiday's HolidayKey
    /// HolidayNameProviders.Add(new ResourceManagerNameProvider(MyHolidayNames.ResourceManager));
    /// </code>
    /// </summary>
    public sealed class ResourceManagerNameProvider : IHolidayNameProvider
    {
        private readonly ResourceManager _resources;

        /// <summary>
        /// Wraps a resource manager - typically the generated <c>ResourceManager</c> property of your .resx.
        /// </summary>
        /// <param name="resources">The resource manager. Not null.</param>
        public ResourceManagerNameProvider(ResourceManager resources)
        {
            if (resources == null) throw new ArgumentNullException("resources");
            _resources = resources;
        }

        /// <summary>
        /// The name for the key in exactly this culture, from the wrapped resources.
        /// </summary>
        /// <param name="holidayKey">The holiday's stable id, used as the resource name.</param>
        /// <param name="culture">The culture to answer for, exactly.</param>
        /// <param name="name">The name found, or null.</param>
        /// <returns>True when the resources hold that name for that exact culture.</returns>
        public bool TryGetName(string holidayKey, CultureInfo culture, out string name)
        {
            name = null;
            if (string.IsNullOrEmpty(holidayKey) || culture == null) return false;

            try
            {
                //tryParents: false - fallback is the library's job, and doing our own would let a
                //culture-neutral row beat a regional one
                var set = _resources.GetResourceSet(culture, true, false);
                if (set == null) return false;
                name = set.GetString(holidayKey);
            }
            catch (MissingManifestResourceException) { return false; }
            catch (MissingSatelliteAssemblyException) { return false; }

            return !string.IsNullOrEmpty(name);
        }
    }
}
