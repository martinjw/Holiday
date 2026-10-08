Public Holidays
===============

Nuget: Install-Package PublicHoliday [![Nuget](https://img.shields.io/nuget/v/PublicHoliday.svg) ](https://www.nuget.org/packages/PublicHoliday/)

Orders and deliveries, data transfers, and other processes can often only be made on business working days. They cannot be made on national public holidays. Public holidays in many countries can be calculated algorithmically. 

> **Upgrading from 3.x?** Version 4.0 is a major release with a few breaking changes (`PublicHolidayNames` returns `string[]` per date, holiday names moved into per-culture resource files, `IHoliday.GetName()` removed, obsolete members removed). See [UPGRADING-4.0.md](UPGRADING-4.0.md).
>
> **Want to add a country or holiday?** Since 4.0 that is mostly declarative — see [CONTRIBUTING.md](CONTRIBUTING.md) for two worked examples.

```C#
//get a list of all holidays for 2017
IList<DateTime> result = new USAPublicHoliday().PublicHolidays(2017);

//get the next working day
DateTime dayAfterColumbus = new USAPublicHoliday().NextWorkingDay(new DateTime(2006, 10, 8)); //returns 10 October 2006

//2nd January 2006 is a Monday. But because 1st January was a Sunday, the bank holiday is the next Monday
bool isHoliday = new UKBankHoliday().IsBankHoliday(new DateTime(2006, 1, 2)); //returns true

//what's the next working day after Sunday 24th December 2006?
DateTime nextWorkingDay = new UKBankHoliday().NextWorkingDay(new DateTime(2006, 12, 24)); //returns 27 December 2006
```

The library contains adjustments for one-off holidays.

```C#
//Next working day after royal wedding - next working day is Tuesday 3rd May (Monday 2nd is MayDay)
DateTime nextWorkingDayAfterRoyalWedding = new UKBankHoliday().NextWorkingDay(new DateTime(2011, 4, 29));
```

There are libraries for:
- Europe
  - Austria : AustriaPublicHoliday
  - Belgium : BelgiumPublicHoliday
  - Croatia : CroatiaPublicHoliday
  - Czech Republic : CzechRepublicPublicHoliday
  - ECB : EcbTargetClosingDay (European Central Bank SEPA Target Closing days - no exchange rates and no SEPA transactions)
  - Denmark : DenmarkPublicHoliday
  - Estonia : EstoniaPublicHoliday
  - Finland: FinlandPublicHoliday
  - France : FrancePublicHoliday
  - Germany : GermanPublicHoliday (set State property for regional holidays)
  - Greece : GreecePublicHoliday
  - Hungary: HungaryPublicHoliday
  - Ireland : IrelandPublicHoliday
  - Italy : ItalyPublicHoliday
  - Latvia : LatviaPublicHoliday
  - Lithuania : LithuaniaPublicHoliday
  - Luxembourg : LuxembourgPublicHoliday
  - Montenegro : MontenegroPublicHoliday
  - Netherlands : DutchPublicHoliday
  - Norway : NorwayPublicHoliday
  - Poland : PolandPublicHoliday
  - Portugal : PortugalPublicHoliday (set Region property for Madeira/Açores regional holidays)
  - Romania : RomanianPublicHoliday
  - Serbia : SerbianPublicHoliday
  - Slovakia : SlovakiaPublicHoliday
  - Spain : SpainPublicHoliday
  - Slovenia : SloveniaPublicHoliday
  - Sweden : SwedenPublicHoliday
  - Switzerland: SwitzerlandPublicHoliday
  - UK : UKBankHoliday (set UkCountry property for Scotland/Northern Ireland variations)
- E. Europe/Asia
  - Kazakhstan : KazakhstanPublicHoliday
  - Turkey : TurkeyPublicHoliday
- N America
  - Canada : CanadaPublicHoliday (set Province in constructor for regional holidays)
  - Canada : CanadaQuebecGovClosingDay (Government province of Quebec closing day)
  - Mexico : MexicoPublicHoliday
  - USA : USAPublicHoliday
  - USA : USAFederalReserveHoliday
  - USA : USANewYorkStockExchangeHoliday
- S America
  - Brazil : BrazilPublicHoliday
- Oceania
  - Australia : AustraliaPublicHoliday (set State property for regional holidays, see note below)
  - New Zealand : NewZealandPublicHoliday
- Asia
  - Japan : JapanPublicHoliday
- Africa
  - South Africa : SouthAfricaPublicHoliday

All use the common interface IPublicHolidays containing:
- IsPublicHoliday(DateTime) (UK: also IsBankHoliday(DateTime))
- IsWorkingDay(DateTime) (i.e. not public holiday, Saturday or Sunday)
- NextWorkingDay(DateTime)
- NextWorkingDay(DateTime, int)
- NextWorkingDayNotSameDay(DateTime)
- NextWorkingDayNotSameDay(DateTime, int)
- PreviousWorkingDay(DateTime)
- PreviousWorkingDay(DateTime, int)
- PreviousWorkingDayNotSameDay(DateTime)
- PreviousWorkingDayNotSameDay(DateTime, int)
- PublicHolidays(int year)
- PublicHolidaysInformation(int year)
- PublicHolidayNames(int year) (returns `IDictionary<DateTime, string[]>` — one name per holiday on a day, usually one)
- PublicHolidayNames(int year, CultureInfo culture)
- GetHolidaysInDateRange(DateTime, DateTime)
- BusinessDaysAdd(DateTime, int)
  - if you have an <abbr title="servive level agreement">SLA</abbr>/turn-around time of 3 business days, calendar.BusinessDaysAdd(dt, 3) will give you the end-date 3 business days (Mon-Fri excluding public holidays)
- BusinessDaysBetween(DateTime, DateTime) (number of Mon-Fri working days)
- Culture (the language holiday names come back in — see [Localized holiday names](#localized-holiday-names))

There are also static methods for all statutory holidays.

### Finding a specific holiday

Every holiday carries a stable identifier, `Holiday.HolidayKey` — the same for every year,
language and country that observes it. The `HolidayKeys` class holds one constant per holiday,
so a specific holiday is found without magic strings or knowing its date:

```C#
var calendar = PublicHolidayFactory.GetPublicHolidayForCountry("BE");
var christmas = calendar.PublicHolidaysInformation(2026)
    .Single(h => h.HolidayKey == HolidayKeys.Christmas);
```

## Localized holiday names

`PublicHolidaysInformation(year)` returns `Holiday` objects, each of which can give you its name
three ways:

| | the question it answers | Belgium's 25 December |
|---|---|---|
| `holiday.Name` | what does this calendar call it? | `Kerstmis` |
| `holiday.EnglishName` | English, always | `Christmas` |
| `holiday.GetName(culture)` | what is it called in this language? | `fr-BE` → `Noël`, `fr` → `Fête de Noël`, `es` → `Kerstmis` (no Spanish, so the calendar's own) |

A name is never empty: whatever you ask for, the holiday's own `EnglishName` is there as the last
resort.

```C#
var calendar = PublicHolidayFactory.GetPublicHolidayForCountry("BE");
var christmas = calendar.PublicHolidaysInformation(2026)
    .Single(h => h.HolidayDate == new DateTime(2026, 12, 25));

christmas.Name;                                // "Kerstmis"
christmas.GetName(new CultureInfo("fr-BE"));   // "Noël"
christmas.GetName(new CultureInfo("de-BE"));   // "Weihnachten"

// or a whole year in one language
IDictionary<DateTime, string[]> french = calendar.PublicHolidayNames(2026, new CultureInfo("fr-BE"));
```

### One app, many countries: pick the calendar from the user

Nothing needs to name a country. Ask the factory for the user's country and let the same locale
choose the language, so a calendar screen localises itself:

```C#
var user = CultureInfo.CurrentUICulture;                            // e.g. "fr-BE"
var country = new RegionInfo(user.Name).TwoLetterISORegionName;      // "BE"

IPublicHolidays calendar = PublicHolidayFactory
    .GetPublicHolidayForCountry(country)                             // BelgiumPublicHoliday
    .WithCulture(user);                                              // answering in French

foreach (var holiday in calendar.PublicHolidaysInformation(DateTime.Today.Year))
{
    Show(holiday.ObservedDate, holiday.Name);                        // "Noël", "Nouvel An", ...
}
```

The same three lines cover every supported country — `de-DE` gives you German holidays named
`Weihnachtstag`, `nl-BE` gives Belgian ones named `Kerstmis`, `el-GR` gives Greek ones named
`Πρωτοχρονιά`. Three things to handle:

- **Not every country is supported.** `GetPublicHolidayForCountry` throws
  `ArgumentOutOfRangeException` for a country code the library has no calendar for, so catch it and
  fall back to whatever your app does without a holiday calendar.
- **Not every country has translated names yet.** Where a language has no resource file the names
  come back in English — today that includes Poland and Japan. Adding them is a translation file,
  not code, and you can supply your own in the meantime (below).
- **Derive the country from a specific culture, not a neutral one.** `CurrentUICulture` normally is
  specific (`fr-BE`), but `new RegionInfo("et")` does not mean Estonia — it means **Ethiopia**, and
  `new RegionInfo("el")` throws. If your app can hand you a bare language, take the country from
  your own user profile instead of inferring it.

### Reading a country in another of its languages

`Name` answers in the calendar's `Culture`, which you can choose once instead of passing a culture
to every call. `WithCulture` works on any calendar and keeps its type, so it combines with a
region:

```C#
new BelgiumPublicHoliday().PublicHolidaysInformation(2026).Last().Name;    // "Kerstmis"
new BelgiumPublicHoliday().WithCulture("fr-BE")
    .PublicHolidaysInformation(2026).Last().Name;                         // "Noël"

new CanadaPublicHoliday("QC").WithCulture("fr-CA");                       // province + language
new AustraliaPublicHoliday { State = AustraliaPublicHoliday.States.NSW }
    .WithCulture("en-AU");

// or set it directly, before or after a first call - the year cache is cleared for you
var swiss = new SwitzerlandPublicHoliday { Culture = new CultureInfo("fr-CH") };
```

### Where the names come from

One resource file per culture (`Localization/Names/<culture>.resx`), keyed by a stable id per
holiday (`Holiday.HolidayKey`). A lookup tries the culture asked for, then its parents:

| File | Holds |
|---|---|
| `Names/et.resx` | Estonian — Estonia is the only country that speaks it, so the language file is all it needs |
| `Names/de.resx` | German as a general translation — `Neujahrstag` |
| `Names/de-AT.resx` | Austria's own wording where it differs — `Neujahr` |

So `de-AT` answers from Austria's file, `de-LI` (no file) from `de`, and `fr-GF` from `fr`. Region
files exist only where a language spans several supported countries: `de`, `en`, `es`, `fr`, `nl`,
`pt`, `sr`. Everything else is a plain language file.

English needs no file: it is the `EnglishName` on each holiday definition. Countries share ids for
shared holidays (Christmas, Easter, …), so one language file serves every country that observes
them — adding French covers Estonia's Easter Monday as much as France's.

### Supplying your own translations

The library does not ship every language, and you may disagree with one it does. Register an
`IHolidayNameProvider` and it is asked before the library's own names.

Say a Polish company in Brussels wants Belgian holidays in Polish for its staff. Put the
translations in a `.resx` of your own, named by holiday id, and wire it up in one line at start-up:

```C#
// MyHolidayNames.resx (neutral) + MyHolidayNames.pl.resx, with rows named after the holiday's
// HolidayKey: "NewYear", "EasterMonday", "BelgianNationalDay", "Christmas", ...
HolidayNameProviders.Add(new ResourceManagerNameProvider(MyHolidayNames.ResourceManager));

var belgium = PublicHolidayFactory.GetPublicHolidayForCountry("BE").WithCulture("pl");

foreach (var holiday in belgium.PublicHolidaysInformation(2026))
{
    holiday.Name;   // "Nowy Rok", "Poniedziałek Wielkanocny", "Belgijskie Święto Narodowe", ...
}
```

Any other store works — a database, JSON, constants — by implementing the interface yourself:

```C#
public sealed class PolishHolidayNames : IHolidayNameProvider
{
    private static readonly Dictionary<string, string> Names = new Dictionary<string, string>
    {
        { "NewYear", "Nowy Rok" },
        { "BelgianNationalDay", "Belgijskie Święto Narodowe" },
        { "Christmas", "Boże Narodzenie" },
    };

    public bool TryGetName(string localizationKey, CultureInfo culture, out string name)
    {
        name = null;
        return culture != null
            && culture.TwoLetterISOLanguageName == "pl"
            && Names.TryGetValue(localizationKey, out name);
    }
}
```

Two rules worth knowing:

- **Answer for one exact culture only.** The library tries `nl-BE`, then `nl`, then invariant, and
  asks your provider at each step. Falling back yourself would let a generic answer of yours beat a
  more specific one.
- **The closest culture wins, whoever supplied it.** Your provider is asked before the library's
  own names *for the same culture*, so you can override them — but a shipped `nl-BE` name still
  beats a culture-neutral one of yours.

Providers are process-wide and normally registered once at start-up;
`HolidayNameProviders.Remove` and `HolidayNameProviders.Clear` undo it. A key your provider does
not know falls through to the library, so a partial translation is fine — with the Polish set
above, `Name` gives `Nowy Rok` and `Boże Narodzenie` but `Ascension` and `Labour Day` in English.

That last point is the difference between the two ways of choosing a language:

| | untranslated holidays come back in |
|---|---|
| `Culture = "pl"` / `WithCulture("pl")` | **English** — you replaced the calendar's language with Polish |
| `GetName(new CultureInfo("pl"))` | the **country's own language** (`Kerstmis`) — the calendar's language is untouched |

So set `Culture` when your app wants one language or a neutral fallback, and use `GetName` when you
want a translation but would rather see the local name than English.

## Weekend Rules

For many countries, when holidays fall on a weekend, the next working Monday becomes a public holiday (this is sometimes called "Mondayised"). This is the general rule in the UK, and used for certain (but not all) holidays in Australia and New Zealand.

In the USA, when holidays fall on Sundays, the holiday is moved to Monday. When the holiday falls on Saturday, the holiday is moved to the preceding Friday. The USA Federal Reserve holidays differ slightly, as holidays that fall on a Saturday do not cause a closure on the preceding Friday as described [on the Federal Reserve's website.](https://www.federalreserve.gov/aboutthefed/k8.htm)

For most of Europe, there is no standard rule for when the holidays fall on weekends. Normally these days are just added to the annual leave.  

Some countries mondayise only part of their calendar. **Latvia** does it for the three holidays its law names - 4 May, 18 November and the Song and Dance Festival closing day - and not for Christmas or New Year's Eve. `HolidayDate` is then the date in the law and `ObservedDate` the day off that follows it:
```C#
// 4 May 2024 was a Saturday, so the day off was Monday 6 May
var restoration = new LatviaPublicHoliday().PublicHolidaysInformation(2024)
    .Single(h => h.HolidayDate == new DateTime(2024, 5, 4));
// restoration.ObservedDate == 2024-05-06
```

## Variations by states and province 

In **Canada** there are some provincial holidays that vary by region. You can access these by passing in the ISO Code of the province to the constructor
```C#
//Retrieve a list of holidays in Saskatchewan for 2016
IList<DateTime> result = new CanadaPublicHoliday("SK").PublicHolidays(2016);
```

In **France** the calendar comes with holidays valid in all the country. 
```C#
// Get the list of public holidays for 2024
IList<DateTime> result = new FrancePublicHoliday().PublicHolidays(2024);

// Get the list of public holidays name and date for 2024
IDictionary<DateTime, string[]> names = new FrancePublicHoliday().PublicHolidayNames(2024);
```

A method returns a list of objects for all public holidays, with the names of the regions concerned for each date :
```C#
var calendar = new FrancePublicHoliday { Region = FrancePublicHoliday.Regions.Martinique };
// Get the 14 dates for the public holidays in Martinique for 2024
var hols = calendar.PublicHolidays(2024);

// We can also recover all the public holidays of all the regions combined
var calendar = new FrancePublicHoliday { };
IList<DateTime> hols = calendar.PublicHolidays(2024);
```

In **Germany** specify the state using an enum (the ISO code)
```C#
//Calendar for Saxony
var calendar = new GermanPublicHoliday { State = GermanPublicHoliday.States.SN };
IList<DateTime> result = calendar.PublicHolidays(2017);
//result contains 22 November 2017, Repentance and Prayer Day
```

In **United Kingdom** England/Wales is default. Specify Scotland or Northern Ireland using an enum
```C#
//Calendar for Scotland
var calendar = new UKBankHoliday { UkCountry = UKBankHoliday.UkCountries.Scotland };
IList<DateTime> result = calendar.PublicHolidays(2022);
//result contains 30 November 2022, St Andrew's Day
```

In **Switzerland** the calendar comes with holidays valid in all the country. Add further ones depending on your local rules in the constructor. Choices: hasSecondJanuary, hasLaborDay, hasCorpusChristi, hasChristmasEve, hasNewYearsEve.
```C#
var calendar = new SwitzerlandPublicHoliday { Canton = SwitzerlandPublicHoliday.Cantons.OW };
var nationalDay = new DateTime(2024, 8, 1);
//yes it is
var isHoliday = calendar.IsPublicHoliday(nationalDay);

// We can also recover all the public holidays of all the cantons combined
var holidayCalendar = new SwitzerlandPublicHoliday { Canton = SwitzerlandPublicHoliday.Cantons.ALL };
IList<DateTime> hols = holidayCalendar.PublicHolidays(2024);
```

A method returns a list of objects for all public holidays, with the names of the regions concerned for each date :
```C#
var holidayCalendar = new SwitzerlandPublicHoliday();
IList<Holiday> hols = holidayCalendar.PublicHolidaysInformation(2024);
```

In **Australia** most holidays are defined by the state or territory. Specify the state using an enum (the ISO code).
```C#
//Calendar for Western Australia
var calendar = new AustraliaPublicHoliday { State = AustraliaPublicHoliday.States.WA };
var westernAustraliaDay = new DateTime(2017, 6, 5);
//yes it is
var isHoliday = calendar.IsPublicHoliday(westernAustraliaDay);
```

**IMPORTANT** A few Australia state holidays do not have fixed rules, and cannot be calculated.  
*  For Victoria, AFL Grand Final Day
*  For Western Australia, Queen's Birthday (we assume end September BUT may change)
*  The calendar does not contain local holidays (Royal Queensland Show day, Royal Hobart Regatta)

## Thanks
@petergaal
@msmells
@oliver-h
@DanielSundberg
@kant2002
@zanemcca
@jcdekoning
@thelious
@rickbeerendonk
@skipishere
@MilkyWare
@Hrothval
@mihaigliga21

## License

License is MIT. You are free to use this software in commercial projects.

## Building the Source

* Supports .net 3.5. To enable dism /online /enable-feature /featurename:NetFx3 /All
* If you use Visual Studio *2026* or Visual Studio *2022* open PublicHoliday.sln (.net 8 +, supports .net 10)
  * You cannot use the command line "dotnet build" because Core tooling cannot build v3.5 (see https://github.com/Microsoft/msbuild/issues/1333)

