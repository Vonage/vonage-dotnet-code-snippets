using Vonage;
using Vonage.Request;
using System;
using System.Threading.Tasks;

namespace DotnetCliCodeSnippets.Accounts
{
    public class ListAllSecrets : ICodeSnippet
    {
        public async Task Execute()
        {
            var vonageApiKey = Environment.GetEnvironmentVariable("VONAGE_API_KEY") ?? "VONAGE_API_KEY";
            var vonageApiSecret = Environment.GetEnvironmentVariable("VONAGE_API_SECRET") ?? "VONAGE_API_SECRET";
            var apiKey = Environment.GetEnvironmentVariable("API_KEY") ?? "API_KEY";

            var credentials = Credentials.FromApiKeyAndSecret(vonageApiKey, vonageApiSecret);
            var client = new VonageClient(credentials);

            var response = await client.AccountClient.RetrieveApiSecretsAsync(apiKey);

            Console.WriteLine($"First Secret Response: {response.Embedded.Secrets[0].Id}");
        }
    }
}
