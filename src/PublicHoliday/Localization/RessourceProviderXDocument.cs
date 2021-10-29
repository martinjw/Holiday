using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace PublicHoliday.Localization
{
    /// <summary>
    /// Ressource in XDocument
    /// </summary>
    class RessourceProviderXDocument : IRessourceProvider<XDocument>
    {
       
        /// <summary>
        /// Get XDocument from from the internal XML LocalizationString
        /// </summary>
        /// <returns>XDocument with Ressource</returns>
        XDocument IRessourceProvider<XDocument>.GetRessource()
        {
            XDocument Result;

#if NETSTANDARD1_0_OR_GREATER || NET451_OR_GREATER || NETCOREAPP1_0_OR_GREATER

            Assembly asm = typeof(RessourceProviderXDocument).GetTypeInfo().Assembly;
            Stream resource = asm.GetManifestResourceStream("PublicHoliday.Localization.LocalizationString.xml");
            Result = XDocument.Load(resource);

#else

            string Texte;
                using (StreamReader reader = new StreamReader(new RessourceProviderXDocument().GetType().Assembly.GetManifestResourceStream("PublicHoliday.Localization.LocalizationString.xml"), Encoding.UTF8))
                {
                     Texte = reader.ReadToEnd();
                }

                Result = XDocument.Load(Texte);

#endif

            return Result;
        }
    }
}
