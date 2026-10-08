# Upgrading to PublicHoliday 4.0

Version 4.0.0 is a major architecture overhaul. The everyday API (`PublicHolidays`,
`IsPublicHoliday`, `NextWorkingDay`, `BusinessDaysAdd`, the per-country static methods) is
unchanged, but there are a handful of breaking changes you may need to act on, and a lot of
internal restructuring that makes the calculated results more correct and every calendar
localizable.

- [Breaking changes](#breaking-changes)
- [Changes and improvements](#changes-and-improvements)
- [Bug fixes](#bug-fixes)
- [For contributors: the new architecture](#for-contributors-the-new-architecture)

---

## Breaking changes

### 1. `PublicHolidayNames` returns `IDictionary<DateTime, string[]>`

Previously the value was a single `string` per date. When two holidays fell on the same day,
calendars either merged the names into one string ("Christi Himmelfahrt, Tag der Arbeit"),
silently dropped one of the holidays, or worked around the collision with a hidden
one-second offset on the dictionary key. Now each date maps to an array with one entry per
holiday — almost always of length 1.

```C#
// Whit Monday and Constitution Day both fall on Monday 5 June 2017
var date = new DateTime(2017, 6, 5);

// 3.x
IDictionary<DateTime, string> names = new DenmarkPublicHoliday().PublicHolidayNames(2017);
string name = names[date];                     // "Anden pinsedag, Grundlovsdag"

// 4.0
IDictionary<DateTime, string[]> names = new DenmarkPublicHoliday().PublicHolidayNames(2017);
string[] dayNames = names[date];               // ["Anden pinsedag", "Grundlovsdag"]
string joined = string.Join(", ", dayNames);   // the old merged string, if you want it
```

The keys are unchanged (the observed date at midnight — the sub-second offset hack is gone),
and the dictionary is sorted by date for every calendar. If you need the full detail per
holiday (actual vs observed date, English and local name, localization id, regions), use
`PublicHolidaysInformation(year)`, which returns one `Holiday` object per holiday.

### 2. `PublicHolidaysInformation` reports the *actual* holiday date separately from the observed date

For calendars with weekend rules (UK, USA, Canada, South Africa, New Zealand, …), 3.x baked the
weekend shift into both `Holiday.HolidayDate` and `Holiday.ObservedDate`. In 4.0
`HolidayDate` is the real calendar date of the holiday and `ObservedDate` carries the shift:

```C#
// Christmas 2021 (25 December is a Saturday)
var christmas = new UKBankHoliday().PublicHolidaysInformation(2021)
    .First(h => h.EnglishName == "Christmas");
// 3.x: HolidayDate = 2021-12-27, ObservedDate = 2021-12-27
// 4.0: HolidayDate = 2021-12-25, ObservedDate = 2021-12-27
```

`PublicHolidays`, `PublicHolidayNames`, `IsPublicHoliday` and the implicit
`Holiday` → `DateTime` cast all still use the **observed** date, so date lookups behave as
before.

### 3. Removed `[Obsolete]` members

| Removed | Use instead |
|---|---|
| `IPublicHolidays.UseCachingHolidays` | Nothing — results are always cached per instance/year now. Calendars with a region/state property invalidate the cache automatically when you change it. |
| `BelgiumPublicHoliday.PublicHolidayNamesFrench(year)` | `PublicHolidayNames(year, new CultureInfo("fr-BE"))` |
| `CanadaQuebecGovClosingDay.PublicHolidayNamesCulture(year, culture)` | `PublicHolidayNames(year, culture)` |
| `CanadaQuebecGovClosingDay.PublicHolidaysInformationWithNames(year)` | `PublicHolidaysInformation(year)` + `Holiday.GetName(culture)` |

### 4. Greece: Greek names no longer depend on the ambient UI culture

3.x returned Greek names from `PublicHolidayNames` only when the *current UI culture* happened
to be Greek — a hidden global dependency — and two of them were wrong: Great Friday and Easter
Monday were both labelled "Καθαρά Δευτέρα", i.e. Clean Monday. In 4.0 Greece works like every
other calendar: it declares Greek as its language and answers in Greek regardless of thread state,
and any caller can ask for a different one.

```C#
var greece = new GreecePublicHoliday();
greece.PublicHolidayNames(2026);                        // Greek, whatever the UI culture is

var goodFriday = greece.PublicHolidaysInformation(2026)
    .First(h => h.HolidayKey == HolidayKeys.GoodFriday);
goodFriday.Name;                                        // "Μεγάλη Παρασκευή" (3.x: Clean Monday)
goodFriday.EnglishName;                                 // "Great Friday"
goodFriday.GetName(new CultureInfo("en"));              // "Great Friday"
```

The same applies to `CanadaQuebecGovClosingDay`, which now names its holidays in French
(`Jour de l'An`, `Vendredi Saint`) rather than English.

### 5. `PublicHolidaysComplete` is `protected abstract`

If you subclassed `PublicHolidayBase` to build your own calendar, you now implement exactly two
members: `PublicHolidaysComplete(int year)` (every holiday of the year as `Holiday` objects)
and `IsPublicHoliday(DateTime)` (usually just `return IsPublicHolidayFromComplete(dt);`).
Overriding `PublicHolidays`/`PublicHolidayNames` directly is no longer the intended extension
point — the base class derives all of those from `PublicHolidaysComplete`. See
[the contributors section](#for-contributors-the-new-architecture) for the easiest way to
compose a calendar from the built-in holiday definitions.

### 6. The name members changed shape

| Change | What to do |
|---|---|
| `IHoliday.IdTextLocalization` → `IHoliday.HolidayKey` | Rename. The value is unchanged — the holiday's stable id, which also names its translation row. Every key is now a constant on the new `HolidayKeys` class, so `h.HolidayKey == HolidayKeys.Christmas` replaces the magic string (the `Holiday` constructor parameter is renamed too, which matters only to named-argument callers). |
| `HolidayDefinition.LocalizationKey` → `HolidayKey`, `LocalizationKeyFor` → `HolidayKeyFor` | Rename, for the same concept under the same name on the authoring side. |
| `IHoliday.GetName()` (no arguments) **removed** | Use `EnglishName`. It returned the English name — the opposite of `Name`, and identical to `EnglishName`. |
| `IHoliday.Name` **added** | Nothing, unless you implement `IHoliday` yourself. Interface-typed callers can now get the local-language name, which was previously only on the concrete `Holiday`. |
| `IPublicHolidays.Culture` **added** | Nothing, unless you implement `IPublicHolidays` yourself — then add the property. Calendars derived from `PublicHolidayBase` inherit it. |
| `Holiday.DefaultCulture` → `Holiday.Culture` | Rename. (`DefaultCulture` only ever existed in 4.0 previews, never in 3.x.) |
| `PublicHolidayBase.DefaultCulture` → `Culture`, and it is no longer `virtual` | If you overrode it to declare your calendar's language, override `protected virtual CountryCulture` instead: that is the country's own language, while `Culture` carries the caller's choice on top of it. |

```C#
IHoliday holiday = calendar.PublicHolidaysInformation(2026).First();
holiday.Name;                              // "Kerstmis" - new on the interface
holiday.EnglishName;                       // "Christmas" - was GetName()
holiday.GetName(new CultureInfo("fr-BE")); // "Noël"
```

### 7. Holiday names moved into per-culture resource files

`Localization/LocalizationString.xml` is gone, along with `LocalizedProviderString`,
`ResourceProviderXDocument` and the `ILocalizedProvider`/`IResourceProvider` interfaces (all were
internal). Names now live in one `.resx` per culture, embedded in the assembly — still a single
DLL with no data files and no satellite assemblies. Dates and `Holiday.Name` are unchanged; two
outputs move:

- **`GetName(new CultureInfo("en"))` returns the holiday's own `EnglishName`.** Previously an
  `<en>` row in the XML overrode it, which is how Australian, Canadian and New Zealand Boxing Day
  came to answer "St Stephen's Day" (next section). Where the two differed the definition's name
  now wins: Switzerland's Christmas answers "Christmas Day", Canada's Thanksgiving
  "Thanksgiving Day".
- **Geneva's fast day is `EnglishName = "Geneva Fast"`**, not the malformed "Geneva PrayDay".

### 8. Boxing Day is no longer St Stephen's Day (localization ids changed)

Australia, Canada and New Zealand shared the `SaintStephensDay` localization id for 26 December,
so `GetName(new CultureInfo("en"))` returned "St Stephen's Day" for a holiday whose English name
is Boxing Day; South Africa got the same for its Day of Goodwill, and its 1 May Workers' Day
answered "Labour Day". Those holidays now carry their own ids, so `Holiday.HolidayKey`
changed for them — the only breaking part if you switch on that value:

| Calendar | Holiday | 3.x / early 4.0 id | 4.0 id |
|---|---|---|---|
| UK | Boxing Day | `BoxingDayUK` | `BoxingDay` |
| Australia, Canada, New Zealand | Boxing Day | `SaintStephensDay` | `BoxingDay` |
| South Africa | Day of Goodwill | `SaintStephensDay` | `DayOfGoodwillZA` |
| South Africa | Workers' Day | `LabourDay` | `WorkersDayZA` |

Dates, `EnglishName`, `Name` and every other output are unchanged; `SaintStephensDay` still
belongs to the calendars that really do observe St Stephen's Day (Ireland, Italy, Germany,
Austria, …).

---

## Changes and improvements

### Every holiday is a reusable definition class

The core of the rework: the *definition* of a holiday (what it is, when it falls, how it shifts
off a weekend, which years it existed) now lives once, in a named class under the public
`PublicHoliday.HolidayDefinitions` namespace, instead of being re-declared inline by every
country that observes it:

```
HolidayDefinitions/
    Christian/        EasterSunday, GoodFriday, EasterMonday, Ascension, WhitMonday,
                      CorpusChristi, CleanMonday, Christmas, Epiphany, Assumption, AllSaints, ...
    Common/           NewYear, LabourDay, WomensDay, Armistice, VictoryInEuropeDay, ...
    Islamic/          EidAlFitr, EidAlAdha (UmAlQura-based, multi-day, year-straddle safe)
    CountrySpecific/  one file per country with its unique holidays as named classes
                      (Czechoslovakia/ holds the historical holidays shared by CZ and SK)
```

A calendar composes its year from a list of these, customizing per instance:

```C#
// how SouthAfricaPublicHoliday attaches the standard New Year with its own weekend rule:
new NewYear { LocalName = "New Year", ObservedDateRule = HolidayCalculator.FixWeekendSundayAfter }

// how CzechRepublicPublicHoliday gates Good Friday to the years it legally existed:
new GoodFriday { LocalName = "Velký Pátek", AppliesInYear = GoodFridayYears } // 1947-1951, 2016-
```

For consumers this means consistency: all ~40 calendars now flow through the same engine, so
same-day collisions, weekend observance, region filtering and localization behave identically
everywhere.

### Localization works for every calendar

`Holiday.GetName(CultureInfo)` (and `PublicHolidayNames(year, culture)`) resolves names for
every country through shared localization keys, and never returns an empty string — it falls
back from the requested culture to the calendar's own language and then English. Greek (`el`)
was added as a language. Because countries share keys for shared holidays (Christmas, Easter
Monday, Labour Day, …), adding one translation row covers every country that observes the
holiday.

### A calendar can be read in another of its languages

Every calendar has a settable `Culture` — the language it answers in — plus a `WithCulture`
helper that keeps the calendar's type, so it combines with a region and with the factory:

```C#
new BelgiumPublicHoliday().WithCulture("fr-BE")
    .PublicHolidaysInformation(2026).Last().Name;                 // "Noël"

new CanadaPublicHoliday("QC").WithCulture("fr-CA");               // province + language
var swiss = new SwitzerlandPublicHoliday { Culture = new CultureInfo("fr-CH") };

// or drive both country and language from the user, naming no country in code
var user = CultureInfo.CurrentUICulture;
var calendar = PublicHolidayFactory
    .GetPublicHolidayForCountry(new RegionInfo(user.Name).TwoLetterISORegionName)
    .WithCulture(user);
```

Note that setting `Culture` *replaces* the calendar's language, so a holiday with no translation
in it falls back to `EnglishName` — whereas `GetName(culture)` on an untouched calendar falls back
to the country's own language. The README has the details.

### Supplying your own translations

The library does not ship every language. Register an `IHolidayNameProvider` (or the ready-made
`ResourceManagerNameProvider` over your own `.resx`) and it is asked before the library's own
names, so you can add a language or override one that ships. See "Supplying your own translations"
in the README for a worked example.

### Every calendar declares its own language

New in 4.0: every calendar declares the language its own holiday names are in — `de-DE`, `et-EE`,
`sr-Cyrl-RS`, `nl-BE` for Belgium as the largest of its three official languages — as
`protected virtual CountryCulture`, surfaced as the settable `Culture` on `IPublicHolidays`. It is
also the fallback when `GetName(culture)` is asked for a culture with no translation, which now
answers in the country's language rather than English:

```C#
var holiday = new GreecePublicHoliday().PublicHolidaysInformation(2026).First();
holiday.GetName(new CultureInfo("es"));   // "Πρωτοχρονιά" (no Spanish translation exists)
                                          // 3.x: "New Year's Day"
```

`Holiday.Name` and `PublicHolidayNames(year)` are unaffected — they still return the calendar's
own name, then English. Only `GetName(culture)` / `PublicHolidayNames(year, culture)` for an
untranslated culture changes, and only for calendars whose language has a resource file.

### Montenegro is now reachable through the factory

`MontenegroPublicHoliday` existed but was missing from `PublicHolidayFactory` and
`PublicHolidayCountryCode`. Added as `"ME"` / `PublicHolidayCountryCode.Me`.

### Region/state property changes invalidate the cache

Changing `State`, `Province`, `Canton`, `UkCountry`, `Region` or an option flag after a first
call now correctly clears the per-instance year cache, so you no longer get stale results from
a reused calendar instance.

### Same-day holidays are never dropped or disguised

Two holidays observed on the same date are now two distinct `Holiday` entries in
`PublicHolidaysInformation`, two names in the `PublicHolidayNames` array for that day, and one
date in `PublicHolidays`. The previous implementations variously dropped one of them, merged
the names, or offset a dictionary key by one second.

---

## Bug fixes

All of these are visible output changes, caught and verified against a golden-master snapshot
of every calendar for 1990–2049:

- **Serbia**: Orthodox Easter holidays were missing entirely in years where they collide with
  Labour Day (e.g. Easter Monday on 1/2 May).
- **Norway / Finland**: Ascension Day disappeared when it fell on Constitution Day / 1 May
  (e.g. Finland 2008).
- **Italy**: Liberation Day (25 April) was silently dropped when it falls in the Easter days
  (2011, 2038).
- **Greece**: the Greek names of Great Friday and Easter Monday were both "Καθαρά Δευτέρα"
  (Clean Monday); now "Μεγάλη Παρασκευή" and "Δευτέρα του Πάσχα".
- **UK**: `IsBankHoliday` was a hand-maintained duplicate of the holiday list and missed
  St Andrew's Day when its observed date falls in December (30 November on a Saturday is
  observed Monday 2 December). It now derives from the same holiday list as everything else.
- **France**: regional variants (e.g. Martinique) threw a duplicate-key exception from
  `PublicHolidayNames` in years where a movable feast lands on a regional holiday (Ascension on
  Slavery Abolition Day 2031, Whit Monday on Abolition Day in Guyane 2019).
- **Switzerland**: `PublicHolidayNames` could throw when Ascension falls on 1 May in a canton
  that observes Labour Day; `HasPentecostMonday` didn't invalidate the cache.
- **Portugal**: the First Octave regional holiday ignored its "since 2002" rule in some views.

---

## For contributors: the new architecture

The library now has three layers (namespaces follow folders):

1. **`HolidayDefinitions/`** — *what* a holiday is. One class per holiday, subclassing one of
   the abstract shapes in `HolidayDefinitions/Base/` (`FixedDateHoliday`, `NthWeekdayHoliday`,
   `OneOffHoliday`, …), a calendar-system base (`Christian/EasterRelativeHoliday`,
   `Islamic/IslamicHolidayDefinition`) or `HolidayDefinition` directly when the
   date math is bespoke. Settable per-instance properties (`LocalName`, `ObservedDateRule`,
   `AppliesInYear`, `Regions`) let a country deviate without a new class.
2. **`PublicHolidayCalendars/`** — *which* holidays a country observes. A calendar is a list of
   definition instances plus its local names and year gates:

   ```C#
   // from CzechRepublicPublicHoliday
   private static readonly HolidayDefinition[] Definitions =
   {
       new Common.NewYear { LocalName = "Nový Rok", AppliesInYear = Until2000 },
       new Christian.GoodFriday { LocalName = "Velký Pátek", AppliesInYear = GoodFridayYears },
       // ...
   };

   protected override IList<Holiday> PublicHolidaysComplete(int year)
   {
       var list = new List<Holiday>();
       foreach (var definition in Definitions) list.AddRange(definition.Build(year));
       return list;
   }
   ```

3. **The base class** derives everything else (`PublicHolidays`, `PublicHolidayNames`,
   `PublicHolidaysInformation`, working-day and business-day math) from
   `PublicHolidaysComplete`, memoized per year.

Support code was untangled along the way: `HolidayCalculator` now contains only generic date
math (weekend-shift rules and day-of-week finders), Easter algorithms moved to
`HolidayDefinitions/Christian/EasterCalculator`, and the working/business-day engines moved to
`WorkingDayCalculator`. See `CONTRIBUTING.md` for a walkthrough of the architecture, including
the golden-master test workflow used to keep behavior locked during changes.
