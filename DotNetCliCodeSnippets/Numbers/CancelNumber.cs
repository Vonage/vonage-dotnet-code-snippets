using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vonage.Request;
using Vonage;
using Vonage.Numbers;

namespace DotnetCliCodeSnippets.Numbers
{
    public class CancelNumber : ICodeSnippet
    {
        public async Task Execute()
        {
            var vonageApiKey = Environment.GetEnvironmentVariable("VONAGE_API_KEY") ?? "VONAGE_API_KEY";
            var vonageApiSecret = Environment.GetEnvironmentVariable("VONAGE_API_SECRET") ?? "VONAGE_API_SECRET";
            var countryCode = Environment.GetEnvironmentVariable("COUNTRY_CODE") ?? "COUNTRY_CODE";
            var vonageNumber = Environment.GetEnvironmentVariable("VONAGE_NUMBER") ?? "VONAGE_NUMBER";

            var credentials = Credentials.FromApiKeyAndSecret(vonageApiKey, vonageApiSecret);
            var client = new VonageClient(credentials);

            var request = new NumberTransactionRequest() { Country = countryCode, Msisdn = vonageNumber };
            var response = await client.NumbersClient.CancelANumberAsync(request);

            Console.WriteLine($"Response Error Code: {response.ErrorCode} and Error Code Label: {response.ErrorCodeLabel}");
        }
    }
}
