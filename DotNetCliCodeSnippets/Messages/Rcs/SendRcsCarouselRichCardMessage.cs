#region

using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Messages.Rcs;
using Vonage.Messages.Rcs.Suggestions;
using Vonage.Request;

#endregion

namespace DotnetCliCodeSnippets.Messages.Rcs;

public class SendRcsCarouselRichCardMessage : ICodeSnippet
{
    public async Task Execute()
    {
        var MESSAGES_TO_NUMBER = Environment.GetEnvironmentVariable("MESSAGES_TO_NUMBER") ?? "MESSAGES_TO_NUMBER";
        var RCS_SENDER_ID = Environment.GetEnvironmentVariable("RCS_SENDER_ID") ?? "RCS_SENDER_ID";
        var MESSAGES_IMAGE_URL = Environment.GetEnvironmentVariable("MESSAGES_IMAGE_URL") ?? "MESSAGES_IMAGE_URL";
        var MESSAGES_VIDEO_URL = Environment.GetEnvironmentVariable("MESSAGES_VIDEO_URL") ?? "MESSAGES_VIDEO_URL";
        var VONAGE_APPLICATION_ID = Environment.GetEnvironmentVariable(VonageConstants.ApplicationId) ?? VonageConstants.ApplicationId;
        var VONAGE_PRIVATE_KEY_PATH = Environment.GetEnvironmentVariable(VonageConstants.PrivateKeyPath) ?? VonageConstants.PrivateKeyPath;
        var credentials = Credentials.FromAppIdAndPrivateKeyPath(VONAGE_APPLICATION_ID, VONAGE_PRIVATE_KEY_PATH);
        var vonageClient = new VonageClient(credentials);
        var request = new RcsCarouselRequest()
        {
            To = MESSAGES_TO_NUMBER,
            From = RCS_SENDER_ID,
            Carousel = new CarouselAttachment(
                new CardAttachment("Option 1: Photo", "Do you prefer this photo?", new Uri(MESSAGES_IMAGE_URL))
                    .WithMediaDescription("Picture of a cat")
                    .WithMediaHeight(CardAttachment.Height.Short)
                    .WithThumbnailUrl(new Uri(MESSAGES_IMAGE_URL))
                    .AppendSuggestion(new ReplySuggestion("Option 1", "card_1")),
                new CardAttachment("Option 2: Video", "Or this video?", new Uri(MESSAGES_VIDEO_URL))
                    .WithMediaDescription("Video of a cat")
                    .WithMediaHeight(CardAttachment.Height.Short)
                    .WithThumbnailUrl(new Uri(MESSAGES_IMAGE_URL))
                    .AppendSuggestion(new ReplySuggestion("Option 2", "card_2"))
                ),
            Rcs = new MessageRcs()
            {
              CardWidth  = RcsCardWidth.Small,
            },
        };
        var response = await vonageClient.MessagesClient.SendAsync(request);
        Console.WriteLine($"Message UUID: {response.MessageUuid}");
    }
}