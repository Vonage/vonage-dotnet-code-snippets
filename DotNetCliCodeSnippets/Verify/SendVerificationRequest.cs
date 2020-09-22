using System;
using System.Collections.Generic;
using System.Text;
using Vonage.Verify;
using Vonage;
using Vonage.Request;

namespace DotnetCliCodeSnippets.Verify
{
    public class SendVerificationRequest : ICodeSnippet

    {
        public void Execute()
        {
            var VONAGE_API_KEY = Environment.GetEnvironmentVariable("VONAGE_API_KEY") ?? "VONAGE_API_KEY";
            var VONAGE_API_SECRET = Environment.GetEnvironmentVariable("VONAGE_API_SECRET") ?? "VONAGE_API_SECRET";
            var RECIPIENT_NUMBER = Environment.GetEnvironmentVariable("RECIPIENT_NUMBER") ?? "RECIPIENT_NUMBER";
            var BRAND_NAME = Environment.GetEnvironmentVariable("BRAND_NAME") ?? "BRAND_NAME";

            var credentials = Credentials.FromApiKeyAndSecret(VONAGE_API_KEY, VONAGE_API_SECRET);
            var client = new VonageClient(credentials);

            var request = new VerifyRequest() { Brand = BRAND_NAME, Number = RECIPIENT_NUMBER };
            var response = client.VerifyClient.VerifyRequest(request);

            Console.WriteLine($"Verify Request Complete\nStatus:{response.Status}\nRequest ID:{response.RequestId}");
        }
    }
}
