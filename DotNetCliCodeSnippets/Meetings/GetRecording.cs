using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Meetings.GetRecording;
using Vonage.Request;

namespace DotnetCliCodeSnippets.Meetings;

public class GetRecording : ICodeSnippet
{
    public async Task Execute()
    {
        var applicationId = Environment.GetEnvironmentVariable("VONAGE_APP_ID") ?? "VONAGE_APP_ID";
        var privateKeyPath = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
        var recordingId = Guid.Parse(Environment.GetEnvironmentVariable("RECORDING_ID") ?? "RECORDING_ID");
        var credentials = Credentials.FromAppIdAndPrivateKeyPath(applicationId, privateKeyPath);
        var client = new VonageClient(credentials);
        var request = GetRecordingRequest.Parse(recordingId);
        var response = await client.MeetingsClient.GetRecordingAsync(request);
        var message = response.Match(
            success => $"Recording retrieved: {success.Id}",
            failure => $"Recording retrieval failed: {failure.GetFailureMessage()}");
        Console.WriteLine(message);
    }
}