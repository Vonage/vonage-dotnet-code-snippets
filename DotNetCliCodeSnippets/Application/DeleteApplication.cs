#region

using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Request;

#endregion

namespace DotnetCliCodeSnippets.Application;

public class DeleteApplication : ICodeSnippet
{
    public async Task Execute()
    {
        var VONAGE_API_KEY = Environment.GetEnvironmentVariable("VONAGE_API_KEY") ?? "VONAGE_API_KEY";
        var VONAGE_API_SECRET = Environment.GetEnvironmentVariable("VONAGE_API_SECRET") ?? "VONAGE_API_SECRET";
        var VONAGE_APPLICATION_ID =
            Environment.GetEnvironmentVariable("VONAGE_APPLICATION_ID") ?? "VONAGE_APPLICATION_ID";
        var credentials = Credentials.FromApiKeyAndSecret(VONAGE_API_KEY, VONAGE_API_SECRET);
        var client = new VonageClient(credentials);
        var response = await client.ApplicationClient.DeleteApplicationAsync(VONAGE_APPLICATION_ID);
        Console.WriteLine(response);
    }
}