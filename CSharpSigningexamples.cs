//programm starts with two arguments
//API-key in argv[1] 
//Private-key in argv[2]

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Signing_test
{
    class Program
    {

        static void Main(string[] args)
        {

            string API_key = args[1];
            string private_key = args[2];

            //example for getbalance method
            string method = "getbalance";
            string data = null; // 

            string res =IndacoinAsyncGetFromApi("https://indacoin.com/api/",
                API_key,
                private_key,
                data,
                method);


            //example for buyorder method
            method = "buyorder";
            data = "{pair:'BTC_USD',price:'597.0100',amount:'0.02428171'}";
            res =IndacoinAsyncGetFromApi("https://indacoin.com/api/",
                API_key,
                private_key,
                data,
                method);
        }

        public static string IndacoinAsyncGetFromApi(string site, string API = null, string sign = null, string data = null, string method = "", Func<string, string, string> tokenCreateFunc = null)
        {
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(site+method);
            if (API != null && sign != null)
            {
                string nonce =  ((int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds).ToString();
                req.Headers.Add("API-Key", API);

                string tokenSign;
                tokenSign = GetSignature(method+nonce + API, sign);

                req.Headers.Add("API-Sign", tokenSign);
                req.Headers.Add("API-Nonce", nonce);
            }
            if (data != null)
            {
                byte[] bdata = Encoding.ASCII.GetBytes(data);
                req.ContentType = "application/json; charset=utf-8";
                req.ContentLength = data.Length;
                req.Method = "POST";
                using (System.IO.Stream stream = req.GetRequestStream())
                {
                    stream.Write(bdata, 0, bdata.Length);
                }
            }
            System.Net.ServicePointManager.ServerCertificateValidationCallback = (senderX, certificate, chain, sslPolicyErrors) => { return true; };
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            using (System.IO.StreamReader stream = new System.IO.StreamReader(
            resp.GetResponseStream(), Encoding.UTF8))
            {
                return stream.ReadToEnd();
            }
        }

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
    }
}
