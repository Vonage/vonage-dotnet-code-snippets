using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vonage.Verify;
using Vonage;
using Vonage.Request;

namespace DotnetCliCodeSnippets.Verify
{
    public class SendVerificationRequest : ICodeSnippet

    {
        public async Task Execute()
        {
            var vonageApiKey = Environment.GetEnvironmentVariable("VONAGE_API_KEY") ?? "VONAGE_API_KEY";
            var vonageApiSecret = Environment.GetEnvironmentVariable("VONAGE_API_SECRET") ?? "VONAGE_API_SECRET";
            var recipientNumber = Environment.GetEnvironmentVariable("RECIPIENT_NUMBER") ?? "RECIPIENT_NUMBER";
            var brandName = Environment.GetEnvironmentVariable("BRAND_NAME") ?? "BRAND_NAME";

            var credentials = Credentials.FromApiKeyAndSecret(vonageApiKey, vonageApiSecret);
            var client = new VonageClient(credentials);

            var request = new VerifyRequest() { Brand = brandName, Number = recipientNumber };
            var response = await client.VerifyClient.VerifyRequestAsync(request);

            Console.WriteLine($"Verify Request Complete\nStatus:{response.Status}\nRequest ID:{response.RequestId}");
        }
    }
}
