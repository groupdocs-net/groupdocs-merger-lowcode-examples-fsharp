# Merge Documents with a Source Stream

The merge plugins (`JoinPdf`, `JoinDocx`, and `JoinPptx`) accept the source document as a path or a stream, but the documents to append are always file paths.

## Code Example

```fsharp
open System
open System.IO
open GroupDocs.Merger.Domain.Options
open GroupDocs.Merger.LowCode

[<EntryPoint>]
let main _ =
    // Load license keys
    let publicKey = Environment.GetEnvironmentVariable("GD_PUBLIC_KEY")
    let privateKey = Environment.GetEnvironmentVariable("GD_PRIVATE_KEY")

    // Apply the license
    License.Set(publicKey, privateKey)

    // Open the source document as a stream
    use stream = File.OpenRead("chapter-1.pdf")

    // The documents to append are file paths
    let merger = JoinPdf(stream, [ "chapter-2.pdf"; "chapter-3.pdf" ], JoinOptions())

    // Save the merged document
    merger.Save("output/merged-chapters.pdf")
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
- `chapter-3.pdf`

## Learn More

- [Loading Source Documents](https://docs.groupdocs.net/merger/developer-guide/loading-source-documents/) in the GroupDocs.Merger.LowCode documentation
- [GroupDocs.Merger.LowCode](https://www.nuget.org/packages/GroupDocs.Merger.LowCode) on NuGet
- [Get a temporary license](https://purchase.groupdocs.net/temporary-license/)
