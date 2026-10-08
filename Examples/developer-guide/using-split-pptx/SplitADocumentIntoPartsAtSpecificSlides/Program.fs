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

    // Start a new part at slide 8
    let splitter = SplitPptx("presentation.pptx", [| 8 |], SplitMode.Interval)

    // Save one document per part
    splitter.Save("output/deck.pptx")
    0
