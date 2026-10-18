# Workflows

Commands run from the repository root. The solution is `aweXpect.Chronology.slnx`.

## Build and Test

```powershell
dotnet build aweXpect.Chronology.slnx
dotnet test Tests/aweXpect.Chronology.Tests
dotnet test Tests/aweXpect.Chronology.Tests -f net10.0 --filter "FullyQualifiedName~TimeSpanExtensions"
dotnet test Tests/aweXpect.Chronology.Api.Tests
```

- Building the library also creates its NuGet package in `Source/aweXpect.Chronology/bin/<Configuration>/` (`GeneratePackageOnBuild`).
- The unit tests use xUnit v2 on VSTest, so `--filter` takes VSTest expressions (`FullyQualifiedName~...`, `DisplayName~...`).
- The unit tests target `net10.0`, `net8.0` and `net48`. The `net48` leg only runs on Windows; pass `-f` to select one framework.
- The solution contains the benchmarks project but not the pipeline project (`Build Project="false"`), so `dotnet build` does not build `Pipeline/`.

## Public API Snapshots

`Tests/aweXpect.Chronology.Api.Tests` (NUnit, `net10.0`) compares the public API of each library build (`netstandard2.0`, `net8.0`, `net10.0`, read from `Source/Directory.Build.props`) with `ApiApprovalTests.aweXpect%2EChronology.<framework>.awexpect-snapshot.txt`, using `aweXpect.Snapshots.PublicApi`. The project builds all target frameworks of the library after its own build and reads them from `Source/aweXpect.Chronology/bin/<Configuration>/<framework>/`, so it must be built in the same configuration it runs in.

When a public API change is intended, accept it in one of these ways and commit the updated snapshot files:

- Run the explicit test: `dotnet test Tests/aweXpect.Chronology.Api.Tests --filter "Name=AcceptApiChanges"`.
- Run the tests with `AWEXPECT_ACCEPT_SNAPSHOTS=all` (PowerShell: `$env:AWEXPECT_ACCEPT_SNAPSHOTS = 'all'`).
- Rename the `*.awexpect-snapshot.pending` file that a failing test writes next to the snapshot.

Never commit `*.awexpect-snapshot.pending` files.

## Build Pipeline

`Pipeline/Build.csproj` is a [NUKE](https://nuke.build/) build. Run it with `./build.ps1 <Target>` (Windows), `./build.sh <Target>` or `build.cmd <Target>`. `./build.ps1 --help` lists the targets. Without a target it runs the defaults `ApiChecks` and `CodeAnalysis`. The configuration is `Debug` locally and `Release` on CI; override it with `--configuration Release`. Versions come from GitVersion; local builds get a `-DEV` suffix. Outputs go to `Artifacts/` and `TestResults/`, which `Clean` empties and git ignores.

| Target | Depends on | What it does |
|---|---|---|
| `Compile` | `Restore`, `CalculateNugetVersion` | Restores (after `Clean`) and builds the solution with the GitVersion version. |
| `UnitTests` | `Compile` | Runs `aweXpect.Chronology.Tests`: `dotnet test` with coverage for every framework except `net48`, and the xUnit console runner for `net48` on Windows. |
| `CodeCoverage` | `UnitTests` | Merges the coverage into `TestResults/reports/OpenCover.xml` with ReportGenerator. |
| `ApiChecks` | `Compile` | Runs `aweXpect.Chronology.Api.Tests`. |
| `CodeAnalysis` | `Compile`, `CodeCoverage` | SonarCloud analysis (`Testably_aweXpect.Chronology`); the end step only runs on CI and needs `SonarToken`. |
| `MutationTests` | `Compile` | Runs Stryker.NET (`Advanced` level, `net10.0`) on the library with the unit tests; on branches other than `main` only code changed since `main` is mutated. On a PR it comments the result. |
| `Benchmarks` | | Builds the benchmarks in `Release`, runs all of them with the JSON exporter into `Artifacts/Benchmarks`, logs the report and comments it on a PR. |
| `Pack` | `UpdateReadme`, `Compile` | Writes a release README with versioned badges to `Artifacts/README.md` and moves the `.nupkg`/`.snupkg` files to `Artifacts/Packages`. |

Mutation tests and benchmarks take a while; CI runs both on every PR, so run them locally only when needed.

## Benchmarks

`Benchmarks/aweXpect..Chronology.Benchmarks` (note the double dot in the folder name) uses BenchmarkDotNet. `HappyCaseBenchmarks` is split into one partial file per type, and each case has a `<Type>_aweXpect` and a `<Type>_DotNet` variant. The PR comment highlights the `_aweXpect` rows. Run a subset locally:

```powershell
dotnet run -c Release --project Benchmarks/aweXpect..Chronology.Benchmarks -- --filter "*TimeSpan*"
```

## Documentation

- `README.md` is the user documentation: a reference table and a section per area. Update it with every public API change.
- `Docs/pages/00-index.md` embeds the README (`{README}`) for docs.testably.org. After a successful `Build` workflow on `main`, `notify-docs-site.yml` triggers a rebuild of `Testably/Testably.Site`.
- The README is packed into the NuGet package; `Pack` adjusts its badges to the release version.
- `Docs/agents/` holds this guide and is not published.

## CI Workflows

- `ci.yml` (pull requests to `main`): unit tests on Ubuntu, Windows and macOS (`CodeCoverage`), API tests (`ApiChecks`), mutation tests, benchmarks and SonarCloud analysis (the last three are skipped for Dependabot), and a job that publishes the test results to the PR.
- `build.yml` (pushes to `main` and `v*` tags): the same test and analysis jobs plus `Pack`. On a tag, `Push` publishes the packages to nuget.org via trusted publishing; a tag without a pre-release suffix (`vX.Y.Z`) also creates a GitHub release, and `Finalize release` comments on the released issues and PRs.
- `notify-docs-site.yml`: see Documentation.
- `.github/dependabot.yml` updates NuGet packages and actions weekly with `chore:` commits. `.github/mergify.yml` squash-merges Dependabot PRs once the unit test and API test checks pass.
- Third-party actions are pinned to a commit SHA with a version comment.
