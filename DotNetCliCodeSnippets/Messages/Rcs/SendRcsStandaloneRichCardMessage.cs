using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Messages.Rcs;
using Vonage.Request;

namespace DotnetCliCodeSnippets.Messages.Rcs;

public class SendRcsStandaloneRichCardMessage: ICodeSnippet
{
    public async Task Execute()
    {
        var to = Environment.GetEnvironmentVariable("TO_NUMBER") ?? "TO_NUMBER";
        var rcsSenderId = Environment.GetEnvironmentVariable("RCS_SENDER_ID") ?? "RCS_SENDER_ID";
        var imageUrl = Environment.GetEnvironmentVariable("IMAGE_URL") ?? "IMAGE_URL";
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
                            StandaloneCard = new
                            {
                                ThumbnailImageAlignment = "RIGHT",
                                CardOrientation = "VERTICAL",
                                CardContent = new
                                {
                                    Title = "Quick question",
                                    Description = "Do you like this picture?",
                                    Media = new
                                    {
                                        Height = "TALL",
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
                                                Text = "Yes",
                                                PostbackData = "suggestion_1",
                                            }
                                        },
                                        new
                                        {
                                            Reply = new
                                            {
                                                Text = "I love it!",
                                                PostbackData = "suggestion_2",
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