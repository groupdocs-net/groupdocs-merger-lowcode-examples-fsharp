open System
open GroupDocs.Merger.LowCode

[<EntryPoint>]
let main _ =
    // Load license keys
    let publicKey = Environment.GetEnvironmentVariable("GD_PUBLIC_KEY")
    let privateKey = Environment.GetEnvironmentVariable("GD_PRIVATE_KEY")

    // Apply the license
    License.Set(publicKey, privateKey)

    // Select pages 2 to 4
    let splitter = SplitDocx("business-plan.docx", 2, 4)

    // Save one document per part
    splitter.Save("output/page.docx")
    0
