# Split Specific Slides into Separate Documents

The following example puts slides 1, 2, and 3 into documents of their own. Each part is numbered after the source slide it holds: `slide_1.pptx`, `slide_2.pptx`, and `slide_3.pptx`.

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

    // Select slides 1, 2, and 3
    let splitter = SplitPptx("presentation.pptx", [| 1; 2; 3 |])

    // Save one document per part
    splitter.Save("output/slide.pptx")
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

- `presentation.pptx`

## Learn More

- [Using SplitPptx to Split PPTX Documents](https://docs.groupdocs.net/merger/developer-guide/using-split-pptx/) in the GroupDocs.Merger.LowCode documentation
- [GroupDocs.Merger.LowCode](https://www.nuget.org/packages/GroupDocs.Merger.LowCode) on NuGet
- [Get a temporary license](https://purchase.groupdocs.net/temporary-license/)
