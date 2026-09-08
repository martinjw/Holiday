using System;
using System.Collections.Generic;

namespace PublicHoliday.Localization
{
    /// <summary>
    /// Registry of <see cref="IHolidayNameProvider"/>s that supply holiday names from outside the library.
    /// Process-wide, normally set up once at start-up:
    /// <code>
    /// HolidayNameProviders.Add(new ResourceManagerNameProvider(MyHolidayNames.ResourceManager));
    /// </code>
    /// Providers are consulted before the library's own names, in the order registered.
    /// </summary>
    public static class HolidayNameProviders
    {
        private static readonly object Sync = new object();

        //replaced wholesale on change, so readers need no lock
        private static volatile IHolidayNameProvider[] _providers = new IHolidayNameProvider[0];

        /// <summary>
        /// The registered providers, in the order they are consulted.
        /// </summary>
        public static IEnumerable<IHolidayNameProvider> All
        {
            get { return _providers; }
        }

        /// <summary>
        /// Registers a provider, after any already registered. Registering the same instance twice does nothing.
        /// </summary>
        /// <param name="provider">The provider. Not null.</param>
        public static void Add(IHolidayNameProvider provider)
        {
            if (provider == null) throw new ArgumentNullException("provider");

            lock (Sync)
            {
                var current = _providers;
                if (Array.IndexOf(current, provider) >= 0) return;

                var updated = new IHolidayNameProvider[current.Length + 1];
                Array.Copy(current, updated, current.Length);
                updated[current.Length] = provider;
                _providers = updated;
            }
        }

        /// <summary>
        /// Unregisters a provider.
        /// </summary>
        /// <param name="provider">The instance passed to <see cref="Add"/>.</param>
        /// <returns>True when it was registered.</returns>
        public static bool Remove(IHolidayNameProvider provider)
        {
            if (provider == null) return false;

            lock (Sync)
            {
                var current = _providers;
                var index = Array.IndexOf(current, provider);
                if (index < 0) return false;

                var updated = new IHolidayNameProvider[current.Length - 1];
                Array.Copy(current, 0, updated, 0, index);
                Array.Copy(current, index + 1, updated, index, current.Length - index - 1);
                _providers = updated;
                return true;
            }
        }

        /// <summary>
        /// Unregisters every provider, leaving only the library's own names.
        /// </summary>
        public static void Clear()
        {
            lock (Sync)
            {
                _providers = new IHolidayNameProvider[0];
            }
        }

        internal static IHolidayNameProvider[] Snapshot
        {
            get { return _providers; }
        }
    }
}
