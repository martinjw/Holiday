using PublicHoliday;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PublicHolidayTests.HelperTest
{
    class PublicHolidayHelperTest : PublicHolidayBase
    {

        public IDictionary<DateTime, string> Holidays { get; set; } = new Dictionary<DateTime, string>();

        public override bool IsPublicHoliday(DateTime dt)
        {
            return Holidays.ContainsKey(dt);
        }

        protected override IList<Holiday> PublicHolidaysComplete(int year)
        {
            return PublicHolidayNames(year)
                .Select(pair => new Holiday(pair.Key, pair.Key, string.Join(", ", pair.Value), null))
                .ToList();
        }

        public override IDictionary<DateTime, string[]> PublicHolidayNames(int year)
        {
            return Holidays
                .Where(holiday => holiday.Key.Year == year)
                .ToDictionary(holiday => holiday.Key, holiday => new[] { holiday.Value });
        }

        public override IList<DateTime> PublicHolidays(int year)
        {
            return PublicHolidayNames(year).Keys.ToList();
        }
    }
}
