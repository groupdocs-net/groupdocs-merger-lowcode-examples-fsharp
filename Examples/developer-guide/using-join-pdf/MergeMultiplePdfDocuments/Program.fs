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

    // Append the documents to the source document
    let merger = JoinPdf("chapter-1.pdf", [ "chapter-2.pdf"; "chapter-3.pdf" ], JoinOptions())

    // Save the merged document
    merger.Save("output/merged-chapters.pdf")
    0
