using Vonage;
using Vonage.Request;
using Vonage.Applications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DotnetCliCodeSnippets.Application
{
    public class ListApplications : ICodeSnippet
    {
        public async Task Execute()
        {
            var vonageApiKey = Environment.GetEnvironmentVariable("VONAGE_API_KEY") ?? "VONAGE_API_KEY";
            var vonageApiSecret = Environment.GetEnvironmentVariable("VONAGE_API_SECRET") ?? "VONAGE_API_SECRET";

            var credentials = Credentials.FromApiKeyAndSecret(vonageApiKey, vonageApiSecret);
            var client = new VonageClient(credentials);

            var request = new ListApplicationsRequest { Page = 1, PageSize = 10 };
            var response = await client.ApplicationClient.ListApplicationsAsync(request);

            Console.WriteLine(JsonConvert.SerializeObject(response));
        }
    }
}
