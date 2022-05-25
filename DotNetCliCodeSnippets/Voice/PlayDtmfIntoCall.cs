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
            var vonageApplicationId = Environment.GetEnvironmentVariable("VONAGE_APPLICATION_ID") ?? "VONAGE_APPLICATION_ID";
            var vonagePrivateKeyPath = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
            var uuid = Environment.GetEnvironmentVariable("UUID") ?? "UUID";
            var digits = Environment.GetEnvironmentVariable("DIGITS") ?? "DIGITS";

            var credentials = Credentials.FromAppIdAndPrivateKeyPath(vonageApplicationId, vonagePrivateKeyPath);
            var client = new VonageClient(credentials);

            var command = new DtmfCommand() { Digits = digits };

            var response = await client.VoiceClient.StartDtmfAsync(uuid, command);

            Console.WriteLine($"Play dtmf complete message: {response.Message}");
        }
    }
}
