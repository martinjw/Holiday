using System;
using System.Collections.Generic;
using System.Linq;

namespace PublicHoliday
{
    /// <summary>
    /// Public holidays in Finland.
    /// https://en.wikipedia.org/wiki/Public_holidays_in_Finland
    /// https://fi.wikipedia.org/wiki/Pyh%C3%A4p%C3%A4iv%C3%A4
    /// </summary>
    public class FinlandPublicHoliday : PublicHolidayBase
    {
        /// <summary>
        /// Include days that are considered holiday in some labor agreements. Relevant as some businesses
        /// are partly or fully closed and public transport runs on special holiday schedule.
        /// </summary>
        private readonly bool _includeNonOfficialHolidays;

        /// <summary>
        /// Public holidays of Finland
        /// </summary>
        /// <param name="includeNonOfficialHolidays">
        /// Midsummer Eve and Christmas Eve are non-official holidays. They are considered
        /// holiday in some labor agreements</param>
        public FinlandPublicHoliday(bool includeNonOfficialHolidays = false)
        {
            _includeNonOfficialHolidays = includeNonOfficialHolidays;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public override IList<DateTime> PublicHolidays(int year)
        {
            return PublicHolidayNames(year).Keys.OrderBy(x => x).ToList();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public override IDictionary<DateTime, string> PublicHolidayNames(int year)
        {
            var names = new Dictionary<DateTime, string>
            {
                { new DateTime(year, 1, 1), "Uudenvuodenpäivä" },
                { new DateTime(year, 1, 6), "Loppiainen" },
                { new DateTime(year, 5, 1), "Vappu" },
                { new DateTime(year, 12, 6), "Itsenäisyyspäivä" },
                { new DateTime(year, 12, 25), "Joulupäivä" },
                { new DateTime(year, 12, 26), "Tapaninpäivä" },
            };

            // Easter holidays: friday, sunday, monday
            var easter = HolidayCalculator.GetEaster(year);
            names.Add(easter.AddDays(-2), "Pitkäperjantai");
            names.Add(easter, "Pääsiäispäivä");
            names.Add(easter.AddDays(1), "2. pääsiäispäivä");

            // Ascension, 39 days after easter
            names.Add(easter.AddDays(39), "Helatorstai");

            // Pentecost sunday, 49 days after easter
            names.Add(easter.AddDays(49), "Helluntaipäivä");

            // Moveable
            names.Add(GetMidsummer(year), "Juhannuspäivä");
            names.Add(GetAllSaintsDay(year), "Pyhäinpäivä");

            // Non-official
            if (_includeNonOfficialHolidays)
            {
                names.Add(GetMidsummer(year).AddDays(-1), "Juhannusaatto");
                names.Add(new DateTime(year, 12, 24), "Jouluaatto");
            }

            return names;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public override bool IsPublicHoliday(DateTime dt)
        {
            // Normalize
            var date = new DateTime(dt.Year, dt.Month, dt.Day);

            return PublicHolidays(dt.Year).Contains(date);
        }

        /// <summary>
        /// Saturday between 20. and 26. June
        /// </summary>
        private DateTime GetMidsummer(int year)
        {
            var date = new DateTime(year, 6, 20);
            return HolidayCalculator.FindNext(date, DayOfWeek.Saturday);
        }

        /// <summary>
        /// Saturday between 31 October and 6 November
        /// </summary>
        private DateTime GetAllSaintsDay(int year)
        {
            var date = new DateTime(year, 10, 31);
            return HolidayCalculator.FindNext(date, DayOfWeek.Saturday);
        }
    }
}
