---
description: Extension methods that create TimeSpan, DateTime, DateTimeOffset, DateOnly and TimeOnly values in a readable way, e.g. 5.Seconds() or 24.December(2024).
---

import PackageInstall from '@site/src/components/PackageInstall';

# aweXpect.Chronology

[aweXpect.Chronology](https://github.com/Testably/aweXpect.Chronology) contains extension methods that create `TimeSpan`, `DateTime`, `DateTimeOffset`, `DateOnly` and `TimeOnly` values in a readable way, e.g. `5.Seconds()` or `24.December(2024)`. It belongs to the [aweXpect](/aweXpect) family, but does not depend on aweXpect, so you can use it in any code.

## Installation

<PackageInstall package="aweXpect.Chronology" />

The extension methods are in the `aweXpect.Chronology` namespace:

```csharp
using aweXpect.Chronology;
```

:::info[Target frameworks]
The package supports .NET Standard 2.0, .NET 8 and .NET 10. The `DateOnly` and `TimeOnly` conversions require .NET 8 or later.
:::

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
