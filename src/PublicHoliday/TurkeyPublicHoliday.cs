﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;


namespace PublicHoliday
{
    /// <summary>
    /// Represents holidays in the Turkey
    /// </summary>
    public class TurkeyPublicHoliday : PublicHolidayBase
    {
        private static int GetHijriYear(int year)
        {
            var diff = year - 621;
            var hijriYear = Convert.ToInt32(Math.Round(diff + Decimal.Divide(diff, 33)));
            return hijriYear;
        }

        /// <summary>
        /// New Year's Day - January 1
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime NewYear(int year)
        {
            return new DateTime(year, 1, 1);
        }

        /// <summary>
        /// National Sovereignty and Children's Day - April 23
        /// </summary>
        /// <param name="year"></param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime NationalSovereigntyAndChildrensDay(int year)
        {
            return new DateTime(year, 4, 23);
        }

        /// <summary>
        /// Labour and Solidarity - Day May 1
        /// </summary>
        /// <param name="year"></param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime LabourDay(int year)
        {
            return new DateTime(year, 5, 1);
        }

        /// <summary>
        /// Ramadan Holiday - 1st Day
        /// </summary>
        /// <param name="year"></param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime RamadanFirstDay(int year)
        {
            var hijriCalendar = new UmAlQuraCalendar();
            return hijriCalendar.ToDateTime(GetHijriYear(year), 10, 1, 0, 0, 0, 0);
        }

        /// <summary>
        /// Ramadan Holiday - 2nd Day
        /// </summary>
        /// <param name="year"></param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime RamadanSecondDay(int year)
        {
            var hijriCalendar = new UmAlQuraCalendar();
            return hijriCalendar.ToDateTime(GetHijriYear(year), 10, 2, 0, 0, 0, 0);
        }

        /// <summary>
        ///  Ramadan Holiday - 3rd Day
        /// </summary>
        /// <param name="year"></param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime RamadanThirdDay(int year)
        {
            var hijriCalendar = new UmAlQuraCalendar();
            return hijriCalendar.ToDateTime(GetHijriYear(year), 10, 3, 0, 0, 0, 0);
        }

        /// <summary>
        ///  Youth And Sports Day - May 19
        /// </summary>
        /// <param name="year"></param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime YouthAndSportsDay(int year)
        {
            return new DateTime(year, 5, 19);
        }

        /// <summary>
        ///  Feast of Sacrifice First Day
        /// </summary>
        /// <param name="year"></param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime FeastOfSacrificesFirstDay(int year)
        {
            var hijriCalendar = new UmAlQuraCalendar();
            return hijriCalendar.ToDateTime(GetHijriYear(year), 12, 10, 0, 0, 0, 0);
        }

        /// <summary>
        ///  Feast of Sacrifice Second Day
        /// </summary>
        /// <param name="year"></param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime FeastOfSacrificesSecondDay(int year)
        {
            var hijriCalendar = new UmAlQuraCalendar();
            return hijriCalendar.ToDateTime(GetHijriYear(year), 12, 11, 0, 0, 0, 0);
        }

        /// <summary>
        ///  Feast of Sacrifice Third Day
        /// </summary>
        /// <param name="year"></param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime FeastOfSacrificesThirdDay(int year)
        {
            var hijriCalendar = new UmAlQuraCalendar();
            return hijriCalendar.ToDateTime(GetHijriYear(year), 12, 12, 0, 0, 0, 0);
        }

        /// <summary>
        ///  Feast of Sacrifice Fourth Day
        /// </summary>
        /// <param name="year"></param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime FeastOfSacrificesFourthdDay(int year)
        {
            var hijriCalendar = new UmAlQuraCalendar();
            return hijriCalendar.ToDateTime(GetHijriYear(year), 12, 13, 0, 0, 0, 0);
        }


        /// <summary>
        /// Democracy and National Unity Day - Jul 15
        /// </summary>
        /// <param name="year"></param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime DemocracyAndNationalUnityDay(int year)
        {
            return new DateTime(year, 7, 15);
        }

        /// <summary>
        /// Victory Day - Aug 30
        /// </summary>
        /// <param name="year"></param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime VictoryDay(int year)
        {
            return new DateTime(year, 8, 30);
        }

        /// <summary>
        /// Republic Day - Oct 29
        /// </summary>
        /// <param name="year"></param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime RepublicDay(int year)
        {
            return new DateTime(year, 10, 29);
        }

        /// <summary>
        /// Check if a specific date is a public holiday.
        /// </summary>
        /// <param name="dt">The date you wish to check</param>
        /// <returns>True if date is a public holiday</returns>
        public override bool IsPublicHoliday(DateTime dt)
        {
            return PublicHolidays(dt.Year).Contains(dt);
        }

        /// <summary>
        /// Public holiday names in Turkey.
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public override IDictionary<DateTime, string> PublicHolidayNames(int year)
        {
            var holidayNames = new Dictionary<DateTime, string>
            {
                {NewYear(year), "Yılbaşı Tatili"},
                {NationalSovereigntyAndChildrensDay(year), "Ulusal Egemenlik ve Çocuk Bayramı"},
                {LabourDay(year), "Emek ve Dayanışma Günü"},
                {RamadanFirstDay(year), "Ramazan Bayramı 1. Gün"},
                {RamadanSecondDay(year), "Ramazan Bayramı 2. Gün"},
                {RamadanThirdDay(year), "Ramazan Bayramı 3. Gün"},
                {YouthAndSportsDay(year), "Atatürk’ü Anma, Gençlik ve Spor Bayramı"},
                {FeastOfSacrificesFirstDay(year), "Kurban Bayramı 1. Gün"},
                {FeastOfSacrificesSecondDay(year), "Kurban Bayramı 2. Gün"},
                {FeastOfSacrificesThirdDay(year), "Kurban Bayramı 3. Gün"},
                {FeastOfSacrificesFourthdDay(year), "Kurban Bayramı 4. Gün"},
                {VictoryDay(year), "Zafer Bayramı"},
                {RepublicDay(year), "Cumhuriyet Bayramı"},
            };

            if(year >= 2017)
            {
                holidayNames.Add(DemocracyAndNationalUnityDay(year), "Demokrasi ve Milli Birlik Günü");
            }

            return holidayNames;
        }

        /// <summary>
        /// Get a list of dates for all holidays in a year.
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public override IList<DateTime> PublicHolidays(int year)
            => PublicHolidayNames(year)
                .Select(x => x.Key.Date)
                .OrderBy(x => x)
                .ToList();
    }
}
