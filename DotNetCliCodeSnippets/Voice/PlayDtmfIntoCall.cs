using Vonage.Voice;
using Vonage.Request;
using Vonage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCliCodeSnippets.Voice
{
    public class PlayDtmfIntoCall : ICodeSnippet
    {
        public async Task Execute()
        {
            var VONAGE_APPLICATION_ID = Environment.GetEnvironmentVariable(VonageConstants.ApplicationId) ?? VonageConstants.ApplicationId;
            var VONAGE_PRIVATE_KEY_PATH = Environment.GetEnvironmentVariable(VonageConstants.PrivateKeyPath) ?? VonageConstants.PrivateKeyPath;
            var VOICE_CALL_ID = Environment.GetEnvironmentVariable("VOICE_CALL_ID") ?? "VOICE_CALL_ID";
            var VOICE_DTMF_DIGITS = Environment.GetEnvironmentVariable("VOICE_DTMF_DIGITS") ?? "VOICE_DTMF_DIGITS";

            var credentials = Credentials.FromAppIdAndPrivateKeyPath(VONAGE_APPLICATION_ID, VONAGE_PRIVATE_KEY_PATH);
            var client = new VonageClient(credentials);

            var command = new DtmfCommand() { Digits = VOICE_DTMF_DIGITS };

            var response = await client.VoiceClient.StartDtmfAsync(VOICE_CALL_ID, command);

            Console.WriteLine($"Play dtmf complete message: {response.Message}");
        }
    }
}
