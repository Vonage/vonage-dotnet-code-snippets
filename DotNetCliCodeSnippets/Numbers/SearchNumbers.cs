using Vonage.Numbers;
using Vonage.Request;
using Vonage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCliCodeSnippets.Numbers
{
    public class SearchNumbers : ICodeSnippet
    {
        public async Task Execute()
        {
            var vonageApiKey = Environment.GetEnvironmentVariable("VONAGE_API_KEY") ?? "VONAGE_API_KEY";
            var vonageApiSecret = Environment.GetEnvironmentVariable("VONAGE_API_SECRET") ?? "VONAGE_API_SECRET";
            var countryCode = Environment.GetEnvironmentVariable("COUNTRY_CODE") ?? "COUNTRY_CODE";            

            var vonageNumberType = Environment.GetEnvironmentVariable("VONAGE_NUMBER_TYPE") ?? "VONAGE_NUMBER_TYPE";
            var vonageNumberFeatures = Environment.GetEnvironmentVariable("VONAGE_NUMBER_FEATURES") ?? "VONAGE_NUMBER_FEATURES";
            var numberSearchCriteria = Environment.GetEnvironmentVariable("NUMBER_SEARCH_CRITERIA") ?? "NUMBER_SEARCH_CRITERIA";
            var numberSearchPattern = (SearchPattern)(Environment.GetEnvironmentVariable("NUMBER_SEARCH_PATTERN") != null ? int.Parse(Environment.GetEnvironmentVariable("NUMBER_SEARCH_PATTERN")) : 0);

            var credentials = Credentials.FromApiKeyAndSecret(vonageApiKey, vonageApiSecret);
            var client = new VonageClient(credentials);

            var request = new NumberSearchRequest()
            {
                Country = countryCode,
                Type = vonageNumberType,
                Features = vonageNumberFeatures,
                Pattern = numberSearchCriteria,
                SearchPattern = numberSearchPattern
            };

            var response = await client.NumbersClient.GetAvailableNumbersAsync(request);
            Console.WriteLine($"Response received first number: {response.Numbers[0].Msisdn}");

        }
    }
}
