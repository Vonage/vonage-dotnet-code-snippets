using Nexmo.Api.Client;
using Nexmo.Api.Request;
using Nexmo.Api.Accounts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCliCodeSnippets.Accounts
{
    public class ChangeAccountSettings : ICodeSnippet
    {
        public void Execute()
        {
            var NEXMO_API_KEY = Environment.GetEnvironmentVariable("NEXMO_API_KEY") ?? "NEXMO_API_KEY";
            var NEXMO_API_SECRET = Environment.GetEnvironmentVariable("NEXMO_API_SECRET") ?? "NEXMO_API_SECRET";
            var SMS_CALLBACK_URL = Environment.GetEnvironmentVariable("SMS_CALLBACK_URL") ?? "SMS_CALLBACK_URL";

            var credentials = Credentials.FromApiKeyAndSecret(NEXMO_API_KEY, NEXMO_API_SECRET);
            var client = new NexmoClient(credentials);

            var request = new AccountSettingsRequest() { MoCallBackUrl = SMS_CALLBACK_URL };
            var response = client.AccountClient.ChangeAccountSettings(request);

            Console.WriteLine($"SMS Callback url set to: {response.MoCallbackUrl}");
        }
    }
}
