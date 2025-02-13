#region

using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Vonage;
using Vonage.NumberVerification.Verify;
using Vonage.Request;

#endregion

namespace DotnetCliCodeSnippets.NumberVerification;

public class Verify : ICodeSnippet
{
    public async Task Execute()
    {
        var VONAGE_APPLICATION_ID = Environment.GetEnvironmentVariable("VONAGE_APPLICATION_ID") ?? "VONAGE_APPLICATION_ID";
        var VONAGE_PRIVATE_KEY_PATH = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
        var PHONE_NUMBER = Environment.GetEnvironmentVariable("PHONE_NUMBER") ?? "PHONE_NUMBER";
        var credentials = Credentials.FromAppIdAndPrivateKeyPath(VONAGE_APPLICATION_ID, VONAGE_PRIVATE_KEY_PATH);
        var client = new VonageClient(credentials);
        var response = await client.NumberVerificationClient.VerifyAsync(VerifyRequest.Parse(PHONE_NUMBER));
        Console.WriteLine(JsonConvert.SerializeObject(response));
    }
}