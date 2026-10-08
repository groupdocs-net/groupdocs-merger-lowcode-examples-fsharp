# Merge PDF Documents from a Stream

The source document can also be a `Stream`; the documents to append are always file paths. The stream is read from the beginning, and it stays open after `Save`.

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
    use stream = File.OpenRead("business-plan.pdf")

    // Append the documents to the source document
    let merger = JoinPdf(stream, [ "cost-analysis.pdf" ], JoinOptions())

    // Save the merged document
    merger.Save("output/business-plan-with-costs.pdf")
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
- `cost-analysis.pdf`

## Learn More

- [Using JoinPdf to Merge PDF Documents](https://docs.groupdocs.net/merger/developer-guide/using-join-pdf/) in the GroupDocs.Merger.LowCode documentation
- [GroupDocs.Merger.LowCode](https://www.nuget.org/packages/GroupDocs.Merger.LowCode) on NuGet
- [Get a temporary license](https://purchase.groupdocs.net/temporary-license/)
