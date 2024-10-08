using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Request;

namespace DotnetCliCodeSnippets.VerifyV2;

public class CreateTemplateRequest: ICodeSnippet
{
    public async Task Execute()
    {
        var VONAGE_APPLICATION_ID = Environment.GetEnvironmentVariable("VONAGE_APP_ID") ?? "VONAGE_APP_ID";
        var VONAGE_APPLICATION_PRIVATE_KEY_PATH = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
        var credentials = Credentials.FromAppIdAndPrivateKeyPath(VONAGE_APPLICATION_ID, VONAGE_APPLICATION_PRIVATE_KEY_PATH);
        var client = new VonageClient(credentials);
        var request = Vonage.VerifyV2.CreateTemplate.CreateTemplateRequest.Build()
            .WithName("my-custom-template")
            .Create();
        var response = await client.VerifyV2Client.CreateTemplateAsync(request);
        var message = response.Match(
            success => $"Template has been created: {success.TemplateId}",
            failure => $"Template couldn't be created: {failure.GetFailureMessage()}");
        Console.WriteLine(message);
    }
}