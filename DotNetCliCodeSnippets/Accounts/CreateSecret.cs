using Nexmo.Api.Accounts;
using Nexmo.Api.Client;
using Nexmo.Api.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCliCodeSnippets.Accounts
{
    public class CreateSecret : ICodeSnippet
    {
        public void Execute()
        {
            var NEXMO_API_KEY = Environment.GetEnvironmentVariable("NEXMO_API_KEY") ?? "NEXMO_API_KEY";
            var NEXMO_API_SECRET = Environment.GetEnvironmentVariable("NEXMO_API_SECRET") ?? "NEXMO_API_SECRET";
            var API_KEY = Environment.GetEnvironmentVariable("API_KEY") ?? "API_KEY";
            var NEW_SECRET = Environment.GetEnvironmentVariable("NEW_SECRET") ?? "NEW_SECRET";

            var credentials = Credentials.FromApiKeyAndSecret(NEXMO_API_KEY, NEXMO_API_SECRET);
            var client = new NexmoClient(credentials);

            var request = new CreateSecretRequest() { Secret = NEW_SECRET };

            var response = client.AccountClient.CreateApiSecret(request, API_KEY);

            Console.WriteLine($"New Secret Created id:{response.Id}");
        }
    }
}
