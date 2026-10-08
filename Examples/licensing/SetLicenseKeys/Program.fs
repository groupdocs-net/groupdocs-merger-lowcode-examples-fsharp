open GroupDocs.Merger.LowCode

[<EntryPoint>]
let main _ =
    // The public and private keys from your license
    let publicKey = "..."
    let privateKey = "..."

    // Set license keys
    License.Set(publicKey, privateKey)
    0
