using Vonage;
using Vonage.Request;
using Vonage.Voice;
using Vonage.Voice.Nccos.Endpoints;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCliCodeSnippets.Voice
{
    public class MakeOutboundCall : ICodeSnippet
    {
        public async Task Execute()
        {
            var vonageApplicationId = Environment.GetEnvironmentVariable("VONAGE_APPLICATION_ID") ?? "VONAGE_APPLICATION_ID";
            var vonagePrivateKeyPath = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
            var toNumber = Environment.GetEnvironmentVariable("TO_NUMBER") ?? "TO_NUMBER";
            var vonageNumber = Environment.GetEnvironmentVariable("VONAGE_NUMBER") ?? "VONAGE_NUMBER";                                    

            var creds = Credentials.FromAppIdAndPrivateKeyPath(vonageApplicationId, vonagePrivateKeyPath);
            var client = new VonageClient(creds);

            var answerUrl = "https://nexmo-community.github.io/ncco-examples/text-to-speech.json";
            var toEndpoint = new PhoneEndpoint() { Number = toNumber };
            var fromEndpoint = new PhoneEndpoint() { Number = vonageNumber };

            var command = new CallCommand() { To = new Endpoint[] { toEndpoint }, From = fromEndpoint, AnswerUrl = new[] { answerUrl } };
            var response = await client.VoiceClient.CreateCallAsync(command);

            Console.WriteLine($"Call Created with call uuid: {response.Uuid}");
        }
    }
}
