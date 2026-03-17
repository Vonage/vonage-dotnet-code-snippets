using Vonage;
using Vonage.Request;
using Vonage.Voice;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCliCodeSnippets.Voice
{
    public class GetRecording : ICodeSnippet
    {
        public async Task Execute()
        {
            var VONAGE_APPLICATION_ID = Environment.GetEnvironmentVariable(VonageConstants.ApplicationId) ?? VonageConstants.ApplicationId;
            var VONAGE_PRIVATE_KEY_PATH = Environment.GetEnvironmentVariable(VonageConstants.PrivateKeyPath) ?? VonageConstants.PrivateKeyPath;
            var VOICE_RECORDING_URL = Environment.GetEnvironmentVariable("VOICE_RECORDING_URL") ?? "RECORDING_URL";

            var credentials = Credentials.FromAppIdAndPrivateKeyPath(VONAGE_APPLICATION_ID, VONAGE_PRIVATE_KEY_PATH);
            var client = new VonageClient(credentials);

            var response = await client.VoiceClient.GetRecordingAsync(VOICE_RECORDING_URL);
            await File.WriteAllBytesAsync("your_recording.mp3", response.ResultStream);
            Console.WriteLine($"Recording size: {response.ResultStream.Length}");
        }
    }
}
