# restore and builds all projects as release.
# creates NuGet package at \artifacts
dotnet --version

$versionPrefix = "1.0.0"
$versionSuffix = "rc1"
$versionFile = $versionPrefix + "." + ${env:APPVEYOR_BUILD_NUMBER}
$versionProduct = $versionPrefix;
if (-Not $versionSuffix.Equals(""))
	{ $versionProduct = $versionProduct + "-" + $versionSuffix }

msbuild /t:Restore,Pack .\src\NLog.Extensions.Hosting\ /p:targetFrameworks='"netstandard2.1"' /p:VersionPrefix=$versionPrefix /p:VersionSuffix=$versionSuffix /p:FileVersion=$versionFile /p:ProductVersion=$versionProduct /p:Configuration=Release /p:IncludeSymbols=true /p:PackageOutputPath=..\..\artifacts /verbosity:minimal
if (-Not $LastExitCode -eq 0)
	{ exit $LastExitCode }

exit $LastExitCode
