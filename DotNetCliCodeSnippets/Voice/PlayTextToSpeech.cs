using Nexmo.Api.Client;
using Nexmo.Api.Request;
using Nexmo.Api.Voice;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCliCodeSnippets.Voice
{
    public class PlayTextToSpeech : ICodeSnippet
    {
        public void Execute()
        {
            var NEXMO_APPLICATION_ID = Environment.GetEnvironmentVariable("NEXMO_APPLICATION_ID") ?? "NEXMO_APPLICATION_ID";
            var NEXMO_PRIVATE_KEY_PATH = Environment.GetEnvironmentVariable("NEXMO_PRIVATE_KEY_PATH") ?? "NEXMO_PRIVATE_KEY_PATH";
            var UUID = Environment.GetEnvironmentVariable("UUID") ?? "UUID";
            var TEXT = Environment.GetEnvironmentVariable("TEXT") ?? "TEXT";

            var credentials = Credentials.FromAppIdAndPrivateKeyPath(NEXMO_APPLICATION_ID, NEXMO_PRIVATE_KEY_PATH);
            var client = new NexmoClient(credentials);

            var command = new TalkCommand() { Text = TEXT};

            var response = client.VoiceClient.StartTalk(UUID, command);

            Console.WriteLine($"Play Text-To-Speech complete message: {response.Message}");
        }
    }
}
