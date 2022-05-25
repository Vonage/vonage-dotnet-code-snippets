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
            var apiKey = Environment.GetEnvironmentVariable("API_KEY") ?? "API_KEY";
            var newSecret = Environment.GetEnvironmentVariable("NEW_SECRET") ?? "NEW_SECRET";

            var credentials = Credentials.FromApiKeyAndSecret(vonageApiKey, vonageApiSecret);
            var client = new VonageClient(credentials);

            var request = new CreateSecretRequest { Secret = newSecret };

            var response = await client.AccountClient.CreateApiSecretAsync(request, apiKey);

            Console.WriteLine($"New Secret Created id:{response.Id}");
        }
    }
}
