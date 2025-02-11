#region

using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Vonage;
using Vonage.Conversations.GetMembers;
using Vonage.Request;

#endregion

namespace DotnetCliCodeSnippets.Conversation.Member;

public class GetMembers : ICodeSnippet
{
    public async Task Execute()
    {
        var VONAGE_APPLICATION_ID = Environment.GetEnvironmentVariable("VONAGE_APPLICATION_ID") ?? "VONAGE_APPLICATION_ID";
        var VONAGE_PRIVATE_KEY_PATH = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
        var CONV_ID = Environment.GetEnvironmentVariable("CONV_ID") ?? "CONV_ID";
        var credentials = Credentials.FromAppIdAndPrivateKeyPath(VONAGE_APPLICATION_ID, VONAGE_PRIVATE_KEY_PATH);
        var client = new VonageClient(credentials);
        var response = await client.ConversationsClient.GetMembersAsync(GetMembersRequest.Build()
            .WithConversationId(CONV_ID)
            .Create());
        Console.WriteLine(JsonConvert.SerializeObject(response));
    }
}