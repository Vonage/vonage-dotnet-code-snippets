using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Request;

namespace DotnetCliCodeSnippets.VerifyV2;

public class VerifyCodeRequest : ICodeSnippet
{
    public async Task Execute()
    {
        var appId = Environment.GetEnvironmentVariable("VONAGE_APP_ID") ?? "VONAGE_APP_ID";
        var privateKeyPath = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
        var requestId = Guid.Parse(Environment.GetEnvironmentVariable("REQUEST_ID") ?? "REQUEST_ID");            
            
        var credentials = Credentials.FromAppIdAndPrivateKeyPath(appId, privateKeyPath);
        var client = new VonageClient(credentials);
            
        // var request = VerifyCodeRequest.Build()
        //     .WithRequestId(requestId)
        //     .WithCode("123456")
        //     .Create();
        //         
        // var response = await client.VerifyV2Client.VerifyCodeAsync(request);
        // var message = response.Match(
        //     success => "Request verification succeeded.", 
        //     failure => $"Request verification failed: {failure.GetFailureMessage()}");
        // Console.WriteLine(message);
    }
}