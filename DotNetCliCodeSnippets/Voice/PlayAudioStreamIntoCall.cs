using Vonage;
using Vonage.Request;
using Vonage.Voice;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCliCodeSnippets.Voice
{
    public class PlayAudioStreamIntoCall : ICodeSnippet
    {
        public async Task Execute()
        {
            var VONAGE_APPLICATION_ID = Environment.GetEnvironmentVariable("VONAGE_APPLICATION_ID") ?? "VONAGE_APPLICATION_ID";
            var VONAGE_PRIVATE_KEY_PATH = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
            var VOICE_CALL_ID = Environment.GetEnvironmentVariable("VOICE_CALL_ID") ?? "VOICE_CALL_ID";
            var VOICE_STREAM_URL = Environment.GetEnvironmentVariable("VOICE_STREAM_URL") ?? "VOICE_STREAM_URL";

            var credentials = Credentials.FromAppIdAndPrivateKeyPath(VONAGE_APPLICATION_ID, VONAGE_PRIVATE_KEY_PATH);
            var client = new VonageClient(credentials);

            var command = new StreamCommand() { StreamUrl = new[] { VOICE_STREAM_URL } };

            var response = await client.VoiceClient.StartStreamAsync(VOICE_CALL_ID, command);

            Console.WriteLine($"Play Stream complete, message: {response.Message}");
        }
    }
}
