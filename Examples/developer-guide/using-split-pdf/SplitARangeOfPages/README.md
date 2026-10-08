# Split a Range of Pages

Pass the first and the last page of a range to put every page of the range into a document of its own. The following example splits out pages 2 to 4.

## Code Example

```fsharp
open System
open GroupDocs.Merger.LowCode

[<EntryPoint>]
let main _ =
    // Load license keys
    let publicKey = Environment.GetEnvironmentVariable("GD_PUBLIC_KEY")
    let privateKey = Environment.GetEnvironmentVariable("GD_PRIVATE_KEY")

    // Apply the license
    License.Set(publicKey, privateKey)

    // Select pages 2 to 4
    let splitter = SplitPdf("business-plan.pdf", 2, 4)

    // Save one document per part
    splitter.Save("output/page.pdf")
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

- `business-plan.pdf`

## Learn More

- [Using SplitPdf to Split PDF Documents](https://docs.groupdocs.net/merger/developer-guide/using-split-pdf/) in the GroupDocs.Merger.LowCode documentation
- [GroupDocs.Merger.LowCode](https://www.nuget.org/packages/GroupDocs.Merger.LowCode) on NuGet
- [Get a temporary license](https://purchase.groupdocs.net/temporary-license/)
