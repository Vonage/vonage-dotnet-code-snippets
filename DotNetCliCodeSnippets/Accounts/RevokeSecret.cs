using Nexmo.Api.Accounts;
using Nexmo.Api;
using Nexmo.Api.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCliCodeSnippets.Accounts
{
    public class RevokeSecret : ICodeSnippet
    {
        public void Execute()
        {
            var NEXMO_API_KEY = Environment.GetEnvironmentVariable("NEXMO_API_KEY") ?? "NEXMO_API_KEY";
            var NEXMO_API_SECRET = Environment.GetEnvironmentVariable("NEXMO_API_SECRET") ?? "NEXMO_API_SECRET";
            var NEXMO_SECRET_ID = Environment.GetEnvironmentVariable("NEXMO_SECRET_ID") ?? "NEXMO_SECRET_ID";

            var credentials = Credentials.FromApiKeyAndSecret(NEXMO_API_KEY, NEXMO_API_SECRET);
            var client = new NexmoClient(credentials);

            var response = client.AccountClient.RevokeApiSecret(NEXMO_SECRET_ID, NEXMO_API_KEY);

            Console.WriteLine($"Secret Revoked: {response}");
        }
    }
}
