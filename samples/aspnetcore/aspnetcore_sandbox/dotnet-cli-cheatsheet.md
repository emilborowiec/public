# My dotnet cli cheat-sheet

## Essentials

Get help

```
dotnet -h
```

Show version

```
dotnet --version
```

Show information about .NET Core, installed runtimes and sdks

```
dotnet --info
dotnet --list-runtimes
dotnet --list-sdks
```

Show list of available templates (all, projects, items, other)

```
dotnet new -l
dotnet new -l --type project
dotnet new -l --type item
dotnet new -l --type other
```

Check for updates to templates and run update

```
dotnet new --update-check
dotnet new --update-apply
```

Install and uninstall new template packs

```
dotnet new -i template-pack-name
dotnet new -u template-pack-name
```

## Managing solutions

Create solution in current directory, named after the directory

```
dotnet new sln
```

Create solution with specified output directory and name

```
dotnet new sln -o outputDir -n solutionName
```


List projects in solution

```
dotnet sln list
```

Add or remove project to/from solution

```
dotnet sln solutionFile add projectPath
dotnet sln solutionFile remove projectPath
```

## Managing projects

Create project for app type: console, library, test, web api, mvc, razor pages, empty web app

```
dotnet new console [-o outputDir] [-n projectName]
dotnet new classlib [-o outputDir] [-n projectName]
dotnet new xunit [-o outputDir] [-n projectName]
dotnet new webapi [-o outputDir] [-n projectName]
dotnet new mvc [-o outputDir] [-n projectName]
dotnet new webapp [-o outputDir] [-n projectName]
dotnet new web [-o outputDir] [-n projectName]
```

Add or remove NuGet package or local project reference to project

```
dotnet add package packageName
dotnet remove package packageName
dotnet add reference projectPath
dotnet remove reference projectPath
```

## Building

Build project or solution, specifying target framework and configuration

```
dotnet build solutionFile|projectFile -c Release -f netcoreapp3.1
```

Publish project or solution as runtime-dependent (not self-contained) package

```
dotnet publish solutionFile|projectFile -c Release -f netcoreapp3.1
```

