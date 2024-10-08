using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Request;

namespace DotnetCliCodeSnippets.VerifyV2;

public class UpdateTemplateRequest : ICodeSnippet
{
    public async Task Execute()
    {
        var VONAGE_APPLICATION_ID = Environment.GetEnvironmentVariable("VONAGE_APP_ID") ?? "VONAGE_APP_ID";
        var VONAGE_APPLICATION_PRIVATE_KEY_PATH = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
        var TEMPLATE_ID = Guid.Parse(Environment.GetEnvironmentVariable("TEMPLATE_ID") ?? "TEMPLATE_ID");
        var credentials = Credentials.FromAppIdAndPrivateKeyPath(VONAGE_APPLICATION_ID, VONAGE_APPLICATION_PRIVATE_KEY_PATH);
        var client = new VonageClient(credentials);
        var request = Vonage.VerifyV2.UpdateTemplate.UpdateTemplateRequest.Build()
            .WithId(TEMPLATE_ID)
            .WithName("my-renamed-template")
            .SetAsNonDefaultTemplate()
            .Create();
        var response = await client.VerifyV2Client.UpdateTemplateAsync(request);
        var message = response.Match(
            success => $"Template has been updated: {success.TemplateId}",
            failure => $"Template couldn't be updated: {failure.GetFailureMessage()}");
        Console.WriteLine(message);
    }
}