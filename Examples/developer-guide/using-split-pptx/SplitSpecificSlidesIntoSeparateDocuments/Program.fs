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
