using System;
using System.Collections.Generic;
using System.Text;

namespace PublicHoliday.Localization
{
    /// <summary>
    /// Interface of RessourceProvider of T
    /// </summary>
    /// <typeparam name="T">Type of Ressource</typeparam>
    interface IRessourceProvider<T>
    {
        /// <summary>
        /// Get ressource
        /// </summary>
        /// <returns>Ressources of type T</returns>
        T GetRessource();

    }
}
