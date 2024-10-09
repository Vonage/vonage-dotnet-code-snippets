#region

using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Request;

#endregion

namespace DotnetCliCodeSnippets.VerifyV2;

public class GetTemplateFragmentsRequest : ICodeSnippet
{
    public async Task Execute()
    {
        var VONAGE_APPLICATION_ID = Environment.GetEnvironmentVariable("VONAGE_APP_ID") ?? "VONAGE_APP_ID";
        var VONAGE_APPLICATION_PRIVATE_KEY_PATH = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
        var TEMPLATE_ID = Guid.Parse(Environment.GetEnvironmentVariable("TEMPLATE_ID") ?? "TEMPLATE_ID");
        var credentials =
            Credentials.FromAppIdAndPrivateKeyPath(VONAGE_APPLICATION_ID, VONAGE_APPLICATION_PRIVATE_KEY_PATH);
        var client = new VonageClient(credentials);
        var request = Vonage.VerifyV2.GetTemplateFragments.GetTemplateFragmentsRequest.Build()
            .WithTemplateId(TEMPLATE_ID)
            .Create();
        var response = await client.VerifyV2Client.GetTemplateFragmentsAsync(request);
        var message = response.Match(
            success => $"Fragments has been retrieved: {success.TotalItems}",
            failure => $"Fragments couldn't be retrieved: {failure.GetFailureMessage()}");
        Console.WriteLine(message);
    }
}