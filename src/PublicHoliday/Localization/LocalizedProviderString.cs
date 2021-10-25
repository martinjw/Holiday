using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace PublicHoliday.Localization
{
    /// <summary>
    /// 
    /// </summary>
    class LocalizedProviderString : ILocalizedProvider<string>
    {

        /// <summary>
        /// Ressource in a XDocument
        /// </summary>
        private readonly IRessourceProvider<XDocument> _RessourceProviderXDocument;

        /// <summary>
        /// Ressource, if not exist obtain.
        /// </summary>
        private XDocument _RessourceXDocument;
        private XDocument RessourceXDocument {
            get
            {
                if (_RessourceXDocument == null)
                {
                    _RessourceXDocument = _RessourceProviderXDocument.GetRessource();
                }
                
                return _RessourceXDocument;
            }
            set
            {
                _RessourceXDocument = value;
            }
             
        }

        /// <summary>
        /// Default CultureInfo.
        /// </summary>
        public CultureInfo DefaultCultureInfo { get; set; }

        /// <summary>
        /// Constructor, specified the provider of Ressource
        /// Set default CultureInfo to "en"
        /// </summary>
        /// <param name="RessourceProviderXDocument">RessourceProvider to use</param>
        public LocalizedProviderString(IRessourceProvider<XDocument> RessourceProviderXDocument)
        {
            DefaultCultureInfo = new CultureInfo("en");
            _RessourceProviderXDocument = RessourceProviderXDocument;
        }

        /// <summary>
        /// Obtain the string of the id and CultureInfo with logic if not find
        /// </summary>
        /// <param name="id">id of the text to search</param>
        /// <param name="culture">CultureInfo of the text to search</param>
        /// <returns>Text find or Empty</returns>
        public string GetLocalized(string id, CultureInfo culture)
        {
            TryGetLocalized(id, culture, out string Result);
            return Result;
        }

        /// <summary>
        /// Obtain the string of the id and the default CultureInfo
        /// </summary>
        /// <param name="id">id of the text to search</param>
        /// <returns>Text find or Empty</returns>
        public string GetLocalized(string id)
        {
            TryGetLocalized(id, DefaultCultureInfo, out string Result);
            return Result;
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
            bool Result = false;
            //Search with parameter
            var Element = getXdocumentValue(RessourceXDocument, culture.Name, id);
            value = "";

            
            if (Element == null && culture.Name != culture.TwoLetterISOLanguageName)
            {
                //Search with language of CultureInfo
                Element = getXdocumentValue(RessourceXDocument, culture.TwoLetterISOLanguageName, id);
            }

            
            if (Element == null && culture.TwoLetterISOLanguageName != DefaultCultureInfo.TwoLetterISOLanguageName)
            {
                //Search with default CultureInfo
                Element = getXdocumentValue(RessourceXDocument, DefaultCultureInfo.TwoLetterISOLanguageName, id);
            }

            if (Element != null)
            {
                var Attribute = Element.Attribute("value").Value;

                if (Attribute != null)
                {
                    value = Attribute.ToString();
                    Result = true;
                }
            }

            return Result;
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
        private XElement getXdocumentValue(XDocument doc, string culture, string IdText)
        {
            var value = (from xml2 in doc.Descendants("root").Descendants(culture).Descendants(IdText)
                          select xml2).FirstOrDefault();
            return value;
        }

    }
}
