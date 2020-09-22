using Vonage;
using Vonage.Request;
using Vonage.Voice;
using Vonage.Voice.Nccos.Endpoints;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCliCodeSnippets.Voice
{
    public class MakeOutboundCall : ICodeSnippet
    {
        public void Execute()
        {
            var VONAGE_APPLICATION_ID = Environment.GetEnvironmentVariable("VONAGE_APPLICATION_ID") ?? "VONAGE_APPLICATION_ID";
            var VONAGE_PRIVATE_KEY_PATH = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
            var TO_NUMBER = Environment.GetEnvironmentVariable("TO_NUMBER") ?? "TO_NUMBER";
            var VONAGE_NUMBER = Environment.GetEnvironmentVariable("VONAGE_NUMBER") ?? "VONAGE_NUMBER";
            var ANSWER_URL = Environment.GetEnvironmentVariable("ANSWER_URL") ?? "ANSWER_URL";

            var toEndpoint = new PhoneEndpoint() { Number = TO_NUMBER };
            var fromEndpoint = new PhoneEndpoint() { Number = VONAGE_NUMBER };                        

            var creds = Credentials.FromAppIdAndPrivateKeyPath(VONAGE_APPLICATION_ID, VONAGE_PRIVATE_KEY_PATH);
            var client = new VonageClient(creds);

            var command = new CallCommand() { To = new Endpoint[] { toEndpoint }, From = fromEndpoint, AnswerUrl = new[] { ANSWER_URL } };
            var response = client.VoiceClient.CreateCall(command);

            Console.WriteLine($"Call Created with call uuid: {response.Uuid}");
        }
    }
}
