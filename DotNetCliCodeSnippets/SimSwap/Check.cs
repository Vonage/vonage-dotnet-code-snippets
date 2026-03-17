#region

using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Vonage;
using Vonage.Request;
using Vonage.SimSwap.Check;

#endregion

namespace DotnetCliCodeSnippets.SimSwap;

public class Check : ICodeSnippet
{
    public async Task Execute()
    {
        var VONAGE_APPLICATION_ID = Environment.GetEnvironmentVariable(VonageConstants.ApplicationId) ?? VonageConstants.ApplicationId;
        var VONAGE_PRIVATE_KEY_PATH = Environment.GetEnvironmentVariable(VonageConstants.PrivateKeyPath) ?? VonageConstants.PrivateKeyPath;
        var PHONE_NUMBER = Environment.GetEnvironmentVariable("PHONE_NUMBER") ?? "PHONE_NUMBER";
        var MAX_AGE = int.Parse(Environment.GetEnvironmentVariable("MAX_AGE") ?? "MAX_AGE");
        var credentials = Credentials.FromAppIdAndPrivateKeyPath(VONAGE_APPLICATION_ID, VONAGE_PRIVATE_KEY_PATH);
        var client = new VonageClient(credentials);
        var response = await client.SimSwapClient.CheckAsync(CheckRequest.Build()
            .WithPhoneNumber(PHONE_NUMBER)
            .WithPeriod(MAX_AGE)
            .Create());
        Console.WriteLine(JsonConvert.SerializeObject(response));
    }
}