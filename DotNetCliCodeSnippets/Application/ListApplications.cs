using Vonage;
using Vonage.Request;
using Vonage.Applications;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DotnetCliCodeSnippets.Application
{
    public class ListApplications : ICodeSnippet
    {
        public void Execute()
        {
            var VONAGE_API_KEY = Environment.GetEnvironmentVariable("VONAGE_API_KEY") ?? "VONAGE_API_KEY";
            var VONAGE_API_SECRET = Environment.GetEnvironmentVariable("VONAGE_API_SECRET") ?? "VONAGE_API_SECRET";

            var credentials = Credentials.FromApiKeyAndSecret(VONAGE_API_KEY, VONAGE_API_SECRET);
            var client = new VonageClient(credentials);

            var request = new ListApplicationsRequest { Page = 1, PageSize = 10 };
            var response = client.ApplicationClient.ListApplications(request);

            Console.WriteLine(JsonConvert.SerializeObject(response));
        }
    }
}
