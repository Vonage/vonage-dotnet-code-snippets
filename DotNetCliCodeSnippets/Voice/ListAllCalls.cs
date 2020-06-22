using Nexmo.Api;
using Nexmo.Api.Request;
using Nexmo.Api.Voice;
using System;

namespace DotnetCliCodeSnippets.Voice
{
    public class ListAllCalls : ICodeSnippet
    {
        public void Execute()
        {
            var NEXMO_APPLICATION_ID = Environment.GetEnvironmentVariable("NEXMO_APPLICATION_ID") ?? "NEXMO_APPLICATION_ID";
            var NEXMO_PRIVATE_KEY_PATH = Environment.GetEnvironmentVariable("NEXMO_PRIVATE_KEY_PATH") ?? "NEXMO_PRIVATE_KEY_PATH";
            
            var credentials = Credentials.FromAppIdAndPrivateKeyPath(NEXMO_APPLICATION_ID, NEXMO_PRIVATE_KEY_PATH);
            var client = new NexmoClient(credentials);

            var DATE_END = DateTime.UtcNow;
            var DATE_START = DATE_END.AddDays(-1);
            var request = new CallSearchFilter() { DateStart = DATE_START, DateEnd = DATE_END};

            var response = client.VoiceClient.GetCalls(request);
            Console.WriteLine(response.Count);            
        }
    }
}
