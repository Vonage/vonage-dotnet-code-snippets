using System;
using System.Drawing;
using System.Threading.Tasks;
using Vonage;
using Vonage.Meetings.UpdateTheme;
using Vonage.Request;

namespace DotnetCliCodeSnippets.Meetings;

public class UpdateTheme : ICodeSnippet
{
    public async Task Execute()
    {
        var applicationId = Environment.GetEnvironmentVariable("VONAGE_APP_ID") ?? "VONAGE_APP_ID";
        var privateKeyPath = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
        var themeId = Guid.Parse(Environment.GetEnvironmentVariable("THEME_ID") ?? "THEME_ID");
        var mainColor = Color.FromName(Environment.GetEnvironmentVariable("MAIN_COLOR") ?? "MAIN_COLOR");
        var brandText = Environment.GetEnvironmentVariable("BRAND_TEXT") ?? "BRAND_TEXT";
        var credentials = Credentials.FromAppIdAndPrivateKeyPath(applicationId, privateKeyPath);
        var client = new VonageClient(credentials);
        var request = UpdateThemeRequest.Build()
            .WithThemeId(themeId)
            .WithColor(mainColor)
            .WithBrandText(brandText)
            .Create();
        var response = await client.MeetingsClient.UpdateThemeAsync(request);
        var message = response.Match(
            success => $"Theme updated: {success.ThemeId}",
            failure => $"Theme update failed: {failure.GetFailureMessage()}");
        Console.WriteLine(message);
    }
}