using Nexmo.Api;
using Nexmo.Api.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCliCodeSnippets.Messaging
{
    public class SendSms : ICodeSnippet
    {
        public void Execute()
        {
            var TO_NUMBER = Environment.GetEnvironmentVariable("TO_NUMBER") ?? "TO_NUMBER";
            var NEXMO_BRAND_NAME = Environment.GetEnvironmentVariable("NEXMO_BRAND_NAME") ?? "NEXMO_BRAND_NAME";
            var NEXMO_API_KEY = Environment.GetEnvironmentVariable("NEXMO_API_KEY") ?? "NEXMO_API_KEY";
            var NEXMO_API_SECRET = Environment.GetEnvironmentVariable("NEXMO_API_SECRET") ?? "NEXMO_API_SECRET";

            var credentials = Credentials.FromApiKeyAndSecret(
                NEXMO_API_KEY,
                NEXMO_API_SECRET
                );

            var nexmoClient = new NexmoClient(credentials);

            var response = nexmoClient.SmsClient.SendAnSms(new Nexmo.Api.Messaging.SendSmsRequest()
            {
                To = TO_NUMBER,
                From = NEXMO_BRAND_NAME,
                Text = "A text message sent using the Nexmo SMS API"
            });
            Console.WriteLine(response.Messages[0].To);

        }
    }
}
