using Vonage;
using Vonage.Messaging;
using Vonage.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCliCodeSnippets.Messaging
{
    public class SendSmsWithUnicode : ICodeSnippet
    {
        public void Execute()
        {
            var TO_NUMBER = Environment.GetEnvironmentVariable("TO_NUMBER") ?? "TO_NUMBER";
            var VONAGE_BRAND_NAME = Environment.GetEnvironmentVariable("VONAGE_BRAND_NAME") ?? "VONAGE_BRAND_NAME";
            var VONAGE_API_KEY = Environment.GetEnvironmentVariable("VONAGE_API_KEY") ?? "VONAGE_API_KEY";
            var VONAGE_API_SECRET = Environment.GetEnvironmentVariable("VONAGE_API_SECRET") ?? "VONAGE_API_SECRET";

            var credentials = Credentials.FromApiKeyAndSecret(
                VONAGE_API_KEY,
                VONAGE_API_SECRET
                );

            var VonageClient = new VonageClient(credentials);

            var response = VonageClient.SmsClient.SendAnSms(new SendSmsRequest()
            {
                To = TO_NUMBER,
                From = VONAGE_BRAND_NAME,
                Text = "こんにちは世界",
                Type = SmsType.unicode
            });
            Console.WriteLine(response.Messages[0].To);
        }
    }
}
