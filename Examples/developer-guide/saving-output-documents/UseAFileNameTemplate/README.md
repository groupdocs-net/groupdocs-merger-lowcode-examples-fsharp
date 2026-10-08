# Use a File Name Template

The following example splits out pages 2 and 4 and saves them with a `{0}` template, so the page numbers replace it: `page-2-of-business-plan.pdf` and `page-4-of-business-plan.pdf`.

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

    // Select pages 2 and 4
    let splitter = SplitPdf("business-plan.pdf", [| 2; 4 |])

    // Save page-2-of-business-plan.pdf and page-4-of-business-plan.pdf
    splitter.Save("output/page-{0}-of-business-plan.pdf")
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

- [Saving Output Documents](https://docs.groupdocs.net/merger/developer-guide/saving-output-documents/) in the GroupDocs.Merger.LowCode documentation
- [GroupDocs.Merger.LowCode](https://www.nuget.org/packages/GroupDocs.Merger.LowCode) on NuGet
- [Get a temporary license](https://purchase.groupdocs.net/temporary-license/)
