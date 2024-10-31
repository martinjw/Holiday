using System;
using System.Collections.Generic;

namespace PublicHoliday
{
    /// <summary>
    /// Finds Japan public holidays. Adjusted for weekends.
    /// <description>
    /// Based on https://en.wikipedia.org/wiki/Public_holidays_in_Japan
    /// </description>
    /// </summary>
    public class JapanPublicHoliday : PublicHolidayBase
    {
        #region Individual Holidays

        /// <summary>
        /// Date of New Year bank holiday.
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime NewYear(int year)
        {
            var hol = new DateTime(year, 1, 1);
            hol = FixSunday(hol);
            return hol;
        }

        /// <summary>
        /// Coming of Age Day (成人の日 Seijin no Hi)
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public static DateTime ComingOfAgeDay(int year)
        {
            //second Monday of January
            return HolidayCalculator.FindFirstMonday(new DateTime(year, 1, 1))
                .AddDays(7);
        }

        /// <summary>
        /// Foundation Day (建国記念の日 Kenkoku Kinen no Hi)
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public static DateTime FoundationDay(int year)
        {
            //Feb 11
            return FixSunday(new DateTime(year, 2, 11));
        }

        /// <summary>
        /// Vernal Equinox Day (春分の日 Shunbun no Hi). *March 20 or 21, not fixed*
        /// </summary>
        /// <param name="year">The year.</param>
        public static DateTime VernalEquinoxDay(int year)
        {
            // Calculation algorithm (Japanese): https://ja.wikipedia.org/wiki/春分の日#1900年から2299年までの春分日

            var yearModuloFour = year % 4;

            DateTime vernalEquinoxDay;
            if (year >= 1960 && year <= 1991)
            {
                vernalEquinoxDay = yearModuloFour == 0
                    ? new DateTime(year, 3, 20)
                    : new DateTime(year, 3, 21);
            }
            else if (year >= 1992 && year <= 2023)
            {
                vernalEquinoxDay = yearModuloFour == 0 || yearModuloFour == 1
                    ? new DateTime(year, 3, 20)
                    : new DateTime(year, 3, 21);
            }
            else if (year >= 2024 && year <= 2055)
            {
                vernalEquinoxDay = yearModuloFour == 3
                    ? new DateTime(year, 3, 21)
                    : new DateTime(year, 3, 20);
            }
            else
            {
                // May be not precise
                vernalEquinoxDay = new DateTime(year, 3, 20);
            }

            return FixSunday(vernalEquinoxDay);
        }

        /// <summary>
        /// Shōwa Day (昭和の日 Shōwa no Hi)
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public static DateTime ShowaDay(int year)
        {
            // using the ō character would causes compilation errors on some system
            //29 April
            return FixSunday(new DateTime(year, 4, 29));
        }

        /// <summary>
        /// Constitution Memorial Day (憲法記念日 Kenpō Kinenbi)
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public static DateTime ConstitutionMemorialDay(int year)
        {
            //3 May
            return FixSunday(new DateTime(year, 5, 3));
        }

        /// <summary>
        /// Greenery Day (みどりの日 Midori no Hi)
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public static DateTime GreeneryDay(int year)
        {
            //4 May
            return FixSunday(new DateTime(year, 5, 4));
        }

        /// <summary>
        /// Children's Day (こどもの日 Kodomo no Hi)
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public static DateTime ChildrensDay(int year)
        {
            //5 May
            return FixSunday(new DateTime(year, 5, 5));
        }

        /// <summary>
        /// Marine Day (海の日 Umi no Hi)
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public static DateTime MarineDay(int year)
        {
            //3rd Monday in July
            return HolidayCalculator.FindFirstMonday(new DateTime(year, 7, 1)).AddDays(14);
        }

        /// <summary>
        /// Mountain Day (山の日 Yama no Hi)
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public static DateTime? MountainDay(int year)
        {
            if (year < 2016) return null;
            //11 August, from 2016 onwards
            return FixSunday(new DateTime(year, 8, 11));
        }

        /// <summary>
        /// Respect for the Aged Day (敬老の日 Keirō no Hi)
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public static DateTime RespectForTheAgedDay(int year)
        {
            //Third Monday of September
            return HolidayCalculator.FindFirstMonday(new DateTime(year, 9, 1)).AddDays(14);
        }

        /// <summary>
        /// Autumnal Equinox Day (秋分の日 Shūbun no Hi)
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public static DateTime AutumnalEquinoxDay(int year)
        {
            // Calculation algorithm (Japanese): https://ja.wikipedia.org/wiki/秋分の日#1900年から2299年までの秋分日

            var yearModuloFour = year % 4;

            DateTime autumnalEquinoxDay;
            if (year >= 1980 && year <= 2011)
            {
                autumnalEquinoxDay = new DateTime(year, 9, 23);
            }
            else if (year >= 2012 && year <= 2043)
            {
                autumnalEquinoxDay = yearModuloFour == 0
                    ? new DateTime(year, 9, 22)
                    : new DateTime(year, 9, 23);
            }
            else if (year >= 2044 && year <= 2075)
            {
                autumnalEquinoxDay = yearModuloFour == 0 || yearModuloFour == 1
                    ? new DateTime(year, 9, 22)
                    : new DateTime(year, 9, 23);
            }
            else
            {
                // May be not precise
                autumnalEquinoxDay = new DateTime(year, 9, 23);
            }

            return FixSunday(autumnalEquinoxDay);
        }

