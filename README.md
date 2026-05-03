# aweXpect.Chronology
[![Nuget](https://img.shields.io/nuget/v/aweXpect.Chronology)](https://www.nuget.org/packages/aweXpect.Chronology) 
[![Build](https://github.com/Testably/aweXpect.Chronology/actions/workflows/build.yml/badge.svg)](https://github.com/Testably/aweXpect.Chronology/actions/workflows/build.yml)
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=Testably_aweXpect.Chronology&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=Testably_aweXpect.Chronology)
[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=Testably_aweXpect.Chronology&metric=coverage)](https://sonarcloud.io/summary/new_code?id=Testably_aweXpect.Chronology)
[![Mutation testing badge](https://img.shields.io/endpoint?style=flat&url=https%3A%2F%2Fbadge-api.stryker-mutator.io%2Fgithub.com%2FTestably%2FaweXpect.Chronology%2Fmain)](https://dashboard.stryker-mutator.io/reports/github.com/Testably/aweXpect.Chronology/main)

Extension methods for creating chronology objects like `TimeSpan` or `DateTime` that read more natural.


## TimeSpan

Add the following extension methods on `int` and `double` that allow creating a `TimeSpan`:
- `.Milliseconds()`
- `.Seconds()`
- `.Minutes()`
- `.Hours()`
- `.Days()`

```csharp
// ↓ Using traditional creation of TimeSpan
TimeSpan timeout = TimeSpan.FromSeconds(10);
TimeSpan timeout = 10.Seconds();
// ↑ Using the extension methods from this library
```

It is also possible to combine multiple extension methods:
```csharp
TimeSpan timeout = 1.Minutes(30.Seconds());
```


## DateTime

Add extension methods on `int` for each month that allow creating a `DateTime`:

```csharp
// ↓ Using traditional creation of DateTime
DateTime time = new DateTime(2024, 12, 24);
DateTime time = 24.December(2024);
// ↑ Using the extension methods from this library
```

It is also possible to specify a time:
```csharp
DateTime time = 24.December(2024).At(18, 30);
```

It is also possible combine this with the `TimeSpan` extensions:
```csharp
DateTime time = 3.Hours().Before(25.December(2024));
```
