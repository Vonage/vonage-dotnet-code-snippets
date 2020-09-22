using Vonage;
using Vonage.Request;
using Vonage.Voice;
using System.Threading;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCliCodeSnippets.Voice
{
    public class MuteCall : ICodeSnippet
    {
        public void Execute()
        {
            var VONAGE_APPLICATION_ID = Environment.GetEnvironmentVariable("VONAGE_APPLICATION_ID") ?? "VONAGE_APPLICATION_ID";
            var VONAGE_PRIVATE_KEY_PATH = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
            var UUID = Environment.GetEnvironmentVariable("UUID") ?? "UUID";

            var credentials = Credentials.FromAppIdAndPrivateKeyPath(VONAGE_APPLICATION_ID, VONAGE_PRIVATE_KEY_PATH);
            var client = new VonageClient(credentials);

            var command = new CallEditCommand() { Action = CallEditCommand.ActionType.mute };
            var response = client.VoiceClient.UpdateCall(UUID, command);

            Console.WriteLine($"Mute Call Command succeeded: {response}");

            Thread.Sleep(5000);

            command = new CallEditCommand() { Action = CallEditCommand.ActionType.unmute };

            response = client.VoiceClient.UpdateCall(UUID, command);
            Console.WriteLine($"Mute Call Command succeeded: {response}");
        }
    }
}
