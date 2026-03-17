using Vonage;
using Vonage.Request;
using Vonage.Voice;
using System;
using System.Threading.Tasks;

namespace DotnetCliCodeSnippets.Voice
{
    public class ListAllCalls : ICodeSnippet
    {
        public async Task Execute()
        {
            var VONAGE_APPLICATION_ID = Environment.GetEnvironmentVariable(VonageConstants.ApplicationId) ?? VonageConstants.ApplicationId;
            var VONAGE_PRIVATE_KEY_PATH = Environment.GetEnvironmentVariable(VonageConstants.PrivateKeyPath) ?? VonageConstants.PrivateKeyPath;
            
            var credentials = Credentials.FromAppIdAndPrivateKeyPath(VONAGE_APPLICATION_ID, VONAGE_PRIVATE_KEY_PATH);
            var client = new VonageClient(credentials);

            var dateEnd = DateTime.UtcNow;
            var dateStart = dateEnd.AddDays(-1);
            var request = new CallSearchFilter() { DateStart = dateStart, DateEnd = dateEnd};

            var response = await client.VoiceClient.GetCallsAsync(request);
            Console.WriteLine(response.Count);            
        }
    }
}
