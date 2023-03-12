using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace PublicHoliday
{
    /// <summary>
    /// Public Holidays in Greece. Based on https://en.wikipedia.org/wiki/Public_holidays_in_Greece
    /// </summary>
    /// <remarks>
    /// NB: Legally every Sunday of the year is a public holiday. This only includes the 6 fixed holidays and 3 non-fixed.
    /// </remarks>
    public class GreecePublicHoliday : PublicHolidayBase
    {
        /// <summary>
        /// Clean Monday (Ash Monday, first day of Lent)
        /// </summary>
        public static DateTime CleanMonday(int year)
        {
            return HolidayCalculator.GetOrthodoxEaster(year).AddDays(-48);
        }

        /// <summary>
        /// Greek Independence Day (also, Annunciation of the Virgin Mary)
        /// </summary>
        public static DateTime IndependenceDay(int year)
        {
            return new DateTime(year, 3, 25);
        }

        /// <summary>
        /// Great Friday
        /// </summary>
        public static DateTime GreatFriday(int year)
        {
            return HolidayCalculator.GetOrthodoxEaster(year).AddDays(-2);
        }

        /// <summary>
        /// Easter Monday
        /// </summary>
        public static DateTime EasterMonday(int year)
        {
            return HolidayCalculator.GetOrthodoxEaster(year).AddDays(1);
        }

        /// <summary>
        /// Whit Monday (Pentecost Monday)
        /// </summary>
        public static DateTime WhitMonday(int year)
        {
            return HolidayCalculator.GetOrthodoxEaster(year).AddDays(50);
        }

        /// <summary>
        /// Public holidays in Greece
        /// </summary>
        public override IList<DateTime> PublicHolidays(int year)
        {
            return PublicHolidayNames(year).Keys.OrderBy(x => x).ToList();
        }

        /// <summary>
        /// Holidays with names (if CurrentCulture is Greek, shown in Greek; otherwise English)
        /// </summary>
        public override IDictionary<DateTime, string> PublicHolidayNames(int year)
        {
            var bHols = new Dictionary<DateTime, string>();
            var isGreek = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName == "el";
            var easter = HolidayCalculator.GetOrthodoxEaster(year);
            bHols.Add(new DateTime(year, 1, 1), isGreek ? "Πρωτοχρονιά" : "New Year's Day");
            bHols.Add(new DateTime(year, 1, 6), isGreek ? "Θεοφάνεια" : "Epiphany");
            bHols.Add(CleanMonday(year), isGreek ? "Καθαρά Δευτέρα" : "Clean Monday");
            bHols.Add(new DateTime(year, 3, 25), isGreek ? "Εικοστή Πέμπτη Μαρτίου" : "Independence Day");
            bHols.Add(GreatFriday(year), isGreek ? "Καθαρά Δευτέρα" : "Great Friday");
            bHols.Add(EasterMonday(year), isGreek ? "Καθαρά Δευτέρα" : "Easter Monday");
            bHols.Add(new DateTime(year, 5, 1), isGreek ? "Εργατική Πρωτομαγιά" : "Labour Day");
            bHols.Add(WhitMonday(year), isGreek ? "Δευτέρα Πεντηκοστής" : "Whit Monday");
            bHols.Add(new DateTime(year, 8, 15), isGreek ? "Κοίμηση της Θεοτόκου" : "Dormition of the Mother of God");
            bHols.Add(new DateTime(year, 10, 28), isGreek ? "Το Όχι" : "Ochi Day");
            bHols.Add(new DateTime(year, 12, 25), isGreek ? "Χριστούγεννα" : "Christmas Day");
            bHols.Add(new DateTime(year, 12, 26), isGreek ? "Σύναξις Υπεραγίας Θεοτόκου Μαρίας" : "Glorifying Mother of God");
            return bHols;
        }

        /// <summary>
        /// Is a specific date a holiday (does not include Sundays)
        /// </summary>
        public override bool IsPublicHoliday(DateTime dt)
        {
            var year = dt.Year;
            var date = dt.Date;
            var day = date.Day;

            switch (dt.Month)
            {
                case 1:
                    if (1 == day) //new year
                        return true;
                    if (6 == day) //epiphany
                        return true;
                    break;

                case 2:
                    if (CleanMonday(year) == date)
                        return true;
                    break;

                case 3:
                case 4:
                    if (CleanMonday(year) == date) //can be in March if easter is late
                        return true;
                    if (IndependenceDay(year) == date)
                        return true;
                    if (GreatFriday(year) == date)
                        return true;
                    if (EasterMonday(year) == date) //can be in May
                        return true;
                    break;

                case 5:
                    if (1 == day) //may day
                        return true;
                    if (GreatFriday(year) == date)
                        return true;
                    if (EasterMonday(year) == date) //can be in May
                        return true;
                    if (WhitMonday(year) == date)
                        return true;
                    break;

                case 6:
                    if (WhitMonday(year) == date)
                        return true;
                    break;

                case 8:
                    if (15 == day) //Dormition
                        return true;
                    break;

                case 10:
                    if (28 == day) //Ochi Day
                        return true;
                    break;

                case 12:
                    if (25 == day) //Christmas
                        return true;
                    if (26 == day) //Glorifying Mother
                        return true;
                    break;
            }

            return false;
        }
    }
}