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
            var VONAGE_APPLICATION_ID = Environment.GetEnvironmentVariable("VONAGE_APPLICATION_ID") ?? "VONAGE_APPLICATION_ID";
            var VONAGE_PRIVATE_KEY_PATH = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
            var VOICE_TO_NUMBER = Environment.GetEnvironmentVariable("VOICE_TO_NUMBER") ?? "VOICE_TO_NUMBER";
            var VONAGE_VIRTUAL_NUMBER = Environment.GetEnvironmentVariable("VONAGE_VIRTUAL_NUMBER") ?? "VONAGE_VIRTUAL_NUMBER";

            var creds = Credentials.FromAppIdAndPrivateKeyPath(VONAGE_APPLICATION_ID, VONAGE_PRIVATE_KEY_PATH);
            var client = new VonageClient(creds);

            var toEndpoint = new PhoneEndpoint() { Number = VOICE_TO_NUMBER };
            var fromEndpoint = new PhoneEndpoint() { Number = VONAGE_VIRTUAL_NUMBER };
            var extraText = "";
            for (var i = 0; i < 50; i++)
                extraText += $"{i} ";
            var talkAction = new TalkAction() { Text = "This is a text to speech call from Vonage " + extraText };
            var ncco = new Ncco(talkAction);

            var command = new CallCommand() { To = new Endpoint[] { toEndpoint }, From = fromEndpoint, Ncco = ncco };
            var response = await client.VoiceClient.CreateCallAsync(command);

            Console.WriteLine($"Call Created with call uuid: {response.Uuid}");
        }
    }
}
