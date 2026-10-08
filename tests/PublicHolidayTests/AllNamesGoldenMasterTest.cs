using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicHoliday;

namespace PublicHolidayTests
{
    /// <summary>
    /// Golden master for holiday NAMES across every calendar configuration - each value of each
    /// region/state/canton property, with every option flag on (138 configurations, against the
    /// 62 hand-listed variants in <see cref="GoldenMasterTest"/>).
    /// <para>
    /// It exists because the sampled list is not enough to protect names: when the names moved out
    /// of C# literals into the per-culture resource files, 26 of them were only produced by
    /// configurations the sample never built - Finland's Midsummer Eve sits behind a constructor
    /// flag, Berlin's Women's Day behind a state - and nothing failed. One line per distinct
    /// (configuration, culture, key, name) so a lost or altered name shows up as a diff.
    /// </para>
    /// Same workflow as the other golden master: a missing fixture is generated and reported
    /// Inconclusive; to accept an intentional change, re-record with
    /// <c>PUBLICHOLIDAY_UPDATE_GOLDEN=1 dotnet test</c> and review the git diff.
    /// </summary>
    [TestClass]
    public class AllNamesGoldenMasterTest
    {
        private const int StartYear = 1990;
        private const int EndYear = 2049;

        [TestMethod]
        public void AllNamesGoldenMaster()
        {
            var rows = new SortedSet<string>(StringComparer.Ordinal);

            foreach (var configuration in AllConfigurations())
            {
                var culture = ((PublicHolidayBase)configuration.Value).Culture.Name;

                for (var year = StartYear; year <= EndYear; year++)
                {
                    foreach (var holiday in configuration.Value.PublicHolidaysInformation(year))
                    {
                        if (string.IsNullOrEmpty(holiday.HolidayKey)) continue;

                        rows.Add(string.Join("|", configuration.Key, culture,
                            holiday.HolidayKey, holiday.Name, holiday.EnglishName));
                    }
                }
            }

            var actual = string.Join("\n", rows) + "\n";
            var file = Path.Combine(FixtureDirectory(), "AllNames.txt");

            if (GoldenMasterFixtures.UpdateRequested || !File.Exists(file))
            {
                var what = File.Exists(file) ? "Re-recorded" : "Generated";
                Directory.CreateDirectory(FixtureDirectory());
                File.WriteAllText(file, actual, new UTF8Encoding(false));
                Assert.Inconclusive($"{what} AllNames.txt ({rows.Count} names). Review 'git diff tests/PublicHolidayTests/GoldenMaster/AllNames.txt', then re-run to verify against it.");
            }

            var expected = File.ReadAllText(file).Replace("\r\n", "\n");
            if (string.Equals(expected, actual, StringComparison.Ordinal)) return;

            var expectedLines = expected.Split('\n');
            var actualLines = actual.Split('\n');
            var onlyExpected = expectedLines.Except(actualLines, StringComparer.Ordinal).Take(10).ToList();
            var onlyActual = actualLines.Except(expectedLines, StringComparer.Ordinal).Take(10).ToList();

            Assert.Fail("Holiday names changed.\n  lost:\n    "
                + string.Join("\n    ", onlyExpected) + "\n  new:\n    "
                + string.Join("\n    ", onlyActual));
        }

        /// <summary>
        /// Every calendar in every configuration that changes which holidays it produces.
        /// </summary>
        internal static IEnumerable<KeyValuePair<string, IPublicHolidays>> AllConfigurations()
        {
            var calendars = typeof(IPublicHolidays).Assembly.GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && typeof(IPublicHolidays).IsAssignableFrom(t))
                .OrderBy(t => t.Name, StringComparer.Ordinal);

            foreach (var type in calendars)
            {
                foreach (var factory in Factories(type))
                {
                    var enumProperties = type.GetProperties()
                        .Where(p => p.CanWrite && p.CanRead && p.PropertyType.IsEnum)
                        .ToList();

                    if (enumProperties.Count == 0)
                    {
                        yield return Configure(type.Name, factory);
                        continue;
                    }

                    foreach (var property in enumProperties)
                    {
                        foreach (var value in Enum.GetValues(property.PropertyType))
                        {
                            var configured = Configure(type.Name + "_" + property.Name + "_" + value, factory);
                            property.SetValue(configured.Value, value, null);
                            yield return configured;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// An instance with every settable boolean option on, so option-gated holidays appear.
        /// </summary>
        private static KeyValuePair<string, IPublicHolidays> Configure(string name, Func<IPublicHolidays> factory)
        {
            var instance = factory();
            foreach (var flag in instance.GetType().GetProperties()
                .Where(p => p.CanWrite && p.PropertyType == typeof(bool)))
            {
                flag.SetValue(instance, true, null);
            }
            return new KeyValuePair<string, IPublicHolidays>(name, instance);
        }

        private static IEnumerable<Func<IPublicHolidays>> Factories(Type type)
        {
            //Canada takes its province as a constructor argument rather than a property
            if (type == typeof(CanadaPublicHoliday))
            {
                foreach (var province in new[] { null, "AB", "BC", "MB", "NB", "NL", "NS", "NT",
                    "NU", "ON", "PE", "QC", "SK", "YT" })
                {
                    var captured = province;
                    yield return () => new CanadaPublicHoliday(captured);
                }
                yield break;
            }

            var constructors = type.GetConstructors();

            if (constructors.Any(c => c.GetParameters().Length == 0))
            {
                yield return () => (IPublicHolidays)Activator.CreateInstance(type);
            }

            //the greediest all-bool constructor with every flag on (Denmark, Finland, Switzerland)
            var allBools = constructors
                .Where(c => c.GetParameters().Length > 0
                            && c.GetParameters().All(p => p.ParameterType == typeof(bool)))
                .OrderByDescending(c => c.GetParameters().Length)
                .FirstOrDefault();
            if (allBools != null)
            {
                var count = allBools.GetParameters().Length;
                yield return () =>
                {
                    var args = new object[count];
                    for (var i = 0; i < count; i++) args[i] = true;
                    return (IPublicHolidays)allBools.Invoke(args);
                };
            }
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
                throw new InvalidOperationException("Could not locate repository root above " + AppContext.BaseDirectory);
            }
            return Path.Combine(dir, "tests", "PublicHolidayTests", "GoldenMaster");
        }
    }
}
