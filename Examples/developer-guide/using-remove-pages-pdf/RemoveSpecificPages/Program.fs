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

    // Remove pages 2 and 4
    let remover = RemovePagesPdf("business-plan.pdf", RemoveOptions([| 2; 4 |]))

    // Save the remaining pages
    remover.Save("output/trimmed.pdf")
    0
