using System;
using System.Collections.Generic;
using PublicHoliday.HolidayDefinitions.Base;

namespace PublicHoliday.HolidayDefinitions.Christian
{
    /// <summary>
    /// A movable feast computed as a fixed offset from Easter Sunday. Set <see cref="Orthodox"/>
    /// to compute from the Orthodox Easter instead of the western one.
    /// </summary>
    public abstract class EasterRelativeHoliday : HolidayDefinition
    {
        /// <summary>
        /// Creates an Easter-relative holiday definition.
        /// </summary>
        /// <param name="holidayKey">Stable identity / localization key.</param>
        /// <param name="englishName">Default English display name.</param>
        /// <param name="offsetDays">Days after Easter Sunday (negative = before).</param>
        protected EasterRelativeHoliday(string holidayKey, string englishName, int offsetDays)
            : base(holidayKey, englishName)
        {
            OffsetDays = offsetDays;
        }

        /// <summary>
        /// Days after Easter Sunday (negative = before).
        /// </summary>
        public int OffsetDays { get; }

        /// <summary>
        /// Compute from the Orthodox Easter (Greece, Serbia, Montenegro, Romania) instead of the
        /// western (Gregorian) Easter.
        /// </summary>
        public bool Orthodox { get; set; }

        /// <inheritdoc />
        protected override IEnumerable<DateTime> GetDates(int year)
        {
            var easter = Orthodox ? EasterCalculator.GetOrthodoxEaster(year) : EasterCalculator.GetEaster(year);
            yield return easter.AddDays(OffsetDays);
        }
    }

    /// <summary>Easter Sunday itself.</summary>
    public class EasterSunday : EasterRelativeHoliday
    {
        /// <summary>Creates the definition.</summary>
        public EasterSunday() : base(HolidayKeys.Easter, "Easter", 0) { }
    }

    /// <summary>Maundy/Holy Thursday - the Thursday before Easter.</summary>
    public class MaundyThursday : EasterRelativeHoliday
    {
        /// <summary>Creates the definition.</summary>
        public MaundyThursday() : base(HolidayKeys.MaundyThursday, "Maundy Thursday", -3) { }
    }

    /// <summary>Good Friday - the Friday before Easter.</summary>
    public class GoodFriday : EasterRelativeHoliday
    {
        /// <summary>Creates the definition.</summary>
        public GoodFriday() : base(HolidayKeys.GoodFriday, "Good Friday", -2) { }
    }

    /// <summary>Easter Monday - the day after Easter.</summary>
    public class EasterMonday : EasterRelativeHoliday
    {
        /// <summary>Creates the definition.</summary>
        public EasterMonday() : base(HolidayKeys.EasterMonday, "Easter Monday", 1) { }
    }

    /// <summary>Ascension Day - 39 days after Easter (always a Thursday).</summary>
    public class Ascension : EasterRelativeHoliday
    {
        /// <summary>Creates the definition.</summary>
        public Ascension() : base(HolidayKeys.Ascension, "Ascension", 39) { }
    }

    /// <summary>Whit/Pentecost Sunday - 49 days after Easter.</summary>
    public class WhitSunday : EasterRelativeHoliday
    {
        /// <summary>Creates the definition.</summary>
        public WhitSunday() : base(HolidayKeys.WhitSunday, "Whit Sunday", 49) { }
    }

    /// <summary>Whit/Pentecost Monday - 50 days after Easter.</summary>
    public class WhitMonday : EasterRelativeHoliday
    {
        /// <summary>Creates the definition.</summary>
        public WhitMonday() : base(HolidayKeys.PentecostMonday, "Whit Monday", 50) { }
    }

    /// <summary>Corpus Christi - the Thursday after Trinity Sunday (60 days after Easter).</summary>
    public class CorpusChristi : EasterRelativeHoliday
    {
        /// <summary>Creates the definition.</summary>
        public CorpusChristi() : base(HolidayKeys.CorpusChristi, "Corpus Christi", 60) { }
    }

    /// <summary>Clean Monday (Ash Monday, first day of Lent in the Eastern churches) - 48 days before Easter (Greece, Cyprus).</summary>
    public class CleanMonday : EasterRelativeHoliday
    {
        /// <summary>Creates the definition.</summary>
        public CleanMonday() : base(HolidayKeys.CleanMonday, "Clean Monday", -48)
        {
            Orthodox = true;
        }
    }
}
