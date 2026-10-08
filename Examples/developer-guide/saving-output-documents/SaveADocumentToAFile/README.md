# Save a Document to a File

The merge plugins and `RemovePagesPdf` write one document. The following example saves a merged document to a folder that is created automatically.

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

    // Append the second chapter to the first one
    let merger = JoinPdf("chapter-1.pdf", [ "chapter-2.pdf" ], JoinOptions())

    // Save to a folder that doesn't exist yet
    merger.Save("output/merged/chapters-1-2.pdf")
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

- `chapter-1.pdf`
- `chapter-2.pdf`

## Learn More

- [Saving Output Documents](https://docs.groupdocs.net/merger/developer-guide/saving-output-documents/) in the GroupDocs.Merger.LowCode documentation
- [GroupDocs.Merger.LowCode](https://www.nuget.org/packages/GroupDocs.Merger.LowCode) on NuGet
- [Get a temporary license](https://purchase.groupdocs.net/temporary-license/)
