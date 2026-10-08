open System
open GroupDocs.Merger.LowCode

[<EntryPoint>]
let main _ =
    // Load license keys
    let publicKey = Environment.GetEnvironmentVariable("GD_PUBLIC_KEY")
    let privateKey = Environment.GetEnvironmentVariable("GD_PRIVATE_KEY")

    // Apply the license
    License.Set(publicKey, privateKey)

    // Select pages 1 and 2
    let splitter = SplitPdf("business-plan.pdf", [| 1; 2 |])

    // Save one document per part
    splitter.Save("output/business-plan-page-{0}.pdf")
    0
