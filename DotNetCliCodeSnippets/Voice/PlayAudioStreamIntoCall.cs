using Vonage;
using Vonage.Request;
using Vonage.Voice;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCliCodeSnippets.Voice
{
    public class PlayAudioStreamIntoCall : ICodeSnippet
    {
        public async Task Execute()
        {
            var vonageApplicationId = Environment.GetEnvironmentVariable("VONAGE_APPLICATION_ID") ?? "VONAGE_APPLICATION_ID";
            var vonagePrivateKeyPath = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
            var uuid = Environment.GetEnvironmentVariable("UUID") ?? "UUID";
            var url = Environment.GetEnvironmentVariable("URL") ?? "URL";

            var credentials = Credentials.FromAppIdAndPrivateKeyPath(vonageApplicationId, vonagePrivateKeyPath);
            var client = new VonageClient(credentials);

            var command = new StreamCommand() { StreamUrl = new[] { url } };

            var response = await client.VoiceClient.StartStreamAsync(uuid, command);

            Console.WriteLine($"Play Stream complete, message: {response.Message}");
        }
    }
}
