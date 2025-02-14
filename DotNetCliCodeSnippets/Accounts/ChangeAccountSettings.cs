﻿using Vonage;
using Vonage.Request;
using Vonage.Accounts;
using System;
using System.Threading.Tasks;

namespace DotnetCliCodeSnippets.Accounts
{
    public class ChangeAccountSettings : ICodeSnippet
    {
        public async Task Execute()
        {
            var vonageApiKey = Environment.GetEnvironmentVariable("VONAGE_API_KEY") ?? "VONAGE_API_KEY";
            var vonageApiSecret = Environment.GetEnvironmentVariable("VONAGE_API_SECRET") ?? "VONAGE_API_SECRET";
            var ACCOUNT_SMS_CALLBACK_URL = Environment.GetEnvironmentVariable("ACCOUNT_SMS_CALLBACK_URL") ?? "ACCOUNT_SMS_CALLBACK_URL";

            var credentials = Credentials.FromApiKeyAndSecret(vonageApiKey, vonageApiSecret);
            var client = new VonageClient(credentials);

            var request = new AccountSettingsRequest { MoCallBackUrl = ACCOUNT_SMS_CALLBACK_URL };
            var response = await client.AccountClient.ChangeAccountSettingsAsync(request);

            Console.WriteLine($"SMS Callback url set to: {response.MoCallbackUrl}");
        }
    }
}
