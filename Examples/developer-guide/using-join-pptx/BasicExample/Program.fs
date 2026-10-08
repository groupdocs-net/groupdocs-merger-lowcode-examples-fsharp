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
    let merger = JoinPptx("deck-1.pptx", [ "deck-2.pptx" ], JoinOptions())

    // Save the merged document
    merger.Save("output/merged-deck.pptx")
    0
