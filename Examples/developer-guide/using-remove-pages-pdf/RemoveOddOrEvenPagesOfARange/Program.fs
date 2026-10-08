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

    // Remove the even pages from 1 to 6
    let remover = RemovePagesPdf("business-plan.pdf", RemoveOptions(1, 6, RangeMode.EvenPages))

    // Save the remaining pages
    remover.Save("output/without-even-pages.pdf")
    0
