using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Meetings.GetRecordings;
using Vonage.Request;

namespace DotnetCliCodeSnippets.Meetings.Snippets;

public class GetRecordings : ICodeSnippet
{
    public async Task Execute()
    {
        var applicationId = Environment.GetEnvironmentVariable("VONAGE_APP_ID") ?? "VONAGE_APP_ID";
        var privateKeyPath = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
        var sessionId = Environment.GetEnvironmentVariable("SESSION_ID") ?? "SESSION_ID";
        var credentials = Credentials.FromAppIdAndPrivateKeyPath(applicationId, privateKeyPath);
        var client = new VonageClient(credentials);
        var request = GetRecordingsRequest.Parse(sessionId);
        var response = await client.MeetingsClient.GetRecordingsAsync(request);
        var message = response.Match(
            success => $"Recordings retrieved: {success.Embedded}",
            failure => $"Recordings retrieval failed: {failure.GetFailureMessage()}");
        Console.WriteLine(message);
    }
}