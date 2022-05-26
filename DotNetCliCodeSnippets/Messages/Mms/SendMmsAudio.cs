﻿using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Messages;
using Vonage.Request;

namespace DotnetCliCodeSnippets.Messages.Mms;

public class SendMmsAudio : ICodeSnippet
{
    public async Task Execute()
    {
        var to = Environment.GetEnvironmentVariable("TO_NUMBER") ?? "TO_NUMBER";
        var brandName = Environment.GetEnvironmentVariable("VONAGE_BRAND_NAME") ?? "VONAGE_BRAND_NAME";
        var apiKey = Environment.GetEnvironmentVariable("VONAGE_API_KEY") ?? "VONAGE_API_KEY";
        var apiSecret = Environment.GetEnvironmentVariable("VONAGE_API_SECRET") ?? "VONAGE_API_SECRET";

        var credentials = Credentials.FromApiKeyAndSecret(
            apiKey,
            apiSecret
        );

        var vonageClient = new VonageClient(credentials);
        
        var request = new Vonage.Messages.Mms.MmsAudioRequest
        {
            To = to,
            From = brandName,
            Audio = new CaptionedAttachment
            {
                Caption = "My music",
                Url = "https://file-examples.com/storage/fe6bd68931628d5b79b8f47/2017/11/file_example_MP3_700KB.mp3"
            }
        };

        var response = await vonageClient.MessagesClient.SendAsync(request);
        Console.WriteLine($"Message UUID: {response.MessageUuid}");
    }
}