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
    let merger = JoinDocx("chapter-1.docx", [ "chapter-2.docx"; "chapter-3.docx" ], JoinOptions())

    // Save the merged document
    merger.Save("output/merged-chapters.docx")
    0
