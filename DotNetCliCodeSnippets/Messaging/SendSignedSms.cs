using Vonage;
using Vonage.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCliCodeSnippets.Messaging
{
    public class SendSignedSms : ICodeSnippet
    {
        public async Task Execute()
        {
            var SMS_TO_NUMBER = Environment.GetEnvironmentVariable("SMS_TO_NUMBER") ?? "SMS_TO_NUMBER";
            var SMS_SENDER_ID = Environment.GetEnvironmentVariable("SMS_SENDER_ID") ?? "SMS_SENDER_ID";
            var vonageApiKey = Environment.GetEnvironmentVariable("VONAGE_API_KEY") ?? "VONAGE_API_KEY";
            var vonageApiSignatureSecret = Environment.GetEnvironmentVariable("VONAGE_API_SIGNATURE_SECRET") ?? "VONAGE_API_SIGNATURE_SECRET";

            var credentials = Credentials.FromApiKeySignatureSecretAndMethod(
                vonageApiKey,
                vonageApiSignatureSecret,
                Vonage.Cryptography.SmsSignatureGenerator.Method.md5hash
                );

            var vonageClient = new VonageClient(credentials);

            var response = await vonageClient.SmsClient.SendAnSmsAsync(new Vonage.Messaging.SendSmsRequest()
            {
                To = SMS_TO_NUMBER,
                From = SMS_SENDER_ID,
                Text = "This is a Signed SMS"
            });
            Console.WriteLine(response.Messages[0].To);
        }
    }
}
