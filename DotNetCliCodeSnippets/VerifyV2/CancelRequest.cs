using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Request;

namespace DotnetCliCodeSnippets.VerifyV2;

public class CancelRequest : ICodeSnippet
{
    public async Task Execute()
    {
        var VONAGE_APPLICATION_ID = Environment.GetEnvironmentVariable("VONAGE_APP_ID") ?? "VONAGE_APP_ID";
        var VONAGE_APPLICATION_PRIVATE_KEY_PATH = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
        var REQUEST_ID = Guid.Parse(Environment.GetEnvironmentVariable("REQUEST_ID") ?? "REQUEST_ID");
        var credentials = Credentials.FromAppIdAndPrivateKeyPath(VONAGE_APPLICATION_ID, VONAGE_APPLICATION_PRIVATE_KEY_PATH);
        var client = new VonageClient(credentials);
        var request = Vonage.VerifyV2.Cancel.CancelRequest.Parse(REQUEST_ID);
        var response = await client.VerifyV2Client.CancelAsync(request);
        var message = response.Match(
            success => "Request has been cancelled",
            failure => $"Request couldn't be cancelled: {failure.GetFailureMessage()}");
        Console.WriteLine(message);
    }
}