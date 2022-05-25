using Vonage;
using Vonage.Request;
using Vonage.Verify;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCliCodeSnippets.Verify
{
    public class CheckVerificationRequest : ICodeSnippet
    {
        public async Task Execute()
        {
            var vonageApiKey = Environment.GetEnvironmentVariable("VONAGE_API_KEY") ?? "VONAGE_API_KEY";
            var vonageApiSecret = Environment.GetEnvironmentVariable("VONAGE_API_SECRET") ?? "VONAGE_API_SECRET";
            var requestId = Environment.GetEnvironmentVariable("REQUEST_ID") ?? "REQUEST_ID";
            var code = Environment.GetEnvironmentVariable("CODE") ?? "CODE";

            var credentials = Credentials.FromApiKeyAndSecret(vonageApiKey, vonageApiSecret);
            var client = new VonageClient(credentials);

            var request = new VerifyCheckRequest() { Code = code, RequestId = requestId };
            var response = await client.VerifyClient.VerifyCheckAsync(request);

            Console.WriteLine($"Verify Check Complete\nRequest Id:{response.RequestId}\nStatus:{response.Status}");
        }
    }
}
