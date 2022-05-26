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
            var toNumber = Environment.GetEnvironmentVariable("TO_NUMBER") ?? "TO_NUMBER";
            var fromNumber = Environment.GetEnvironmentVariable("FROM_NUMBER") ?? "FROM_NUMBER";
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
                To = toNumber,
                From = fromNumber,
                Text = "This is a Signed SMS"
            });
            Console.WriteLine(response.Messages[0].To);
        }
    }
}
