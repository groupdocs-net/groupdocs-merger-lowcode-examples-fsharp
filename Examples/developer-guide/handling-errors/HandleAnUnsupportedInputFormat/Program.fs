open System
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
        // A DOCX document passed to the PDF plugin
        let splitter = SplitPdf("business-plan.docx", [| 1 |])
        splitter.Save("output/page.pdf")
    with :? FileTypeNotSupportedException as ex ->
        // Input format does not match the expected format 'PDF'; the supplied file is ...
        printfn "%s" ex.Message
    0
