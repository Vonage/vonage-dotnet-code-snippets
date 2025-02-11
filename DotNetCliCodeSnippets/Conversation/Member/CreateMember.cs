#region

using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Vonage;
using Vonage.Conversations;
using Vonage.Conversations.CreateMember;
using Vonage.Request;

#endregion

namespace DotnetCliCodeSnippets.Conversation.Member;

public class CreateMember : ICodeSnippet
{
    public async Task Execute()
    {
        var VONAGE_APPLICATION_ID = Environment.GetEnvironmentVariable("VONAGE_APPLICATION_ID") ?? "VONAGE_APPLICATION_ID";
        var VONAGE_PRIVATE_KEY_PATH = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
        var CONV_ID = Environment.GetEnvironmentVariable("CONV_ID") ?? "CONV_ID";
        var CONV_USER_ID = Environment.GetEnvironmentVariable("CONV_USER_ID") ?? "CONV_USER_ID";
        var CONV_USER_NAME = Environment.GetEnvironmentVariable("CONV_USER_NAME") ?? "CONV_USER_NAME";
        var CONV_MEMBER_STATE = Enum.Parse<CreateMemberRequest.AvailableStates>(Environment.GetEnvironmentVariable("CONV_MEMBER_STATE") ?? "CONV_MEMBER_STATE");
        var credentials = Credentials.FromAppIdAndPrivateKeyPath(VONAGE_APPLICATION_ID, VONAGE_PRIVATE_KEY_PATH);
        var client = new VonageClient(credentials);
        var response = await client.ConversationsClient.CreateMemberAsync(CreateMemberRequest.Build()
            .WithConversationId(CONV_ID)
            .WithState(CONV_MEMBER_STATE)
            .WithUser(new MemberUser(CONV_USER_ID, CONV_USER_NAME))
            .WithApp(CONV_USER_ID, ChannelType.App)
            .Create());
        Console.WriteLine(JsonConvert.SerializeObject(response));
    }
}