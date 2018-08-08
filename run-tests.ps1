dotnet restore test/NLog.Extensions.Hosting.Tests/NLog.Extensions.Hosting.Tests.csproj -v minimal
dotnet build test/NLog.Extensions.Hosting.Tests/NLog.Extensions.Hosting.Tests.csproj  --configuration release -v minimal
dotnet test test/NLog.Extensions.Hosting.Tests/NLog.Extensions.Hosting.Tests.csproj  --configuration release

exit $LASTEXITCODE