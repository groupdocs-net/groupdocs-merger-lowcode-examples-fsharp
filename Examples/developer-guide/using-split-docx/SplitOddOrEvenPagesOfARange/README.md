# Split Odd or Even Pages of a Range

Add a `RangeMode` to narrow the range to its odd or even pages. The following example splits out the even pages from 1 to 6: pages 2, 4, and 6.

## Code Example

```fsharp
open System
open GroupDocs.Merger.Domain.Options
open GroupDocs.Merger.LowCode

[<EntryPoint>]
let main _ =
    // Load license keys
    let publicKey = Environment.GetEnvironmentVariable("GD_PUBLIC_KEY")
    let privateKey = Environment.GetEnvironmentVariable("GD_PRIVATE_KEY")

    // Apply the license
    License.Set(publicKey, privateKey)

    // Select the even pages from 1 to 6
    let splitter = SplitDocx("business-plan.docx", 1, 6, RangeMode.EvenPages)

    // Save one document per part
    splitter.Save("output/even-page.docx")
    0
```

## How to Run

1. Install the .NET SDK for `net10.0`.
2. Set the `GD_PUBLIC_KEY` and `GD_PRIVATE_KEY` environment variables to your license keys.
3. Open this directory and run the example:
   ```bash
   dotnet run
   ```

## Input Files

- `business-plan.docx`

## Learn More

- [Using SplitDocx to Split DOCX Documents](https://docs.groupdocs.net/merger/developer-guide/using-split-docx/) in the GroupDocs.Merger.LowCode documentation
- [GroupDocs.Merger.LowCode](https://www.nuget.org/packages/GroupDocs.Merger.LowCode) on NuGet
- [Get a temporary license](https://purchase.groupdocs.net/temporary-license/)
