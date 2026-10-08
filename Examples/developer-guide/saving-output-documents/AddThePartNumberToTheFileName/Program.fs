open System
open GroupDocs.Merger.LowCode

[<EntryPoint>]
let main _ =
    // Load license keys
    let publicKey = Environment.GetEnvironmentVariable("GD_PUBLIC_KEY")
    let privateKey = Environment.GetEnvironmentVariable("GD_PRIVATE_KEY")

    // Apply the license
    License.Set(publicKey, privateKey)

    // Select pages 2 and 4
    let splitter = SplitPdf("business-plan.pdf", [| 2; 4 |])

    // Save business-plan_2.pdf and business-plan_4.pdf
    splitter.Save("output/business-plan.pdf")
    0
