using Nexmo.Api.Client;
using Nexmo.Api.Request;
using Nexmo.Api.Voice;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCliCodeSnippets.Voice
{
    public class PlayAudioStreamIntoCall : ICodeSnippet
    {
        public void Execute()
        {
            var NEXMO_APPLICATION_ID = Environment.GetEnvironmentVariable("NEXMO_APPLICATION_ID") ?? "NEXMO_APPLICATION_ID";
            var NEXMO_PRIVATE_KEY_PATH = Environment.GetEnvironmentVariable("NEXMO_PRIVATE_KEY_PATH") ?? "NEXMO_PRIVATE_KEY_PATH";
            var UUID = Environment.GetEnvironmentVariable("UUID") ?? "UUID";
            var URL = Environment.GetEnvironmentVariable("URL") ?? "URL";

            var credentials = Credentials.FromAppIdAndPrivateKeyPath(NEXMO_APPLICATION_ID, NEXMO_PRIVATE_KEY_PATH);
            var client = new NexmoClient(credentials);

            var command = new StreamCommand() { StreamUrl = new[] { URL } };

            var response = client.VoiceClient.StartStream(UUID, command);

            Console.WriteLine($"Play Stream complete, message: {response.Message}");
        }
    }
}
