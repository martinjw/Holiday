Public Holidays
===============

Nuget: Install-Package PublicHoliday [![Nuget](https://img.shields.io/nuget/v/PublicHoliday.svg) ](https://www.nuget.org/packages/PublicHoliday/)

Orders and deliveries, data transfers, and other processes can often only be made on business working days. They cannot be made on national public holidays. Public holidays in many countries can be calculated algorithmically. 

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
  - Czech Republic : CzechRepublicPublicHoliday
  - ECB : EcbTargetClosingDay (European Central Bank SEPA Target Closing days - no exchange rates and no SEPA transactions)
  - France : FrancePublicHoliday
  - Germany : GermanPublicHoliday (set State property for regional holidays)
  - Ireland : IrelandPublicHoliday
  - Italy : ItalyPublicHoliday
  - Luxembourg : LuxembourgPublicHoliday
  - Netherlands : DutchPublicHoliday
  - Norway : NorwayPublicHoliday
  - Poland : PolandPublicHoliday
  - Slovakia : SlovakiaPublicHoliday
  - Spain : SpainPublicHoliday
  - Sweden : SwedenPublicHoliday
  - Switzerland: SwitzerlandPublicHoliday
  - UK : UKBankHoliday
- E. Europe/Asia
  - Kazakhstan : KazakhstanPublicHoliday
- N America
  - Canada : CanadaPublicHoliday (set Province in constructor for regional holidays)
  - USA : USAPublicHoliday
- Oceania
  - Australia : AustraliaPublicHoliday (set State property for regional holidays, see note below)
  - New Zealand : NewZealandPublicHoliday
- Asia
  - Japan : JapanPublicHoliday

All use the common interface IPublicHoliday containing:
- IsPublicHoliday(DateTime) (UK: also IsBankHoliday(DateTime))
- IsWorkingDay(DateTime) (i.e. not public holiday, Saturday or Sunday)
- NextWorkingDay(DateTime)
- PublicHolidays(int year)
- PublicHolidaysInformation(int year)
- PublicHolidayNames(int year)
- GetHolidaysInDateRange(DateTime, DateTime)

There are also static methods for all statutory holidays.

## Weekend Rules

For many countries, when holidays fall on a weekend, the next working Monday becomes a public holiday (this is sometimes called "Mondayised"). This is the general rule in the UK, and used for certain (but not all) holidays in Australia and New Zealand. In the USA, when holidays fall on Sundays, the holiday is moved to Monday. When the holiday falls on Saturday, the holiday is moved to the preceding Friday.

For most of Europe, there is no standard rule for when the holidays fall on weekends. Normally these days are just added to the annual leave.  

## Variations by states and province 

In **Canada** there are some provincial holidays that vary by region. You can access these by passing in the ISO Code of the province to the constructor
```C#
//Retrieve a list of holidays in Saskatchewan for 2016
IList<DateTime> result = new CanadaPublicHoliday("SK").PublicHolidays(2016);
```

In **Germany** specify the state using an enum (the ISO code)
```C#
//Calendar for Saxony
var calendar = new GermanPublicHoliday { State = GermanPublicHoliday.States.SN };
IList<DateTime> result = calendar.PublicHolidays(2017);
//result contains 22 November 2017, Repentance and Prayer Day
```

In **Switzerland** the calendar comes with holidays valid in all the country. Add further ones depending on your local rules in the constructor. Choices: hasSecondJanuary, hasLaborDay, hasCorpusChristi, hasChristmasEve, hasNewYearsEve.
```C#
var calendar = SwitzerlandPublicHoliday(hasLaborDay:true);
var laborDay = new DateTime(2017, 5, 1);
//yes it is
var isHoliday = calendar.IsPublicHoliday(laborDay);
```

In **Australia** most holidays are defined by the state or territory. Specify the state using an enum (the ISO code).
```C#
//Calendar for Western Australia
var calendar = AustraliaPublicHoliday { State = AustraliaPublicHoliday.States.WA };
var westernAustrliaDay = new DateTime(2017, 6, 5);
//yes it is
var isHoliday = holidayCalendar.IsPublicHoliday(westernAustrliaDay);
```

**IMPORTANT** A few Australia state holidays do not have fixed rules, and cannot be calculated.  
*  For Victoria, AFL Grand Final Day
*  For Western Australia, Queen's Birthday (we assume end September BUT may change)
*  The calender does not contain local holidays (Royal Queensland Show day, Royal Hobart Regatta)

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

## License

License is MIT. You are free to use this software in commercial projects.

## Building the Source

* If you use Visual Studio *2019* open PublicHoliday.sln (.net Core)
  * You cannot use the command line "dotnet build" because Core tooling cannot build v3.5 (see https://github.com/Microsoft/msbuild/issues/1333)
* If you use Visual Studio *2015* open PublicHoliday2015.sln (does not include .net Core; v3.5-v4.6 only)
