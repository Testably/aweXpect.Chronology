# Project Structure

## Layout

| Path | Contents |
|---|---|
| `Source/aweXpect.Chronology/` | The library, the only shipped project. |
| `Tests/aweXpect.Chronology.Tests/` | Unit tests (TUnit with aweXpect assertions). |
| `Tests/aweXpect.Chronology.Api.Tests/` | Public API snapshot tests (TUnit with `aweXpect.Snapshots.PublicApi`). |
| `Benchmarks/aweXpect..Chronology.Benchmarks/` | BenchmarkDotNet comparisons with the plain .NET equivalents. |
| `Pipeline/` | The Fallout build (`Build.*.cs`, one partial file per target group). |
| `Docs/` | `logo.png` (package icon), `pages/` (published to docs.testably.org), `agents/` (this guide). |
| `.github/` | CI workflows, Dependabot and Mergify configuration. |
| `.fallout/` | Fallout parameters (`Solution`) and the generated build schema. |

Shared MSBuild settings: `Source/Directory.Build.props` (target frameworks, package metadata, signing, warnings as errors), `Tests/Directory.Build.props` (target frameworks and the TUnit packages of the test projects) and `Directory.Packages.props` (central package versions). `Pipeline/Directory.Build.props` and `.targets` are empty on purpose, so the pipeline does not import them.

## Library

All public types are in the namespace `aweXpect.Chronology`. The design is a set of extension methods that return small `readonly struct` builders; each builder wraps one BCL value and converts to it implicitly, and on .NET 8+ also to `DateOnly`/`TimeOnly` where it makes sense.

| File | Public type | Role |
|---|---|---|
| `TimeSpanExtensions.cs` | `TimeSpanBuilderExtensions` | `Milliseconds`, `Seconds`, `Minutes`, `Hours`, `Days` on `int` and `double`, each with an optional `TimeSpan` offset. |
| `TimeSpanBuilder.cs` | `TimeSpanBuilder` | Wraps a `TimeSpan`; arithmetic operators and conversions to `TimeSpan` (and `TimeOnly`). |
| `DateTimeExtensions.cs` | `DateTimeExtensions` | `January` to `December` on `int` (day) with the year, `At` (also on `DateTime` and, on .NET 8+, `DateOnly`), `AsUtc`, `AsLocal`, `Before` and `After`. |
| `DateBuilder.cs` | `DateBuilder` | A date without time; converts to `DateTime` (and `DateOnly`). |
| `DateTimeBuilder.cs` | `DateTimeBuilder` | A date with time; converts to `DateTime` (and `DateOnly`/`TimeOnly`). |
| `DateTimeOffsetExtensions.cs` | `DateTimeOffsetExtensions` | `WithOffset` on `DateBuilder`, `DateTimeBuilder` and `DateTime`. |
| `DateTimeOffsetBuilder.cs` | `DateTimeOffsetBuilder` | Wraps a `DateTimeOffset`; converts to `DateTimeOffset` and `DateTime` (and `DateOnly`/`TimeOnly`). |

The date builders also support `+` and `-` with a `TimeSpan`.

Members that only exist on .NET 8+ are wrapped in `#if NET8_0_OR_GREATER`, including separate XML doc variants where the summary mentions them. These differences show up in the per-framework API snapshots.

## Tests

- `Tests/aweXpect.Chronology.Tests/Usings.cs` declares global usings for `System`, `System.Threading.Tasks`, `TUnit.Core` and `static aweXpect.Expect`, so tests assert with `await That(result).IsEqualTo(expected);`.
- Tests for a builder live in `<Builder>Tests.cs`. Tests for an extension class are split into `<Class>.<Method>Tests.cs`, each a nested `sealed class <Method>Tests` inside a `sealed partial class <Class>`.
- Test names follow `Method_Scenario_ShouldExpectation` (for example `Days_Int_WithOffset_ShouldReturnCorrectTimeSpan`). Tests are `async Task` methods with an arrange, act and assert block.
- Tests of .NET 8+ members use `#if NET8_0_OR_GREATER` like the library.
- `Tests/aweXpect.Chronology.Api.Tests/Helper.cs` locates the solution directory by searching for `aweXpect.Chronology.slnx` above the test output directory and reads the target frameworks from `Source/Directory.Build.props`.
