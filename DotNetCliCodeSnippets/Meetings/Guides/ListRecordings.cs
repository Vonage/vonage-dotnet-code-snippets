using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Meetings.GetRecordings;
using Vonage.Request;

namespace DotnetCliCodeSnippets.Meetings.Guides;

public class ListRecordings : ICodeSnippet
{
    public async Task Execute()
    {
        var applicationId = Environment.GetEnvironmentVariable("VONAGE_APP_ID") ?? "VONAGE_APP_ID";
        var privateKeyPath = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
        var credentials = Credentials.FromAppIdAndPrivateKeyPath(applicationId, privateKeyPath);
        var client = new VonageClient(credentials);
        var request =
            GetRecordingsRequest.Parse("2_MX40NjMwODczMn5-MTU3NTgyODEwNzQ2MH5OZDJrVmdBRUNDbG5MUzNqNX20yQ1Z-fg");
        var response = await client.MeetingsClient.GetRecordingsAsync(request);
    }
}