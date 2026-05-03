# aweXpect.Chronology
[![Nuget](https://img.shields.io/nuget/v/aweXpect.Chronology)](https://www.nuget.org/packages/aweXpect.Chronology) 
[![Build](https://github.com/Testably/aweXpect.Chronology/actions/workflows/build.yml/badge.svg)](https://github.com/Testably/aweXpect.Chronology/actions/workflows/build.yml)
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=Testably_aweXpect.Chronology&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=Testably_aweXpect.Chronology)
[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=Testably_aweXpect.Chronology&metric=coverage)](https://sonarcloud.io/summary/new_code?id=Testably_aweXpect.Chronology)
[![Mutation testing badge](https://img.shields.io/endpoint?style=flat&url=https%3A%2F%2Fbadge-api.stryker-mutator.io%2Fgithub.com%2FTestably%2FaweXpect.Chronology%2Fmain)](https://dashboard.stryker-mutator.io/reports/github.com/Testably/aweXpect.Chronology/main)

Extension methods for creating chronology objects like `TimeSpan` or `DateTime` that read more natural.


## Installation

```shell
dotnet add package aweXpect.Chronology
```

Or add a `<PackageReference>` to your project file:

```xml
<PackageReference Include="aweXpect.Chronology" Version="*" />
```

Supported target frameworks: **.NET Standard 2.0**, **.NET 8**, **.NET 10**.
`DateOnly` and `TimeOnly` conversions require .NET 8 or higher.


## Reference

| Category | Methods | Example | Result |
|---|---|---|---|
| `TimeSpan` units | `Milliseconds`, `Seconds`, `Minutes`, `Hours`, `Days` | `5.Minutes()` | `TimeSpan` |
| `TimeSpan` operators | `+`, `-`, `*` (by `double`), `/` (by `double`), unary `-` | `5.Minutes() * 2` | `TimeSpan` |
| Date | `January` … `December` | `24.December(2024)` | `DateTime` |
| Time of day | `At(hours, minutes, [seconds], [milliseconds])`, `At(TimeSpan)` | `24.December(2024).At(18, 30)` | `DateTime` |
| Kind | `AsUtc`, `AsLocal` | `24.December(2024).AsUtc()` | `DateTime` |
| Offset | `WithOffset(TimeSpan)` | `24.December(2024).WithOffset(2.Hours())` | `DateTimeOffset` |
| Relative | `Before`, `After` | `3.Hours().Before(25.December(2024))` | `DateTime` |
| .NET 8+ conversions | implicit casts to `DateOnly` / `TimeOnly` | `DateOnly d = 24.December(2024);` | `DateOnly` / `TimeOnly` |


## TimeSpan

Add the following extension methods on `int` and `double` that allow creating a `TimeSpan`:
- `.Milliseconds()`
- `.Seconds()`
- `.Minutes()`
- `.Hours()`
- `.Days()`

Traditional:
```csharp
TimeSpan timeout = TimeSpan.FromSeconds(10);
```

With aweXpect.Chronology:
```csharp
TimeSpan timeout = 10.Seconds();
```

It is also possible to combine multiple extension methods:
```csharp
TimeSpan timeout = 1.Minutes(30.Seconds());
```

The builder also supports arithmetic operators `+`, `-`, `*` (by `double`), `/` (by `double`) and unary negation:
```csharp
TimeSpan doubled = 5.Minutes() * 2;
TimeSpan combined = 1.Minutes() + 30.Seconds();
TimeSpan negative = -10.Seconds();
```


## DateTime

Add extension methods on `int` for each month that allow creating a `DateTime`:

Traditional:
```csharp
DateTime time = new DateTime(2024, 12, 24);
```

With aweXpect.Chronology:
```csharp
DateTime time = 24.December(2024);
```

A time of day can be specified with explicit components or a `TimeSpan`:
```csharp
DateTime time = 24.December(2024).At(18, 30);
DateTime preciseTime = 24.December(2024).At(18, 30, 45, 500);
DateTime fromTimeSpan = 24.December(2024).At(18.Hours(30.Minutes()));
```

Set the `DateTimeKind` with `AsUtc()` or `AsLocal()`:
```csharp
DateTime utc = 24.December(2024).At(18, 30).AsUtc();
DateTime local = 24.December(2024).At(18, 30).AsLocal();
```

Combine with `TimeSpan` extensions to express relative dates with `Before` or `After`:
```csharp
DateTime earlier = 3.Hours().Before(25.December(2024));
DateTime later = 3.Hours().After(25.December(2024));
```


## DateTimeOffset

Use `WithOffset` to attach a UTC offset to a date or date-and-time:

```csharp
DateTimeOffset time = 24.December(2024).At(14, 30).WithOffset(2.Hours());
```


## DateOnly and TimeOnly (.NET 8+)

On .NET 8 and later, the builders implicitly convert to `DateOnly` and `TimeOnly`:

```csharp
DateOnly date = 24.December(2024);
TimeOnly time = 18.Hours(30.Minutes());
```
