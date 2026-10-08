open System
open System.IO
open GroupDocs.Merger.LowCode

[<EntryPoint>]
let main _ =
    // Load license keys
    let publicKey = Environment.GetEnvironmentVariable("GD_PUBLIC_KEY")
    let privateKey = Environment.GetEnvironmentVariable("GD_PRIVATE_KEY")

    // Apply the license
    License.Set(publicKey, privateKey)

    // Open the source document as a stream
    use stream = File.OpenRead("business-plan.pdf")

    // Select pages 1 and 2
    let splitter = SplitPdf(stream, [| 1; 2 |])

    // Save one document per part
    splitter.Save("output/page.pdf")
    0
