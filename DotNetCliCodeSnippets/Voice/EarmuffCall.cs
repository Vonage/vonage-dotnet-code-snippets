using Nexmo.Api.Client;
using Nexmo.Api.Request;
using Nexmo.Api.Voice;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DotnetCliCodeSnippets.Voice
{
    public class EarmuffCall : ICodeSnippet
    {
        public void Execute()
        {
            var NEXMO_APPLICATION_ID = Environment.GetEnvironmentVariable("NEXMO_APPLICATION_ID") ?? "NEXMO_APPLICATION_ID";
            var NEXMO_PRIVATE_KEY_PATH = Environment.GetEnvironmentVariable("NEXMO_PRIVATE_KEY_PATH") ?? "NEXMO_PRIVATE_KEY_PATH";
            var UUID = Environment.GetEnvironmentVariable("UUID") ?? "UUID";

            var credentials = Credentials.FromAppIdAndPrivateKeyPath(NEXMO_APPLICATION_ID, NEXMO_PRIVATE_KEY_PATH);
            var client = new NexmoClient(credentials);

            var command = new CallEditCommand() { Action = CallEditCommand.ActionType.earmuff };
            var response = client.VoiceClient.UpdateCall(UUID, command);

            Console.WriteLine($"Earmuff Call Command succeeded: {response}");

            Thread.Sleep(3000);

            command = new CallEditCommand() { Action = CallEditCommand.ActionType.unearmuff };
            response = client.VoiceClient.UpdateCall(UUID, command);

        }
    }
}
