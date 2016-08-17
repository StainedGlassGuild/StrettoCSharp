# Extract project info from SharedAssemblyInfo.cs
get-content ..\SharedAssemblyInfo.cs |
foreach { 
    if ($_ -match "Company\(`"(?<content>.*)`"\)")     { $company     = $matches['content'] }
    if ($_ -match "Copyright\(`"(?<content>.*)`"\)")   { $copyright   = $matches['content'] }
    if ($_ -match "Description\(`"(?<content>.*)`"\)") { $description = $matches['content'] }
    if ($_ -match "Product\(`"(?<content>.*)`"\)")     { $product     = $matches['content'] }
    if ($_ -match "Version\(`"(?<content>.*)`"\)")     { $version     = $matches['content'] }
}

# Replace tokens in Package.nuspec with extracted values
$tempSpecFile = "temp.nuspec"
(cat Package.nuspec) -replace "%company%"     , "$company"     `
                     -replace "%copyright%"   , "$copyright"   `
                     -replace "%description%" , "$description" `
                     -replace "%product%"     , "$product"     `
                     -replace "%version%"     , "$version"     `
                     > $tempSpecFile

# Download nuget.exe in solution folder if it doesn't already exist
$targetNugetExe = "nuget.exe"
if (!(Test-Path $targetNugetExe))
{
    $sourceNugetExe = "https://dist.nuget.org/win-x86-commandline/latest/nuget.exe"
    Write-Output "Downloading nuget.exe from '$sourceNugetExe'"
    Invoke-WebRequest $sourceNugetExe -OutFile $targetNugetExe
}

# Create NuGet package from generated spec
& .\nuget pack $tempSpecFile

# Remove temporary generated spec
Remove-Item $tempSpecFile

# Publish package to NuGet gallery
$generatedPackage = "$product.$version.nupkg"
& .\nuget push $generatedPackage -Source https://www.nuget.org/api/v2/package

# Remove generated package
Remove-Item $generatedPackage

# Prompt user
Write-Host -NoNewLine 'Press any key to continue...';
$null = $Host.UI.RawUI.ReadKey('NoEcho,IncludeKeyDown');