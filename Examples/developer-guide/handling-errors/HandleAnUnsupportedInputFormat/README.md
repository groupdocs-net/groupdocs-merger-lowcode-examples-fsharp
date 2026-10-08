# Handle an Unsupported Input Format

The following example passes a DOCX document to the `SplitPdf` plugin and prints the message of the exception.

## Code Example

```fsharp
open System
open GroupDocs.Merger.Exceptions
open GroupDocs.Merger.LowCode

[<EntryPoint>]
let main _ =
    // Load license keys
    let publicKey = Environment.GetEnvironmentVariable("GD_PUBLIC_KEY")
    let privateKey = Environment.GetEnvironmentVariable("GD_PRIVATE_KEY")

    // Apply the license
    License.Set(publicKey, privateKey)

    try
        // A DOCX document passed to the PDF plugin
        let splitter = SplitPdf("business-plan.docx", [| 1 |])
        splitter.Save("output/page.pdf")
    with :? FileTypeNotSupportedException as ex ->
        // Input format does not match the expected format 'PDF'; the supplied file is ...
        printfn "%s" ex.Message
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

- [Handling Errors](https://docs.groupdocs.net/merger/developer-guide/handling-errors/) in the GroupDocs.Merger.LowCode documentation
- [GroupDocs.Merger.LowCode](https://www.nuget.org/packages/GroupDocs.Merger.LowCode) on NuGet
- [Get a temporary license](https://purchase.groupdocs.net/temporary-license/)
