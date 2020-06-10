using Nexmo.Api;
using Nexmo.Api.Redaction;
using Nexmo.Api.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCliCodeSnippets.Redact
{
    public class RedactTransaction : ICodeSnippet
    {
        public void Execute()
        {            
            var NEXMO_REDACT_ID = Environment.GetEnvironmentVariable("NEXMO_REDACT_ID") ?? "NEXMO_REDACT_ID";
            var type = Environment.GetEnvironmentVariable("NEXMO_REDACT_TYPE") ?? "NEXMO_REDACT_TYPE";
            var product = Environment.GetEnvironmentVariable("NEXMO_REDACT_PRODUCT") ?? "NEXMO_REDACT_PRODUCT";

            var NEXMO_API_KEY = Environment.GetEnvironmentVariable("NEXMO_API_KEY") ?? "NEXMO_API_KEY";
            var NEXMO_API_SECRET = Environment.GetEnvironmentVariable("NEXMO_API_SECRET") ?? "NEXMO_API_SECRET";
            
            var credentials = Credentials.FromApiKeyAndSecret(NEXMO_API_KEY, NEXMO_API_SECRET);
            var client = new NexmoClient(credentials);

            var NEXMO_REDACT_TYPE = Enum.Parse(typeof(RedactionType), type) as RedactionType?;
            var NEXMO_REDACT_PRODUCT = Enum.Parse(typeof(RedactionProduct), product) as RedactionProduct?;

            var request = new RedactRequest() { Id = NEXMO_REDACT_ID, Type = NEXMO_REDACT_TYPE, Product = NEXMO_REDACT_PRODUCT };
            var response = client.RedactClient.Redact(request);

            Console.WriteLine($"Redaction successful = {response}");
        }
    }
}
