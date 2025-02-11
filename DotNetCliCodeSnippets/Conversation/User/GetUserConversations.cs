#region

using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Vonage;
using Vonage.Conversations.GetUserConversations;
using Vonage.Request;

#endregion

namespace DotnetCliCodeSnippets.Conversation.User;

public class GetUserConversations : ICodeSnippet
{
    public async Task Execute()
    {
        var VONAGE_API_KEY = Environment.GetEnvironmentVariable("VONAGE_API_KEY") ?? "VONAGE_API_KEY";
        var VONAGE_API_SECRET = Environment.GetEnvironmentVariable("VONAGE_API_SECRET") ?? "VONAGE_API_SECRET";
        var USER_ID = Environment.GetEnvironmentVariable("USER_ID") ?? "USER_ID";
        var credentials = Credentials.FromApiKeyAndSecret(VONAGE_API_KEY, VONAGE_API_SECRET);
        var client = new VonageClient(credentials);
        var response = await client.ConversationsClient.GetUserConversationsAsync(GetUserConversationsRequest.Build()
            .WithUserId(USER_ID)
            .Create());
        Console.WriteLine(JsonConvert.SerializeObject(response));
    }
}