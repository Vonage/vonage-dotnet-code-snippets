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
            var vonageApplicationId = Environment.GetEnvironmentVariable("VONAGE_APPLICATION_ID") ?? "VONAGE_APPLICATION_ID";
            var vonagePrivateKeyPath = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
            var uuid = Environment.GetEnvironmentVariable("UUID") ?? "UUID";

            var credentials = Credentials.FromAppIdAndPrivateKeyPath(vonageApplicationId, vonagePrivateKeyPath);
            var client = new VonageClient(credentials);

            var command = new CallEditCommand() { Action = CallEditCommand.ActionType.mute };
            var response = await client.VoiceClient.UpdateCallAsync(uuid, command);

            Console.WriteLine($"Mute Call Command succeeded: {response}");

            Thread.Sleep(5000);

            command = new CallEditCommand() { Action = CallEditCommand.ActionType.unmute };

            response = await client.VoiceClient.UpdateCallAsync(uuid, command);
            Console.WriteLine($"Mute Call Command succeeded: {response}");
        }
    }
}
