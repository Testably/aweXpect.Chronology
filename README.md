# aweXpect.Chronology
[![Nuget](https://img.shields.io/nuget/v/aweXpect.Chronology)](https://www.nuget.org/packages/aweXpect.Chronology) 
[![Build](https://github.com/Testably/aweXpect.Chronology/actions/workflows/build.yml/badge.svg)](https://github.com/Testably/aweXpect.Chronology/actions/workflows/build.yml)
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=Testably_aweXpect.Chronology&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=Testably_aweXpect.Chronology)
[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=Testably_aweXpect.Chronology&metric=coverage)](https://sonarcloud.io/summary/new_code?id=Testably_aweXpect.Chronology)
[![Mutation testing badge](https://img.shields.io/endpoint?style=flat&url=https%3A%2F%2Fbadge-api.stryker-mutator.io%2Fgithub.com%2FTestably%2FaweXpect.Chronology%2Fmain)](https://dashboard.stryker-mutator.io/reports/github.com/Testably/aweXpect.Chronology/main)

Extension methods for creating chronology objects like `TimeSpan` or `DateTime` that read more naturally.

The full documentation is available at [docs.testably.org](https://docs.testably.org/aweXpect/chronology/).


## Installation

```shell
dotnet add package aweXpect.Chronology
```

Supported target frameworks: **.NET Standard 2.0**, **.NET 8**, **.NET 10**. The `DateOnly` and `TimeOnly` conversions require .NET 8 or later.

The extension methods are in the `aweXpect.Chronology` namespace:

```csharp
using aweXpect.Chronology;
```


## At a glance

Without aweXpect.Chronology:

```csharp
TimeSpan timeout = TimeSpan.FromMinutes(1) + TimeSpan.FromSeconds(30);
DateTime start = new DateTime(2024, 12, 24, 18, 30, 0, DateTimeKind.Utc);
DateTimeOffset end = new DateTimeOffset(2024, 12, 25, 6, 0, 0, TimeSpan.FromHours(2));
DateTime reminder = start - TimeSpan.FromHours(3);
```

With aweXpect.Chronology:

```csharp
TimeSpan timeout = 1.Minutes(30.Seconds());
DateTime start = 24.December(2024).At(18, 30).AsUtc();
DateTimeOffset end = 25.December(2024).At(6, 0).WithOffset(2.Hours());
DateTime reminder = 3.Hours().Before(start);
```

The methods return lightweight builders that convert implicitly to the .NET types, so you can pass them wherever a `TimeSpan`, `DateTime` or `DateTimeOffset` is expected.


## Overview

| Feature                                         | Methods                                                         | Example                                   |
|-------------------------------------------------|-----------------------------------------------------------------|-------------------------------------------|
| [Units](#units)                                 | `Milliseconds`, `Seconds`, `Minutes`, `Hours`, `Days`           | `5.Minutes()`                             |
| [Combine values](#combine-values)               | the same methods with a `TimeSpan` argument                     | `1.Minutes(30.Seconds())`                 |
| [Arithmetic](#arithmetic)                       | `+`, `-`, `*` (by `double`), `/` (by `double`), unary `-`       | `5.Minutes() * 2`                         |
| [Dates](#dates)                                 | `January` … `December`                                          | `24.December(2024)`                       |
| [Time of day](#time-of-day)                     | `At(hours, minutes, [seconds], [milliseconds])`, `At(TimeSpan)` | `24.December(2024).At(18, 30)`            |
| [Kind](#kind)                                   | `AsUtc`, `AsLocal`                                              | `24.December(2024).At(18, 30).AsUtc()`    |
| [Relative dates](#relative-dates)               | `Before`, `After`                                               | `3.Hours().Before(25.December(2024))`     |
| [Add and subtract](#add-and-subtract)           | `+`, `-` with a `TimeSpan`                                      | `24.December(2024) + 18.Hours()`          |
| [DateTimeOffset](#datetimeoffset)               | `WithOffset(TimeSpan)`                                          | `24.December(2024).WithOffset(2.Hours())` |
| [DateOnly and TimeOnly](#dateonly-and-timeonly) | implicit conversions                                            | `DateOnly date = 24.December(2024);`      |


## TimeSpan

### Units

The package adds the extension methods `Milliseconds()`, `Seconds()`, `Minutes()`, `Hours()` and `Days()` on `int` and `double`:

```csharp
TimeSpan timeout = 10.Seconds();
TimeSpan duration = 1.5.Hours();
```

### Combine values

Each method has an overload that adds another `TimeSpan`, so you can write a value with several units:

```csharp
TimeSpan timeout = 1.Minutes(30.Seconds()); // 00:01:30
TimeSpan period = 2.Days(12.Hours());       // 2.12:00:00
```

### Arithmetic

The result supports the operators `+`, `-`, `*` (by `double`), `/` (by `double`) and unary negation:

```csharp
TimeSpan doubled = 5.Minutes() * 2;
TimeSpan half = 5.Minutes() / 2;
TimeSpan combined = 1.Minutes() + 30.Seconds();
TimeSpan negative = -10.Seconds();
```


## Dates and times

### Dates

The package adds an extension method on `int` for each month, which takes the day and the year:

```csharp
DateTime christmasEve = 24.December(2024);
```

The date has the time 00:00 and the `DateTimeKind` `Unspecified`. Set the [kind](#kind) explicitly when the value is compared with UTC or local times.

### Time of day

`At` sets the time of day, either with explicit components or with a `TimeSpan`:

```csharp
DateTime time = 24.December(2024).At(18, 30);
DateTime preciseTime = 24.December(2024).At(18, 30, 45, 500);
DateTime fromTimeSpan = 24.December(2024).At(18.Hours(30.Minutes()));
```

`At` also works on an existing `DateTime` or `DateOnly` and replaces its time of day.

A component outside its range, e.g. `At(24, 0)` or `At(18, 60)`, and a `TimeSpan` outside a single day, e.g. `At(24.Hours())` or `At(-1.Hours())`, throw an `ArgumentOutOfRangeException`.

### Kind

`AsUtc()` and `AsLocal()` set the `DateTimeKind` of a date with a time of day or of an existing `DateTime`:

```csharp
DateTime utc = 24.December(2024).At(18, 30).AsUtc();
DateTime local = 24.December(2024).At(18, 30).AsLocal();
```

A date without a time has no `AsUtc()` or `AsLocal()`. Add the time explicitly, e.g. `24.December(2024).At(0, 0).AsUtc()` for midnight UTC.

### Relative dates

`Before` and `After` on a `TimeSpan` express a date relative to another one:

```csharp
DateTime earlier = 3.Hours().Before(25.December(2024));
DateTime later = 3.Hours().After(25.December(2024));
```

With a `DateTimeOffset`, the result keeps its offset:

```csharp
DateTimeOffset earlier = 3.Hours().Before(25.December(2024).At(12, 0).WithOffset(2.Hours())); // 09:00 +02:00
```

### Add and subtract

You can add a `TimeSpan` to a date or subtract one from it:

```csharp
DateTime evening = 24.December(2024) + 18.Hours();
DateTime dayBefore = 24.December(2024) - 1.Days();
```


## DateTimeOffset

`WithOffset` attaches a UTC offset to a date, a date with a time of day or an existing `DateTime`:

```csharp
DateTimeOffset date = 24.December(2024).WithOffset(1.Hours());
DateTimeOffset time = 24.December(2024).At(14, 30).WithOffset(2.Hours());
```

**Caution:** For a `DateTime` with the kind `Utc` or `Local`, the offset has to match: `24.December(2024).At(14, 30).AsUtc().WithOffset(2.Hours())` throws an `ArgumentException`. Use an `Unspecified` value, as in the examples above, or the matching offset.

The result also supports `+` and `-` with a `TimeSpan`. When you assign it to a `DateTime`, it keeps the clock time and drops the offset.


## DateOnly and TimeOnly

On .NET 8 and later, the results convert implicitly to `DateOnly` and `TimeOnly`:

```csharp
DateOnly date = 24.December(2024);
TimeOnly time = 18.Hours(30.Minutes());
TimeOnly timeOfDay = 24.December(2024).At(18, 30);
```

A date converts to `DateOnly`, a duration to `TimeOnly`, and a date with a time of day or an offset to both.
