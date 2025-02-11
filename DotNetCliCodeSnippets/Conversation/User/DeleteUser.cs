#region

using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Vonage;
using Vonage.Request;
using Vonage.Users.DeleteUser;

#endregion

namespace DotnetCliCodeSnippets.Conversation.User;

public class DeleteUser : ICodeSnippet
{
    public async Task Execute()
    {
        var VONAGE_APPLICATION_ID = Environment.GetEnvironmentVariable("VONAGE_APPLICATION_ID") ?? "VONAGE_APPLICATION_ID";
        var VONAGE_PRIVATE_KEY_PATH = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
        var USER_ID = Environment.GetEnvironmentVariable("USER_ID") ?? "USER_ID";
        var credentials = Credentials.FromAppIdAndPrivateKeyPath(VONAGE_APPLICATION_ID, VONAGE_PRIVATE_KEY_PATH);
        var client = new VonageClient(credentials);
        var response = await client.UsersClient.DeleteUserAsync(DeleteUserRequest.Parse(USER_ID));
        Console.WriteLine(JsonConvert.SerializeObject(response));
    }
}