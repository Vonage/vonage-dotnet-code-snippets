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
            var VONAGE_APPLICATION_ID = Environment.GetEnvironmentVariable("VONAGE_APPLICATION_ID") ?? "VONAGE_APPLICATION_ID";
            var VONAGE_PRIVATE_KEY_PATH = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
            var VOICE_CALL_ID = Environment.GetEnvironmentVariable("VOICE_CALL_ID") ?? "VOICE_CALL_ID";
            var VOICE_NCCO_URL = Environment.GetEnvironmentVariable("VOICE_NCCO_URL") ?? "VOICE_NCCO_URL";

            var credentials = Credentials.FromAppIdAndPrivateKeyPath(VONAGE_APPLICATION_ID, VONAGE_PRIVATE_KEY_PATH);
            var client = new VonageClient(credentials);
            
            var callEditCommand = new CallEditCommand()
            {
                Action = CallEditCommand.ActionType.transfer,
                Destination = new Destination()
                {
                    Url = new[] { VOICE_NCCO_URL }
                }
            };

            var response = await client.VoiceClient.UpdateCallAsync(VOICE_CALL_ID, callEditCommand);

            Console.WriteLine($"Call transfer success: {response}");
        }
    }
}
