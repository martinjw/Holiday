using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicHoliday;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace PublicHolidayTests
{
    /// <summary>
    /// Golden-master snapshot of every calendar's <c>PublicHolidaysInformation</c> output for
    /// 1990-2049, including regional/option variants. It catches collateral damage: the holiday
    /// definitions are shared, so one edit to <c>Christian.Christmas</c> or
    /// <c>HolidayCalculator.FixWeekend</c> can move thirty calendars, and the fixture that changed
    /// says which. It is not the specification - a country's own rules belong in its
    /// <c>TestXxxPublicHoliday</c> tests, with the date and its source named.
    ///
    /// A missing fixture is generated and reported Inconclusive. To accept an intentional change,
    /// re-record with <c>PUBLICHOLIDAY_UPDATE_GOLDEN=1 dotnet test</c> and review
    /// <c>git diff tests/PublicHolidayTests/GoldenMaster</c>. Never edit a fixture by hand.
    /// </summary>
    [TestClass]
    public class GoldenMasterTest
    {
        private const int StartYear = 1990;
        private const int EndYear = 2049;

        internal static Dictionary<string, IPublicHolidays> Variants()
        {
            var variants = new Dictionary<string, IPublicHolidays>();

            // Default calendar per country code (skip "PO" - alias of "PL")
            foreach (var code in new[]
            {
                "AU", "AT", "BE", "BR", "CA", "CZ", "DK", "NL", "EE", "FI", "FR", "DE", "GR",
                "HR", "HU", "IE", "IT", "JP", "KZ", "LT", "LV", "LU", "ME", "MX", "NZ", "NO", "PL",
                "PT", "RO", "RS", "SK", "SI", "ZA", "ES", "SE", "CH", "TR", "GB", "US",
            })
            {
                var calendar = PublicHolidayFactory.GetPublicHolidayForCountry(code);
                variants.Add(calendar.GetType().Name, calendar);
            }

            // Special (non-country) calendars
            variants.Add(nameof(CanadaQuebecGovClosingDay), new CanadaQuebecGovClosingDay());
            variants.Add(nameof(EcbTargetClosingDay), new EcbTargetClosingDay());
            variants.Add(nameof(USAFederalReserveHoliday), new USAFederalReserveHoliday());
            variants.Add(nameof(USANewYorkStockExchangeHoliday), new USANewYorkStockExchangeHoliday());

            // Regional / option variants
            variants.Add("UKBankHoliday_Wales", new UKBankHoliday { UkCountry = UKBankHoliday.UkCountries.Wales });
            variants.Add("UKBankHoliday_Scotland", new UKBankHoliday { UkCountry = UKBankHoliday.UkCountries.Scotland });
            variants.Add("UKBankHoliday_NorthernIreland", new UKBankHoliday { UkCountry = UKBankHoliday.UkCountries.NorthernIreland });
            variants.Add("GermanPublicHoliday_BY", new GermanPublicHoliday { State = GermanPublicHoliday.States.BY });
            variants.Add("GermanPublicHoliday_SN", new GermanPublicHoliday { State = GermanPublicHoliday.States.SN });
            variants.Add("SwitzerlandPublicHoliday_ZH", new SwitzerlandPublicHoliday { Canton = SwitzerlandPublicHoliday.Cantons.ZH });
            variants.Add("SwitzerlandPublicHoliday_GE", new SwitzerlandPublicHoliday { Canton = SwitzerlandPublicHoliday.Cantons.GE });
            variants.Add("SwitzerlandPublicHoliday_Flags", new SwitzerlandPublicHoliday(hasSecondJanuary: true, hasLaborDay: true, hasCorpusChristi: true));
            variants.Add("AustraliaPublicHoliday_NSW", new AustraliaPublicHoliday { State = AustraliaPublicHoliday.States.NSW });
            variants.Add("AustraliaPublicHoliday_NSW_Bank", new AustraliaPublicHoliday { State = AustraliaPublicHoliday.States.NSW, IncludeNSWBankHoliday = true });
            variants.Add("AustraliaPublicHoliday_VIC", new AustraliaPublicHoliday { State = AustraliaPublicHoliday.States.VIC });
            variants.Add("AustraliaPublicHoliday_WA", new AustraliaPublicHoliday { State = AustraliaPublicHoliday.States.WA });
            variants.Add("NewZealandPublicHoliday_AUCKLAND", new NewZealandPublicHoliday { ProvincialDistrict = NewZealandPublicHoliday.ProvincialDistricts.AUCKLAND });
            variants.Add("CanadaPublicHoliday_QC", new CanadaPublicHoliday("QC"));
            variants.Add("FrancePublicHoliday_Martinique", new FrancePublicHoliday { Region = FrancePublicHoliday.Regions.Martinique });
            variants.Add("FrancePublicHoliday_AlsaceMoselle", new FrancePublicHoliday { Region = FrancePublicHoliday.Regions.AlsaceMoselle });
            variants.Add("PortugalPublicHoliday_Madeira", new PortugalPublicHoliday { Region = PortugalPublicHoliday.Regions.Madeira });
            variants.Add("PortugalPublicHoliday_Acores", new PortugalPublicHoliday { Region = PortugalPublicHoliday.Regions.Acores });
            variants.Add("DenmarkPublicHoliday_AllOptions", new DenmarkPublicHoliday(true, true, includeDayAfterAscension: true, includeChristmasEve: true, includeNewYearsEve: true));
            variants.Add("DutchPublicHoliday_EasterSunday", new DutchPublicHoliday { IncludeEasterSunday = true });

            return variants;
        }

        [TestMethod]
        public void GoldenMaster()
        {
            var dir = FixtureDirectory();
            Directory.CreateDirectory(dir);
            var generated = new List<string>();
            var failures = new List<string>();

            foreach (var variant in Variants())
            {
                var actual = Render(variant.Value);
                var file = Path.Combine(dir, variant.Key + ".txt");
                if (GoldenMasterFixtures.UpdateRequested || !File.Exists(file))
                {
                    File.WriteAllText(file, actual, new UTF8Encoding(false));
                    generated.Add(variant.Key);
                    continue;
                }
                var expected = File.ReadAllText(file).Replace("\r\n", "\n");
                if (!string.Equals(expected, actual, StringComparison.Ordinal))
                {
                    failures.Add(variant.Key + ": " + FirstDifference(expected, actual));
                }
            }

            if (failures.Count > 0)
            {
                Assert.Fail($"Golden master mismatch in {failures.Count} calendar(s):\n" + string.Join("\n", failures));
            }
            if (generated.Count > 0)
            {
                var what = GoldenMasterFixtures.UpdateRequested ? "Re-recorded" : "Generated";
                Assert.Inconclusive($"{what} {generated.Count} fixture file(s) ({string.Join(", ", generated.Take(5))}...). Review 'git diff tests/PublicHolidayTests/GoldenMaster', then re-run to verify against them.");
            }
        }

        private static string Render(IPublicHolidays calendar)
        {
            var sb = new StringBuilder();
            for (int year = StartYear; year <= EndYear; year++)
            {
                var lines = calendar.PublicHolidaysInformation(year)
                    .Select(h => string.Join("|",
                        h.HolidayDate.ToString("yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture),
                        h.ObservedDate.ToString("yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture),
                        h.EnglishName,
                        h.Name,
                        h.HolidayKey,
                        h.IsPublic,
                        h.Regions == null ? "" : string.Join(",", h.Regions)))
                    .OrderBy(l => l, StringComparer.Ordinal);
                foreach (var line in lines)
                {
                    sb.Append(year).Append('|').Append(line).Append('\n');
                }
            }
            return sb.ToString();
        }

        private static string FirstDifference(string expected, string actual)
        {
            var expectedLines = expected.Split('\n');
            var actualLines = actual.Split('\n');
            int max = Math.Max(expectedLines.Length, actualLines.Length);
            for (int i = 0; i < max; i++)
            {
                var e = i < expectedLines.Length ? expectedLines[i] : "<missing>";
                var a = i < actualLines.Length ? actualLines[i] : "<missing>";
                if (!string.Equals(e, a, StringComparison.Ordinal))
                {
                    return $"first diff at line {i + 1}:\n  expected: {e}\n  actual:   {a}";
                }
            }
            return "lengths differ but no differing line found";
        }

        private static string FixtureDirectory()
        {
            var dir = AppContext.BaseDirectory;
            while (dir != null && !File.Exists(Path.Combine(dir, "PublicHoliday.sln")))
            {
                dir = Path.GetDirectoryName(dir);
            }
            if (dir == null)
            {
                throw new InvalidOperationException("Could not locate repository root (PublicHoliday.sln) above " + AppContext.BaseDirectory);
            }
            return Path.Combine(dir, "tests", "PublicHolidayTests", "GoldenMaster");
        }
    }
}
