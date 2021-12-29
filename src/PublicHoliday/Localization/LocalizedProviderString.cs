using System.Globalization;
using System.Linq;
using System.Xml.Linq;

namespace PublicHoliday.Localization
{
    /// <summary>
    ///
    /// </summary>
    internal class LocalizedProviderString : ILocalizedProvider<string>
    {
        /// <summary>
        /// Resource in a XDocument
        /// </summary>
        private readonly IResourceProvider<XDocument> _resourceProviderXDocument;

        /// <summary>
        /// Resource, if not exist obtain.
        /// </summary>
        private XDocument _resourceXDocument;

        private XDocument ResourceXDocument
        {
            get
            {
                if (_resourceXDocument == null)
                {
                    _resourceXDocument = _resourceProviderXDocument.GetResource();
                }

                return _resourceXDocument;
            }
            set
            {
                _resourceXDocument = value;
            }
        }

        /// <summary>
        /// Default CultureInfo.
        /// </summary>
        public CultureInfo DefaultCultureInfo { get; set; }

        /// <summary>
        /// Constructor, specified the provider of Resource
        /// Set default CultureInfo to "en"
        /// </summary>
        /// <param name="resourceProviderXDocument">ResourceProvider to use</param>
        public LocalizedProviderString(IResourceProvider<XDocument> resourceProviderXDocument)
        {
            DefaultCultureInfo = new CultureInfo("en");
            _resourceProviderXDocument = resourceProviderXDocument;
        }

        /// <summary>
        /// Obtain the string of the id and CultureInfo with logic if not find
        /// </summary>
        /// <param name="id">id of the text to search</param>
        /// <param name="culture">CultureInfo of the text to search</param>
        /// <returns>Text find or Empty</returns>
        public string GetLocalized(string id, CultureInfo culture)
        {
            TryGetLocalized(id, culture, out string result);
            return result;
        }

        /// <summary>
        /// Obtain the string of the id and the default CultureInfo
        /// </summary>
        /// <param name="id">id of the text to search</param>
        /// <returns>Text find or Empty</returns>
        public string GetLocalized(string id)
        {
            TryGetLocalized(id, DefaultCultureInfo, out string result);
            return result;
        }

        /// <summary>
        /// Try obtain the string of the id and the CultureInfo.
        /// If we not find, try the language o  parameter else the default CultureInfo.
        /// </summary>
        /// <param name="id">id of the text to search</param>
        /// <param name="culture">CultureInfo of the text to search</param>
        /// <param name="value">Text find or Empty</param>
        /// <returns>If we find or not a text</returns>
        public bool TryGetLocalized(string id, CultureInfo culture, out string value)
        {
            bool result = false;
            //Search with parameter
            var element = XDocumentValue(ResourceXDocument, culture.Name, id);
            value = "";

            if (element == null && culture.Name != culture.TwoLetterISOLanguageName)
            {
                //Search with language of CultureInfo
                element = XDocumentValue(ResourceXDocument, culture.TwoLetterISOLanguageName, id);
            }

            if (element == null && culture.TwoLetterISOLanguageName != DefaultCultureInfo.TwoLetterISOLanguageName)
            {
                //Search with default CultureInfo
                element = XDocumentValue(ResourceXDocument, DefaultCultureInfo.TwoLetterISOLanguageName, id);
            }

            var attribute = element?.Attribute("value")?.Value;

            if (attribute != null)
            {
                value = attribute.ToString();
                result = true;
            }

            return result;
        }

        /// <summary>
        /// Try obtain the string of the id and the default CultureInfo
        /// </summary>
        /// <param name="id">id of the text to search</param>
        /// <param name="value">Text find or Empty</param>
        /// <returns>If we find or not the id with default CultureInfo</returns>
        public bool TryGetLocalized(string id, out string value)
        {
            return TryGetLocalized(id, DefaultCultureInfo, out value);
        }

        /// <summary>
        /// Search for the culture and id in the doc
        /// </summary>
        /// <param name="doc">doc in which to search</param>
        /// <param name="culture">Culture of the text to search</param>
        /// <param name="IdText">Id of the text to search</param>
        /// <returns>XElement find or null</returns>
        private XElement XDocumentValue(XDocument doc, string culture, string IdText)
        {
            var value = (from xml2 in doc.Descendants("root").Descendants(culture).Descendants(IdText)
                         select xml2).FirstOrDefault();
            return value;
        }
    }
}