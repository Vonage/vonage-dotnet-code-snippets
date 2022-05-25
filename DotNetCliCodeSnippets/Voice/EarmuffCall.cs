using Vonage;
using Vonage.Request;
using Vonage.Voice;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DotnetCliCodeSnippets.Voice
{
    public class EarmuffCall : ICodeSnippet
    {
        public async Task Execute()
        {
            var vonageApplicationId = Environment.GetEnvironmentVariable("VONAGE_APPLICATION_ID") ?? "VONAGE_APPLICATION_ID";
            var vonagePrivateKeyPath = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
            var uuid = Environment.GetEnvironmentVariable("UUID") ?? "UUID";

            var credentials = Credentials.FromAppIdAndPrivateKeyPath(vonageApplicationId, vonagePrivateKeyPath);
            var client = new VonageClient(credentials);

            var command = new CallEditCommand() { Action = CallEditCommand.ActionType.earmuff };
            var response = await client.VoiceClient.UpdateCallAsync(uuid, command);

            Console.WriteLine($"Earmuff Call Command succeeded: {response}");

            Thread.Sleep(3000);

            command = new CallEditCommand() { Action = CallEditCommand.ActionType.unearmuff };
            response = await client.VoiceClient.UpdateCallAsync(uuid, command);

        }
    }
}
