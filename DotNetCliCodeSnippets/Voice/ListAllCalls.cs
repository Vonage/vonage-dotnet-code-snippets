using Vonage;
using Vonage.Request;
using Vonage.Voice;
using System;

namespace DotnetCliCodeSnippets.Voice
{
    public class ListAllCalls : ICodeSnippet
    {
        public void Execute()
        {
            var VONAGE_APPLICATION_ID = Environment.GetEnvironmentVariable("VONAGE_APPLICATION_ID") ?? "VONAGE_APPLICATION_ID";
            var VONAGE_PRIVATE_KEY_PATH = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
            
            var credentials = Credentials.FromAppIdAndPrivateKeyPath(VONAGE_APPLICATION_ID, VONAGE_PRIVATE_KEY_PATH);
            var client = new VonageClient(credentials);

            var DATE_END = DateTime.UtcNow;
            var DATE_START = DATE_END.AddDays(-1);
            var request = new CallSearchFilter() { DateStart = DATE_START, DateEnd = DATE_END};

            var response = client.VoiceClient.GetCalls(request);
            Console.WriteLine(response.Count);            
        }
    }
}
