#region

using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Vonage;
using Vonage.Conversations.CreateEvent;
using Vonage.Request;

#endregion

namespace DotnetCliCodeSnippets.Conversation.Event;

public class CreateEvent : ICodeSnippet
{
    public async Task Execute()
    {
        var VONAGE_APPLICATION_ID = Environment.GetEnvironmentVariable("VONAGE_APPLICATION_ID") ?? "VONAGE_APPLICATION_ID";
        var VONAGE_PRIVATE_KEY_PATH = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
        var CONV_EVENT_TYPE = Environment.GetEnvironmentVariable("$CONV_EVENT_TYPE") ?? "$CONV_EVENT_TYPE";
        var CONV_ID = Environment.GetEnvironmentVariable("CONV_ID") ?? "CONV_ID";
        var CONV_EVENT_FROM = Environment.GetEnvironmentVariable("CONV_EVENT_FROM") ?? "CONV_EVENT_FROM";
        var credentials = Credentials.FromAppIdAndPrivateKeyPath(VONAGE_APPLICATION_ID, VONAGE_PRIVATE_KEY_PATH);
        var client = new VonageClient(credentials);
        var response = await client.ConversationsClient.CreateEventAsync(CreateEventRequest.Build()
            .WithConversationId(CONV_ID)
            .WithType(CONV_EVENT_TYPE)
            .WithBody(new
            {
                message_type = "text",
                text = "string"
            })
            .WithFrom(CONV_EVENT_FROM)
            .Create());
        Console.WriteLine(JsonConvert.SerializeObject(response));
    }
}