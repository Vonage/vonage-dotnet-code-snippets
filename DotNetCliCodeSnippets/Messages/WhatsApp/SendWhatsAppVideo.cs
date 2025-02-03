﻿using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Messages;
using Vonage.Messages.WhatsApp;
using Vonage.Request;

namespace DotnetCliCodeSnippets.Messages.WhatsApp;

public class SendWhatsAppVideo : ICodeSnippet
{
    public async Task Execute()
    {
        var MESSAGES_TO_NUMBER = Environment.GetEnvironmentVariable("MESSAGES_TO_NUMBER") ?? "MESSAGES_TO_NUMBER";
        var WHATSAPP_SENDER_ID = Environment.GetEnvironmentVariable("WHATSAPP_SENDER_ID") ?? "WHATSAPP_SENDER_ID";
        var MESSAGES_VIDEO_URL = Environment.GetEnvironmentVariable("MESSAGES_VIDEO_URL") ?? "MESSAGES_VIDEO_URL";
        var VONAGE_APPLICATION_ID = Environment.GetEnvironmentVariable("VONAGE_APPLICATION_ID") ?? "VONAGE_APPLICATION_ID";
        var VONAGE_PRIVATE_KEY_PATH = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
        var credentials = Credentials.FromAppIdAndPrivateKeyPath(VONAGE_APPLICATION_ID, VONAGE_PRIVATE_KEY_PATH);
        var vonageClient = new VonageClient(credentials);
        var request = new WhatsAppVideoRequest
        {
            To = MESSAGES_TO_NUMBER,
            From = WHATSAPP_SENDER_ID,
            Video = new CaptionedAttachment
            {
                Caption = "My Video",
                Url = MESSAGES_VIDEO_URL
            }
        };
        var response = await vonageClient.MessagesClient.SendAsync(request);
        Console.WriteLine($"Message UUID: {response.MessageUuid}");
    }
}