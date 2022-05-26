using Vonage;
using Vonage.Request;
using Vonage.Voice;
using Vonage.Voice.Nccos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCliCodeSnippets.Voice
{
    public class TransferCallNcco : ICodeSnippet
    {
        public async Task Execute()
        {
            var vonageApplicationId = Environment.GetEnvironmentVariable("VONAGE_APPLICATION_ID") ?? "VONAGE_APPLICATION_ID";
            var vonagePrivateKeyPath = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
            var uuid = Environment.GetEnvironmentVariable("UUID") ?? "UUID";            

            var credentials = Credentials.FromAppIdAndPrivateKeyPath(vonageApplicationId, vonagePrivateKeyPath);
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

            var response = await client.VoiceClient.UpdateCallAsync(uuid, callEditCommand);

            Console.WriteLine($"Call transfer success: {response}");
        }
    }
}
