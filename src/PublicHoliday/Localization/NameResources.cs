using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml.Linq;

namespace PublicHoliday.Localization
{
    /// <summary>
    /// The holiday names shipped with the library: one .resx per culture (Names.de-AT.resx is what Austria
    /// calls its holidays, Names.de.resx the generic German translation), embedded in this assembly and
    /// read here. Answers for one culture only - <see cref="CultureFallback"/> decides which to try.
    /// </summary>
    internal static class NameResources
    {
        private const string ResourcePrefix = "PublicHoliday.Localization.Names.";

        private static readonly Dictionary<string, string> NoRows = new Dictionary<string, string>(0);
        private static readonly object Sync = new object();

        //file suffix ("de-AT", or "EcbTargetClosingDay.en-US") -> its rows. A file that does not exist
        //caches NoRows, so it is looked for once.
        private static readonly Dictionary<string, Dictionary<string, string>> Loaded =
            new Dictionary<string, Dictionary<string, string>>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// The shipped name for a key in this culture exactly, or null. English is never here: it is the
        /// definition's own EnglishName.
        /// </summary>
        /// <param name="holidayKey">The holiday's stable id.</param>
        /// <param name="culture">The culture to answer for, exactly.</param>
        /// <param name="calendarId">
        /// The calendar asking. Its own file (Names.EcbTargetClosingDay.en-US.resx) is read before the
        /// shared one for the culture, so a calendar that words a holiday differently from the culture it
        /// shares does not have to fight over the shared row. Optional - almost no calendar needs a file.
        /// </param>
        internal static string Find(string holidayKey, CultureInfo culture, string calendarId = null)
        {
            if (string.IsNullOrEmpty(holidayKey) || culture == null || string.IsNullOrEmpty(culture.Name))
            {
                return null;
            }

            return string.IsNullOrEmpty(calendarId)
                ? Row(culture.Name, holidayKey)
                : Row(calendarId + "." + culture.Name, holidayKey) ?? Row(culture.Name, holidayKey);
        }

        private static string Row(string fileSuffix, string holidayKey)
        {
            string name;
            RowsFor(fileSuffix).TryGetValue(holidayKey, out name);
            return string.IsNullOrEmpty(name) ? null : name;
        }

        private static Dictionary<string, string> RowsFor(string fileSuffix)
        {
            lock (Sync)
            {
                Dictionary<string, string> rows;
                if (!Loaded.TryGetValue(fileSuffix, out rows))
                {
                    Loaded[fileSuffix] = rows = Read(fileSuffix);
                }
                return rows;
            }
        }

        private static Dictionary<string, string> Read(string fileSuffix)
        {
            var stream = typeof(NameResources).Assembly.GetManifestResourceStream(ResourcePrefix + fileSuffix);
            if (stream == null) return NoRows;

            using (stream)
            using (var reader = new StreamReader(stream, Encoding.UTF8))
            {
                //Load(TextReader) is the only overload every target framework has
                var rows = new Dictionary<string, string>(StringComparer.Ordinal);
                foreach (var data in XDocument.Load(reader).Root.Elements("data"))
                {
                    var key = data.Attribute("name")?.Value;
                    var value = data.Element("value")?.Value;
                    if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
                    {
                        rows[key] = value;
                    }
                }
                return rows.Count == 0 ? NoRows : rows;
            }
        }
    }
}
