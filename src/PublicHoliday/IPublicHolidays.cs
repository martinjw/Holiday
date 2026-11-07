using System;
using System.Collections.Generic;
using System.Globalization;

namespace PublicHoliday
{
    /// <summary>
    /// A country's public holidays, and the working-day arithmetic that follows from them. Get one from
    /// <see cref="PublicHolidayFactory"/> or by constructing a calendar directly.
    /// </summary>
    public interface IPublicHolidays
    {
        /// <summary>
        /// The language holiday names come back in - the culture of <see cref="Holiday.Name"/>. Defaults to
        /// the country's own language; set it to read a multilingual country in one of its others, or to
        /// follow a user's locale. See <see cref="CalendarExtensions.WithCulture{T}(T, CultureInfo)"/>.
        /// </summary>
        CultureInfo Culture { get; set; }

        /// <summary>
        /// The dates of the year's public holidays, ascending. A day with two holidays on it appears once,
        /// and holidays observed in only part of the country are excluded - use
        /// <see cref="PublicHolidaysInformation"/> for those.
        /// </summary>
        /// <param name="year">The year.</param>
        IList<DateTime> PublicHolidays(int year);

        /// <summary>
        /// Every holiday of the year in full: its actual and observed date, its names, and which regions it
        /// applies to. Unlike <see cref="PublicHolidays"/> this includes region-only holidays (with
        /// <see cref="Holiday.IsPublic"/> false) and keeps two holidays that share a day distinct.
        /// </summary>
        /// <param name="year">The year.</param>
        IList<Holiday> PublicHolidaysInformation(int year);

        /// <summary>
        /// The year's holiday names, keyed by the date they are observed on, in this calendar's
        /// <see cref="Culture"/>. Two holidays on the same day are two entries in that day's array, which is
        /// otherwise of length one.
        /// </summary>
        /// <param name="year">The year.</param>
        IDictionary<DateTime, string[]> PublicHolidayNames(int year);

        /// <summary>
        /// As <see cref="PublicHolidayNames(int)"/>, in the language you name. A holiday with no translation
        /// for that culture falls back to this calendar's own language, then to English, so a name is never
        /// empty.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="culture">The language to answer in, e.g. new CultureInfo("fr-BE"); null for this
        /// calendar's own <see cref="Culture"/>.</param>
        IDictionary<DateTime, string[]> PublicHolidayNames(int year, CultureInfo culture);

        /// <summary>
        /// The first working day on or after <paramref name="dt"/> - so a date that is already a working day
        /// is returned unchanged. A working day is Monday to Friday and not a public holiday.
        /// </summary>
        /// <param name="dt">The date to start from.</param>
        DateTime NextWorkingDay(DateTime dt);

        /// <summary>
        /// The first working day strictly after <paramref name="dt"/>, even when that date is itself a
        /// working day.
        /// </summary>
        /// <param name="dt">The date to start from.</param>
        DateTime NextWorkingDayNotSameDay(DateTime dt);

        /// <summary>
        /// The working day <paramref name="openDayAdd"/> working days on or after <paramref name="dt"/>.
        /// Zero returns the first working day on or after the date.
        /// </summary>
        /// <param name="dt">The date to start from.</param>
        /// <param name="openDayAdd">How many working days to move forward.</param>
        DateTime NextWorkingDay(DateTime dt, int openDayAdd);

        /// <summary>
        /// As <see cref="NextWorkingDay(DateTime, int)"/>, but never returns <paramref name="dt"/> itself.
        /// </summary>
        /// <param name="dt">The date to start from.</param>
        /// <param name="openDayAdd">How many working days to move forward.</param>
        DateTime NextWorkingDayNotSameDay(DateTime dt, int openDayAdd);

        /// <summary>
        /// The last working day on or before <paramref name="dt"/> - so a date that is already a working day
        /// is returned unchanged.
        /// </summary>
        /// <param name="dt">The date to start from.</param>
        DateTime PreviousWorkingDay(DateTime dt);

        /// <summary>
        /// The last working day strictly before <paramref name="dt"/>, even when that date is itself a
        /// working day.
        /// </summary>
        /// <param name="dt">The date to start from.</param>
        DateTime PreviousWorkingDayNotSameDay(DateTime dt);

        /// <summary>
        /// The working day <paramref name="openDaySubstract"/> working days on or before
        /// <paramref name="dt"/>.
        /// </summary>
        /// <param name="dt">The date to start from.</param>
        /// <param name="openDaySubstract">How many working days to move back.</param>
        DateTime PreviousWorkingDay(DateTime dt, int openDaySubstract);

        /// <summary>
        /// As <see cref="PreviousWorkingDay(DateTime, int)"/>, but never returns <paramref name="dt"/>
        /// itself.
        /// </summary>
        /// <param name="dt">The date to start from.</param>
        /// <param name="openDaySubstract">How many working days to move back.</param>
        DateTime PreviousWorkingDayNotSameDay(DateTime dt, int openDaySubstract);

        /// <summary>
        /// The holidays observed between two dates, inclusive, spanning as many years as the range covers.
        /// Includes region-only holidays, as <see cref="PublicHolidaysInformation"/> does.
        /// </summary>
        /// <param name="startDate">First date of the range.</param>
        /// <param name="endDate">Last date of the range.</param>
        IList<Holiday> GetHolidaysInDateRange(DateTime startDate, DateTime endDate);

        /// <summary>
        /// Whether this date is a public holiday. Weekends are not holidays in themselves - use
        /// <see cref="IsWorkingDay(DateTime)"/> for "is anyone at work".
        /// </summary>
        /// <param name="dt">The date to check.</param>
        bool IsPublicHoliday(DateTime dt);

        /// <summary>
        /// Whether today is a working day: Monday to Friday and not a public holiday.
        /// </summary>
        bool IsWorkingDay();

        /// <summary>
        /// Whether this date is a working day: Monday to Friday and not a public holiday.
        /// </summary>
        /// <param name="dt">The date to check.</param>
        bool IsWorkingDay(DateTime dt);

        /// <summary>
        /// The date <paramref name="businessDays"/> business days after <paramref name="dt"/> - a delivery
        /// date or an SLA deadline. Counting starts the day after: adding 1 gives the next working day.
        /// </summary>
        /// <param name="dt">The date to count from, exclusive.</param>
        /// <param name="businessDays">How many business days to add.</param>
        DateTime BusinessDaysAdd(DateTime dt, int businessDays);

        /// <summary>
        /// How many business days fall between two dates, counting both ends. Zero when
        /// <paramref name="end"/> is before <paramref name="start"/>.
        /// </summary>
        /// <param name="start">First date of the range.</param>
        /// <param name="end">Last date of the range.</param>
        int BusinessDaysBetween(DateTime start, DateTime end);
    }
}
