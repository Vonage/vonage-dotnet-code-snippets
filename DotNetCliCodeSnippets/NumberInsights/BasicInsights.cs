using Vonage;
using Vonage.NumberInsights;
using Vonage.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCliCodeSnippets.NumberInsights
{
    public class BasicInsights : ICodeSnippet
    {
        public void Execute()
        {
            var VONAGE_API_KEY = Environment.GetEnvironmentVariable("VONAGE_API_KEY") ?? "VONAGE_API_KEY";
            var VONAGE_API_SECRET = Environment.GetEnvironmentVariable("VONAGE_API_SECRET") ?? "VONAGE_API_SECRET";
            var INSIGHT_NUMBER = Environment.GetEnvironmentVariable("INSIGHT_NUMBER") ?? "INSIGHT_NUMBER";

            var creds = Credentials.FromApiKeyAndSecret(VONAGE_API_KEY, VONAGE_API_SECRET);
            var client = new VonageClient(creds);

            var request = new BasicNumberInsightRequest() { Number = INSIGHT_NUMBER };
            var response = client.NumberInsightClient.GetNumberInsightBasic(request);

            Console.WriteLine($"Basic insights request complete.\nStatus:{response.Status}\n" +
                $"Country Code:{response.CountryName}\nNational Formatted Number:{response.NationalFormatNumber}");
        }
    }
}
