#region

using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Vonage;
using Vonage.Request;
using Vonage.Users.CreateUser;

#endregion

namespace DotnetCliCodeSnippets.Conversation.User;

public class CreateUser : ICodeSnippet
{
    public async Task Execute()
    {
        var VONAGE_APPLICATION_ID = Environment.GetEnvironmentVariable(VonageConstants.ApplicationId) ?? VonageConstants.ApplicationId;
        var VONAGE_PRIVATE_KEY_PATH = Environment.GetEnvironmentVariable(VonageConstants.PrivateKeyPath) ?? VonageConstants.PrivateKeyPath;
        var USER_NAME = Environment.GetEnvironmentVariable("USER_NAME") ?? "USER_NAME";
        var USER_DISPLAY_NAME = Environment.GetEnvironmentVariable("USER_DISPLAY_NAME") ?? "USER_DISPLAY_NAME";
        var credentials = Credentials.FromAppIdAndPrivateKeyPath(VONAGE_APPLICATION_ID, VONAGE_PRIVATE_KEY_PATH);
        var client = new VonageClient(credentials);
        var response = await client.UsersClient.CreateUserAsync(CreateUserRequest.Build()
            .WithName(USER_NAME)
            .WithDisplayName(USER_DISPLAY_NAME)
            .Create());
        Console.WriteLine(JsonConvert.SerializeObject(response));
    }
}