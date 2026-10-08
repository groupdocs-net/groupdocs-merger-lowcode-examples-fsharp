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

    // Select the even slides from 1 to 6
    let splitter = SplitPptx("presentation.pptx", 1, 6, RangeMode.EvenPages)

    // Save one document per part
    splitter.Save("output/even-slide.pptx")
    0
