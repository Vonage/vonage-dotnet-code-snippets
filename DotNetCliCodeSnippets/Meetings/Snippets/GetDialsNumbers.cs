using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Meetings.GetRecordings;
using Vonage.Request;

namespace DotnetCliCodeSnippets.Meetings.Snippets;

public class ListDialInNumbers: ICodeSnippet
{
    public async Task Execute()
    {
        var applicationId = Environment.GetEnvironmentVariable("VONAGE_APP_ID") ?? "VONAGE_APP_ID";
        var privateKeyPath = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
        var credentials = Credentials.FromAppIdAndPrivateKeyPath(applicationId, privateKeyPath);
        var client = new VonageClient(credentials);
        var response = await client.MeetingsClient.GetDialNumbersAsync();
        var message = response.Match(
            success => $"Numbers retrieved: {success.Length}",
            failure => $"Numbers retrieval failed: {failure.GetFailureMessage()}");
        Console.WriteLine(message);
    }
}