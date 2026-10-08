using System;
using System.Collections.Generic;
using PublicHoliday.HolidayDefinitions;
using PublicHoliday.HolidayDefinitions.Christian;
using Christian = PublicHoliday.HolidayDefinitions.Christian;
using Common = PublicHoliday.HolidayDefinitions.Common;
using Local = PublicHoliday.HolidayDefinitions.CountrySpecific.Italy;
using PublicHoliday.HolidayDefinitions.Base;
using System.Globalization;
using PublicHoliday.Localization;

namespace PublicHoliday
{
    /// <summary>
    /// Holidays in Italy
    /// </summary>
    public class ItalyPublicHoliday : PublicHolidayBase
    {

        /// <summary>
        /// Culture whose language this calendar's holiday names are in: Italian.
        /// Used by <see cref="Holiday.GetName(CultureInfo)"/> when the requested
        /// culture has no translation.
        /// </summary>
        protected override CultureInfo CountryCulture => _defaultCulture;

        private static readonly CultureInfo _defaultCulture = SafeCulture.Get("it-IT", "it");
        #region Individual Holidays

        /// <summary>
        /// Capodanno - New Year's Day
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime NewYear(int year)
        {
            return new DateTime(year, 1, 1);
        }

        /// <summary>
        /// Epifania - Epiphany January 6
        /// </summary>

        public static DateTime Epiphany(int year)
        {
            return new DateTime(year, 1, 6);
        }

        /// <summary>
        /// Pasqua - Easter
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        private static DateTime Easter(int year)
        {
            return EasterCalculator.GetEaster(year); ;
        }

        /// <summary>
        /// Pasquetta - Easter Monday
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime EasterMonday(int year)
        {
            return EasterCalculator.EasterMonday(EasterCalculator.GetEaster(year));
        }

        private static DateTime EasterMonday(DateTime easter)
        {
            return EasterCalculator.EasterMonday(easter);
        }

        /// <summary>
        /// Festa della Liberazione- Liberation Day
        /// </summary>
        /// <param name="year">The year.</param>
        public static DateTime LiberationDay(int year)
        {
            return new DateTime(year, 4, 25);
        }

        /// <summary>
        /// Festa del Lavoro - Labour Day
        /// </summary>
        /// <param name="year">The year.</param>
        public static DateTime LabourDay(int year)
        {
            return new DateTime(year, 5, 1);
        }

        /// <summary>
        /// Festa della Repubblica - Republic Day
        /// </summary>
        public static DateTime RepublicDay(int year)
        {
            return new DateTime(year, 6, 2);
        }

        /// <summary>
        /// Ferragosto - Assumption of Mary
        /// </summary>
        public static DateTime Assumption(int year)
        {
            return new DateTime(year, 8, 15);
        }


        /// <summary>
        /// Tutti i santi - All Saints
        /// </summary>

        public static DateTime AllSaints(int year)
        {
            return new DateTime(year, 11, 1);
        }
        /// <summary>
        /// Immacolata Concezione - Immaculate Conception
        /// </summary>

        public static DateTime ImmaculateConception(int year)
        {
            return new DateTime(year, 12, 8);
        }

        /// <summary>
        /// Natale - Christmas
        /// </summary>
        public static DateTime Christmas(int year)
        {
            return new DateTime(year, 12, 25);
        }

        /// <summary>
        /// Santo Stefano - St Stephen's Day
        /// </summary>
        public static DateTime StStephen(int year)
        {
            return new DateTime(year, 12, 26);
        }

        #endregion Individual Holidays

        //Liberation Day (25 April) can fall on Easter or Easter Monday (e.g. 2011);
        //same-day holidays stay distinct entries (names aggregated by the base class)
        private static readonly HolidayDefinition[] Definitions =
        {
            new Common.NewYear(),
            new Christian.Epiphany(),
            new Christian.EasterSunday(),
            new Christian.EasterMonday(),
            new Local.LiberationDay(),
            new Common.LabourDay(),
            new Local.RepublicDay(),
            new Christian.Assumption(),
            new Christian.AllSaints(),
            new Christian.ImmaculateConception(),
            new Christian.Christmas(),
            new Christian.SaintStephensDay(),
        };

        /// <summary>
        /// All Italian public holidays for the year (names in Italian).
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
