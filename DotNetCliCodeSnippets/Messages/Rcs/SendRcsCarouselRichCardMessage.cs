#region

using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Messages.Rcs;
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
        var VONAGE_APPLICATION_ID = Environment.GetEnvironmentVariable("VONAGE_APPLICATION_ID") ?? "VONAGE_APPLICATION_ID";
        var VONAGE_PRIVATE_KEY_PATH = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
        var credentials = Credentials.FromAppIdAndPrivateKeyPath(VONAGE_APPLICATION_ID, VONAGE_PRIVATE_KEY_PATH);
        var vonageClient = new VonageClient(credentials);
        var request = new RcsCustomRequest
        {
            To = MESSAGES_TO_NUMBER,
            From = RCS_SENDER_ID,
            Custom =
                new
                {
                    ContentMessage = new
                    {
                        RichCard = new
                        {
                            CarouselCard = new
                            {
                                CardWidth = "MEDIUM",
                                CardContents = new[]
                                {
                                    new
                                    {
                                        Title = "Option 1: Photo",
                                        Description = "Do you prefer this photo?",
                                        Media = new
                                        {
                                            Height = "MEDIUM",
                                            ContentInfo = new
                                            {
                                                FileUrl = MESSAGES_IMAGE_URL,
                                                ForceRefresh = false
                                            }
                                        },
                                        Suggestions = new[]
                                        {
                                            new
                                            {
                                                Reply = new
                                                {
                                                    Text = "Option 1",
                                                    PostbackData = "card_1"
                                                }
                                            }
                                        }
                                    },
                                    new
                                    {
                                        Title = "Option 2: Video",
                                        Description = "Do you prefer this video?",
                                        Media = new
                                        {
                                            Height = "MEDIUM",
                                            ContentInfo = new
                                            {
                                                FileUrl = MESSAGES_VIDEO_URL,
                                                ForceRefresh = false
                                            }
                                        },
                                        Suggestions = new[]
                                        {
                                            new
                                            {
                                                Reply = new
                                                {
                                                    Text = "Option 2",
                                                    PostbackData = "card_2"
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
        };
        var response = await vonageClient.MessagesClient.SendAsync(request);
        Console.WriteLine($"Message UUID: {response.MessageUuid}");
    }
}