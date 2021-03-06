$projectFile = "src\NLog.Extensions.Hosting\NLog.Extensions.Hosting.csproj"
$sonarQubeId = "nlog.extensions.hosting"
$github = "nlog/NLog.Extensions.Hosting"
$baseBranch = "master"
$framework = "netstandard2.0"
$sonarOrg = "nlog"


if ($env:APPVEYOR_REPO_NAME -eq $github) {

    if (-not $env:sonar_token) {
        Write-warning "Sonar: not running SonarQube, no sonar_token"
        return;
    }
 
    $prMode = $false;
    $branchMode = $false;
     
    if ($env:APPVEYOR_PULL_REQUEST_NUMBER) { 
        # first check PR as that is on the base branch
        $prMode = $true;
        Write-Output "Sonar: on PR $env:APPVEYOR_PULL_REQUEST_NUMBER"
    }
    elseif ($env:APPVEYOR_REPO_BRANCH -eq $baseBranch) {
        Write-Output "Sonar: on base branch ($baseBranch)"
    }
    else {
        $branchMode = $true;
        Write-Output "Sonar: on branch $env:APPVEYOR_REPO_BRANCH"
    }

    choco install "msbuild-sonarqube-runner" -y

    $sonarUrl = "https://sonarcloud.io"
    $sonarToken = $env:sonar_token
    $buildVersion = $env:APPVEYOR_BUILD_VERSION

    if ($prMode) {
        $pr = $env:APPVEYOR_PULL_REQUEST_NUMBER
        Write-Output "Sonar: Running Sonar for PR $pr"
        dotnet sonarscanner begin /d:sonar.organization="$sonarOrg" /k:"$sonarQubeId" /d:"sonar.host.url=$sonarUrl" /d:"sonar.login=$sonarToken" /v:"$buildVersion" /d:"sonar.cs.opencover.reportsPaths=coverage.xml" /d:"sonar.analysis.mode=preview" /d:"sonar.github.pullRequest=$pr" /d:"sonar.github.repository=$github" /d:"sonar.github.oauth=$env:github_auth_token"
    }
    elseif ($branchMode) {
        $branch = $env:APPVEYOR_REPO_BRANCH;
        Write-Output "Sonar: Running Sonar in branch mode for branch $branch"
        dotnet sonarscanner begin /d:sonar.organization="$sonarOrg" /k:"$sonarQubeId" /d:"sonar.host.url=$sonarUrl" /d:"sonar.login=$sonarToken" /v:"$buildVersion" /d:"sonar.cs.opencover.reportsPaths=coverage.xml" /d:"sonar.branch.name=$branch"  
    }
    else {
        Write-Output "Sonar: Running Sonar in non-preview mode, on branch $env:APPVEYOR_REPO_BRANCH"
        dotnet sonarscanner begin /d:sonar.organization="$sonarOrg" /k:"$sonarQubeId" /d:"sonar.host.url=$sonarUrl" /d:"sonar.login=$sonarToken" /v:"$buildVersion" /d:"sonar.cs.opencover.reportsPaths=coverage.xml"
    }

    dotnet build /t:Rebuild $projectFile /p:targetFrameworks=$framework /verbosity:minimal

    dotnet sonarscanner end /d:"sonar.login=$env:sonar_token"
}
else {
    Write-Output "Sonar: not running as we're on '$env:APPVEYOR_REPO_NAME'"
}