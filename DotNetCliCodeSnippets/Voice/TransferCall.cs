using Nexmo.Api;
using Nexmo.Api.Request;
using Nexmo.Api.Voice;
using System;

namespace DotnetCliCodeSnippets.Voice
{
    public class TransferCall : ICodeSnippet
    {
        public void Execute()
        {
            var NEXMO_APPLICATION_ID = Environment.GetEnvironmentVariable("NEXMO_APPLICATION_ID") ?? "NEXMO_APPLICATION_ID";
            var NEXMO_PRIVATE_KEY_PATH = Environment.GetEnvironmentVariable("NEXMO_PRIVATE_KEY_PATH") ?? "NEXMO_PRIVATE_KEY_PATH";
            var UUID = Environment.GetEnvironmentVariable("UUID") ?? "UUID";
            var NCCO_URL = Environment.GetEnvironmentVariable("NCCO_URL") ?? "NCCO_URL";

            var credentials = Credentials.FromAppIdAndPrivateKeyPath(NEXMO_APPLICATION_ID, NEXMO_PRIVATE_KEY_PATH);
            var client = new NexmoClient(credentials);
            
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
