﻿using Vonage;
using Vonage.Request;
using Vonage.Verify;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCliCodeSnippets.Verify
{
    public class CheckVerificationRequest : ICodeSnippet
    {
        public void Execute()
        {
            var VONAGE_API_KEY = Environment.GetEnvironmentVariable("VONAGE_API_KEY") ?? "VONAGE_API_KEY";
            var VONAGE_API_SECRET = Environment.GetEnvironmentVariable("VONAGE_API_SECRET") ?? "VONAGE_API_SECRET";
            var REQUEST_ID = Environment.GetEnvironmentVariable("REQUEST_ID") ?? "REQUEST_ID";
            var CODE = Environment.GetEnvironmentVariable("CODE") ?? "CODE";

            var credentials = Credentials.FromApiKeyAndSecret(VONAGE_API_KEY, VONAGE_API_SECRET);
            var client = new VonageClient(credentials);

            var request = new VerifyCheckRequest() { Code = CODE, RequestId = REQUEST_ID };
            var response = client.VerifyClient.VerifyCheck(request);

            Console.WriteLine($"Verify Check Complete\nRequest Id:{response.RequestId}\nStatus:{response.Status}");
        }
    }
}
