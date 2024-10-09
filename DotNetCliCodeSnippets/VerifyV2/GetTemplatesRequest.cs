#region

using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Request;

#endregion

namespace DotnetCliCodeSnippets.VerifyV2;

public class GetTemplatesRequest : ICodeSnippet
{
    public async Task Execute()
    {
        var VONAGE_APPLICATION_ID = Environment.GetEnvironmentVariable("VONAGE_APP_ID") ?? "VONAGE_APP_ID";
        var VONAGE_APPLICATION_PRIVATE_KEY_PATH = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ??
                                                  "VONAGE_PRIVATE_KEY_PATH";
        var credentials =
            Credentials.FromAppIdAndPrivateKeyPath(VONAGE_APPLICATION_ID, VONAGE_APPLICATION_PRIVATE_KEY_PATH);
        var client = new VonageClient(credentials);
        var request = Vonage.VerifyV2.GetTemplates.GetTemplatesRequest.Build()
            .Create();
        var response = await client.VerifyV2Client.GetTemplatesAsync(request);
        var message = response.Match(
            success => $"Templates has been retrieved: {success.TotalItems}",
            failure => $"Templates couldn't be retrieved: {failure.GetFailureMessage()}");
        Console.WriteLine(message);
    }
}