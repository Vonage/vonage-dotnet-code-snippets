using Nexmo.Api.Client;
using Nexmo.Api.Request;
using Nexmo.Api.Voice;
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
            var NEXMO_APPLICATION_ID = Environment.GetEnvironmentVariable("NEXMO_APPLICATION_ID") ?? "NEXMO_APPLICATION_ID";
            var NEXMO_PRIVATE_KEY_PATH = Environment.GetEnvironmentVariable("NEXMO_PRIVATE_KEY_PATH") ?? "NEXMO_PRIVATE_KEY_PATH";
            var UUID = Environment.GetEnvironmentVariable("UUID") ?? "UUID";

            var credentials = Credentials.FromAppIdAndPrivateKeyPath(NEXMO_APPLICATION_ID, NEXMO_PRIVATE_KEY_PATH);
            var client = new NexmoClient(credentials);

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
