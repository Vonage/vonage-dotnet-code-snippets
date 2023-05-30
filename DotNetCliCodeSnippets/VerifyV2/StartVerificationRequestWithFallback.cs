using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Request;
using Vonage.VerifyV2.StartVerification;
using Vonage.VerifyV2.StartVerification.SilentAuth;
using Vonage.VerifyV2.StartVerification.Sms;
using Vonage.VerifyV2.StartVerification.WhatsApp;

namespace DotnetCliCodeSnippets.VerifyV2;

public class StartVerificationRequestWithFallback: ICodeSnippet
{
    public async Task Execute()
    {
        var to = Environment.GetEnvironmentVariable("TO_NUMBER") ?? "TO_NUMBER";
        var brandName = Environment.GetEnvironmentVariable("VONAGE_BRAND_NAME") ?? "VONAGE_BRAND_NAME";
        var appId = Environment.GetEnvironmentVariable("VONAGE_APP_ID") ?? "VONAGE_APP_ID";
        var privateKeyPath = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
        var credentials = Credentials.FromAppIdAndPrivateKeyPath(appId, privateKeyPath);
        var client = new VonageClient(credentials);
        var request = StartVerificationRequest.Build()
            .WithBrand(brandName)
            .WithWorkflow(SmsWorkflow.Parse(to))
            .WithFallbackWorkflow(WhatsAppWorkflow.Parse(to))
            .WithFallbackWorkflow(SilentAuthWorkflow.Parse(to))
            .Create();
        var response = await client.VerifyV2Client.StartVerificationAsync(request);
        var message = response.Match(
            success => $"Request verification succeeded - {success.RequestId}",
            failure => $"Request verification failed: {failure.GetFailureMessage()}");
        Console.WriteLine(message);
    }
}