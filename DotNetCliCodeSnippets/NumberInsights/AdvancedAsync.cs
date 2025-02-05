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
            var VONAGE_API_KEY = Environment.GetEnvironmentVariable("VONAGE_API_KEY") ?? "VONAGE_API_KEY";
            var VONAGE_API_SECRET = Environment.GetEnvironmentVariable("VONAGE_API_SECRET") ?? "VONAGE_API_SECRET";
            var INSIGHT_NUMBER = Environment.GetEnvironmentVariable("INSIGHT_NUMBER") ?? "INSIGHT_NUMBER";
            var INSIGHT_CALLBACK_URL = Environment.GetEnvironmentVariable("INSIGHT_CALLBACK_URL") ?? "INSIGHT_CALLBACK_URL";

            var creds = Credentials.FromApiKeyAndSecret(VONAGE_API_KEY, VONAGE_API_SECRET);
            var client = new VonageClient(creds);

            var request = new AdvancedNumberInsightAsynchronousRequest() { Number = INSIGHT_NUMBER, Callback = INSIGHT_CALLBACK_URL };
            var response = await client.NumberInsightClient.GetNumberInsightAsynchronousAsync(request);

            Console.WriteLine($"Advanced insights request status: {response.Status}");
        }
    }
}
