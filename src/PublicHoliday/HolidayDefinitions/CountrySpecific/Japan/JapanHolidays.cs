using System;
using System.Collections.Generic;
using PublicHoliday.HolidayDefinitions.Base;

namespace PublicHoliday.HolidayDefinitions.CountrySpecific.Japan
{
    /// <summary>
    /// The Japanese substitute-holiday rule (振替休日 furikae kyūjitsu): a holiday falling on a
    /// Sunday is observed the next Monday.
    /// </summary>
    internal static class JapanWeekendRule
    {
        internal static DateTime SundayToMonday(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Sunday ? date.AddDays(1) : date;
        }
    }

    /// <summary>Coming of Age Day (成人の日 Seijin no Hi) - second Monday of January.</summary>
    public class ComingOfAgeDay : NthWeekdayHoliday
    {
        /// <summary>Creates the definition.</summary>
        public ComingOfAgeDay() : base(HolidayKeys.ComingOfAgeDayJP, "Coming Of Age Day", 1, DayOfWeek.Monday, 2) { }
    }

    /// <summary>Foundation Day (建国記念の日 Kenkoku Kinen no Hi) - 11 February.</summary>
    public class FoundationDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public FoundationDay() : base(HolidayKeys.FoundationDayJP, "Foundation Day", 2, 11)
        {
            ObservedDateRule = JapanWeekendRule.SundayToMonday;
        }
    }

    /// <summary>
    /// Vernal Equinox Day (春分の日 Shunbun no Hi) - 20 or 21 March, from the year-banded
    /// approximation at https://ja.wikipedia.org/wiki/春分の日 (1900-2299).
    /// </summary>
    public class VernalEquinoxDay : HolidayDefinition
    {
        /// <summary>Creates the definition.</summary>
        public VernalEquinoxDay() : base(HolidayKeys.VernalEquinoxDayJP, "Vernal Equinox Day")
        {
            ObservedDateRule = JapanWeekendRule.SundayToMonday;
        }

        /// <inheritdoc />
        protected override IEnumerable<DateTime> GetDates(int year)
        {
            var yearModuloFour = year % 4;
            if (year >= 1960 && year <= 1991)
            {
                yield return yearModuloFour == 0 ? new DateTime(year, 3, 20) : new DateTime(year, 3, 21);
            }
            else if (year >= 1992 && year <= 2023)
            {
                yield return yearModuloFour == 0 || yearModuloFour == 1 ? new DateTime(year, 3, 20) : new DateTime(year, 3, 21);
            }
            else if (year >= 2024 && year <= 2055)
            {
                yield return yearModuloFour == 3 ? new DateTime(year, 3, 21) : new DateTime(year, 3, 20);
            }
            else
            {
                // May be not precise
                yield return new DateTime(year, 3, 20);
            }
        }
    }

    /// <summary>Shōwa Day (昭和の日 Shōwa no Hi) - 29 April, start of Golden Week.</summary>
    public class ShowaDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public ShowaDay() : base(HolidayKeys.ShowaDayJP, "Shōwa Day", 4, 29)
        {
            ObservedDateRule = JapanWeekendRule.SundayToMonday;
        }
    }

    /// <summary>
    /// Constitution Memorial Day (憲法記念日 Kenpō Kinenbi) - 3 May. In Golden Week a Sunday can
    /// push one holiday into the next, so the substitute day cascades past Greenery Day and
    /// Children's Day.
    /// </summary>
    public class ConstitutionMemorialDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public ConstitutionMemorialDay() : base(HolidayKeys.ConstitutionMemorialDayJP, "Constitution Memorial Day", 5, 3)
        {
            ObservedDateRule = Observed;
        }

        internal static DateTime Observed(DateTime date)
        {
            var observed = JapanWeekendRule.SundayToMonday(date);
            if (GreeneryDay.Observed(new DateTime(observed.Year, 5, 4)) == observed)
                observed = observed.AddDays(1);
            if (ChildrensDay.Observed(new DateTime(observed.Year, 5, 5)) == observed)
                observed = observed.AddDays(1);
            return observed;
        }
    }

    /// <summary>Greenery Day (みどりの日 Midori no Hi) - 4 May; its substitute day cascades past Children's Day.</summary>
    public class GreeneryDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public GreeneryDay() : base(HolidayKeys.GreeneryDayJP, "Greenery Day", 5, 4)
        {
            ObservedDateRule = Observed;
        }

        internal static DateTime Observed(DateTime date)
        {
            var observed = JapanWeekendRule.SundayToMonday(date);
            if (ChildrensDay.Observed(new DateTime(observed.Year, 5, 5)) == observed)
                observed = observed.AddDays(1);
            return observed;
        }
    }

    /// <summary>Children's Day (こどもの日 Kodomo no Hi) - 5 May.</summary>
    public class ChildrensDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public ChildrensDay() : base(HolidayKeys.ChildrensDayJP, "Children's Day", 5, 5)
        {
            ObservedDateRule = Observed;
        }

        internal static DateTime Observed(DateTime date)
        {
            return JapanWeekendRule.SundayToMonday(date);
        }
    }

    /// <summary>Marine Day (海の日 Umi no Hi) - third Monday of July.</summary>
    public class MarineDay : NthWeekdayHoliday
    {
        /// <summary>Creates the definition.</summary>
        public MarineDay() : base(HolidayKeys.MarineDayJP, "Marine Day", 7, DayOfWeek.Monday, 3) { }
    }

    /// <summary>Mountain Day (山の日 Yama no Hi) - 11 August, from 2016 onwards.</summary>
    public class MountainDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public MountainDay() : base(HolidayKeys.MountainDayJP, "Mountain Day", 8, 11)
        {
            ObservedDateRule = JapanWeekendRule.SundayToMonday;
            AppliesInYear = Since2016;
        }

        private static bool Since2016(int year)
        {
            return year >= 2016;
        }
    }

    /// <summary>Respect for the Aged Day (敬老の日 Keirō no Hi) - third Monday of September.</summary>
    public class RespectForTheAgedDay : NthWeekdayHoliday
    {
        /// <summary>Creates the definition.</summary>
        public RespectForTheAgedDay() : base(HolidayKeys.RespectForTheAgedDayJP, "Respect For The Aged Day", 9, DayOfWeek.Monday, 3) { }
    }

    /// <summary>
    /// Autumnal Equinox Day (秋分の日 Shūbun no Hi) - 22 or 23 September, from the year-banded
    /// approximation at https://ja.wikipedia.org/wiki/秋分の日 (1900-2299).
    /// </summary>
    public class AutumnalEquinoxDay : HolidayDefinition
    {
        /// <summary>Creates the definition.</summary>
        public AutumnalEquinoxDay() : base(HolidayKeys.AutumnalEquinoxDayJP, "Autumnal Equinox Day")
        {
            ObservedDateRule = JapanWeekendRule.SundayToMonday;
        }

        /// <inheritdoc />
        protected override IEnumerable<DateTime> GetDates(int year)
        {
            var yearModuloFour = year % 4;
            if (year >= 1980 && year <= 2011)
            {
                yield return new DateTime(year, 9, 23);
            }
            else if (year >= 2012 && year <= 2043)
            {
                yield return yearModuloFour == 0 ? new DateTime(year, 9, 22) : new DateTime(year, 9, 23);
            }
            else if (year >= 2044 && year <= 2075)
            {
                yield return yearModuloFour == 0 || yearModuloFour == 1 ? new DateTime(year, 9, 22) : new DateTime(year, 9, 23);
            }
            else
            {
                // May be not precise
                yield return new DateTime(year, 9, 23);
            }
        }
    }

    /// <summary>Health and Sports Day (体育の日 Taiiku no Hi) - second Monday of October.</summary>
    public class HealthAndSportsDay : NthWeekdayHoliday
    {
        /// <summary>Creates the definition.</summary>
        public HealthAndSportsDay() : base(HolidayKeys.HealthAndSportsDayJP, "Health And Sports Day", 10, DayOfWeek.Monday, 2) { }
    }

    /// <summary>Culture Day (文化の日 Bunka no Hi) - 3 November.</summary>
    public class CultureDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public CultureDay() : base(HolidayKeys.CultureDayJP, "Culture Day", 11, 3)
        {
            ObservedDateRule = JapanWeekendRule.SundayToMonday;
        }
    }

    /// <summary>Labour Thanksgiving Day (勤労感謝の日 Kinrō Kansha no Hi) - 23 November.</summary>
    public class LabourThanksgivingDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public LabourThanksgivingDay() : base(HolidayKeys.LabourThanksgivingDayJP, "Labour Thanksgiving Day", 11, 23)
        {
            ObservedDateRule = JapanWeekendRule.SundayToMonday;
        }
    }

    /// <summary>
    /// The Emperor's Birthday (天皇誕生日 Tennō Tanjōbi) - 23 February for Emperor Naruhito from
    /// 2020; 23 December for Emperor Akihito before that.
    /// </summary>
    public class EmperorsBirthday : HolidayDefinition
    {
        /// <summary>Creates the definition.</summary>
        public EmperorsBirthday() : base(HolidayKeys.EmperorsBirthdayJP, "Emperor's Birthday")
        {
            ObservedDateRule = JapanWeekendRule.SundayToMonday;
        }

        /// <inheritdoc />
        protected override IEnumerable<DateTime> GetDates(int year)
        {
            yield return year >= 2020 ? new DateTime(year, 2, 23) : new DateTime(year, 12, 23);
        }
    }
}
