using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Request;
using Vonage.VerifyV2;
using Vonage.VerifyV2.StartVerification;

namespace DotnetCliCodeSnippets.VerifyV2;

public class CreateTemplateFragmentRequest : ICodeSnippet
{
    public async Task Execute()
    {
        var VONAGE_APPLICATION_ID = Environment.GetEnvironmentVariable("VONAGE_APP_ID") ?? "VONAGE_APP_ID";
        var VONAGE_APPLICATION_PRIVATE_KEY_PATH = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
        var TEMPLATE_ID = Guid.Parse(Environment.GetEnvironmentVariable("TEMPLATE_ID") ?? "TEMPLATE_ID");
        var credentials = Credentials.FromAppIdAndPrivateKeyPath(VONAGE_APPLICATION_ID, VONAGE_APPLICATION_PRIVATE_KEY_PATH);
        var client = new VonageClient(credentials);
        var request = Vonage.VerifyV2.CreateTemplateFragment.CreateTemplateFragmentRequest.Build()
            .WithTemplateId(TEMPLATE_ID)
            .WithText("The authentication code for your ${brand} is: ${code}")
            .WithLocale(Locale.EnUs)
            .WithChannel(VerificationChannel.Sms)
            .Create();
        var response = await client.VerifyV2Client.CreateTemplateFragmentAsync(request);
        var message = response.Match(
            success => $"Fragment has been created: {success.TemplateFragmentId}",
            failure => $"Fragment couldn't be created: {failure.GetFailureMessage()}");
        Console.WriteLine(message);
    }
}