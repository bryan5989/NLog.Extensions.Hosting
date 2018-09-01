# NLog.Extensions.Hosting


[![sheepreaper-ci MyGet Build Status](https://www.myget.org/BuildSource/Badge/sheepreaper-ci?identifier=057b14cc-34b7-4654-b9fd-59000aac4ff8)](https://www.myget.org/)
[![NuGet Pre Release](https://img.shields.io/nuget/vpre/NLog.Extensions.Hosting.svg)](https://www.nuget.org/packages/NLog.Extensions.Hosting)
[![Build status Windows](https://ci.appveyor.com/api/projects/status/s6y4650sro3sk5wg/branch/master?svg=true)](https://ci.appveyor.com/project/nlog/nlog-extensions-hosting/branch/master)
[![Build Status Linux](https://travis-ci.org/NLog/NLog.Extensions.Hosting.svg?branch=master)](https://travis-ci.org/NLog/NLog.Extensions.Hosting)

[![BCH compliance](https://bettercodehub.com/edge/badge/NLog/NLog.Extensions.Hosting?branch=master)](https://bettercodehub.com/)
[![](https://sonarcloud.io/api/project_badges/measure?project=nlog.extensions.hosting&metric=ncloc)](https://sonarcloud.io/dashboard/?id=nlog.extensions.hosting) 
[![](https://sonarcloud.io/api/project_badges/measure?project=nlog.extensions.hosting&metric=bugs)](https://sonarcloud.io/dashboard/?id=nlog.extensions.hosting) 
[![](https://sonarcloud.io/api/project_badges/measure?project=nlog.extensions.hosting&metric=vulnerabilities)](https://sonarcloud.io/dashboard/?id=nlog.extensions.hosting) 
[![](https://sonarcloud.io/api/project_badges/measure?project=nlog.extensions.hosting&metric=code_smells)](https://sonarcloud.io/project/issues?id=nlog.extensions.hosting&resolved=false&types=CODE_SMELL) 
[![](https://sonarcloud.io/api/project_badges/measure?project=nlog.extensions.hosting&metric=duplicated_lines_density)](https://sonarcloud.io/component_measures/domain/Duplications?id=nlog.extensions.hosting) 
[![](https://sonarcloud.io/api/project_badges/measure?project=nlog.extensions.hosting&metric=sqale_debt_ratio)](https://sonarcloud.io/dashboard/?id=nlog.extensions.hosting) 
[![](https://sonarcloud.io/api/project_badges/measure?project=nlog.extensions.hosting&metric=coverage)](https://sonarcloud.io/component_measures?id=nlog.extensions.hosting&metric=coverage) 


Facilitates configuring a .NetCore 2.1 Generic Host Builder object with [NLog](https://github.com/NLog/NLog) as the ILogger provider for the container with as little as a single call to .UseNLog() before building.


## Getting started
Pardon our dust: This section is being updated

- [Getting started with ASP.NET Core 2](https://github.com/NLog/NLog.Web/wiki/Getting-started-with-ASP.NET-Core-2)
- [Getting started with .NET Core 2 Console application](https://github.com/NLog/NLog.Extensions.Logging/wiki/Getting-started-with-.NET-Core-2---Console-application)
- [Multiple blogs to get started with ASP.NET Core and NLog](https://github.com/damienbod/AspNetCoreNlog)




Known issues
---
- none


### How to run the example (GenericHost-ExampleConsoleApp-NetCore21)
How to run the [GenericHost-ExampleConsoleApp-NetCore21](https://github.com/bryan5989/NLog.Extensions.Hosting/tree/master/examples/GenericHost-ExampleConsoleApp-NetCore21):

1. Install dotnet: http://dot.net 
2. From source: `dotnet run`
3. or, after publish: `dotnet NLog.Extensions.Hosting.Examples.GenericHostConsoleApp.NetCore21.dll`
