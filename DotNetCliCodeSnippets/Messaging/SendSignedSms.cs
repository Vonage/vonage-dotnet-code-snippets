using Vonage;
using Vonage.Request;
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
            var VONAGE_API_KEY = Environment.GetEnvironmentVariable("VONAGE_API_KEY") ?? "VONAGE_API_KEY";
            var VONAGE_API_SIGNATURE_SECRET = Environment.GetEnvironmentVariable("VONAGE_API_SIGNATURE_SECRET") ?? "VONAGE_API_SIGNATURE_SECRET";

            var credentials = Credentials.FromApiKeySignatureSecretAndMethod(
                VONAGE_API_KEY,
                VONAGE_API_SIGNATURE_SECRET,
                Vonage.Cryptography.SmsSignatureGenerator.Method.md5hash
                );

            var VonageClient = new VonageClient(credentials);

            var response = VonageClient.SmsClient.SendAnSms(new Vonage.Messaging.SendSmsRequest()
            {
                To = TO_NUMBER,
                From = FROM_NUMBER,
                Text = "This is a Signed SMS"
            });
            Console.WriteLine(response.Messages[0].To);
        }
    }
}
