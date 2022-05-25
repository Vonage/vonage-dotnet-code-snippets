using Vonage;
using Vonage.Redaction;
using Vonage.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCliCodeSnippets.Redact
{
    public class RedactTransaction : ICodeSnippet
    {
        public async Task Execute()
        {            
            var vonageRedactId = Environment.GetEnvironmentVariable("VONAGE_REDACT_ID") ?? "VONAGE_REDACT_ID";
            var type = Environment.GetEnvironmentVariable("VONAGE_REDACT_TYPE") ?? "VONAGE_REDACT_TYPE";
            var product = Environment.GetEnvironmentVariable("VONAGE_REDACT_PRODUCT") ?? "VONAGE_REDACT_PRODUCT";

            var vonageApiKey = Environment.GetEnvironmentVariable("VONAGE_API_KEY") ?? "VONAGE_API_KEY";
            var vonageApiSecret = Environment.GetEnvironmentVariable("VONAGE_API_SECRET") ?? "VONAGE_API_SECRET";
            
            var credentials = Credentials.FromApiKeyAndSecret(vonageApiKey, vonageApiSecret);
            var client = new VonageClient(credentials);

            var vonageRedactType = Enum.Parse(typeof(RedactionType), type) as RedactionType?;
            var vonageRedactProduct = Enum.Parse(typeof(RedactionProduct), product) as RedactionProduct?;

            var request = new RedactRequest() { Id = vonageRedactId, Type = vonageRedactType, Product = vonageRedactProduct };
            var response = await client.RedactClient.RedactAsync(request);

            Console.WriteLine($"Redaction successful = {response}");
        }
    }
}