        /// <summary>
        /// Health and Sports Day (体育の日 Taiiku no Hi)
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public static DateTime HealthAndSportsDay(int year)
        {
            //Second Monday of October
            return HolidayCalculator.FindFirstMonday(new DateTime(year, 10, 1)).AddDays(7);
        }

        /// <summary>
        /// Culture Day (文化の日 Bunka no Hi)
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public static DateTime CultureDay(int year)
        {
            //November 3
            return FixSunday(new DateTime(year, 11, 3));
        }

        /// <summary>
        /// Labour Thanksgiving Day (勤労感謝の日 Kinrō Kansha no Hi)
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public static DateTime LabourThanksgivingDay(int year)
        {
            //November 23
            return FixSunday(new DateTime(year, 11, 23));
        }

        /// <summary>
        /// The Emperor's Birthday (天皇誕生日 Tennō Tanjōbi)
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public static DateTime EmperorsBirthday(int year)
        {
            if (year >= 2020)
            {
                //23 February Emperor Naruhito 徳仁 2020 – 	 
                return FixSunday(new DateTime(year, 2, 23));
            }
            //23 December Emperor Akihito 明仁 1989–2018
            return FixSunday(new DateTime(year, 12, 23));
        }

        private static DateTime FixSunday(DateTime hol)
        {
            if (hol.DayOfWeek == DayOfWeek.Sunday)
                hol = hol.AddDays(1);
            return hol;
        }

        #endregion Individual Holidays

        /// <summary>
        /// Get a list of dates for all holidays in a year.
        /// </summary>
        /// <param name="year">The year</param>
        /// <returns>List of bank holidays</returns>
        public override IList<DateTime> PublicHolidays(int year)
        {
            return new List<DateTime>(PublicHolidayNames(year).Keys);
        }

        /// <summary>
        /// Get a list of dates for all holidays in a year.
        /// </summary>
        /// <param name="year">The year</param>
        /// <returns>Dictionary of bank holidays</returns>
        public override IDictionary<DateTime, string> PublicHolidayNames(int year)
        {
            var constitutionMemorialDay = ConstitutionMemorialDay(year);
            var greeneryDay = GreeneryDay(year);
            if (greeneryDay == constitutionMemorialDay) greeneryDay = greeneryDay.AddMilliseconds(1);
            var childrensDay = ChildrensDay(year);
            if (greeneryDay == childrensDay) childrensDay = childrensDay.AddMilliseconds(1);

            var hols = new SortedDictionary<DateTime, string>
            {
                { NewYear(year), "New Year" },
                { ComingOfAgeDay(year), "Coming Of Age Day" },
                { FoundationDay(year), "Foundation Day" },
                { VernalEquinoxDay(year), "Vernal Equinox Day" },
                { ShowaDay(year), "Shōwa Day" },
                { constitutionMemorialDay, "Constitution Memorial Day" },
                { greeneryDay, "Greenery Day" },
                { childrensDay, "Children's Day" },
                { MarineDay(year), "Marine Day" },
             };
            if (year >= 2016)
            {
                hols.Add(MountainDay(year).GetValueOrDefault(), "Mountain Day");
            }
            hols.Add(RespectForTheAgedDay(year), "Respect For The Aged Day");
            hols.Add(AutumnalEquinoxDay(year), "Autumnal Equinox Day");
            hols.Add(HealthAndSportsDay(year), "Health And Sports Day");
            hols.Add(CultureDay(year), "Culture Day");
            hols.Add(LabourThanksgivingDay(year), "Labour Thanksgiving Day");
            hols.Add(EmperorsBirthday(year), "Emperor's Birthday");
            return hols;
        }

        /// <summary>
        /// Check if a specific date is a public holiday.
        /// </summary>
        /// <param name="dt">The date you wish to check</param>
        /// <returns>
        /// True if date is a bank holiday (excluding weekends)
        /// </returns>
        public override bool IsPublicHoliday(DateTime dt)
        {
            var year = dt.Year;
            var date = dt.Date;

            switch (dt.Month)
            {
                case 1:
                    if (NewYear(year) == date)
                        return true;
                    if (ComingOfAgeDay(year) == date)
                        return true;
                    break;

                case 2:
                    if (FoundationDay(year) == date)
                        return true;
                    if (year >= 2020 && date == EmperorsBirthday(year))
                        return true;
                    break;

                case 3:
                    if (VernalEquinoxDay(year) == date)
                        return true;
                    break;

                case 4:
                    if (ShowaDay(year) == date)
                        return true;
                    break;

                case 5:
                    if (ConstitutionMemorialDay(year) == date)
                        return true;
                    if (GreeneryDay(year) == date)
                        return true;
                    if (ChildrensDay(year) == date)
                        return true;
                    break;

                case 7:
                    if (MarineDay(year) == date)
                        return true;
                    break;

                case 8:
                    if (MountainDay(year) == date)
                        return true;
                    break;

                case 9:
                    if (RespectForTheAgedDay(year) == date)
                        return true;
                    if (AutumnalEquinoxDay(year) == date)
                        return true;
                    break;

                case 10:
                    if (HealthAndSportsDay(year) == date)
                        return true;
                    break;

                case 11:
                    if (CultureDay(year) == date)
                        return true;
                    if (LabourThanksgivingDay(year) == date)
                        return true;
                    break;

                case 12:
                    if (year < 2020 && EmperorsBirthday(year) == date)
                        return true;
                    break;
            }

            return false;
        }
    }
}