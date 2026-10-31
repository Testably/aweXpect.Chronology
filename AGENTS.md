# aweXpect.Chronology Agent Guide

aweXpect.Chronology is a small library of extension methods that make `TimeSpan`, `DateTime` and `DateTimeOffset` values read naturally (`5.Minutes()`, `24.December(2024).At(18, 30)`). It is part of the aweXpect family but does not depend on aweXpect at runtime.

## Design Goals

Correctness is a must. The other goals are strong defaults and win in this order when they conflict: stable and compatible, AOT and trimming friendly, a consistent and pleasant API, a fast happy path, extensible, errors at compile time, documented. [Docs/agents/design-goals.md](Docs/agents/design-goals.md) explains each goal, the code rules, the checks before a commit and the goals of this repository.

## Project Constraints

- Use the SDK pinned in `global.json` (`rollForward: latestPatch`). The root `Directory.Build.props` only sets up strong-name signing: library settings live in `Source/Directory.Build.props`, test settings in `Tests/Directory.Build.props`. Package versions are managed centrally in `Directory.Packages.props`.
- The library targets `netstandard2.0;net8.0;net10.0`. `DateOnly`/`TimeOnly` support goes behind `#if NET8_0_OR_GREATER`. Unit tests target `net10.0;net8.0;net48`.
- `netstandard2.0` and `net48` have no polyfills for `IsExternalInit`, `System.Index` or `System.Range`: no records, `init` accessors, list patterns or ranges. Build `net48` first when using a newer language feature.
- The library compiles with `TreatWarningsAsErrors`, nullable enabled and XML docs generated. A missing XML doc (CS1591) only warns, but every public member has one; keep it that way. Assemblies are strong-name signed with `strongname.snk`.
- The package has no runtime dependencies (`Nullable` is a private, build-only polyfill). Do not add one without the maintainer's agreement. The code uses no reflection; keep it that way so it stays trimming and AOT friendly.
- All public types live in the `aweXpect.Chronology` namespace. Fluent methods return the `readonly struct` builders (`TimeSpanBuilder`, `DateBuilder`, `DateTimeBuilder`, `DateTimeOffsetBuilder`) so that implicit conversions work.
- Code style follows `.editorconfig`: tabs, file-scoped namespaces, explicit types instead of `var`.

## Validation

- Run the relevant tests before pushing: `dotnet test` runs all test projects (TUnit on the Microsoft.Testing.Platform). On Windows this includes `net48`.
- Any public API change must update the snapshots in `Tests/aweXpect.Chronology.Api.Tests` (one per library target framework). Review the diff, commit the updated `*.awexpect-snapshot.txt` files and never commit `*.awexpect-snapshot.pending` files. See [workflows](Docs/agents/workflows.md#public-api-snapshots).
- New or changed public API also needs the README (the NuGet readme) and `Docs/pages/00-index.md` (the page published on docs.testably.org) updated.
- All code is covered by unit tests. CI checks coverage (SonarCloud quality gate, more than 90 %) and mutation score (Stryker.NET).

## Repository Conventions

- C# files in `Source/`, `Tests/` and `Benchmarks/` start with a UTF-8 BOM; Markdown, project and pipeline files mostly do not. Keep a file's existing BOM state. PowerShell rewrites (`Set-Content`, `Out-File`) change it, so prefer targeted edits and check `git diff` for a stray or missing U+FEFF.
- Git stores text files with LF (`* text=auto`); `.editorconfig` asks for CRLF in the working tree. Multi-line raw string literals take the line endings of the file, so edit with tools that preserve them (not `sed -i`).
- No em-dashes in Markdown or XML docs.
- Local agent notes (for example `.claude/`) are never committed.

## Documentation

Pages under `Docs/pages` are published on docs.testably.org and follow the [docs style guide](https://github.com/Testably/Testably.Site/blob/main/Docs/style-guide.md). The key rules:

- US English, sentence case for headings and labels, no em dashes, one line per paragraph.
- A `description` in the front matter of every page; the H1 is the title; order with unique `NN-` prefixes.
- Relative file links within the repository, site-absolute `/Library/...` links across libraries.
- Install instructions only through `<PackageInstall package="..." />`, never hand-written commands or NuGet badges.
- Examples check results with `await That(...)`; complete examples use TUnit `[Test]`.

`README.md` is the GitHub and NuGet landing page and is maintained separately from `Docs/pages/00-index.md`; keep their reference tables and sections in sync by hand.

## Git Workflow

- Work on a feature branch and open a pull request against `main`. PRs are squash-merged, so the PR title becomes the commit subject.
- Commit subjects and PR titles follow [conventional commits](https://www.conventionalcommits.org/en/v1.0.0/): `feat:`, `fix:`, `refactor:`, `test:`, `docs:`, `ci:`, `chore:`. Dependabot uses `chore:`.
- The commit message is the PR description: the subject is the title, the body explains why (the diff shows what). Write each paragraph on a single line. No co-author or attribution trailers.
- Verify review findings against the code before changing it.

## References

- [Docs/agents/design-goals.md](Docs/agents/design-goals.md): the goals and code rules for every change, the checks before a commit and the goals of this repository.
- [Docs/agents/workflows.md](Docs/agents/workflows.md): build, test, API snapshot, benchmark, mutation and documentation commands, the build pipeline targets and the CI workflows.
- [Docs/agents/project-structure.md](Docs/agents/project-structure.md): projects, source locations and test conventions.
- [CONTRIBUTING.md](CONTRIBUTING.md): contributor expectations.
