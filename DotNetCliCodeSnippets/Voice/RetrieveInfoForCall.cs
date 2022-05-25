using Vonage;
using Vonage.Request;
using Vonage.Voice;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCliCodeSnippets.Voice
{
    public class RetrieveInfoForCall : ICodeSnippet
    {
        public async Task Execute()
        {
            var vonageApplicationId = Environment.GetEnvironmentVariable("VONAGE_APPLICATION_ID") ?? "VONAGE_APPLICATION_ID";
            var vonagePrivateKeyPath = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
            var uuid = Environment.GetEnvironmentVariable("UUID") ?? "UUID";

            var credentials = Credentials.FromAppIdAndPrivateKeyPath(vonageApplicationId, vonagePrivateKeyPath);
            var client = new VonageClient(credentials);

            var response = await client.VoiceClient.GetCallAsync(uuid);

            Console.WriteLine($"Call info retrieved for {response.Uuid}");
        }
    }
}
