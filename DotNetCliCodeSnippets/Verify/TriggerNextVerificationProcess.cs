﻿using Vonage;
using Vonage.Request;
using Vonage.Verify;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCliCodeSnippets.Verify
{
    public class TriggerNextVerificationProcess : ICodeSnippet
    {
        public void Execute()
        {
            var VONAGE_API_KEY = Environment.GetEnvironmentVariable("VONAGE_API_KEY") ?? "VONAGE_API_KEY";
            var VONAGE_API_SECRET = Environment.GetEnvironmentVariable("VONAGE_API_SECRET") ?? "VONAGE_API_SECRET";
            var REQUEST_ID = Environment.GetEnvironmentVariable("REQUEST_ID") ?? "REQUEST_ID";

            var credentials = Credentials.FromApiKeyAndSecret(VONAGE_API_KEY, VONAGE_API_SECRET);
            var client = new VonageClient(credentials);
            var request = new VerifyControlRequest() { RequestId = REQUEST_ID, Cmd = "trigger_next_event" };

            var response = client.VerifyClient.VerifyControl(request);
            Console.WriteLine($"Next Verify Request Triggered\nStatus:{response.Status}");
        }
    }
}
