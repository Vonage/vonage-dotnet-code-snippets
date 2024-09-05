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
        var to = Environment.GetEnvironmentVariable("TO_NUMBER") ?? "TO_NUMBER";
        var rcsSenderId = Environment.GetEnvironmentVariable("RCS_SENDER_ID") ?? "RCS_SENDER_ID";
        var imageUrl = Environment.GetEnvironmentVariable("IMAGE_URL") ?? "IMAGE_URL";
        var videoUrl = Environment.GetEnvironmentVariable("VIDEO_URL") ?? "VIDEO_URL";
        var appId = Environment.GetEnvironmentVariable("VONAGE_APP_ID") ?? "VONAGE_APP_ID";
        var privateKeyPath = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
        var credentials = Credentials.FromAppIdAndPrivateKeyPath(appId, privateKeyPath);
        var vonageClient = new VonageClient(credentials);
        var request = new RcsCustomRequest
        {
            To = to,
            From = rcsSenderId,
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
                                                FileUrl = imageUrl,
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
                                                FileUrl = videoUrl,
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