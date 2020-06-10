using Nexmo.Api.Request;
using Nexmo.Api;
using Nexmo.Api.Voice;
using System;
using System.Collections.Generic;
using System.Text;
using Nexmo.Api.Voice.Nccos;
using Nexmo.Api.Voice.Nccos.Endpoints;

namespace DotnetCliCodeSnippets.Voice
{
    public class MakeCallWithNcco : ICodeSnippet
    {
        

        public void Execute()
        {
            var NEXMO_APPLICATION_ID = Environment.GetEnvironmentVariable("NEXMO_APPLICATION_ID") ?? "NEXMO_APPLICATION_ID";
            var NEXMO_PRIVATE_KEY_PATH = Environment.GetEnvironmentVariable("NEXMO_PRIVATE_KEY_PATH") ?? "NEXMO_PRIVATE_KEY_PATH";
            var TO_NUMBER = Environment.GetEnvironmentVariable("TO_NUMBER") ?? "TO_NUMBER";
            var NEXMO_NUMBER = Environment.GetEnvironmentVariable("NEXMO_NUMBER") ?? "NEXMO_NUMBER";
            var EVENT_URL = new[] { Environment.GetEnvironmentVariable("EVENT_URL") ?? "https://example.com" };

            var toEndpoint = new PhoneEndpoint() { Number = TO_NUMBER };
            var fromEndpoint = new PhoneEndpoint() { Number = NEXMO_NUMBER };

            var talkAction = new TalkAction() { Text = "This is a text to speech call from Nexmo" };
            var ncco = new Ncco(talkAction);

            var command = new CallCommand() { To = new Endpoint[] { toEndpoint }, From = fromEndpoint, Ncco = ncco, EventUrl= EVENT_URL };

            var creds = Credentials.FromAppIdAndPrivateKeyPath(NEXMO_APPLICATION_ID, NEXMO_PRIVATE_KEY_PATH);
            var client = new NexmoClient(creds);

            var response = client.VoiceClient.CreateCall(command);

            Console.WriteLine($"Call Created with call uuid: {response.Uuid}");
        }
    }
}
