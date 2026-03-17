#region

using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Request;

#endregion

namespace DotnetCliCodeSnippets.Voice;

public class StopTextToSpeech : ICodeSnippet
{
    public async Task Execute()
    {
        var VONAGE_APPLICATION_ID = Environment.GetEnvironmentVariable(VonageConstants.ApplicationId) ?? VonageConstants.ApplicationId;
        var VONAGE_PRIVATE_KEY_PATH = Environment.GetEnvironmentVariable(VonageConstants.PrivateKeyPath) ?? VonageConstants.PrivateKeyPath;
        var VOICE_CALL_ID = Environment.GetEnvironmentVariable("VOICE_CALL_ID") ?? "VOICE_CALL_ID";
        var credentials = Credentials.FromAppIdAndPrivateKeyPath(VONAGE_APPLICATION_ID, VONAGE_PRIVATE_KEY_PATH);
        var client = new VonageClient(credentials);
        var response = await client.VoiceClient.StopTalkAsync(VOICE_CALL_ID);
        Console.WriteLine($"Stop Text-To-Speech complete message: {response.Message}");
    }
}