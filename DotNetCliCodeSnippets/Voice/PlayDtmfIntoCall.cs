using Vonage.Voice;
using Vonage.Request;
using Vonage;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCliCodeSnippets.Voice
{
    public class PlayDtmfIntoCall : ICodeSnippet
    {
        public void Execute()
        {
            var VONAGE_APPLICATION_ID = Environment.GetEnvironmentVariable("VONAGE_APPLICATION_ID") ?? "VONAGE_APPLICATION_ID";
            var VONAGE_PRIVATE_KEY_PATH = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
            var UUID = Environment.GetEnvironmentVariable("UUID") ?? "UUID";
            var DIGITS = Environment.GetEnvironmentVariable("DIGITS") ?? "DIGITS";

            var credentials = Credentials.FromAppIdAndPrivateKeyPath(VONAGE_APPLICATION_ID, VONAGE_PRIVATE_KEY_PATH);
            var client = new VonageClient(credentials);

            var command = new DtmfCommand() { Digits = DIGITS };

            var response = client.VoiceClient.StartDtmf(UUID, command);

            Console.WriteLine($"Play dtmf complete message: {response.Message}");
        }
    }
}
