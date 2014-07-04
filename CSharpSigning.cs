//you need BouncyCastle library
//visit http://www.bouncycastle.org/csharp/ for more information about it
//you also can find it in Extension Manager of you Development Enviroment (NuGet in MSVC)

public static string GetSignature(string message, string privateKey)
{
   // Convert from Base64 format to bytes
   byte[] bPrivateKey = Convert.FromBase64String(privateKey);

   var encoder = new ASCIIEncoding();
   byte[] bMessage = encoder.GetBytes(message);
   // Generating private key parameters
   string curveName = "secp256k1";
   Org.BouncyCastle.Asn1.X9.X9ECParameters ecP = Org.BouncyCastle.Asn1.Sec.SecNamedCurves.GetByName(curveName);
   ECDomainParameters ecSpec = new ECDomainParameters(ecP.Curve, ecP.G, ecP.N, ecP.H, ecP.GetSeed());
   ISigner signer = SignerUtilities.GetSigner("SHA-1withECDSA");
   BigInteger biPrivateKey = new BigInteger(bPrivateKey);
   ECPrivateKeyParameters keyParameters = new ECPrivateKeyParameters(biPrivateKey, ecSpec);
   // Signing
   signer.Init(true, keyParameters);
   signer.BlockUpdate(bMessage, 0, bMessage.Length);
   byte[] bSignature = signer.GenerateSignature();
   return Convert.ToBase64String(bSignature);
}
