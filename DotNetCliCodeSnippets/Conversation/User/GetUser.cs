#region

using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Vonage;
using Vonage.Request;
using Vonage.Users.GetUser;

#endregion

namespace DotnetCliCodeSnippets.Conversation.User;

public class GetUser : ICodeSnippet
{
    public async Task Execute()
    {
        var VONAGE_APPLICATION_ID = Environment.GetEnvironmentVariable(VonageConstants.ApplicationId) ?? VonageConstants.ApplicationId;
        var VONAGE_PRIVATE_KEY_PATH = Environment.GetEnvironmentVariable(VonageConstants.PrivateKeyPath) ?? VonageConstants.PrivateKeyPath;
        var USER_ID = Environment.GetEnvironmentVariable("USER_ID") ?? "USER_ID";
        var credentials = Credentials.FromAppIdAndPrivateKeyPath(VONAGE_APPLICATION_ID, VONAGE_PRIVATE_KEY_PATH);
        var client = new VonageClient(credentials);
        var response = await client.UsersClient.GetUserAsync(GetUserRequest.Parse(USER_ID));
        Console.WriteLine(JsonConvert.SerializeObject(response));
    }
}