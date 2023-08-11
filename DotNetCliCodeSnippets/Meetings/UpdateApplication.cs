using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Meetings.UpdateApplication;
using Vonage.Request;

namespace DotnetCliCodeSnippets.Meetings;

public class UpdateApplication : ICodeSnippet
{
    public async Task Execute()
    {
        var applicationId = Environment.GetEnvironmentVariable("VONAGE_APP_ID") ?? "VONAGE_APP_ID";
        var privateKeyPath = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
        var themeId = Guid.Parse(Environment.GetEnvironmentVariable("THEME_ID") ?? "THEME_ID");
        var credentials = Credentials.FromAppIdAndPrivateKeyPath(applicationId, privateKeyPath);
        var client = new VonageClient(credentials);
        var request = UpdateApplicationRequest.Parse(themeId);
        var response = await client.MeetingsClient.UpdateApplicationAsync(request);
        var message = response.Match(
            success => $"Application was updated: {success.DefaultThemeId}",
            failure => $"Application update failed: {failure.GetFailureMessage()}");
        Console.WriteLine(message);
    }
}