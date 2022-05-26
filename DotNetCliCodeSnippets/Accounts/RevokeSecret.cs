using Vonage;
using Vonage.Request;
using System;
using System.Threading.Tasks;

namespace DotnetCliCodeSnippets.Accounts
{
    public class RevokeSecret : ICodeSnippet
    {
        public async Task Execute()
        {
            var vonageApiKey = Environment.GetEnvironmentVariable("VONAGE_API_KEY") ?? "VONAGE_API_KEY";
            var vonageApiSecret = Environment.GetEnvironmentVariable("VONAGE_API_SECRET") ?? "VONAGE_API_SECRET";
            var vonageSecretId = Environment.GetEnvironmentVariable("VONAGE_SECRET_ID") ?? "VONAGE_SECRET_ID";

            var credentials = Credentials.FromApiKeyAndSecret(vonageApiKey, vonageApiSecret);
            var client = new VonageClient(credentials);

            var response = await client.AccountClient.RevokeApiSecretAsync(vonageSecretId, vonageApiKey);

            Console.WriteLine($"Secret Revoked: {response}");
        }
    }
}
