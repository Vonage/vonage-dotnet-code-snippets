using Vonage;
using Vonage.Request;
using Vonage.Voice;
using System.Threading;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCliCodeSnippets.Voice
{
    public class MuteCall : ICodeSnippet
    {
        public async Task Execute()
        {
            var VONAGE_APPLICATION_ID = Environment.GetEnvironmentVariable("VONAGE_APPLICATION_ID") ?? "VONAGE_APPLICATION_ID";
            var VONAGE_PRIVATE_KEY_PATH = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
            var VOICE_CALL_ID = Environment.GetEnvironmentVariable("VOICE_CALL_ID") ?? "VOICE_CALL_ID";

            var credentials = Credentials.FromAppIdAndPrivateKeyPath(VONAGE_APPLICATION_ID, VONAGE_PRIVATE_KEY_PATH);
            var client = new VonageClient(credentials);

            var command = new CallEditCommand() { Action = CallEditCommand.ActionType.mute };
            var response = await client.VoiceClient.UpdateCallAsync(VOICE_CALL_ID, command);

            Console.WriteLine($"Mute Call Command succeeded: {response}");

            Thread.Sleep(5000);

            command = new CallEditCommand() { Action = CallEditCommand.ActionType.unmute };

            response = await client.VoiceClient.UpdateCallAsync(VOICE_CALL_ID, command);
            Console.WriteLine($"Mute Call Command succeeded: {response}");
        }
    }
}
