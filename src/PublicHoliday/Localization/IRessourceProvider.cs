using System;
using System.Collections.Generic;
using System.Text;

namespace PublicHoliday.Localization
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface IRessourceProvider<T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        T GetRessource();

    }
}
