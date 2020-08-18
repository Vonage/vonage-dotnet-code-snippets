using Vonage;
using Vonage.Numbers;
using Vonage.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCliCodeSnippets.Numbers
{
    public class ListOwnedNumbers : ICodeSnippet
    {
        public void Execute()
        {
            var VONAGE_API_KEY = Environment.GetEnvironmentVariable("VONAGE_API_KEY") ?? "VONAGE_API_KEY";
            var VONAGE_API_SECRET = Environment.GetEnvironmentVariable("VONAGE_API_SECRET") ?? "VONAGE_API_SECRET";            
                        
            var NUMBER_SEARCH_CRITERIA = Environment.GetEnvironmentVariable("NUMBER_SEARCH_CRITERIA") ?? "NUMBER_SEARCH_CRITERIA";
            var NUMBER_SEARCH_PATTERN = (SearchPattern)(Environment.GetEnvironmentVariable("NUMBER_SEARCH_PATTERN") != null ? int.Parse(Environment.GetEnvironmentVariable("NUMBER_SEARCH_PATTERN")) : 0);

            var credentials = Credentials.FromApiKeyAndSecret(VONAGE_API_KEY, VONAGE_API_SECRET);
            var client = new VonageClient(credentials);

            var request = new NumberSearchRequest() 
            { 
                SearchPattern = NUMBER_SEARCH_PATTERN, 
                Pattern = NUMBER_SEARCH_CRITERIA 
            };

            var response = client.NumbersClient.GetOwnedNumbers(request);

            Console.WriteLine($"First Owned Number Matching Criteria : {response.Numbers[0].Msisdn}");
        }
    }
}
