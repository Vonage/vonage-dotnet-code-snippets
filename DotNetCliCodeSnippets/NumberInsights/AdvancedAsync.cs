using Vonage;
using Vonage.Request;
using Vonage.NumberInsights;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCliCodeSnippets.NumberInsights
{
    public class AdvancedAsync : ICodeSnippet
    {
        public async Task Execute()
        {
            var vonageApiKey = Environment.GetEnvironmentVariable("VONAGE_API_KEY") ?? "VONAGE_API_KEY";
            var vonageApiSecret = Environment.GetEnvironmentVariable("VONAGE_API_SECRET") ?? "VONAGE_API_SECRET";
            var insightNumber = Environment.GetEnvironmentVariable("INSIGHT_NUMBER") ?? "INSIGHT_NUMBER";
            var callbackUrl = "https://demo.ngrok.io/webhooks/insight";

            var creds = Credentials.FromApiKeyAndSecret(vonageApiKey, vonageApiSecret);
            var client = new VonageClient(creds);

            var request = new AdvancedNumberInsightAsynchronousRequest() { Number = insightNumber, Callback = callbackUrl };
            var response = await client.NumberInsightClient.GetNumberInsightAsync(request);

            Console.WriteLine($"Advanced insights request status: {response.Status}");
        }
    }
}
