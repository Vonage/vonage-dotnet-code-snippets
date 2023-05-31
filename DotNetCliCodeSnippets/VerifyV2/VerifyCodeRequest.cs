using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Request;

namespace DotnetCliCodeSnippets.VerifyV2;

public class VerifyCodeRequest : ICodeSnippet
{
    public async Task Execute()
    {
        var VONAGE_APPLICATION_ID = Environment.GetEnvironmentVariable("VONAGE_APP_ID") ?? "VONAGE_APP_ID";
        var VONAGE_APPLICATION_PRIVATE_KEY_PATH = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
        var REQUEST_ID = Guid.Parse(Environment.GetEnvironmentVariable("REQUEST_ID") ?? "REQUEST_ID");
        var CODE = Environment.GetEnvironmentVariable("VERIFICATION_CODE") ?? "VERIFICATION_CODE";
        var credentials = Credentials.FromAppIdAndPrivateKeyPath(VONAGE_APPLICATION_ID, VONAGE_APPLICATION_PRIVATE_KEY_PATH);
        var client = new VonageClient(credentials);
        var request = Vonage.VerifyV2.VerifyCode.VerifyCodeRequest.Build()
            .WithRequestId(REQUEST_ID)
            .WithCode(CODE)
            .Create();
        var response = await client.VerifyV2Client.VerifyCodeAsync(request);
        var message = response.Match(
            success => "Code verification succeeded.",
            failure => $"Code verification failed: {failure.GetFailureMessage()}");
        Console.WriteLine(message);
    }
}