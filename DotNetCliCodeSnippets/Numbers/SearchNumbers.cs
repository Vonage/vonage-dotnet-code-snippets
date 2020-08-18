using Vonage.Numbers;
using Vonage.Request;
using Vonage;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCliCodeSnippets.Numbers
{
    public class SearchNumbers : ICodeSnippet
    {
        public void Execute()
        {
            var VONAGE_API_KEY = Environment.GetEnvironmentVariable("VONAGE_API_KEY") ?? "VONAGE_API_KEY";
            var VONAGE_API_SECRET = Environment.GetEnvironmentVariable("VONAGE_API_SECRET") ?? "VONAGE_API_SECRET";
            var COUNTRY_CODE = Environment.GetEnvironmentVariable("COUNTRY_CODE") ?? "COUNTRY_CODE";            

            var VONAGE_NUMBER_TYPE = Environment.GetEnvironmentVariable("VONAGE_NUMBER_TYPE") ?? "VONAGE_NUMBER_TYPE";
            var VONAGE_NUMBER_FEATURES = Environment.GetEnvironmentVariable("VONAGE_NUMBER_FEATURES") ?? "VONAGE_NUMBER_FEATURES";
            var NUMBER_SEARCH_CRITERIA = Environment.GetEnvironmentVariable("NUMBER_SEARCH_CRITERIA") ?? "NUMBER_SEARCH_CRITERIA";
            var NUMBER_SEARCH_PATTERN = (SearchPattern)(Environment.GetEnvironmentVariable("NUMBER_SEARCH_PATTERN") != null ? int.Parse(Environment.GetEnvironmentVariable("NUMBER_SEARCH_PATTERN")) : 0);

            var credentials = Credentials.FromApiKeyAndSecret(VONAGE_API_KEY, VONAGE_API_SECRET);
            var client = new VonageClient(credentials);

            var request = new NumberSearchRequest()
            {
                Country = COUNTRY_CODE,
                Type = VONAGE_NUMBER_TYPE,
                Features = VONAGE_NUMBER_FEATURES,
                Pattern = NUMBER_SEARCH_CRITERIA,
                SearchPattern = NUMBER_SEARCH_PATTERN
            };

            var response = client.NumbersClient.GetAvailableNumbers(request);
            Console.WriteLine($"Response received first number: {response.Numbers[0].Msisdn}");

        }
    }
}
