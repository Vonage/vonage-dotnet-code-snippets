using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Request;
using Vonage.VerifyV2.StartVerification;
using Vonage.VerifyV2.StartVerification.Email;
using Vonage.VerifyV2.StartVerification.SilentAuth;
using Vonage.VerifyV2.StartVerification.Sms;
using Vonage.VerifyV2.StartVerification.WhatsApp;

namespace DotnetCliCodeSnippets.VerifyV2;

public class StartVerificationRequestWithFallback: ICodeSnippet
{
    public async Task Execute()
    {
        var TO_NUMBER = Environment.GetEnvironmentVariable("TO_NUMBER") ?? "TO_NUMBER";
        var TO_EMAIL = Environment.GetEnvironmentVariable("TO_EMAIL") ?? "TO_EMAIL";
        var BRAND_NAME = Environment.GetEnvironmentVariable("VONAGE_BRAND_NAME") ?? "VONAGE_BRAND_NAME";
        var VONAGE_APPLICATION_ID = Environment.GetEnvironmentVariable("VONAGE_APP_ID") ?? "VONAGE_APP_ID";
        var VONAGE_APPLICATION_PRIVATE_KEY_PATH = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
        var credentials = Credentials.FromAppIdAndPrivateKeyPath(VONAGE_APPLICATION_ID, VONAGE_APPLICATION_PRIVATE_KEY_PATH);
        var client = new VonageClient(credentials);
        var request = StartVerificationRequest.Build()
            .WithBrand(BRAND_NAME)
            .WithWorkflow(SilentAuthWorkflow.Parse(TO_NUMBER))
            .WithFallbackWorkflow(EmailWorkflow.Parse(TO_EMAIL))
            .Create();
        var response = await client.VerifyV2Client.StartVerificationAsync(request);
        var message = response.Match(
            success => $"Request verification succeeded - {success.RequestId}",
            failure => $"Request verification failed: {failure.GetFailureMessage()}");
        Console.WriteLine(message);
    }
}