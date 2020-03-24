using System;
using Nexmo.Api.Request;
using System.Collections.Generic;
using System.Text;
using Nexmo.Api.Client;
using Nexmo.Api.Numbers;

namespace DotnetCliCodeSnippets.Numbers
{
    public class BuyNumber : ICodeSnippet
    {
        public void Execute()
        {
            var NEXMO_API_KEY = Environment.GetEnvironmentVariable("NEXMO_API_KEY") ?? "NEXMO_API_KEY";
            var NEXMO_API_SECRET = Environment.GetEnvironmentVariable("NEXMO_API_SECRET") ?? "NEXMO_API_SECRET";
            var COUNTRY_CODE = Environment.GetEnvironmentVariable("COUNTRY_CODE") ?? "COUNTRY_CODE";
            var NEXMO_NUMBER = Environment.GetEnvironmentVariable("NEXMO_NUMBER") ?? "NEXMO_NUMBER";

            var credentials = Credentials.FromApiKeyAndSecret(NEXMO_API_KEY, NEXMO_API_SECRET);
            var client = new NexmoClient(credentials);

            var request = new NumberTransactionRequest() { Country = COUNTRY_CODE, Msisdn = NEXMO_NUMBER };
            var response = client.NumbersClient.BuyANumber(request);

            Console.WriteLine($"Response Error Code: {response.ErrorCode} and Error Code Label: {response.ErrorCodeLabel}");
        }
    }
}
