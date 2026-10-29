using System;
using System.Collections.Generic;
using System.Globalization;
using PublicHoliday.HolidayDefinitions;
using PublicHoliday.HolidayDefinitions.Christian;
using Christian = PublicHoliday.HolidayDefinitions.Christian;
using Common = PublicHoliday.HolidayDefinitions.Common;
using Local = PublicHoliday.HolidayDefinitions.CountrySpecific.Belgium;
using PublicHoliday.HolidayDefinitions.Base;

namespace PublicHoliday
{
    /// <summary>
    /// Finds Belgium public holidays. 
    /// Public holidays on Sundays are not deferred to following weekday automatically- 
    /// they may be taken at an arbitary date.
    /// </summary>
    /// <remarks>
    /// Strictly Easter Sunday is also a public holiday
    /// </remarks>
    public class BelgiumPublicHoliday : PublicHolidayBase
    {
        #region Individual Holidays

        /// <summary>
        /// New Year's Day January 1 Nieuwjaar / Nouvel An 
        /// </summary>
        public static DateTime NewYear(int year)
        {
            return new DateTime(year, 1, 1);
        }

        /// <summary>
        /// Easter Monday 1st Monday after Easter Paasmaandag / Lundi de Pâques
        /// </summary>
        public static DateTime EasterMonday(int year)
        {
            return EasterCalculator.EasterMonday(EasterCalculator.GetEaster(year));
        }

        //Labor Day May 1 Dag van de arbeid / Fête du Travail
        /// <summary>
        /// Mays the day.
        /// </summary>
        /// <param name="year">The year.</param>
        public static DateTime MayDay(int year)
        {
            return new DateTime(year, 5, 1);
        }


        /// <summary>
        /// Ascension 6th Thursday after Easter- Hemelvaartsdag / Ascension
        /// </summary>
        public static DateTime Ascension(int year)
        {
            return EasterCalculator.AscensionDay(EasterCalculator.GetEaster(year));
        }

        /// <summary>
        /// Whit Monday - Pentecost Monday 7th Monday after Easter Pinkstermaandag / Lundi de Pentecôte
        /// </summary>
        public static DateTime PentecostMonday(int year)
        {
            return EasterCalculator.WhitMonday(EasterCalculator.GetEaster(year));
        }

        /// <summary>
        /// National holiday July 21 Nationale feestdag / Fête nationale
        /// </summary>
        public static DateTime National(int year)
        {
            return new DateTime(year, 7, 21);
        }

        /// <summary>
        /// Assumption of Mary August 15 Onze Lieve Vrouw hemelvaart / Assomption
        /// </summary>
        public static DateTime Assumption(int year)
        {
            return new DateTime(year, 8, 15);
        }

        /// <summary>
        /// All Saints November 1 Allerheiligen / Toussaint 
        /// </summary>
        public static DateTime AllSaints(int year)
        {
            return new DateTime(year, 11, 1);
        }

        /// <summary>
        /// Armistice Day November 11 Wapenstilstand / Jour de l'armistice
        /// </summary>
        public static DateTime Armistice(int year)
        {
            return new DateTime(year, 11, 11);
        }

        /// <summary>
        /// Christmas December 25  Kerstmis / Noël
        /// </summary>
        public static DateTime Christmas(int year)
        {
            return new DateTime(year, 12, 25);
        }
        #endregion

        /// <summary>
        /// Culture used when <see cref="Holiday.GetName(CultureInfo)"/> is
        /// asked for a culture with no match. Belgium has three official languages; Dutch (the
        /// largest) is the default. Use GetName("fr-BE") / GetName("de-BE") for the others.
        /// </summary>
        protected override CultureInfo CountryCulture => _defaultCulture;
        private static readonly CultureInfo _defaultCulture = new CultureInfo("nl-BE");

        private static readonly HolidayDefinition[] Definitions =
        {
            new Common.NewYear(),
            new Christian.EasterMonday(),
            new Common.LabourDay(),
            new Christian.Ascension(),
            new Christian.WhitMonday(),
            new Local.NationalDay(),
            new Christian.Assumption(),
            new Christian.AllSaints(),
            new Common.Armistice(),
            new Christian.Christmas(),
        };

        /// <summary>
        /// All Belgian public holidays for the year. Names resolve per culture
        /// (nl-BE / fr-BE / de-BE) via <see cref="Holiday.GetName(CultureInfo)"/>.
        /// </summary>
        /// <param name="year">The year.</param>
        protected override IList<Holiday> PublicHolidaysComplete(int year)
        {
            var list = new List<Holiday>();
            foreach (var definition in Definitions)
            {
                list.AddRange(definition.Build(year));
            }
            return list;
        }
    }
}