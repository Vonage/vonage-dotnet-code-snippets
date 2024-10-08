using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Request;

namespace DotnetCliCodeSnippets.VerifyV2;

public class UpdateTemplateFragmentRequest : ICodeSnippet
{
    public async Task Execute()
    {
        var VONAGE_APPLICATION_ID = Environment.GetEnvironmentVariable("VONAGE_APP_ID") ?? "VONAGE_APP_ID";
        var VONAGE_APPLICATION_PRIVATE_KEY_PATH = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
        var TEMPLATE_ID = Guid.Parse(Environment.GetEnvironmentVariable("TEMPLATE_ID") ?? "TEMPLATE_ID");
        var TEMPLATE_FRAGMENT_ID = Guid.Parse(Environment.GetEnvironmentVariable("TEMPLATE_FRAGMENT_ID") ?? "TEMPLATE_FRAGMENT_ID");
        var credentials = Credentials.FromAppIdAndPrivateKeyPath(VONAGE_APPLICATION_ID, VONAGE_APPLICATION_PRIVATE_KEY_PATH);
        var client = new VonageClient(credentials);
        var request = Vonage.VerifyV2.UpdateTemplateFragment.UpdateTemplateFragmentRequest.Build()
            .WithId(TEMPLATE_ID)
            .WithFragmentId(TEMPLATE_FRAGMENT_ID)
            .WithText("The authentication code for your ${brand} is: ${code}")
            .Create();
        var response = await client.VerifyV2Client.UpdateTemplateFragmentAsync(request);
        var message = response.Match(
            success => $"Fragment has been updated: {success.TemplateFragmentId}",
            failure => $"Fragment couldn't be updated: {failure.GetFailureMessage()}");
        Console.WriteLine(message);
    }
}