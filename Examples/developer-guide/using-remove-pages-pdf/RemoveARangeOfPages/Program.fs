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

    // Remove pages 15 to 18
    let remover = RemovePagesPdf("business-plan.pdf", RemoveOptions(15, 18))

    // Save the remaining pages
    remover.Save("output/without-appendix.pdf")
    0
