using Nexmo.Api.Client;
using Nexmo.Api.Request;
using Nexmo.Api.Voice;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCliCodeSnippets.Voice
{
    public class RetrieveInfoForCall : ICodeSnippet
    {
        public void Execute()
        {
            var NEXMO_APPLICATION_ID = Environment.GetEnvironmentVariable("NEXMO_APPLICATION_ID") ?? "NEXMO_APPLICATION_ID";
            var NEXMO_PRIVATE_KEY_PATH = Environment.GetEnvironmentVariable("NEXMO_PRIVATE_KEY_PATH") ?? "NEXMO_PRIVATE_KEY_PATH";
            var UUID = Environment.GetEnvironmentVariable("UUID") ?? "UUID";

            var credentials = Credentials.FromAppIdAndPrivateKeyPath(NEXMO_APPLICATION_ID, NEXMO_PRIVATE_KEY_PATH);
            var client = new NexmoClient(credentials);

            var response = client.VoiceClient.GetCall(UUID);

            Console.WriteLine($"Call info retrieved for {response.Uuid}");
        }
    }
}
