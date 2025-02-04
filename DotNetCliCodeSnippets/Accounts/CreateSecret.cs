using Vonage.Accounts;
using Vonage;
using Vonage.Request;
using System;
using System.Threading.Tasks;

namespace DotnetCliCodeSnippets.Accounts
{
    public class CreateSecret : ICodeSnippet
    {
        public async Task Execute()
        {
            var vonageApiKey = Environment.GetEnvironmentVariable("VONAGE_API_KEY") ?? "VONAGE_API_KEY";
            var vonageApiSecret = Environment.GetEnvironmentVariable("VONAGE_API_SECRET") ?? "VONAGE_API_SECRET";
            var ACCOUNT_ID = Environment.GetEnvironmentVariable("ACCOUNT_ID") ?? "ACCOUNT_ID";
            var ACCOUNT_SECRET_VALUE = Environment.GetEnvironmentVariable("ACCOUNT_SECRET_VALUE") ?? "ACCOUNT_SECRET_VALUE";

            var credentials = Credentials.FromApiKeyAndSecret(vonageApiKey, vonageApiSecret);
            var client = new VonageClient(credentials);

            var request = new CreateSecretRequest { Secret = ACCOUNT_SECRET_VALUE };

            var response = await client.AccountClient.CreateApiSecretAsync(request, ACCOUNT_ID);

            Console.WriteLine($"New Secret Created id:{response.Id}");
        }
    }
}
