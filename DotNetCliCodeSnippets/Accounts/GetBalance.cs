using Nexmo.Api;
using Nexmo.Api.Request;
using Nexmo.Api.Accounts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCliCodeSnippets.Accounts
{
    public class GetBalance : ICodeSnippet
    {
        public void Execute()
        {
            var NEXMO_API_KEY = Environment.GetEnvironmentVariable("NEXMO_API_KEY") ?? "NEXMO_API_KEY";
            var NEXMO_API_SECRET = Environment.GetEnvironmentVariable("NEXMO_API_SECRET") ?? "NEXMO_API_SECRET";
            var credentials = Credentials.FromApiKeyAndSecret(NEXMO_API_KEY, NEXMO_API_SECRET);
            var client = new NexmoClient(credentials);
            var response = client.AccountClient.GetAccountBalance();

            Console.WriteLine($"Current Account Balance: {response.Value}");
        }
    }
}
