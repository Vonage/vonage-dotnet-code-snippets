﻿using Vonage;
using Vonage.Messaging;
using Vonage.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCliCodeSnippets.Messaging
{
    public class SendSmsWithUnicode : ICodeSnippet
    {
        public async Task Execute()
        {
            var toNumber = Environment.GetEnvironmentVariable("TO_NUMBER") ?? "TO_NUMBER";
            var vonageBrandName = Environment.GetEnvironmentVariable("VONAGE_BRAND_NAME") ?? "VONAGE_BRAND_NAME";
            var vonageApiKey = Environment.GetEnvironmentVariable("VONAGE_API_KEY") ?? "VONAGE_API_KEY";
            var vonageApiSecret = Environment.GetEnvironmentVariable("VONAGE_API_SECRET") ?? "VONAGE_API_SECRET";

            var credentials = Credentials.FromApiKeyAndSecret(
                vonageApiKey,
                vonageApiSecret
                );

            var vonageClient = new VonageClient(credentials);

            var response = await vonageClient.SmsClient.SendAnSmsAsync(new SendSmsRequest()
            {
                To = toNumber,
                From = vonageBrandName,
                Text = "こんにちは世界",
                Type = SmsType.Unicode
            });
            Console.WriteLine(response.Messages[0].To);
        }
    }
}
