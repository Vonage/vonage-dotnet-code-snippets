using Vonage;
using Vonage.Redaction;
using Vonage.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCliCodeSnippets.Redact
{
    public class RedactTransaction : ICodeSnippet
    {
        public void Execute()
        {            
            var VONAGE_REDACT_ID = Environment.GetEnvironmentVariable("VONAGE_REDACT_ID") ?? "VONAGE_REDACT_ID";
            var type = Environment.GetEnvironmentVariable("VONAGE_REDACT_TYPE") ?? "VONAGE_REDACT_TYPE";
            var product = Environment.GetEnvironmentVariable("VONAGE_REDACT_PRODUCT") ?? "VONAGE_REDACT_PRODUCT";

            var VONAGE_API_KEY = Environment.GetEnvironmentVariable("VONAGE_API_KEY") ?? "VONAGE_API_KEY";
            var VONAGE_API_SECRET = Environment.GetEnvironmentVariable("VONAGE_API_SECRET") ?? "VONAGE_API_SECRET";
            
            var credentials = Credentials.FromApiKeyAndSecret(VONAGE_API_KEY, VONAGE_API_SECRET);
            var client = new VonageClient(credentials);

            var VONAGE_REDACT_TYPE = Enum.Parse(typeof(RedactionType), type) as RedactionType?;
            var VONAGE_REDACT_PRODUCT = Enum.Parse(typeof(RedactionProduct), product) as RedactionProduct?;

            var request = new RedactRequest() { Id = VONAGE_REDACT_ID, Type = VONAGE_REDACT_TYPE, Product = VONAGE_REDACT_PRODUCT };
            var response = client.RedactClient.Redact(request);

            Console.WriteLine($"Redaction successful = {response}");
        }
    }
}
