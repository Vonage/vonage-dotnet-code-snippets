using Vonage;
using Vonage.Request;
using Vonage.Verify;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCliCodeSnippets.Verify
{
    public class SendPsd2 : ICodeSnippet
    {
        public void Execute()
        {
            var VONAGE_API_KEY = Environment.GetEnvironmentVariable("VONAGE_API_KEY") ?? "VONAGE_API_KEY";
            var VONAGE_API_SECRET = Environment.GetEnvironmentVariable("VONAGE_API_SECRET") ?? "VONAGE_API_SECRET";
            var RECIPIENT_NUMBER = Environment.GetEnvironmentVariable("RECIPIENT_NUMBER") ?? "RECIPIENT_NUMBER";
            var PAYEE_NAME = Environment.GetEnvironmentVariable("PAYEE_NAME") ?? "PAYEE_NAME";
            var AMOUNT = Double.Parse(Environment.GetEnvironmentVariable("Amount") ?? "5.0");

            var creds = Credentials.FromApiKeyAndSecret(VONAGE_API_KEY, VONAGE_API_SECRET);
            var client = new VonageClient(creds);

            var request = new Psd2Request { Amount = AMOUNT, Payee = PAYEE_NAME, Number = RECIPIENT_NUMBER };
            var response = client.VerifyClient.VerifyRequestWithPSD2(request);
        }
    }
}
