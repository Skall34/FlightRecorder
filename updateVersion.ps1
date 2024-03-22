function Update-vdproj-version([string] $ver, [string] $filename) {
    $productCodePattern     = '\"ProductCode\" = \"8\:{([\d\w-]+)}\"'
    $packageCodePattern     = '\"PackageCode\" = \"8\:{([\d\w-]+)}\"'
    $productVersionPattern  = '\"ProductVersion\" = \"8\:[0-9]+(\.([0-9]+)){1,3}\"'
    $productCode            = '"ProductCode" = "8:{' + [guid]::NewGuid().ToString().ToUpper() + '}"'
    $packageCode            = '"PackageCode" = "8:{' + [guid]::NewGuid().ToString().ToUpper() + '}"'
    $productVersion         = '"ProductVersion" = "8:' + $ver + '"'

    (Get-Content $filename) | ForEach-Object {
        % {$_ -replace $productCodePattern, $productCode } |
        % {$_ -replace $packageCodePattern, $packageCode } |
        % {$_ -replace $productVersionPattern, $productVersion }
    } | Set-Content $filename
}
echo $args[0]
echo $args[1]

Update-vdproj-version $args[0] "Installer.vdproj"

