using Vonage;
using Vonage.Request;
using Vonage.Voice;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCliCodeSnippets.Voice
{
    public class RetrieveInfoForCall : ICodeSnippet
    {
        public void Execute()
        {
            var VONAGE_APPLICATION_ID = Environment.GetEnvironmentVariable("VONAGE_APPLICATION_ID") ?? "VONAGE_APPLICATION_ID";
            var VONAGE_PRIVATE_KEY_PATH = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
            var UUID = Environment.GetEnvironmentVariable("UUID") ?? "UUID";

            var credentials = Credentials.FromAppIdAndPrivateKeyPath(VONAGE_APPLICATION_ID, VONAGE_PRIVATE_KEY_PATH);
            var client = new VonageClient(credentials);

            var response = client.VoiceClient.GetCall(UUID);

            Console.WriteLine($"Call info retrieved for {response.Uuid}");
        }
    }
}
