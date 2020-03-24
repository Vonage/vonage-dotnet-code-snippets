using Nexmo.Api.Client;
using Nexmo.Api.Request;
using Nexmo.Api.Voice;
using Nexmo.Api.Voice.Nccos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCliCodeSnippets.Voice
{
    public class TransferCallNcco : ICodeSnippet
    {
        public void Execute()
        {
            var NEXMO_APPLICATION_ID = Environment.GetEnvironmentVariable("NEXMO_APPLICATION_ID") ?? "NEXMO_APPLICATION_ID";
            var NEXMO_PRIVATE_KEY_PATH = Environment.GetEnvironmentVariable("NEXMO_PRIVATE_KEY_PATH") ?? "NEXMO_PRIVATE_KEY_PATH";
            var UUID = Environment.GetEnvironmentVariable("UUID") ?? "UUID";            

            var credentials = Credentials.FromAppIdAndPrivateKeyPath(NEXMO_APPLICATION_ID, NEXMO_PRIVATE_KEY_PATH);
            var client = new NexmoClient(credentials);

            var talkAction = new TalkAction() { Text = "This is a transfer action using an inline NCCO" };
            var ncco = new Ncco(talkAction);
            var callEditCommand = new CallEditCommand() 
            { 
                Action = CallEditCommand.ActionType.transfer, 
                Destination = new Destination() 
                { 
                    Ncco = ncco
                } 
            };

            var response = client.VoiceClient.UpdateCall(UUID, callEditCommand);

            Console.WriteLine($"Call transfer success: {response}");
        }
    }
}
