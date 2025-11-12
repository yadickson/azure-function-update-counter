# azure-function-update-counter
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
dotnet execute update
```

## Clean project

```bash
dotnet execute clean
```

## Build project

```bash
dotnet execute build
```

## Format project

```bash
dotnet execute format
```

## Running Lint

```bash
dotnet execute lint
```

## Running Unit test

```bash
dotnet execute test
```

## Running Coverage Test

```bash
dotnet execute test:coverage
```

## Running Mutation Test

```bash
dotnet execute test:mutation
```

## Running Azure Function

```bash
dotnet execute start
```

## Set version using recursive project modification

```bash
dotnet setversion -r 1.0.0
```
