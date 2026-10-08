open System
open GroupDocs.Merger.LowCode

[<EntryPoint>]
let main _ =
    // Load license keys
    let publicKey = Environment.GetEnvironmentVariable("GD_PUBLIC_KEY")
    let privateKey = Environment.GetEnvironmentVariable("GD_PRIVATE_KEY")

    // Apply the license
    License.Set(publicKey, privateKey)

    // Select slides 2 to 4
    let splitter = SplitPptx("presentation.pptx", 2, 4)

    // Save one document per part
    splitter.Save("output/slide.pptx")
    0
