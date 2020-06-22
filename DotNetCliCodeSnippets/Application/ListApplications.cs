using Nexmo.Api;
using Nexmo.Api.Request;
using Nexmo.Api.Applications;
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
            var NEXMO_API_KEY = Environment.GetEnvironmentVariable("NEXMO_API_KEY") ?? "NEXMO_API_KEY";
            var NEXMO_API_SECRET = Environment.GetEnvironmentVariable("NEXMO_API_SECRET") ?? "NEXMO_API_SECRET";

            var credentials = Credentials.FromApiKeyAndSecret(NEXMO_API_KEY, NEXMO_API_SECRET);
            var client = new NexmoClient(credentials);

            var request = new ListApplicationsRequest { Page = 1, PageSize = 10 };
            var response = client.ApplicationClient.ListApplications(request);

            Console.WriteLine(JsonConvert.SerializeObject(response));
        }
    }
}
