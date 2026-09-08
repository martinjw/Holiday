# Contributing: adding countries and holidays

Since version 4.0 the library is built from three layers, and almost every contribution is a
change to exactly one of them:

1. **`HolidayDefinitions/`** — *what* a holiday is: one named class per holiday that knows how
   to compute its date(s) for any year. Shared holidays live in `Christian/`, `Common/` and
   `Islamic/`; holidays unique to one country live in
   `CountrySpecific/<Country>/<Country>Holidays.cs`. The abstract building blocks
   (`HolidayDefinition` and the date-computation shapes) are in `HolidayDefinitions/Base/`.
2. **`PublicHolidayCalendars/`** — *which* holidays a country observes: a calendar is little
   more than a list of definition instances, each customized with that country's deviations
   (year gates, weekend rules, regions).
3. **`Localization/Names/<culture>.resx`** — *what it is called*: one resource file per culture,
   keyed by holiday. No display names live in the calendars.

Everything else (`PublicHolidays`, `PublicHolidayNames`, `PublicHolidaysInformation`,
`IsPublicHoliday`, working-day and business-day math, per-year caching, localization) is derived
by the base class from one method: `PublicHolidaysComplete(int year)`.

In 3.x each country re-implemented its holidays inline — its own date math, its own weekend
handling, its own same-day-collision workarounds, and often a second hand-maintained copy of the
holiday list inside `IsPublicHoliday`. Adding a holiday observed by three countries meant
writing it three times, and the copies drifted apart. In 4.0 you declare a holiday once and
attach it per country with one line.

