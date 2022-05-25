using Vonage;
using Vonage.NumberInsights;
using Vonage.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCliCodeSnippets.NumberInsights
{
    public class BasicInsights : ICodeSnippet
    {
        public async Task Execute()
        {
            var vonageApiKey = Environment.GetEnvironmentVariable("VONAGE_API_KEY") ?? "VONAGE_API_KEY";
            var vonageApiSecret = Environment.GetEnvironmentVariable("VONAGE_API_SECRET") ?? "VONAGE_API_SECRET";
            var insightNumber = Environment.GetEnvironmentVariable("INSIGHT_NUMBER") ?? "INSIGHT_NUMBER";

            var creds = Credentials.FromApiKeyAndSecret(vonageApiKey, vonageApiSecret);
            var client = new VonageClient(creds);

            var request = new BasicNumberInsightRequest() { Number = insightNumber };
            var response = await client.NumberInsightClient.GetNumberInsightBasicAsync(request);

            Console.WriteLine($"Basic insights request complete.\nStatus:{response.Status}\n" +
                $"Country Code:{response.CountryName}\nNational Formatted Number:{response.NationalFormatNumber}");
        }
    }
}
