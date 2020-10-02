## Copyright (c) Microsoft Corporation.
## Licensed under the MIT License.

[CmdletBinding()]
param (
    [Parameter()]
    [string]
    $Configuration = "Debug",

    [Parameter()]
    [switch]
    $Clean
)

try {
    Push-Location "$PSScriptRoot/src"

    $outPath = "$PSScriptRoot/out"

    if ($Clean) {
        if (Test-Path $outPath) {
            Write-Verbose "Deleting $outPath"
            Remove-Item -recurse -force -path $outPath
        }

        dotnet clean
    }

    dotnet build --output "$PSScriptRoot/out" --configuration $Configuration

}
finally {
    Pop-Location
}
