open System
open GroupDocs.Merger.Domain.Options
open GroupDocs.Merger.Exceptions
open GroupDocs.Merger.LowCode

[<EntryPoint>]
let main _ =
    // Load license keys
    let publicKey = Environment.GetEnvironmentVariable("GD_PUBLIC_KEY")
    let privateKey = Environment.GetEnvironmentVariable("GD_PRIVATE_KEY")

    // Apply the license
    License.Set(publicKey, privateKey)

    try
        // The document has 18 pages
        let remover = RemovePagesPdf("business-plan.pdf", RemoveOptions([| 50 |]))
        remover.Save("output/trimmed.pdf")
    with :? GroupDocsMergerException as ex ->
        // Page number more than page count.
        printfn "%s" ex.Message
    0
