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

        public override IDictionary<DateTime, string> PublicHolidayNames(int year)
        {
            var result =
            from Holiday in Holidays
            where Holiday.Key.Year == year
            select Holiday;

            return new Dictionary<DateTime, string>(result);
        }

        public override IList<DateTime> PublicHolidays(int year)
        {
            return PublicHolidayNames(year).Keys.ToList();
        }
    }
}
