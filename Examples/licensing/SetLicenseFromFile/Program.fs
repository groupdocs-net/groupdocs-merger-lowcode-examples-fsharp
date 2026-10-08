open GroupDocs.Merger.LowCode

[<EntryPoint>]
let main _ =
    // The path to the license file. The path can be relative or absolute.
    let licensePath = "GroupDocs.Merger.LowCode.lic"

    // Apply the license
    License.Set(licensePath)
    0
