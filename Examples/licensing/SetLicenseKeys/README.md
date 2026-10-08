# Set License Keys

You can set the public and private keys of a metered license directly. The following sample demonstrates how to set license keys.

## Code Example

```fsharp
open GroupDocs.Merger.LowCode

[<EntryPoint>]
let main _ =
    // The public and private keys from your license
    let publicKey = "..."
    let privateKey = "..."

    // Set license keys
    License.Set(publicKey, privateKey)
    0
```

## How to Run

1. Install the .NET SDK for `net10.0`.
2. Edit `Program.fs` so that it uses your license: the path to your license file, or your public and private keys.
3. Open this directory and run the example:
   ```bash
   dotnet run
   ```

## Learn More

- [Licensing](https://docs.groupdocs.net/merger/licensing/) in the GroupDocs.Merger.LowCode documentation
- [GroupDocs.Merger.LowCode](https://www.nuget.org/packages/GroupDocs.Merger.LowCode) on NuGet
- [Get a temporary license](https://purchase.groupdocs.net/temporary-license/)
