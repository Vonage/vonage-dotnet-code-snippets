using Vonage;
using Vonage.Request;
using Vonage.Accounts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCliCodeSnippets.Accounts
{
    public class ChangeAccountSettings : ICodeSnippet
    {
        public void Execute()
        {
            var VONAGE_API_KEY = Environment.GetEnvironmentVariable("VONAGE_API_KEY") ?? "VONAGE_API_KEY";
            var VONAGE_API_SECRET = Environment.GetEnvironmentVariable("VONAGE_API_SECRET") ?? "VONAGE_API_SECRET";
            var SMS_CALLBACK_URL = Environment.GetEnvironmentVariable("SMS_CALLBACK_URL") ?? "SMS_CALLBACK_URL";

            var credentials = Credentials.FromApiKeyAndSecret(VONAGE_API_KEY, VONAGE_API_SECRET);
            var client = new VonageClient(credentials);

            var request = new AccountSettingsRequest() { MoCallBackUrl = SMS_CALLBACK_URL };
            var response = client.AccountClient.ChangeAccountSettings(request);

            Console.WriteLine($"SMS Callback url set to: {response.MoCallbackUrl}");
        }
    }
}
