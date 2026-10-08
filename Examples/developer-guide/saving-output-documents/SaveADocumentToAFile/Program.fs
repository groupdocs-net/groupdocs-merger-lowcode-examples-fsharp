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

    // Append the second chapter to the first one
    let merger = JoinPdf("chapter-1.pdf", [ "chapter-2.pdf" ], JoinOptions())

    // Save to a folder that doesn't exist yet
    merger.Save("output/merged/chapters-1-2.pdf")
    0
