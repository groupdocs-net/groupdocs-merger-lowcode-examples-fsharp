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

    // Append the cost analysis to the business plan
    let merger = JoinPdf("business-plan.pdf", [ "cost-analysis.pdf" ], JoinOptions())

    // Save the merged document
    merger.Save("output/business-plan-with-costs.pdf")
    0
