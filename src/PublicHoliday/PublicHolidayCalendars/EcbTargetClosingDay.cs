using System;
using System.Collections.Generic;
using PublicHoliday.HolidayDefinitions;
using PublicHoliday.HolidayDefinitions.Christian;
using Christian = PublicHoliday.HolidayDefinitions.Christian;
using Common = PublicHoliday.HolidayDefinitions.Common;
using PublicHoliday.HolidayDefinitions.Base;

namespace PublicHoliday
{
    /// <summary>
    /// ECB - SEPA TARGET Closing Days
    /// <para>List of days when SEPA is not processing transactions in the EURO area and not publishing currency exchange rates. 
    /// Based on source: 
    /// http://www.sepaforcorporates.com/single-euro-payments-area/european-sepa-target-closing-days-2017-2018/
    /// </para>
    /// </summary>
    public class EcbTargetClosingDay : PublicHolidayBase
    {

        #region Individual Holidays

        /// <summary>
        /// New Year’s Day January 1
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime NewYear(int year)
        {
            return new DateTime(year, 1, 1);
        }

        /// <summary>
        /// Good Friday
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime GoodFriday(int year)
        {
            return EasterCalculator.GoodFriday(EasterCalculator.GetEaster(year));
        }

        /// <summary>
        /// Easter Monday
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime EasterMonday(int year)
        {
            return EasterCalculator.EasterMonday(EasterCalculator.GetEaster(year));
        }

        /// <summary>
        /// Labour Day - May 1
        /// </summary>
        /// <returns>Date of in the given year.</returns>
        public static DateTime LabourDay(int year)
        {
            return new DateTime(year, 5, 1);
        }

        /// <summary>
        /// Christmas Day - December 25
        /// </summary>
        /// <returns>Date of in the given year.</returns>
        public static DateTime ChristmasDay(int year)
        {
            return new DateTime(year, 12, 25);
        }

        /// <summary>
        /// Christmas Holiday - December 26
        /// </summary>
        /// <returns>Date of in the given year.</returns>
        public static DateTime ChristmasHoliday(int year)
        {
            return new DateTime(year, 12, 26);
        }

        #endregion

        /// <summary>
        /// ECB - SEPA TARGET Closing Days (names in English).
        /// </summary>
        private static readonly HolidayDefinition[] Definitions =
        {
            new Common.NewYear(),
            new Christian.GoodFriday(),
            new Christian.EasterMonday(),
            new Common.LabourDay(),
            new Christian.Christmas(),
            new Christian.SaintStephensDay(),
        };

        /// <summary>
        /// All ECB TARGET closing days for the year.
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



