using Vonage;
using Vonage.Request;
using Vonage.Verify;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCliCodeSnippets.Verify
{
    public class TriggerNextVerificationProcess : ICodeSnippet
    {
        public async Task Execute()
        {
            var vonageApiKey = Environment.GetEnvironmentVariable("VONAGE_API_KEY") ?? "VONAGE_API_KEY";
            var vonageApiSecret = Environment.GetEnvironmentVariable("VONAGE_API_SECRET") ?? "VONAGE_API_SECRET";
            var requestId = Environment.GetEnvironmentVariable("REQUEST_ID") ?? "REQUEST_ID";

            var credentials = Credentials.FromApiKeyAndSecret(vonageApiKey, vonageApiSecret);
            var client = new VonageClient(credentials);
            var request = new VerifyControlRequest() { RequestId = requestId, Cmd = "trigger_next_event" };

            var response = await client.VerifyClient.VerifyControlAsync(request);
            Console.WriteLine($"Next Verify Request Triggered\nStatus:{response.Status}");
        }
    }
}
