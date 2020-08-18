using Vonage.Accounts;
using Vonage;
using Vonage.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCliCodeSnippets.Accounts
{
    public class ListAllSecrets : ICodeSnippet
    {
        public void Execute()
        {
            var VONAGE_API_KEY = Environment.GetEnvironmentVariable("VONAGE_API_KEY") ?? "VONAGE_API_KEY";
            var VONAGE_API_SECRET = Environment.GetEnvironmentVariable("VONAGE_API_SECRET") ?? "VONAGE_API_SECRET";
            var API_KEY = Environment.GetEnvironmentVariable("API_KEY") ?? "API_KEY";

            var credentials = Credentials.FromApiKeyAndSecret(VONAGE_API_KEY, VONAGE_API_SECRET);
            var client = new VonageClient(credentials);

            var response = client.AccountClient.RetrieveApiSecrets(API_KEY);

            Console.WriteLine($"First Secret Response: {response.Embedded.Secrets[0].Id}");
        }
    }
}
