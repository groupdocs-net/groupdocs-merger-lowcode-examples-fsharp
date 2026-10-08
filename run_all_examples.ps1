# PowerShell script to run all GroupDocs.Merger.LowCode code examples

Write-Host "==============================================" -ForegroundColor Cyan
Write-Host "GroupDocs.Merger.LowCode F# Code Examples" -ForegroundColor Cyan
Write-Host "==============================================" -ForegroundColor Cyan
Write-Host ""

# Check for license keys
$licenseWarning = $false
if (-not $env:GD_PUBLIC_KEY) {
    Write-Host "[WARNING] GD_PUBLIC_KEY environment variable is not set" -ForegroundColor Yellow
    $licenseWarning = $true
}
if (-not $env:GD_PRIVATE_KEY) {
    Write-Host "[WARNING] GD_PRIVATE_KEY environment variable is not set" -ForegroundColor Yellow
    $licenseWarning = $true
}

if ($licenseWarning) {
    Write-Host ""
    Write-Host "[INFO] License keys are required for examples to work properly." -ForegroundColor White
    Write-Host "[INFO] Set them using: `$env:GD_PUBLIC_KEY='your-key'; `$env:GD_PRIVATE_KEY='your-key'" -ForegroundColor White
    Write-Host "[INFO] Or edit the Program.fs files directly with your license keys." -ForegroundColor White
    Write-Host ""
    $continue = Read-Host "Do you want to continue anyway? (y/N)"
    if ($continue -ne "y" -and $continue -ne "Y") {
        Write-Host "Aborted." -ForegroundColor Red
        exit 1
    }
    Write-Host ""
}

Write-Host "[INFO] Starting to run all GroupDocs.Merger.LowCode examples..." -ForegroundColor Green
Write-Host "[INFO] This will run 35 examples and skip 2 that need a license put into Program.fs." -ForegroundColor White
Write-Host "[INFO] Each example will be built and run individually." -ForegroundColor White
Write-Host ""

$projectCount = 0
$successCount = 0
$failedCount = 0
$skippedCount = 0

Write-Host "========================================" -ForegroundColor Cyan
Write-Host "Running Examples..." -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan

Get-ChildItem -Path .\Examples -Recurse -Filter "*.fsproj" | ForEach-Object {
    $projectCount++
    $projectDir = $_.Directory.FullName
    $projectName = $_.Directory.Name

    Write-Host ""
    Write-Host "[$projectCount] Running: $projectName" -ForegroundColor Yellow
    Write-Host "   Directory: $projectDir" -ForegroundColor Gray

    # Skip examples that read a license file or keys from the code
    $code = Get-Content -Raw -LiteralPath (Join-Path $projectDir "Program.fs")
    if ($code -and $code.Contains("License.Set") -and -not $code.Contains("GD_PUBLIC_KEY")) {
        Write-Host "   [SKIPPED] Needs your license in Program.fs; add it and run this example with dotnet run" -ForegroundColor DarkYellow
        $skippedCount++
        return
    }

    Push-Location $projectDir

    # Try to build first
    Write-Host "   Building project..." -ForegroundColor Gray
    $buildResult = dotnet build --verbosity quiet 2>&1
    if ($LASTEXITCODE -ne 0) {
        Write-Host "   [ERROR] Build failed for: $projectName" -ForegroundColor Red
        $failedCount++
    } else {
        Write-Host "   Building successful, running example..." -ForegroundColor Gray

        # Capture output and check for unhandled exceptions
        $runResult = dotnet run --verbosity quiet 2>&1
        $runExitCode = $LASTEXITCODE

        # Check if output contains "Unhandled exception"
        if ($runResult -match "Unhandled exception") {
            Write-Host "   [ERROR] Unhandled exception detected in: $projectName" -ForegroundColor Red
            Write-Host "   [ERROR] Output:" -ForegroundColor Red
            $runResult | ForEach-Object { Write-Host "   $_" -ForegroundColor Red }
            $failedCount++
        } elseif ($runExitCode -ne 0) {
            Write-Host "   [ERROR] Failed to run: $projectName" -ForegroundColor Red
            Write-Host "   [ERROR] Output:" -ForegroundColor Red
            $runResult | ForEach-Object { Write-Host "   $_" -ForegroundColor Red }
            $failedCount++
        } else {
            Write-Host "   [SUCCESS] Completed: $projectName" -ForegroundColor Green
            $successCount++
        }
    }

    Pop-Location
}

Write-Host ""
Write-Host "========================================" -ForegroundColor Cyan
Write-Host "Summary" -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan
Write-Host "Total projects found: $projectCount" -ForegroundColor White
Write-Host "Successful runs: $successCount" -ForegroundColor Green
Write-Host "Failed runs: $failedCount" -ForegroundColor $(if ($failedCount -gt 0) { "Red" } else { "Green" })
Write-Host "Skipped: $skippedCount" -ForegroundColor White

if ($failedCount -gt 0) {
    Write-Host ""
    Write-Host "[NOTE] Some examples failed. This might be due to:" -ForegroundColor Yellow
    Write-Host "       - Missing license keys" -ForegroundColor White
    Write-Host "       - Missing sample files" -ForegroundColor White
    Write-Host "       - .NET version compatibility" -ForegroundColor White
    Write-Host "       - File access permissions" -ForegroundColor White
}

Write-Host ""
Write-Host "All examples completed. Check the output above for any errors." -ForegroundColor White
Read-Host "Press Enter to continue"
