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
            var vonageApplicationId = Environment.GetEnvironmentVariable("VONAGE_APPLICATION_ID") ?? "VONAGE_APPLICATION_ID";
            var vonagePrivateKeyPath = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
            var recordingUrl = Environment.GetEnvironmentVariable("RECORDING_URL") ?? "RECORDING_URL";

            var credentials = Credentials.FromAppIdAndPrivateKeyPath(vonageApplicationId, vonagePrivateKeyPath);
            var client = new VonageClient(credentials);

            var response = await client.VoiceClient.GetRecordingAsync(recordingUrl);
            await File.WriteAllBytesAsync("your_recording.mp3", response.ResultStream);
            Console.WriteLine($"Recording size: {response.ResultStream.Length}");
        }
    }
}
