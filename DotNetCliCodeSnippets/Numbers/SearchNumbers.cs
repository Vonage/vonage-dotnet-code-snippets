using Nexmo.Api.Numbers;
using Nexmo.Api.Request;
using Nexmo.Api.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCliCodeSnippets.Numbers
{
    public class SearchNumbers : ICodeSnippet
    {
        public void Execute()
        {
            var NEXMO_API_KEY = Environment.GetEnvironmentVariable("NEXMO_API_KEY") ?? "NEXMO_API_KEY";
            var NEXMO_API_SECRET = Environment.GetEnvironmentVariable("NEXMO_API_SECRET") ?? "NEXMO_API_SECRET";
            var COUNTRY_CODE = Environment.GetEnvironmentVariable("COUNTRY_CODE") ?? "COUNTRY_CODE";            

            var NEXMO_NUMBER_TYPE = Environment.GetEnvironmentVariable("NEXMO_NUMBER_TYPE") ?? "NEXMO_NUMBER_TYPE";
            var NEXMO_NUMBER_FEATURES = Environment.GetEnvironmentVariable("NEXMO_NUMBER_FEATURES") ?? "NEXMO_NUMBER_FEATURES";
            var NUMBER_SEARCH_CRITERIA = Environment.GetEnvironmentVariable("NUMBER_SEARCH_CRITERIA") ?? "NUMBER_SEARCH_CRITERIA";
            var NUMBER_SEARCH_PATTERN = Environment.GetEnvironmentVariable("NUMBER_SEARCH_PATTERN") != null ? int.Parse(Environment.GetEnvironmentVariable("NUMBER_SEARCH_PATTERN")) : 0;

            var credentials = Credentials.FromApiKeyAndSecret(NEXMO_API_KEY, NEXMO_API_SECRET);
            var client = new NexmoClient(credentials);

            var request = new NumberSearchRequest()
            {
                Country = COUNTRY_CODE,
                Type = NEXMO_NUMBER_TYPE,
                Features = NEXMO_NUMBER_FEATURES,
                Pattern = NUMBER_SEARCH_CRITERIA,
                SearchPattern = NUMBER_SEARCH_PATTERN
            };

            var response = client.NumbersClient.GetAvailableNumbers(request);
            Console.WriteLine($"Response received first number: {response.Numbers[0].Msisdn}");

        }
    }
}
