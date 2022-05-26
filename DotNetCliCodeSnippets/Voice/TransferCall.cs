using Vonage;
using Vonage.Request;
using Vonage.Voice;
using System;
using System.Threading.Tasks;

namespace DotnetCliCodeSnippets.Voice
{
    public class TransferCall : ICodeSnippet
    {
        public async Task Execute()
        {
            var vonageApplicationId = Environment.GetEnvironmentVariable("VONAGE_APPLICATION_ID") ?? "VONAGE_APPLICATION_ID";
            var vonagePrivateKeyPath = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
            var uuid = Environment.GetEnvironmentVariable("UUID") ?? "UUID";
            var nccoUrl = Environment.GetEnvironmentVariable("NCCO_URL") ?? "NCCO_URL";

            var credentials = Credentials.FromAppIdAndPrivateKeyPath(vonageApplicationId, vonagePrivateKeyPath);
            var client = new VonageClient(credentials);
            
            var callEditCommand = new CallEditCommand()
            {
                Action = CallEditCommand.ActionType.transfer,
                Destination = new Destination()
                {
                    Url = new[] { nccoUrl }
                }
            };

            var response = await client.VoiceClient.UpdateCallAsync(uuid, callEditCommand);

            Console.WriteLine($"Call transfer success: {response}");
        }
    }
}
