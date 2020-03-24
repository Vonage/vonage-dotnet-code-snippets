using Nexmo.Api.Voice;
using Nexmo.Api.Request;
using Nexmo.Api.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCliCodeSnippets.Voice
{
    public class PlayDtmfIntoCall : ICodeSnippet
    {
        public void Execute()
        {
            var NEXMO_APPLICATION_ID = Environment.GetEnvironmentVariable("NEXMO_APPLICATION_ID") ?? "NEXMO_APPLICATION_ID";
            var NEXMO_PRIVATE_KEY_PATH = Environment.GetEnvironmentVariable("NEXMO_PRIVATE_KEY_PATH") ?? "NEXMO_PRIVATE_KEY_PATH";
            var UUID = Environment.GetEnvironmentVariable("UUID") ?? "UUID";
            var DIGITS = Environment.GetEnvironmentVariable("DIGITS") ?? "DIGITS";

            var credentials = Credentials.FromAppIdAndPrivateKeyPath(NEXMO_APPLICATION_ID, NEXMO_PRIVATE_KEY_PATH);
            var client = new NexmoClient(credentials);

            var command = new DtmfCommand() { Digits = DIGITS };

            var response = client.VoiceClient.StartDtmf(UUID, command);

            Console.WriteLine($"Play dtmf complete message: {response.Message}");
        }
    }
}
