using Vonage;
using Vonage.Request;
using Vonage.Voice;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DotnetCliCodeSnippets.Voice
{
    public class GetRecording : ICodeSnippet
    {
        public void Execute()
        {
            var VONAGE_APPLICATION_ID = Environment.GetEnvironmentVariable("VONAGE_APPLICATION_ID") ?? "VONAGE_APPLICATION_ID";
            var VONAGE_PRIVATE_KEY_PATH = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
            var RECORDING_URL = Environment.GetEnvironmentVariable("RECORDING_URL") ?? "RECORDING_URL";

            var credentials = Credentials.FromAppIdAndPrivateKeyPath(VONAGE_APPLICATION_ID, VONAGE_PRIVATE_KEY_PATH);
            var client = new VonageClient(credentials);

            var response = client.VoiceClient.GetRecording(RECORDING_URL);
            File.WriteAllBytes("your_recording.mp3", response.ResultStream);
            Console.WriteLine($"Recording size: {response.ResultStream.Length}");
        }
    }
}