- [Walkthrough A: adding a new country](#walkthrough-a-adding-a-new-country)
- [Walkthrough B: adding a holiday shared by several countries](#walkthrough-b-adding-a-holiday-shared-by-several-countries)
- [Verifying your change](#verifying-your-change)

---

## Walkthrough A: adding a new country

Suppose we add **Iceland**. Five steps.

### 1. Country-unique holidays get named classes

Anything Iceland observes that no other supported country does goes in a new file
`src/PublicHoliday/HolidayDefinitions/CountrySpecific/Iceland/IcelandHolidays.cs` — one class
per holiday, subclassing the shape from `HolidayDefinitions/Base/` that matches how the date is
computed (this is what Estonia's file looks like today, abbreviated):

```C#
using System;
using PublicHoliday.HolidayDefinitions.Base;

namespace PublicHoliday.HolidayDefinitions.CountrySpecific.Iceland
{
    /// <summary>Icelandic National Day - 17 June.</summary>
    public class IcelandicNationalDay : FixedDateHoliday
    {
        public IcelandicNationalDay() : base(HolidayKeys.IcelandicNationalDayIS, "Icelandic National Day", 6, 17) { }
    }

    /// <summary>Commerce Day - first Monday of August.</summary>
    public class CommerceDay : NthWeekdayHoliday
    {
        public CommerceDay() : base(HolidayKeys.CommerceDayIS, "Commerce Day", 8, DayOfWeek.Monday, 1) { }
    }
}
```

Available shapes: `FixedDateHoliday` (month/day), `NthWeekdayHoliday` (3rd Monday of…),
`WeekdayOnOrAfterHoliday` / `WeekdayOnOrBeforeHoliday`, `NearestWeekdayHoliday`,
`LookupTableHoliday` (officially announced per year, like NZ Matariki), `OneOffHoliday`
(happened exactly once), `Christian/EasterRelativeHoliday` (offset from Easter, western or
Orthodox), `Islamic/IslamicHolidayDefinition` (Hijri calendar, multi-day). Only subclass
`HolidayDefinition` directly when the date math fits none of these.

Three naming rules:

- **The first constructor argument is the `HolidayKey`** — the holiday's stable identity.
  Country-unique holidays get an ISO-suffixed key (`IcelandicNationalDayIS`) so they can never
  collide with a shared key. A key with no resource row falls back to the English name, so a
  holiday works before anyone translates it.
- **Every key is a constant on `HolidayKeys`** (`src/PublicHoliday/HolidayKeys.cs`, field name
  == value, regions mirroring the HolidayDefinitions folders, alphabetical inside a region) —
  add yours there first and reference it, never a string literal. `TestHolidayKeys` fails with the exact missing name if you forget.
- **Don't create a class for a holiday that already exists.** Christmas, Easter Monday, Labour
  Day, New Year etc. are already in `Christian/` and `Common/` — you attach those in the
  calendar (next step), never re-declare them.

### 2. The calendar: a list of definitions

`src/PublicHoliday/PublicHolidayCalendars/IcelandPublicHoliday.cs`. The whole class is a
`Definitions` array and the one required override:

```C#
using System.Collections.Generic;
using System.Globalization;
using PublicHoliday.HolidayDefinitions.Base;
using PublicHoliday.HolidayDefinitions.Christian;
using PublicHoliday.HolidayDefinitions.Common;
using PublicHoliday.Localization;
using Local = PublicHoliday.HolidayDefinitions.CountrySpecific.Iceland;

namespace PublicHoliday
{
    /// <summary>Public holidays in Iceland.</summary>
    public class IcelandPublicHoliday : PublicHolidayBase
    {
        /// <summary>
        /// Culture whose language this calendar's holiday names are in: Icelandic.
        /// </summary>
        protected override CultureInfo CountryCulture => _countryCulture;

        private static readonly CultureInfo _countryCulture = SafeCulture.Get("is-IS", "is");

        private static readonly HolidayDefinition[] Definitions =
        {
            new NewYear(),
            new MaundyThursday(),
            new GoodFriday(),
            new EasterSunday(),
            new EasterMonday(),
            new LabourDay(),
            new Ascension(),
            new WhitMonday(),
            new Local.IcelandicNationalDay(),
            new Local.CommerceDay(),
            new Christmas(),
            new SaintStephensDay(),
        };

        /// <summary>All Icelandic public holidays for the year.</summary>
        protected override IList<Holiday> PublicHolidaysComplete(int year)
        {
            var list = new List<Holiday>();
            foreach (var definition in Definitions)
            {
                list.AddRange(definition.Build(year));
            }
            return list;
        }
    }
}
```

That's a complete, working calendar — `IsPublicHoliday`, `NextWorkingDay`, `BusinessDaysAdd`,
`PublicHolidayNames`, caching and same-day collision handling all come from the base class — but so
far it answers in English. Note there is not a single display name in it: the definitions carry the
dates and an `EnglishName`, and the Icelandic wording goes in a resource file.

### 3. The names: one resource file for the country's language

Add `src/PublicHoliday/Localization/Names/is.resx`, with one row per holiday named after its
`HolidayKey`. Existing files are the template — copy the four `resheader` elements from any
of them:

```xml
<data name="NewYear" xml:space="preserve"><value>Nýársdagur</value></data>
<data name="MaundyThursday" xml:space="preserve"><value>Skírdagur</value></data>
<data name="GoodFriday" xml:space="preserve"><value>Föstudagurinn langi</value></data>
<data name="IcelandicNationalDayIS" xml:space="preserve"><value>Þjóðhátíðardagurinn</value></data>
<data name="CommerceDayIS" xml:space="preserve"><value>Frídagur verslunarmanna</value></data>
<!-- ... -->
```

The csproj picks the file up by wildcard, so there is nothing to register. Three rules:

- **Use the plain language file unless the language spans several supported countries.**
  `Names/is.resx` is right for Iceland: Icelandic is spoken in one supported country, and a lookup
  tries the culture then its parents, so the calendar's `is-IS` reaches `is` — as would `is-Latn-IS`
  or anything else Icelandic. Add `Names/xx-YY.resx` only when two supported countries share a
  language and word something differently: that is why `de` has `de-AT` (`Neujahr`) alongside the
  general `de` (`Neujahrstag`), and why `en`, `es`, `fr`, `nl`, `pt` and `sr` have region files.
  A region file answers one culture; a language file answers all of them.
- **Use `SafeCulture.Get(specific, neutralLanguage)`** for `CountryCulture`, never
  `new CultureInfo(...)`: the field is static, so a culture name the platform does not know (older
  target frameworks, Mono, minimal Linux images) would throw out of the type initializer and break
  the whole calendar rather than one name lookup.
- **A key with no row falls back to `EnglishName`**, so a partial file is valid — the calendar
  still works, it just answers in English for the rows you have not written yet.

Because the calendar reuses the shared `Christian`/`Common` classes, other languages come for free:
a French caller gets "Lundi de Pâques" from an Icelandic calendar with no extra work, because
`Names/fr.resx` already has that key.

A holiday lasting several numbered days is still **one row**: put a `{0}` where the day belongs and
it is filled in, so `EidAlFitr = "Ramazan Bayramı {0}. Gün"` covers all three days of the feast.
(The definition supplies the number by overriding `DayNumberFor`; `IslamicHolidayDefinition`
already does.)

`LocalName` on a definition overrides everything, but almost nothing needs it — one calendar does,
`EcbTargetClosingDay`, whose wording disagrees with the `en-US` it shares with the USA calendars.
A plain country name is a row.

**Exceptions and deviations** are per-instance properties on the definitions, not code:

```C#
// only exists since a given year (name the gate, don't inline a lambda):
new ChristmasEve { AppliesInYear = From1980 },
...
private static bool From1980(int year) { return year >= 1980; }

// shifts off a weekend (rules from HolidayCalculator, or your own Func<DateTime, DateTime>):
new NewYear { ObservedDateRule = HolidayCalculator.FixWeekend },

// limited to some regions:
new Local.SomeRegionalDay { Regions = new[] { "Nordurland" } },
```

If a country's definition list depends on configuration (a `State`/`Region`/`Canton` property or
constructor flags), replace the static array with a per-instance `GetDefinitions()` iterator
(see `UKBankHoliday` or `GermanPublicHoliday`) — and every mutable property's setter **must**
call `ClearHolidayCache()`. Genuine one-off days (royal weddings, mourning days) are
`OneOffHoliday` subclasses in the country file, not ad-hoc list additions.

### 4. Wire it up

- `PublicHolidayFactory`: add `case "IS": return new IcelandPublicHoliday();`
- `PublicHolidayCountryCode`: add the `Is` enum member.
- `tests/PublicHolidayTests/TestAllPublicHolidays.cs`: add the calendar to `AllCalendars()`
  **and** the "IS" row to the factory-test dictionary.
- `README.md`: add the country to the list.
- A `tests/PublicHolidayTests/TestIcelandPublicHoliday.cs` with named assertions for a handful
  of externally verified dates (movable feasts, year gates, weekend shifts — the interesting
  ones, not every fixed date).

Nothing to register for the resource file — the csproj includes `Localization\Names\*.resx` by
wildcard.

### 5. Golden master

Run the test suite once. Two fixtures are generated and both report Inconclusive:

- `GoldenMaster/IcelandPublicHoliday.txt` — every holiday for 1990–2049 from `GoldenMasterTest`,
  which sees the calendar through `AllCalendars()`.
- `GoldenMaster/AllNames.txt` — the names fixture, which discovers your calendar by reflection and
  exercises **every** configuration of it (each value of each region property, every option flag
  on), so a name that only appears behind a flag is covered too.

**Review both against official sources** — they are the contract every future refactor is verified
against. Run again: green. If the calendar has region or option variants worth pinning in the date
fixture as well, add them to the variants list in `GoldenMasterTest.cs`.

---

## Walkthrough B: adding a holiday shared by several countries

The rule: **a holiday observed by two or more countries is declared once, in a shared class.**
`Christian/` for feasts, `Common/` for secular days. This is not hypothetical — here is exactly
how Victory in Europe Day is done today, shared by France, the Czech Republic and Slovakia.

One class, in `HolidayDefinitions/Common/CommonHolidays.cs`:

```C#
/// <summary>Victory in Europe Day - 8 May.</summary>
public class VictoryInEuropeDay : FixedDateHoliday
{
    public VictoryInEuropeDay() : base("VictoryInEuropeDay", "Victory in Europe Day", 5, 8) { }
}
```

One line in each country's `Definitions`, carrying only that country's legal history — no names:

```C#
// FrancePublicHoliday
yield return new Common.VictoryInEuropeDay();

// CzechRepublicPublicHoliday
new Common.VictoryInEuropeDay { AppliesInYear = Since1992 },

// SlovakiaPublicHoliday
new Common.VictoryInEuropeDay { AppliesInYear = VictoryOverFascismYears },
```

And one row per language, all keyed `VictoryInEuropeDay` — each country's own wording in its own
file, and the generic translations that serve everyone else:

| File | Row | Serves |
|---|---|---|
| `Names/fr-FR.resx` | `Fête de la Victoire` | what France calls it |
| `Names/cs-CZ.resx` | `Den osvobození` | what the Czech Republic calls it |
| `Names/sk-SK.resx` | `Deň víťazstva nad fašizmom` | what Slovakia calls it |
| `Names/de.resx` | `Tag des Sieges` | any of them, asked in German |
| `Names/it.resx` | `Festa della Vittoria` | any of them, asked in Italian |

The date math exists once. The weekend rule, year gates and wording vary per country without
touching the class, and `GetName("de")` answers for all three from the single German row. When a
fourth country adopts the holiday, that is one line plus one row.

For comparison, the 3.x way: each of the three calendars contained its own
`new DateTime(year, 5, 8)` construction inside its own list-building method, with its own name
string, and France additionally kept a private static helper for it — three implementations to
keep in sync, and no way to ask for the name in another language.

**Region file or language file?** French is the case that needs both, because France, Belgium and
Quebec all speak it and word things differently. `Names/fr.resx` is French for everybody — it is
what a French-speaking reader of the Czech calendar gets, and what `fr-GF` or any other French
variant falls back to. `Names/fr-FR.resx`, `fr-BE` and `fr-CA` hold only what those countries say
differently. For a language spoken by one supported country there is nothing to distinguish, so it
gets a language file and no region file.

**Promoting an existing holiday**: if you're adding a country and discover its "unique" holiday
already exists as a class in another country's `CountrySpecific/` file, move that class to
`Common/` (or `Christian/`), keep its `HolidayKey` unchanged, and repoint the original
country at the shared class. Countries that existed before the promotion must produce
byte-identical golden-master output afterwards.

**One trap — a shared key shares its wording in every language.** So if a country observes a
shared holiday under a genuinely different name, do not reuse the key: either group the countries
that agree under a key of their own, or give the odd one out a country-suffixed key. 26 December
is the worked example — the UK, Australia, Canada and New Zealand all call it Boxing Day and share
a `BoxingDay` key, South Africa calls it the Day of Goodwill and uses `DayOfGoodwillZA`, and
`SaintStephensDay` is left to the countries that really do observe St Stephen's Day. While they
all shared `SaintStephensDay`, three calendars answered `GetName("en")` with "St Stephen's Day"
for a holiday whose English name is Boxing Day.

---

## Verifying your change

```
dotnet build src/PublicHoliday/PublicHoliday.csproj -c Debug    # must be 0 warnings, all 6 TFMs
dotnet test PublicHoliday.sln -c Debug
```

Note the library multi-targets down to .NET Framework 3.5 (`LangVersion` 7.3) — see the
building notes in `README.md`, and keep new `src/` code free of modern-C#-only syntax. The
resource files are deliberately embedded verbatim rather than compiled (`Type="Non-Resx"` in the
csproj): compiling `.resx` for the net35 target needs `ResGen.exe`, which the .NET Core build of
MSBuild cannot run, so `dotnet build` would fail outright. Don't "fix" that item.

For a behavior-preserving change (refactor, promotion of a shared class), the golden-master
fixtures must be **byte-identical**. For an intentional behavior change, re-record them and let
git show you what moved:

```
PUBLICHOLIDAY_UPDATE_GOLDEN=1 dotnet test        # rewrites the fixtures, reports Inconclusive
git diff tests/PublicHolidayTests/GoldenMaster   # every changed line must be explainable
dotnet test                                      # green against the new fixtures
```

`git checkout` the fixtures if the diff is not what you meant. Every changed line must be
explainable by your change, and a change to one country may only move that country's fixture —
anything else that moves is collateral damage from a shared definition, so investigate it before
committing. Never re-record to make a red test green without reading the diff, and never edit a
fixture by hand. Remember there are two kinds: the dates fixture per calendar, and `AllNames.txt`
for names across every configuration.
