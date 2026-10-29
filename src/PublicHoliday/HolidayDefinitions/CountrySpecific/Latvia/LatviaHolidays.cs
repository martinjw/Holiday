using System;
using System.Collections.Generic;
using PublicHoliday.Dates;
using PublicHoliday.HolidayDefinitions.Base;

namespace PublicHoliday.HolidayDefinitions.CountrySpecific.Latvia
{
    /// <summary>
    /// Latvia's rule for a holiday falling on a weekend: the holiday itself stays on its date
    /// (svētku diena), and the next working day is declared a day off as well (pārceltā brīvdiena,
    /// "transferred day off"). Introduced by the 2007 amendment to the holidays law, and only for
    /// the three holidays the law names - see <see cref="RestorationOfIndependenceDayOff"/>,
    /// <see cref="SongAndDanceFestivalClosingDayOff"/> and <see cref="ProclamationDayOff"/>.
    /// Christmas and New Year are deliberately not shifted.
    /// </summary>
    public abstract class TransferredDayOff : HolidayDefinition
    {
        private readonly HolidayDefinition _holiday;

        /// <summary>Creates the day off that follows <paramref name="holiday"/> when it falls on a weekend.</summary>
        protected TransferredDayOff(string holidayKey, string englishName, HolidayDefinition holiday)
            : base(holidayKey, englishName)
        {
            _holiday = holiday;
        }

        /// <inheritdoc />
        protected override IEnumerable<DateTime> GetDates(int year)
        {
            if (year < 2007) yield break;
            foreach (var holiday in _holiday.Build(year))
            {
                var dayOff = HolidayCalculator.FixWeekend(holiday.HolidayDate);
                if (dayOff != holiday.HolidayDate) yield return dayOff;
            }
        }
    }

    /// <summary>
    /// Restoration of Independence Day - 4 May (1990 declaration). A holiday since the 2002
    /// amendment to the holidays law, in force from 23 April 2002.
    /// </summary>
    public class RestorationOfIndependenceDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public RestorationOfIndependenceDay()
            : base(HolidayKeys.RestorationOfIndependenceDayLV, "Restoration of Independence Day", 5, 4)
        {
            AppliesInYear = Since2002;
        }

        private static bool Since2002(int year)
        {
            return year >= 2002;
        }
    }

    /// <summary>The day off following 4 May when it falls on a weekend.</summary>
    public class RestorationOfIndependenceDayOff : TransferredDayOff
    {
        /// <summary>Creates the definition.</summary>
        public RestorationOfIndependenceDayOff()
            : base(HolidayKeys.RestorationOfIndependenceDayTransferredLV,
                "Restoration of Independence Day (transferred day off)", new RestorationOfIndependenceDay()) { }
    }

    /// <summary>Mother's Day - second Sunday of May.</summary>
    public class MothersDay : NthWeekdayHoliday
    {
        /// <summary>Creates the definition.</summary>
        public MothersDay() : base(HolidayKeys.MothersDayLV, "Mother's Day", 5, DayOfWeek.Sunday, 2) { }
    }

    /// <summary>Midsummer Eve (Līgo Day) - 23 June.</summary>
    public class LigoDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public LigoDay() : base(HolidayKeys.LigoDayLV, "Midsummer Eve", 6, 23) { }
    }

    /// <summary>Midsummer Day (Jāņi) - 24 June.</summary>
    public class MidsummerDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public MidsummerDay() : base(HolidayKeys.MidsummerDayLV, "Midsummer Day", 6, 24) { }
    }

    /// <summary>
    /// Closing day of the Latvian Song and Dance Festival, a holiday since the 2017 amendment.
    /// The festival is held roughly every five years on dates announced per festival, so the
    /// dates are a table rather than a formula; it has always closed on a Sunday, so the
    /// following Monday has always been a transferred day off.
    /// </summary>
    public class SongAndDanceFestivalClosingDay : LookupTableHoliday
    {
        private static readonly IDictionary<int, DateTime> Dates = new Dictionary<int, DateTime>
        {
            { 2018, new DateTime(2018, 7, 8) },
            { 2023, new DateTime(2023, 7, 9) },
        };

        /// <summary>Creates the definition.</summary>
        public SongAndDanceFestivalClosingDay()
            : base(HolidayKeys.SongAndDanceFestivalLV, "Song and Dance Festival Closing Day", Dates) { }
    }

    /// <summary>The day off following the Song and Dance Festival closing day when it falls on a weekend.</summary>
    public class SongAndDanceFestivalClosingDayOff : TransferredDayOff
    {
        /// <summary>Creates the definition.</summary>
        public SongAndDanceFestivalClosingDayOff()
            : base(HolidayKeys.SongAndDanceFestivalTransferredLV,
                "Song and Dance Festival Closing Day (transferred day off)", new SongAndDanceFestivalClosingDay()) { }
    }

    /// <summary>Proclamation Day of the Republic of Latvia - 18 November (1918).</summary>
    public class ProclamationDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public ProclamationDay()
            : base(HolidayKeys.ProclamationDayLV, "Proclamation of the Republic of Latvia", 11, 18) { }
    }

    /// <summary>The day off following 18 November when it falls on a weekend.</summary>
    public class ProclamationDayOff : TransferredDayOff
    {
        /// <summary>Creates the definition.</summary>
        public ProclamationDayOff()
            : base(HolidayKeys.ProclamationDayTransferredLV,
                "Proclamation of the Republic of Latvia (transferred day off)", new ProclamationDay()) { }
    }

    /// <summary>
    /// Second Day of Christmas - 26 December. Latvia numbers its Christmas days rather than
    /// naming the day after St Stephen, so it has its own key.
    /// </summary>
    public class SecondChristmasDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public SecondChristmasDay() : base(HolidayKeys.SecondChristmasDayLV, "Second Day of Christmas", 12, 26) { }
    }

    /// <summary>Pastoral visit of Pope Francis - 24 September 2018, a one-off holiday.</summary>
    public class PopeFrancisVisitDay : OneOffHoliday
    {
        /// <summary>Creates the definition.</summary>
        public PopeFrancisVisitDay()
            : base(HolidayKeys.PopeFrancisVisitLV, "Pastoral Visit of Pope Francis", new DateTime(2018, 9, 24)) { }
    }

    /// <summary>
    /// Day of the bronze medal won by the Latvian ice hockey team at the 2023 World Championship -
    /// 29 May 2023, declared by the Saeima the evening before.
    /// </summary>
    public class BronzeMedalDay : OneOffHoliday
    {
        /// <summary>Creates the definition.</summary>
        public BronzeMedalDay()
            : base(HolidayKeys.BronzeMedalDayLV, "Day of the Bronze Medal Win", new DateTime(2023, 5, 29)) { }
    }
}
