using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace PublicHoliday.Localization
{
    class LocalizedProviderString : ILocalizedProvider<string>
    {

        private readonly IRessourceProvider<XDocument> _RessourceProviderXDocument;

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

        public CultureInfo DefaultCultureInfo { get; set; }

        public LocalizedProviderString(IRessourceProvider<XDocument> RessourceProviderXDocument)
        {
            DefaultCultureInfo = new CultureInfo("en");
            _RessourceProviderXDocument = RessourceProviderXDocument;
        }

        public string GetLocalized(string id, CultureInfo culture)
        {
            TryGetLocalized(id, culture, out string Result);
            return Result;
        }

        public string GetLocalized(string id)
        {
            TryGetLocalized(id, DefaultCultureInfo, out string Result);
            return Result;
        }

        public bool TryGetLocalized(string id, CultureInfo culture, out string value)
        {
            bool Result = false;
            var Element = getXdocumentValue(RessourceXDocument, culture.Name, id);
            value = "";

            if (Element == null && culture.Name != culture.TwoLetterISOLanguageName)
            {
                Element = getXdocumentValue(RessourceXDocument, culture.TwoLetterISOLanguageName, id);

            }

            if (Element == null && culture.TwoLetterISOLanguageName != DefaultCultureInfo.TwoLetterISOLanguageName)
            {
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

        public bool TryGetLocalized(string id, out string value)
        {
            return TryGetLocalized(id, DefaultCultureInfo, out value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="culture"></param>
        /// <param name="IdText"></param>
        /// <returns></returns>
        private XElement getXdocumentValue(XDocument doc, string culture, string IdText)
        {
            var value = (from xml2 in doc.Descendants("root").Descendants(culture).Descendants(IdText)
                          select xml2).FirstOrDefault();
            return value;
        }

    }
}
