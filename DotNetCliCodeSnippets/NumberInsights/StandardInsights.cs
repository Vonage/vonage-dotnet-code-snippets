using Nexmo.Api.Client;
using Nexmo.Api.NumberInsights;
using Nexmo.Api.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCliCodeSnippets.NumberInsights
{
    public class StandardInsights : ICodeSnippet
    {
        public void Execute()
        {
            var NEXMO_API_KEY = Environment.GetEnvironmentVariable("NEXMO_API_KEY") ?? "NEXMO_API_KEY";
            var NEXMO_API_SECRET = Environment.GetEnvironmentVariable("NEXMO_API_SECRET") ?? "NEXMO_API_SECRET";
            var INSIGHT_NUMBER = Environment.GetEnvironmentVariable("INSIGHT_NUMBER") ?? "INSIGHT_NUMBER";

            var creds = Credentials.FromApiKeyAndSecret(NEXMO_API_KEY, NEXMO_API_SECRET);
            var client = new NexmoClient(creds);

            var request = new StandardNumberInsightRequest() { Number = INSIGHT_NUMBER};
            var response = client.NumberInsightClient.GetNumberInsightStandard(request);

            Console.WriteLine($"Standard insights request complete\nStatus: {response.Status}.\n" +
                $"Carrier: {response.CurrentCarrier?.Name}\nNumber ported status: {response.Ported} ");
        }
    }
}
