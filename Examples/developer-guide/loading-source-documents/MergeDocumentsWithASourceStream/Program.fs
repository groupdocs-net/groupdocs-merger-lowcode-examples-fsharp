open System
open System.IO
open GroupDocs.Merger.Domain.Options
open GroupDocs.Merger.LowCode

[<EntryPoint>]
let main _ =
    // Load license keys
    let publicKey = Environment.GetEnvironmentVariable("GD_PUBLIC_KEY")
    let privateKey = Environment.GetEnvironmentVariable("GD_PRIVATE_KEY")

    // Apply the license
    License.Set(publicKey, privateKey)

    // Open the source document as a stream
    use stream = File.OpenRead("chapter-1.pdf")

    // The documents to append are file paths
    let merger = JoinPdf(stream, [ "chapter-2.pdf"; "chapter-3.pdf" ], JoinOptions())

    // Save the merged document
    merger.Save("output/merged-chapters.pdf")
    0
