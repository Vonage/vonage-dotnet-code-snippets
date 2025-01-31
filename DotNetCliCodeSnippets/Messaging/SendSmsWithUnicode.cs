using Vonage;
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
            var SMS_TO_NUMBER = Environment.GetEnvironmentVariable("SMS_TO_NUMBER") ?? "SMS_TO_NUMBER";
            var SMS_SENDER_ID = Environment.GetEnvironmentVariable("SMS_SENDER_ID") ?? "SMS_SENDER_ID";
            var vonageApiKey = Environment.GetEnvironmentVariable("VONAGE_API_KEY") ?? "VONAGE_API_KEY";
            var vonageApiSecret = Environment.GetEnvironmentVariable("VONAGE_API_SECRET") ?? "VONAGE_API_SECRET";

            var credentials = Credentials.FromApiKeyAndSecret(
                vonageApiKey,
                vonageApiSecret
                );

            var vonageClient = new VonageClient(credentials);

            var response = await vonageClient.SmsClient.SendAnSmsAsync(new SendSmsRequest()
            {
                To = SMS_TO_NUMBER,
                From = SMS_SENDER_ID,
                Text = "こんにちは世界",
                Type = SmsType.Unicode
            });
            Console.WriteLine(response.Messages[0].To);
        }
    }
}
