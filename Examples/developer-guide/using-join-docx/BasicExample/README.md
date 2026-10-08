# Basic Example

The following example appends the second chapter of a business plan to the first one. The documents are loaded from the current folder, and the merged document is saved to the `output` folder.

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

    // Append the documents to the source document
    let merger = JoinDocx("chapter-1.docx", [ "chapter-2.docx" ], JoinOptions())

    // Save the merged document
    merger.Save("output/chapters-1-2.docx")
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

- `chapter-1.docx`
- `chapter-2.docx`

## Learn More

- [Using JoinDocx to Merge DOCX Documents](https://docs.groupdocs.net/merger/developer-guide/using-join-docx/) in the GroupDocs.Merger.LowCode documentation
- [GroupDocs.Merger.LowCode](https://www.nuget.org/packages/GroupDocs.Merger.LowCode) on NuGet
- [Get a temporary license](https://purchase.groupdocs.net/temporary-license/)
