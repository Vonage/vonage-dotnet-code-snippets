using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Meetings.DeleteRecording;
using Vonage.Request;

namespace DotnetCliCodeSnippets.Meetings.Snippets;

public class DeleteRecording : ICodeSnippet
{
    public async Task Execute()
    {
        var applicationId = Environment.GetEnvironmentVariable("VONAGE_APP_ID") ?? "VONAGE_APP_ID";
        var privateKeyPath = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
        var recordingId = Guid.Parse(Environment.GetEnvironmentVariable("RECORDING_ID") ?? "RECORDING_ID");
        var credentials = Credentials.FromAppIdAndPrivateKeyPath(applicationId, privateKeyPath);
        var client = new VonageClient(credentials);
        var request = DeleteRecordingRequest.Parse(recordingId);
        var response = await client.MeetingsClient.DeleteRecordingAsync(request);
        var message = response.Match(
            success => "Recording deleted",
            failure => $"Recording deletion failed: {failure.GetFailureMessage()}");
        Console.WriteLine(message);
    }
}