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
- USA : USAPublicHoliday
- UK : UKBankHoliday
- France : FrancePublicHoliday
- Belgium : BelgiumPublicHoliday
- Canada : CanadaPublicHoliday
- Netherlands : DutchPublicHoliday
- Norway : NorwayPublicHoliday
- Spain : SpainPublicHoliday
- Kazakhstan : KazakhstanPublicHoliday

All use the common interface IPublicHoliday containing:
- IsBankHoliday(DateTime)
- NextWorkingDay(DateTime)
- PublicHolidays(int year)
- PublicHolidayNames(int year)
There are also static methods for all statutory holidays.

Note for France and Belgium when holidays fall on weekends, there is no standard rule for when the holiday may be taken (unlike the UK and USA, where the preceding Friday or next Monday are taken). Normally these days are just added to the annual leave.

In Canada there are some provincial holidays that vary by region. You can access these by passing in the ISO Code of the province to the constructor
```
//Retrieve a list of holidays in Saskatchewan for 2016
IList<DateTime> result = new CanadaPublicHoliday("SK").PublicHolidays(2016);
```

License is MIT. You are free to use this software in commercial projects.

