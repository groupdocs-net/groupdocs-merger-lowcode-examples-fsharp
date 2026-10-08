open System
open GroupDocs.Merger.LowCode

[<EntryPoint>]
let main _ =
    // Load license keys
    let publicKey = Environment.GetEnvironmentVariable("GD_PUBLIC_KEY")
    let privateKey = Environment.GetEnvironmentVariable("GD_PRIVATE_KEY")

    // Apply the license
    License.Set(publicKey, privateKey)

    // Load the source document from a file path
    let splitter = SplitPdf("business-plan.pdf", [| 1; 2 |])

    // Save one document per page
    splitter.Save("output/page.pdf")
    0
