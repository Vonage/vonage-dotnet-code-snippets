using Vonage;
using Vonage.Request;
using Vonage.Voice;
using Vonage.Voice.Nccos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCliCodeSnippets.Voice
{
    public class TransferCallNcco : ICodeSnippet
    {
        public void Execute()
        {
            var VONAGE_APPLICATION_ID = Environment.GetEnvironmentVariable("VONAGE_APPLICATION_ID") ?? "VONAGE_APPLICATION_ID";
            var VONAGE_PRIVATE_KEY_PATH = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
            var UUID = Environment.GetEnvironmentVariable("UUID") ?? "UUID";            

            var credentials = Credentials.FromAppIdAndPrivateKeyPath(VONAGE_APPLICATION_ID, VONAGE_PRIVATE_KEY_PATH);
            var client = new VonageClient(credentials);

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
