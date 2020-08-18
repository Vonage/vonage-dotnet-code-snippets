using System;
using System.Collections.Generic;
using System.Text;
using Vonage.Request;
using Vonage;
using Vonage.Numbers;

namespace DotnetCliCodeSnippets.Numbers
{
    public class CancelNumber : ICodeSnippet
    {
        public void Execute()
        {
            var VONAGE_API_KEY = Environment.GetEnvironmentVariable("VONAGE_API_KEY") ?? "VONAGE_API_KEY";
            var VONAGE_API_SECRET = Environment.GetEnvironmentVariable("VONAGE_API_SECRET") ?? "VONAGE_API_SECRET";
            var COUNTRY_CODE = Environment.GetEnvironmentVariable("COUNTRY_CODE") ?? "COUNTRY_CODE";
            var VONAGE_NUMBER = Environment.GetEnvironmentVariable("VONAGE_NUMBER") ?? "VONAGE_NUMBER";

            var credentials = Credentials.FromApiKeyAndSecret(VONAGE_API_KEY, VONAGE_API_SECRET);
            var client = new VonageClient(credentials);

            var request = new NumberTransactionRequest() { Country = COUNTRY_CODE, Msisdn = VONAGE_NUMBER };
            var response = client.NumbersClient.CancelANumber(request);

            Console.WriteLine($"Response Error Code: {response.ErrorCode} and Error Code Label: {response.ErrorCodeLabel}");
        }
    }
}
