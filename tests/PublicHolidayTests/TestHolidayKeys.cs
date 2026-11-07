using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicHoliday;

namespace PublicHolidayTests
{
    /// <summary>
    /// Locks <see cref="HolidayKeys"/> to reality: every key any calendar configuration actually
    /// produces (1990-2049) has a constant, and every constant is produced - so the class can
    /// neither fall behind a new holiday nor accumulate dead keys. Also verifies each constant's
    /// field name equals its value, since consumers see the name and the resources match the value.
    /// </summary>
    [TestClass]
    public class TestHolidayKeys
    {
        private const int StartYear = 1990;
        private const int EndYear = 2049;

        /// <summary>
        /// Keys that are real but cannot appear in 1990-2049 output: historical year-bands and a
        /// shared default that every current user overrides. Each entry needs a reason.
        /// </summary>
        private static readonly string[] KeysOutsideSnapshotRange =
        {
            HolidayKeys.DominionDay,         // Quebec, name of Canada Day until 1981
            HolidayKeys.NationalizationDayCS,// Czechoslovakia, 1952-1974
            HolidayKeys.SaintPeterAndPaul,   // Czechoslovakia, until 1951
            HolidayKeys.DayAfterLabourDay,   // shared default key; SI/ME/RS each override with their own
        };

        [TestMethod]
        public void EveryConstantNameEqualsItsValue()
        {
            foreach (var field in Constants())
            {
                Assert.AreEqual(field.Name, (string)field.GetRawConstantValue(),
                    $"HolidayKeys.{field.Name} must equal its own name");
            }
        }

        [TestMethod]
        public void ConstantsMatchTheKeysCalendarsProduce()
        {
            var constants = new HashSet<string>(Constants().Select(f => (string)f.GetRawConstantValue()), StringComparer.Ordinal);

            var produced = new HashSet<string>(StringComparer.Ordinal);
            foreach (var configuration in AllNamesGoldenMasterTest.AllConfigurations())
            {
                for (var year = StartYear; year <= EndYear; year++)
                {
                    foreach (var holiday in configuration.Value.PublicHolidaysInformation(year))
                    {
                        produced.Add(holiday.HolidayKey);
                    }
                }
            }

            var missingConstants = produced.Except(constants).OrderBy(k => k, StringComparer.Ordinal).ToList();
            Assert.AreEqual(0, missingConstants.Count,
                "Keys produced by a calendar but missing from HolidayKeys - add the constant(s): "
                + string.Join(", ", missingConstants));

            var deadConstants = constants.Except(produced)
                .Except(KeysOutsideSnapshotRange)
                .OrderBy(k => k, StringComparer.Ordinal).ToList();
            Assert.AreEqual(0, deadConstants.Count,
                "HolidayKeys constants no calendar produces in " + StartYear + "-" + EndYear
                + " - remove them or explain them in KeysOutsideSnapshotRange: "
                + string.Join(", ", deadConstants));
        }

        private static IEnumerable<FieldInfo> Constants()
        {
            var fields = typeof(HolidayKeys)
                .GetFields(BindingFlags.Public | BindingFlags.Static)
                .Where(f => f.IsLiteral && f.FieldType == typeof(string))
                .ToList();
            Assert.IsTrue(fields.Count > 200, "HolidayKeys reflection found suspiciously few constants");
            return fields;
        }
    }
}
