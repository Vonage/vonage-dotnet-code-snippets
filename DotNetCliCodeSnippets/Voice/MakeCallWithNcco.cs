using Vonage.Request;
using Vonage;
using Vonage.Voice;
using Vonage.Voice.Nccos;
using Vonage.Voice.Nccos.Endpoints;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCliCodeSnippets.Voice
{
    public class MakeCallWithNcco : ICodeSnippet
    {
        

        public async Task Execute()
        {
            var vonageApplicationId = Environment.GetEnvironmentVariable("VONAGE_APPLICATION_ID") ?? "VONAGE_APPLICATION_ID";
            var vonagePrivateKeyPath = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
            var toNumber = Environment.GetEnvironmentVariable("TO_NUMBER") ?? "TO_NUMBER";
            var vonageNumber = Environment.GetEnvironmentVariable("VONAGE_NUMBER") ?? "VONAGE_NUMBER";
            var eventUrl = new[] { Environment.GetEnvironmentVariable("EVENT_URL") ?? "https://example.com" };            

            var creds = Credentials.FromAppIdAndPrivateKeyPath(vonageApplicationId, vonagePrivateKeyPath);
            var client = new VonageClient(creds);

            var toEndpoint = new PhoneEndpoint() { Number = toNumber };
            var fromEndpoint = new PhoneEndpoint() { Number = vonageNumber };
            var extraText = "";
            for (var i = 0; i < 50; i++)
                extraText += $"{i} ";
            var talkAction = new TalkAction() { Text = "This is a text to speech call from Vonage " + extraText };
            var ncco = new Ncco(talkAction);

            var command = new CallCommand() { To = new Endpoint[] { toEndpoint }, From = fromEndpoint, Ncco = ncco, EventUrl = eventUrl };
            var response = await client.VoiceClient.CreateCallAsync(command);

            Console.WriteLine($"Call Created with call uuid: {response.Uuid}");
        }
    }
}
