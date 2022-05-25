using Vonage;
using Vonage.Request;
using Vonage.Verify;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCliCodeSnippets.Verify
{
    public class SendPsd2 : ICodeSnippet
    {
        public async Task Execute()
        {
            var vonageApiKey = Environment.GetEnvironmentVariable("VONAGE_API_KEY") ?? "VONAGE_API_KEY";
            var vonageApiSecret = Environment.GetEnvironmentVariable("VONAGE_API_SECRET") ?? "VONAGE_API_SECRET";
            var recipientNumber = Environment.GetEnvironmentVariable("RECIPIENT_NUMBER") ?? "RECIPIENT_NUMBER";
            var payeeName = Environment.GetEnvironmentVariable("PAYEE_NAME") ?? "PAYEE_NAME";
            var amount = Double.Parse(Environment.GetEnvironmentVariable("Amount") ?? "5.0");

            var creds = Credentials.FromApiKeyAndSecret(vonageApiKey, vonageApiSecret);
            var client = new VonageClient(creds);

            var request = new Psd2Request { Amount = amount, Payee = payeeName, Number = recipientNumber };
            var response = await client.VerifyClient.VerifyRequestWithPSD2Async(request);
        }
    }
}
