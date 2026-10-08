#!/bin/bash

echo "=============================================="
echo "GroupDocs.Merger.LowCode F# Code Examples"
echo "=============================================="
echo

# Check for license keys
license_warning=false
if [ -z "$GD_PUBLIC_KEY" ]; then
    echo "[WARNING] GD_PUBLIC_KEY environment variable is not set"
    license_warning=true
fi
if [ -z "$GD_PRIVATE_KEY" ]; then
    echo "[WARNING] GD_PRIVATE_KEY environment variable is not set"
    license_warning=true
fi

if [ "$license_warning" = true ]; then
    echo
    echo "[INFO] License keys are required for examples to work properly."
    echo "[INFO] Set them using: export GD_PUBLIC_KEY=your-key && export GD_PRIVATE_KEY=your-key"
    echo "[INFO] Or edit the Program.fs files directly with your license keys."
    echo
    read -p "Do you want to continue anyway? (y/N): " continue
    if [[ ! "$continue" =~ ^[Yy]$ ]]; then
        echo "Aborted."
        exit 1
    fi
    echo
fi

echo "[INFO] Starting to run all GroupDocs.Merger.LowCode examples..."
echo "[INFO] This will run 35 examples and skip 2 that need a license put into Program.fs."
echo "[INFO] Each example will be built and run individually."
echo

project_count=0
success_count=0
failed_count=0
skipped_count=0

echo "========================================"
echo "Running Examples..."
echo "========================================"

while IFS= read -r -d '' file; do
    ((project_count++))
    dir=$(dirname "$file")
    project_name=$(basename "$dir")

    echo
    echo "[$project_count] Running: $project_name"
    echo "   Directory: $dir"

    # Skip examples that read a license file or keys from the code
    if grep -qF "License.Set" "$dir/Program.fs" && ! grep -qF "GD_PUBLIC_KEY" "$dir/Program.fs"; then
        echo "   [SKIPPED] Needs your license in Program.fs; add it and run this example with dotnet run"
        ((skipped_count++))
        continue
    fi

    # Change to project directory
    cd "$dir" || {
        echo "   [ERROR] Could not change to directory: $dir"
        ((failed_count++))
        continue
    }

    # Try to build first
    echo "   Building project..."
    if dotnet build --verbosity quiet >/dev/null 2>&1; then
        echo "   Building successful, running example..."

        # Capture output and check for unhandled exceptions
        run_output=$(dotnet run --verbosity quiet 2>&1)
        run_exit_code=$?

        # Check if output contains "Unhandled exception"
        if echo "$run_output" | grep -qi "Unhandled exception"; then
            echo "   [ERROR] Unhandled exception detected in: $project_name"
            echo "   [ERROR] Output:"
            echo "$run_output" | sed 's/^/   /'
            ((failed_count++))
        elif [ $run_exit_code -ne 0 ]; then
            echo "   [ERROR] Failed to run: $project_name"
            echo "   [ERROR] Output:"
            echo "$run_output" | sed 's/^/   /'
            ((failed_count++))
        else
            echo "   [SUCCESS] Completed: $project_name"
            ((success_count++))
        fi
    else
        echo "   [ERROR] Build failed for: $project_name"
        ((failed_count++))
    fi

    # Return to original directory
    cd - >/dev/null 2>&1
done < <(find ./Examples -name "*.fsproj" -print0)

echo
echo "========================================"
echo "Summary"
echo "========================================"
echo "Total projects found: $project_count"
echo "Successful runs: $success_count"
echo "Failed runs: $failed_count"
echo "Skipped: $skipped_count"

if [ $failed_count -gt 0 ]; then
    echo
    echo "[NOTE] Some examples failed. This might be due to:"
    echo "       - Missing license keys"
    echo "       - Missing sample files"
    echo "       - .NET version compatibility"
    echo "       - File access permissions"
fi

echo
echo "All examples completed. Check the output above for any errors."
