using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Request;

namespace DotnetCliCodeSnippets.VerifyV2;

public class GetTemplateRequest : ICodeSnippet
{
    public async Task Execute()
    {
        var VONAGE_APPLICATION_ID = Environment.GetEnvironmentVariable("VONAGE_APP_ID") ?? "VONAGE_APP_ID";
        var VONAGE_APPLICATION_PRIVATE_KEY_PATH = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
        var TEMPLATE_ID = Guid.Parse(Environment.GetEnvironmentVariable("TEMPLATE_ID") ?? "TEMPLATE_ID");
        var credentials = Credentials.FromAppIdAndPrivateKeyPath(VONAGE_APPLICATION_ID, VONAGE_APPLICATION_PRIVATE_KEY_PATH);
        var client = new VonageClient(credentials);
        var request = Vonage.VerifyV2.GetTemplate.GetTemplateRequest.Parse(TEMPLATE_ID);
        var response = await client.VerifyV2Client.GetTemplateAsync(request);
        var message = response.Match(
            success => $"Template has been retrieved: {success.TemplateId}",
            failure => $"Template couldn't be retrieved: {failure.GetFailureMessage()}");
        Console.WriteLine(message);
    }
}