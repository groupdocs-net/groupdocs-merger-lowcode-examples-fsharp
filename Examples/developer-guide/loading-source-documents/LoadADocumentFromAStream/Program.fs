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

    // Load the source document from the stream
    let splitter = SplitPdf(stream, [| 1; 2 |])

    // Save one document per page
    splitter.Save("output/page.pdf")
    0
