using System;
using System.Collections.Generic;
using PublicHoliday.HolidayDefinitions;
using PublicHoliday.HolidayDefinitions.Christian;
using Christian = PublicHoliday.HolidayDefinitions.Christian;
using Common = PublicHoliday.HolidayDefinitions.Common;
using Local = PublicHoliday.HolidayDefinitions.CountrySpecific.Slovenia;
using PublicHoliday.HolidayDefinitions.Base;
using System.Globalization;
using PublicHoliday.Localization;

namespace PublicHoliday
{
    /// <summary>
    /// Holidays in Slovenia
    /// Taken from official government page https://www.gov.si/teme/drzavni-prazniki-in-dela-prosti-dnevi/
    /// </summary>
    public class SloveniaPublicHoliday : PublicHolidayBase
    {

        /// <summary>
        /// Culture whose language this calendar's holiday names are in: Slovenian.
        /// Used by <see cref="Holiday.GetName(CultureInfo)"/> when the requested
        /// culture has no translation.
        /// </summary>
        protected override CultureInfo CountryCulture => _defaultCulture;

        private static readonly CultureInfo _defaultCulture = SafeCulture.Get("sl-SI", "sl");
        #region Individual Holidays

        /// <summary>
        /// Novo leto (1. januar) - New Year's Day
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime NewYearFirst(int year)
        {
            return new DateTime(year, 1, 1);
        }

        /// <summary>
        /// Novo leto (2. januar) - New Year's Day
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime NewYearSecond(int year)
        {
            return new DateTime(year, 1, 2);
        }

        /// <summary>
        /// Prešernov dan - Cultural holiday
        /// </summary>
        public static DateTime PreserenDay(int year)
        {
            return new DateTime(year, 2, 8);
        }

        /// <summary>
        /// Ostermontag - Easter Monday
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
        /// Resistance against the occupation
        /// </summary>
        /// <param name="year">The year.</param>
        public static DateTime ResistanceAgainstOccupation(int year)
        {
            return new DateTime(year, 4, 27);
        }

        /// <summary>
        /// Praznik dela 1.maj - Labour Day 1. may
        /// </summary>
        /// <param name="year">The year.</param>
        public static DateTime LabourDayFirst(int year)
        {
            return new DateTime(year, 5, 1);
        }

        /// <summary>
        /// Praznik dela 2.maj - Labour Day 2. may
        /// </summary>
        /// <param name="year">The year.</param>
        public static DateTime LabourDaySecond(int year)
        {
            return new DateTime(year, 5, 2);
        }

        /// <summary>
        /// Dan državnosti - National day
        /// </summary>
        public static DateTime NationalDay(int year)
        {
            return new DateTime(year, 6, 25);
        }

        /// <summary>
        /// Marijino vnebovzetje - Assumption of Mary
        /// </summary>
        public static DateTime Assumption(int year)
        {
            return new DateTime(year, 8, 15);
        }

        /// <summary>
        /// Dan reformacije - Reformation day
        /// </summary>
        public static DateTime ReformationDay(int year)
        {
            return new DateTime(year, 10, 31);
        }

        /// <summary>
        /// Dan spomina na mrtve (Vsi sveti) - All Saints
        /// </summary>
        public static DateTime AllSaints(int year)
        {
            return new DateTime(year, 11, 1);
        }

        /// <summary>
        /// Božič - Christmas
        /// </summary>
        public static DateTime Christmas(int year)
        {
            return new DateTime(year, 12, 25);
        }

        /// <summary>
        /// Dan samostojnosti in enotnosti - Day of sovereignity and unity
        /// </summary>
        public static DateTime UnityDay(int year)
        {
            return new DateTime(year, 12, 26);
        }

        #endregion Individual Holidays

        /// <summary>
        /// The holiday definitions composing this calendar.
        /// </summary>
        private static readonly HolidayDefinition[] Definitions =
        {
            new Common.NewYear(),
            new Common.DayAfterNewYear(),
            new Local.PreserenDay(),
            new Christian.EasterMonday(),
            new Local.ResistanceDay(),
            new Common.LabourDay(),
            new Common.DayAfterLabourDay { HolidayKey = HolidayKeys.LabourDaySecondSI },
            new Christian.Assumption(),
            new Local.StatehoodDay(),
            new Christian.AllSaints(),
            new Local.UnityDay(),
            new Christian.ReformationDay(),
            new Christian.Christmas(),
        };

        /// <summary>
        /// All public holidays of the year, built from the definitions.
        /// </summary>
        /// <param name="year">The year</param>
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