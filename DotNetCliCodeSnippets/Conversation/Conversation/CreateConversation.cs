#region

using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Vonage;
using Vonage.Conversations.CreateConversation;
using Vonage.Request;

#endregion

namespace DotnetCliCodeSnippets.Conversation.Conversation;

public class CreateConversation : ICodeSnippet
{
    public async Task Execute()
    {
        var VONAGE_APPLICATION_ID = Environment.GetEnvironmentVariable("VONAGE_APPLICATION_ID") ?? "VONAGE_APPLICATION_ID";
        var VONAGE_PRIVATE_KEY_PATH = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
        var CONV_NAME = Environment.GetEnvironmentVariable("CONV_NAME") ?? "CONV_NAME";
        var CONV_DISPLAY_NAME = Environment.GetEnvironmentVariable("CONV_DISPLAY_NAME") ?? "CONV_DISPLAY_NAME";
        var credentials = Credentials.FromAppIdAndPrivateKeyPath(VONAGE_APPLICATION_ID, VONAGE_PRIVATE_KEY_PATH);
        var client = new VonageClient(credentials);
        var response = await client.ConversationsClient.CreateConversationAsync(CreateConversationRequest.Build()
            .WithName(CONV_NAME)
            .WithDisplayName(CONV_DISPLAY_NAME)
            .Create());
        Console.WriteLine(JsonConvert.SerializeObject(response));
    }
}