﻿using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Messages.Messenger;
using Vonage.Request;

namespace DotnetCliCodeSnippets.Messages.Messenger;

public class SendMessengerText : ICodeSnippet
{
    public async Task Execute()
    {
        var MESSENGER_RECIPIENT_ID = Environment.GetEnvironmentVariable("MESSENGER_RECIPIENT_ID") ?? "MESSENGER_RECIPIENT_ID";
        var MESSENGER_SENDER_ID = Environment.GetEnvironmentVariable("MESSENGER_SENDER_ID") ?? "MESSENGER_SENDER_ID";
        var VONAGE_APPLICATION_ID = Environment.GetEnvironmentVariable("VONAGE_APPLICATION_ID") ?? "VONAGE_APPLICATION_ID";
        var VONAGE_PRIVATE_KEY_PATH = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
        var credentials = Credentials.FromAppIdAndPrivateKeyPath(VONAGE_APPLICATION_ID, VONAGE_PRIVATE_KEY_PATH);
        var vonageClient = new VonageClient(credentials);
        var request = new MessengerTextRequest
        {
            To = MESSENGER_RECIPIENT_ID,
            From = MESSENGER_SENDER_ID,
            Text = "This is a Facebook Messenger Message sent from the Messages API"
        };
        var response = await vonageClient.MessagesClient.SendAsync(request);
        Console.WriteLine($"Message UUID: {response.MessageUuid}");
    }
}