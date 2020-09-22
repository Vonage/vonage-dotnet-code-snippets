using Vonage;
using Vonage.Request;
using Vonage.Voice;
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
            var VONAGE_APPLICATION_ID = Environment.GetEnvironmentVariable("VONAGE_APPLICATION_ID") ?? "VONAGE_APPLICATION_ID";
            var VONAGE_PRIVATE_KEY_PATH = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
            var UUID = Environment.GetEnvironmentVariable("UUID") ?? "UUID";

            var credentials = Credentials.FromAppIdAndPrivateKeyPath(VONAGE_APPLICATION_ID, VONAGE_PRIVATE_KEY_PATH);
            var client = new VonageClient(credentials);

            var command = new CallEditCommand() { Action = CallEditCommand.ActionType.earmuff };
            var response = client.VoiceClient.UpdateCall(UUID, command);

            Console.WriteLine($"Earmuff Call Command succeeded: {response}");

            Thread.Sleep(3000);

            command = new CallEditCommand() { Action = CallEditCommand.ActionType.unearmuff };
            response = client.VoiceClient.UpdateCall(UUID, command);

        }
    }
}
