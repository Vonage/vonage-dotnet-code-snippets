using Vonage;
using Vonage.Request;
using System;
using System.Threading.Tasks;

namespace DotnetCliCodeSnippets.Accounts
{
    public class FetchSecret : ICodeSnippet
    {
        public async Task Execute()
        {
            var vonageApiKey = Environment.GetEnvironmentVariable("VONAGE_API_KEY") ?? "VONAGE_API_KEY";
            var vonageApiSecret = Environment.GetEnvironmentVariable("VONAGE_API_SECRET") ?? "VONAGE_API_SECRET";
            var ACCOUNT_SECRET_ID = Environment.GetEnvironmentVariable("ACCOUNT_SECRET_ID") ?? "ACCOUNT_SECRET_ID";
            var ACCOUNT_ID = Environment.GetEnvironmentVariable("ACCOUNT_ID") ?? "ACCOUNT_ID";
            var credentials = Credentials.FromApiKeyAndSecret(vonageApiKey, vonageApiSecret);
            var client = new VonageClient(credentials);

            var response = await client.AccountClient.RetrieveApiSecretAsync(ACCOUNT_SECRET_ID, ACCOUNT_ID);

            Console.WriteLine($"Api Secret Retrieved {response.Id} created at {response.CreatedAt}");
        }
    }
}
