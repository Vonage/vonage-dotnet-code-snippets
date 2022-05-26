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
            var vonageApplicationId = Environment.GetEnvironmentVariable("VONAGE_APPLICATION_ID") ?? "VONAGE_APPLICATION_ID";
            var vonagePrivateKeyPath = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
            
            var credentials = Credentials.FromAppIdAndPrivateKeyPath(vonageApplicationId, vonagePrivateKeyPath);
            var client = new VonageClient(credentials);

            var dateEnd = DateTime.UtcNow;
            var dateStart = dateEnd.AddDays(-1);
            var request = new CallSearchFilter() { DateStart = dateStart, DateEnd = dateEnd};

            var response = await client.VoiceClient.GetCallsAsync(request);
            Console.WriteLine(response.Count);            
        }
    }
}
