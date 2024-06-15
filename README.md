# Fluent Errors

[![Coverage Status](https://coveralls.io/repos/github/ne1410s/FluentErrors/badge.svg?branch=main)](https://coveralls.io/github/ne1410s/FluentErrors?branch=main)

[![Codacy Badge](https://app.codacy.com/project/badge/Grade/9fcf73d6791b4e36b461432dab7194d6)](https://app.codacy.com/gh/ne1410s/FluentErrors/dashboard)

[![Mutation testing badge](https://img.shields.io/endpoint?style=flat&url=https%3A%2F%2Fbadge-api.stryker-mutator.io%2Fgithub.com%2Fne1410s%2FFluentErrors%2Fmain)](https://dashboard.stryker-mutator.io/reports/github.com/ne1410s/FluentErrors/main)

## Overview
With Fluent Errors, you can chain one or many assertions to an object, to effect bespoke exception(s).
The origin for this code came from N-Tier ASP.NET Core Web Api where it was convenient to have a constistent and ubiquitous behaviour across all tiers of the application.
Indeed, mapping these exceptions to http response codes is made as straight-forward as possible with this library.

## Notes
### Commands
```powershell
# Restore tools
dotnet tool restore

# Run unit tests
gci **/TestResults/ | ri -r; dotnet test -c Release -s .runsettings; dotnet reportgenerator -targetdir:coveragereport -reports:**/coverage.cobertura.xml -reporttypes:"html;jsonsummary"; start coveragereport/index.html;

# Run mutation tests
gci **/StrykerOutput/ | ri -r; dotnet stryker -o;

# Pack and publish a pre-release to a local feed
$suffix="alpha001"; dotnet pack -c Release -o nu --version-suffix $suffix; dotnet nuget push "nu\*.*$suffix.nupkg" --source localdev; gci nu/ | ri -r; rmdir nu;
```
