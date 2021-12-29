using System.IO;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace PublicHoliday.Localization
{
    /// <summary>
    /// Resource in XDocument
    /// </summary>
    internal class ResourceProviderXDocument : IResourceProvider<XDocument>
    {
        /// <summary>
        /// Get XDocument from from the internal XML LocalizationString
        /// </summary>
        /// <returns>XDocument with Resource</returns>
        XDocument IResourceProvider<XDocument>.GetResource()
        {
            XDocument Result;

#if NETSTANDARD1_0_OR_GREATER || NET451_OR_GREATER || NETCOREAPP1_0_OR_GREATER

            Assembly asm = typeof(ResourceProviderXDocument).GetTypeInfo().Assembly;
            Stream resource = asm.GetManifestResourceStream("PublicHoliday.Localization.LocalizationString.xml");
            Result = XDocument.Load(resource);

#else

            string Texte;
                using (StreamReader reader = new StreamReader(new ResourceProviderXDocument().GetType().Assembly.GetManifestResourceStream("PublicHoliday.Localization.LocalizationString.xml"), Encoding.UTF8))
                {
                     Texte = reader.ReadToEnd();
                }

                Result = XDocument.Load(Texte);

#endif

            return Result;
        }
    }
}