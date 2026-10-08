@echo off
setlocal enabledelayedexpansion

echo ===============================================
echo GroupDocs.Merger.LowCode F# Code Examples
echo ===============================================
echo.

REM Check for license keys
set "license_warning="
if "%GD_PUBLIC_KEY%"=="" (
    set "license_warning=1"
    echo [WARNING] GD_PUBLIC_KEY environment variable is not set
)
if "%GD_PRIVATE_KEY%"=="" (
    set "license_warning=1"
    echo [WARNING] GD_PRIVATE_KEY environment variable is not set
)

if defined license_warning (
    echo.
    echo [INFO] License keys are required for examples to work properly.
    echo [INFO] Set them using: set GD_PUBLIC_KEY=your-key ^& set GD_PRIVATE_KEY=your-key
    echo [INFO] Or edit the Program.fs files directly with your license keys.
    echo.
    set /p "continue=Do you want to continue anyway? (y/N): "
    if /i not "!continue!"=="y" (
        echo Aborted.
        pause
        exit /b 1
    )
    echo.
)

echo [INFO] Starting to run all GroupDocs.Merger.LowCode examples...
echo [INFO] This will run 35 examples and skip 2 that need a license put into Program.fs.
echo [INFO] Each example will be built and run individually.
echo.

set "project_count=0"
set "success_count=0"
set "failed_count=0"
set "skipped_count=0"

echo ========================================
echo Running Examples...
echo ========================================

for /r Examples %%i in (*.fsproj) do (
    set /a "project_count+=1"
    set "project_dir=%%~dpi"
    for %%j in ("%%~dpi\.") do set "project_name=%%~nj"

    echo.
    echo [!project_count!] Running: !project_name!
    echo    Directory: !project_dir!

    REM Skip examples that read a license file or keys from the code
    set "own_license="
    findstr /l /c:"License.Set" "%%~dpiProgram.fs" >nul 2>&1 && (findstr /l /c:"GD_PUBLIC_KEY" "%%~dpiProgram.fs" >nul 2>&1 || set "own_license=1")

    if defined own_license (
        echo    [SKIPPED] Needs your license in Program.fs; add it and run this example with dotnet run
        set /a "skipped_count+=1"
    ) else (
        pushd "!project_dir!"

        REM Try to build first
        echo    Building project...
        dotnet build --verbosity quiet >nul 2>&1
        if errorlevel 1 (
            echo    [ERROR] Build failed for: !project_name!
            set /a "failed_count+=1"
        ) else (
            echo    Building successful, running example...

            REM Capture output and check for unhandled exceptions
            dotnet run --verbosity quiet > temp_output.txt 2>&1
            set "run_exit_code=!errorlevel!"

            REM Check if output contains "Unhandled exception"
            findstr /i "Unhandled exception" temp_output.txt >nul 2>&1
            if !errorlevel! equ 0 (
                echo    [ERROR] Unhandled exception detected in: !project_name!
                echo    [ERROR] Output:
                type temp_output.txt
                set /a "failed_count+=1"
            ) else if !run_exit_code! neq 0 (
                echo    [ERROR] Failed to run: !project_name!
                echo    [ERROR] Output:
                type temp_output.txt
                set /a "failed_count+=1"
            ) else (
                echo    [SUCCESS] Completed: !project_name!
                set /a "success_count+=1"
            )

            REM Clean up temp file
            if exist temp_output.txt del temp_output.txt
        )

        popd
    )
)

echo.
echo ========================================
echo Summary
echo ========================================
echo Total projects found: %project_count%
echo Successful runs: %success_count%
echo Failed runs: %failed_count%
echo Skipped: %skipped_count%

if %failed_count% gtr 0 (
    echo.
    echo [NOTE] Some examples failed. This might be due to:
    echo        - Missing license keys
    echo        - Missing sample files
    echo        - .NET version compatibility
    echo        - File access permissions
)

echo.
echo All examples completed. Check the output above for any errors.
pause
