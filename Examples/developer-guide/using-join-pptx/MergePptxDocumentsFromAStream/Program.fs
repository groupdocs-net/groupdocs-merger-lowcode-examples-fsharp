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
    use stream = File.OpenRead("deck-1.pptx")

    // Append the documents to the source document
    let merger = JoinPptx(stream, [ "deck-2.pptx" ], JoinOptions())

    // Save the merged document
    merger.Save("output/merged-deck.pptx")
    0
