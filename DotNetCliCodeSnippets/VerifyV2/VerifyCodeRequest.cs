using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Request;

namespace DotnetCliCodeSnippets.VerifyV2;

public class VerifyCodeRequest : ICodeSnippet
{
    public async Task Execute()
    {
        var appId = Environment.GetEnvironmentVariable("VONAGE_APP_ID") ?? "VONAGE_APP_ID";
        var privateKeyPath = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
        var requestId = Guid.Parse(Environment.GetEnvironmentVariable("REQUEST_ID") ?? "REQUEST_ID");
        var verificationCode = Environment.GetEnvironmentVariable("VERIFICATION_CODE") ?? "VERIFICATION_CODE";
        var credentials = Credentials.FromAppIdAndPrivateKeyPath(appId, privateKeyPath);
        var client = new VonageClient(credentials);
        var request = Vonage.VerifyV2.VerifyCode.VerifyCodeRequest.Build()
            .WithRequestId(requestId)
            .WithCode(verificationCode)
            .Create();
        var response = await client.VerifyV2Client.VerifyCodeAsync(request);
        var message = response.Match(
            success => "Code verification succeeded.",
            failure => $"Code verification failed: {failure.GetFailureMessage()}");
        Console.WriteLine(message);
    }
}