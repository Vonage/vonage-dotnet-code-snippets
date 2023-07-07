using System;
using System.Drawing;
using System.Threading.Tasks;
using Vonage;
using Vonage.Meetings.CreateTheme;
using Vonage.Request;

namespace DotnetCliCodeSnippets.Meetings.Snippets;

public class CreateTheme : ICodeSnippet
{
    public async Task Execute()
    {
        var applicationId = Environment.GetEnvironmentVariable("VONAGE_APP_ID") ?? "VONAGE_APP_ID";
        var privateKeyPath = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
        var mainColor = Color.FromName(Environment.GetEnvironmentVariable("MAIN_COLOR") ?? "MAIN_COLOR");
        var brandText = Environment.GetEnvironmentVariable("BRAND_TEXT") ?? "BRAND_TEXT";
        var credentials = Credentials.FromAppIdAndPrivateKeyPath(applicationId, privateKeyPath);
        var client = new VonageClient(credentials);
        var request = CreateThemeRequest.Build()
            .WithBrand(brandText)
            .WithColor(mainColor)
            .Create();
        var response = await client.MeetingsClient.CreateThemeAsync(request);
        var message = response.Match(
            success => $"Theme has been created: {success.ThemeId}",
            failure => $"Theme creation failed: {failure.GetFailureMessage()}");
        Console.WriteLine(message);
    }
}