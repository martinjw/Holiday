using System;

namespace PublicHolidayTests
{
    /// <summary>
    /// Shared by the two golden-master tests: whether this run should rewrite the fixture files
    /// instead of comparing against them.
    /// </summary>
    internal static class GoldenMasterFixtures
    {
        private const string UpdateVariable = "PUBLICHOLIDAY_UPDATE_GOLDEN";

        /// <summary>
        /// True when the run was asked to re-record the fixtures:
        /// <c>PUBLICHOLIDAY_UPDATE_GOLDEN=1 dotnet test</c>. Review the result with
        /// <c>git diff tests/PublicHolidayTests/GoldenMaster</c>; git holds the previous version,
        /// so <c>git checkout</c> undoes it.
        /// </summary>
        public static bool UpdateRequested
        {
            get
            {
                var value = Environment.GetEnvironmentVariable(UpdateVariable);
                return value == "1" || string.Equals(value, "true", StringComparison.OrdinalIgnoreCase);
            }
        }
    }
}
