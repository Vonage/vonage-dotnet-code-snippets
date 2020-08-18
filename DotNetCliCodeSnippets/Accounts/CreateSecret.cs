using Vonage.Accounts;
using Vonage;
using Vonage.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCliCodeSnippets.Accounts
{
    public class CreateSecret : ICodeSnippet
    {
        public void Execute()
        {
            var VONAGE_API_KEY = Environment.GetEnvironmentVariable("VONAGE_API_KEY") ?? "VONAGE_API_KEY";
            var VONAGE_API_SECRET = Environment.GetEnvironmentVariable("VONAGE_API_SECRET") ?? "VONAGE_API_SECRET";
            var API_KEY = Environment.GetEnvironmentVariable("API_KEY") ?? "API_KEY";
            var NEW_SECRET = Environment.GetEnvironmentVariable("NEW_SECRET") ?? "NEW_SECRET";

            var credentials = Credentials.FromApiKeyAndSecret(VONAGE_API_KEY, VONAGE_API_SECRET);
            var client = new VonageClient(credentials);

            var request = new CreateSecretRequest() { Secret = NEW_SECRET };

            var response = client.AccountClient.CreateApiSecret(request, API_KEY);

            Console.WriteLine($"New Secret Created id:{response.Id}");
        }
    }
}
