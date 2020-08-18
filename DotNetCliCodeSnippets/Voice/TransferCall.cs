using Vonage;
using Vonage.Request;
using Vonage.Voice;
using System;

namespace DotnetCliCodeSnippets.Voice
{
    public class TransferCall : ICodeSnippet
    {
        public void Execute()
        {
            var VONAGE_APPLICATION_ID = Environment.GetEnvironmentVariable("VONAGE_APPLICATION_ID") ?? "VONAGE_APPLICATION_ID";
            var VONAGE_PRIVATE_KEY_PATH = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
            var UUID = Environment.GetEnvironmentVariable("UUID") ?? "UUID";
            var NCCO_URL = Environment.GetEnvironmentVariable("NCCO_URL") ?? "NCCO_URL";

            var credentials = Credentials.FromAppIdAndPrivateKeyPath(VONAGE_APPLICATION_ID, VONAGE_PRIVATE_KEY_PATH);
            var client = new VonageClient(credentials);
            
            var callEditCommand = new CallEditCommand()
            {
                Action = CallEditCommand.ActionType.transfer,
                Destination = new Destination()
                {
                    Url = new[] { NCCO_URL }
                }
            };

            var response = client.VoiceClient.UpdateCall(UUID, callEditCommand);

            Console.WriteLine($"Call transfer success: {response}");
        }
    }
}
