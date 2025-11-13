# azure-function-update-counter

[![build](https://img.shields.io/github/actions/workflow/status/yadickson/azure-function-update-counter/dotnet.yml?branch=main&style=flat-square)](https://github.com/yadickson/azure-function-update-counter/actions/workflows/dotnet.yml)
![tests](https://img.shields.io/endpoint?style=flat-square&url=https%3A%2F%2Fgist.githubusercontent.com%2Fyadickson%2F2edc636fc2ff6aff4b056d455f3290be%2Fraw%2Fazure-function-update-counter-junit-tests.json)
![coverage](https://img.shields.io/endpoint?style=flat-square&url=https%3A%2F%2Fgist.githubusercontent.com%2Fyadickson%2F2edc636fc2ff6aff4b056d455f3290be%2Fraw%2Fazure-function-update-counter-jacoco-coverage.json)

Azure Function To Update Counter


## Install dependencies on MacOS

```bash
brew tap azure/functions
```
```bash
brew update
```
```bash
brew install azure-functions-core-tools@4
```
```bash
brew install azure-cli
```

## Checking Azure CLI

```bash
az --version
```
```bash
az extension add --name azure-devops
```


## Create Azure Function Project by Zero

```bash
func init --worker-runtime dotnet-isolated  --target-framework net8.0
```
```bash
func new --name HttpExample --template "HTTP trigger" --authlevel "anonymous"
```
```bash
func azure functionapp fetch-app-settings "UpdateCounterFunction" --output-file local.settings.json
```
```bash
func start
```

## Initialize dotnet tools

```bash
dotnet new tool-manifest --force
```
```bash
dotnet tool install dotnet-format
```
```bash
dotnet tool install roslynator.dotnet.cli
```
```bash
dotnet tool install dotnet-stryker
```
```bash
dotnet tool install dotnet-reportgenerator-globaltool
```
```bash
dotnet tool install JetBrains.ReSharper.GlobalTools
```
```bash
dotnet tool install dotnet-outdated-tool
```
```bash
dotnet tool install dotnet-setversion
```
```bash
dotnet tool install dotnet-coverage
```
```bash
dotnet tool install JetBrains.dotCover.CommandLineTools
```
```bash
dotnet tool install dotnet-tool-exec
```

## Restore tools

```bash
dotnet tool restore
```

## Restore project

```bash
dotnet restore
```

## Update project

```bash
dotnet r update
```

## Clean project

```bash
dotnet r clean
```

## Build project

```bash
dotnet r build
```

## Format project

```bash
dotnet r format
```

## Running Lint

```bash
dotnet r lint
```

## Running Unit test

```bash
dotnet r test
```

## Running Coverage Test

```bash
dotnet r test:coverage
```

## Running Mutation Test

```bash
dotnet r test:mutation
```

## Running Azure Function

```bash
dotnet r start
```

## Set version using recursive project modification

```bash
dotnet setversion -r 1.0.0
```
