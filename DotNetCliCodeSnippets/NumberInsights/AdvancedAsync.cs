using Vonage;
using Vonage.Request;
using Vonage.NumberInsights;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCliCodeSnippets.NumberInsights
{
    public class AdvancedAsync : ICodeSnippet
    {
        public void Execute()
        {
            var VONAGE_API_KEY = Environment.GetEnvironmentVariable("VONAGE_API_KEY") ?? "VONAGE_API_KEY";
            var VONAGE_API_SECRET = Environment.GetEnvironmentVariable("VONAGE_API_SECRET") ?? "VONAGE_API_SECRET";
            var INSIGHT_NUMBER = Environment.GetEnvironmentVariable("INSIGHT_NUMBER") ?? "INSIGHT_NUMBER";
            var callbackUrl = "https://demo.ngrok.io/webhooks/insight";

            var creds = Credentials.FromApiKeyAndSecret(VONAGE_API_KEY, VONAGE_API_SECRET);
            var client = new VonageClient(creds);

            var request = new AdvancedNumberInsightAsynchronousRequest() { Number = INSIGHT_NUMBER, Callback = callbackUrl };
            var response = client.NumberInsightClient.GetNumberInsightAsync(request);

            Console.WriteLine($"Advanced insights request status: {response.Status}");
        }
    }
}
