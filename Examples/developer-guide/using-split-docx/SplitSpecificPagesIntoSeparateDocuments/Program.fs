open System
open GroupDocs.Merger.LowCode

[<EntryPoint>]
let main _ =
    // Load license keys
    let publicKey = Environment.GetEnvironmentVariable("GD_PUBLIC_KEY")
    let privateKey = Environment.GetEnvironmentVariable("GD_PRIVATE_KEY")

    // Apply the license
    License.Set(publicKey, privateKey)

    // Select pages 1, 2, and 3
    let splitter = SplitDocx("business-plan.docx", [| 1; 2; 3 |])

    // Save one document per part
    splitter.Save("output/page.docx")
    0
