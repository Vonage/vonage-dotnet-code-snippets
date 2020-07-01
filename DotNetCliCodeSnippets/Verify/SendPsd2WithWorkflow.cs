using Nexmo.Api;
using Nexmo.Api.Request;
using Nexmo.Api.Verify;
using System;

namespace DotnetCliCodeSnippets.Verify
{
    public class SendPsd2WithWorkflow : ICodeSnippet
    {
        public void Execute()
        {
            var NEXMO_API_KEY = Environment.GetEnvironmentVariable("NEXMO_API_KEY") ?? "NEXMO_API_KEY";
            var NEXMO_API_SECRET = Environment.GetEnvironmentVariable("NEXMO_API_SECRET") ?? "NEXMO_API_SECRET";
            var RECIPIENT_NUMBER = Environment.GetEnvironmentVariable("RECIPIENT_NUMBER") ?? "RECIPIENT_NUMBER";
            var PAYEE = Environment.GetEnvironmentVariable("PAYEE") ?? "PAYEE";
            var AMOUNT = Double.Parse(Environment.GetEnvironmentVariable("Amount") ?? "5.0");

            var creds = Credentials.FromApiKeyAndSecret(NEXMO_API_KEY, NEXMO_API_SECRET);
            var client = new NexmoClient(creds);

            var request = new Psd2Request { Amount = AMOUNT, Payee = PAYEE, Number = RECIPIENT_NUMBER, WorkflowId = Psd2Request.Workflow.TTS };
            var response = client.VerifyClient.VerifyRequestWithPSD2(request);
        }
    }
}
