using Nexmo.Api;
using Nexmo.Api.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCliCodeSnippets.Messaging
{
    public class SendSignedSms : ICodeSnippet
    {
        public void Execute()
        {
            var TO_NUMBER = Environment.GetEnvironmentVariable("TO_NUMBER") ?? "TO_NUMBER";
            var FROM_NUMBER = Environment.GetEnvironmentVariable("FROM_NUMBER") ?? "FROM_NUMBER";
            var NEXMO_API_KEY = Environment.GetEnvironmentVariable("NEXMO_API_KEY") ?? "NEXMO_API_KEY";
            var NEXMO_API_SIGNATURE_SECRET = Environment.GetEnvironmentVariable("NEXMO_API_SIGNATURE_SECRET") ?? "NEXMO_API_SIGNATURE_SECRET";

            var credentials = Credentials.FromApiKeySignatureSecretAndMethod(
                NEXMO_API_KEY,
                NEXMO_API_SIGNATURE_SECRET,
                Nexmo.Api.Cryptography.SmsSignatureGenerator.Method.md5hash
                );

            var nexmoClient = new NexmoClient(credentials);

            var response = nexmoClient.SmsClient.SendAnSms(new Nexmo.Api.Messaging.SendSmsRequest()
            {
                To = TO_NUMBER,
                From = FROM_NUMBER,
                Text = "This is a Signed SMS"
            });
            Console.WriteLine(response.Messages[0].To);
        }
    }
}
