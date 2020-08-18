using Vonage;
using Vonage.Request;
using Vonage.Voice;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCliCodeSnippets.Voice
{
    public class PlayTextToSpeech : ICodeSnippet
    {
        public void Execute()
        {
            var VONAGE_APPLICATION_ID = Environment.GetEnvironmentVariable("VONAGE_APPLICATION_ID") ?? "VONAGE_APPLICATION_ID";
            var VONAGE_PRIVATE_KEY_PATH = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
            var UUID = Environment.GetEnvironmentVariable("UUID") ?? "UUID";
            var TEXT = Environment.GetEnvironmentVariable("TEXT") ?? "TEXT";

            var credentials = Credentials.FromAppIdAndPrivateKeyPath(VONAGE_APPLICATION_ID, VONAGE_PRIVATE_KEY_PATH);
            var client = new VonageClient(credentials);

            var command = new TalkCommand() { Text = TEXT};

            var response = client.VoiceClient.StartTalk(UUID, command);

            Console.WriteLine($"Play Text-To-Speech complete message: {response.Message}");
        }
    }
}
