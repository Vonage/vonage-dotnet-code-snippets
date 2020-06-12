using Nexmo.Api;
using Nexmo.Api.Request;
using Nexmo.Api.Voice;
using Nexmo.Api.Voice.Nccos.Endpoints;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCliCodeSnippets.Voice
{
    public class MakeOutboundCall : ICodeSnippet
    {
        public void Execute()
        {
            var NEXMO_APPLICATION_ID = Environment.GetEnvironmentVariable("NEXMO_APPLICATION_ID") ?? "NEXMO_APPLICATION_ID";
            var NEXMO_PRIVATE_KEY_PATH = Environment.GetEnvironmentVariable("NEXMO_PRIVATE_KEY_PATH") ?? "NEXMO_PRIVATE_KEY_PATH";
            var TO_NUMBER = Environment.GetEnvironmentVariable("TO_NUMBER") ?? "TO_NUMBER";
            var NEXMO_NUMBER = Environment.GetEnvironmentVariable("NEXMO_NUMBER") ?? "NEXMO_NUMBER";
            var ANSWER_URL = Environment.GetEnvironmentVariable("ANSWER_URL") ?? "ANSWER_URL";

            var toEndpoint = new PhoneEndpoint() { Number = TO_NUMBER };
            var fromEndpoint = new PhoneEndpoint() { Number = NEXMO_NUMBER };                        

            var creds = Credentials.FromAppIdAndPrivateKeyPath(NEXMO_APPLICATION_ID, NEXMO_PRIVATE_KEY_PATH);
            var client = new NexmoClient(creds);

            var command = new CallCommand() { To = new Endpoint[] { toEndpoint }, From = fromEndpoint, AnswerUrl = new[] { ANSWER_URL } };
            var response = client.VoiceClient.CreateCall(command);

            Console.WriteLine($"Call Created with call uuid: {response.Uuid}");
        }
    }
}
