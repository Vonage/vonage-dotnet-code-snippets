using Nexmo.Api;
using Nexmo.Api.Request;
using Nexmo.Api.Verify;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCliCodeSnippets.Verify
{
    public class TriggerNextVerificationProcess : ICodeSnippet
    {
        public void Execute()
        {
            var NEXMO_API_KEY = Environment.GetEnvironmentVariable("NEXMO_API_KEY") ?? "NEXMO_API_KEY";
            var NEXMO_API_SECRET = Environment.GetEnvironmentVariable("NEXMO_API_SECRET") ?? "NEXMO_API_SECRET";
            var REQUEST_ID = Environment.GetEnvironmentVariable("REQUEST_ID") ?? "REQUEST_ID";

            var credentials = Credentials.FromApiKeyAndSecret(NEXMO_API_KEY, NEXMO_API_SECRET);
            var client = new NexmoClient(credentials);
            var request = new VerifyControlRequest() { RequestId = REQUEST_ID, Cmd = "trigger_next_event" };

            var response = client.VerifyClient.VerifyControl(request);
            Console.WriteLine($"Next Verify Request Triggered\nStatus:{response.Status}");
        }
    }
}
