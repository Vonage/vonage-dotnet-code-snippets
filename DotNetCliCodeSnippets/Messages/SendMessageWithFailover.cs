#region

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vonage;
using Vonage.Messages;
using Vonage.Messages.Rcs;
using Vonage.Messages.Sms;
using Vonage.Request;

#endregion

namespace DotnetCliCodeSnippets.Messages;

public class SendMessageWithFailover : ICodeSnippet
{
    public async Task Execute()
    {
        var MESSAGES_TO_NUMBER = Environment.GetEnvironmentVariable("MESSAGES_TO_NUMBER") ?? "MESSAGES_TO_NUMBER";
        var RCS_SENDER_ID = Environment.GetEnvironmentVariable("RCS_SENDER_ID") ?? "RCS_SENDER_ID";
        var SMS_SENDER_ID = Environment.GetEnvironmentVariable("SMS_SENDER_ID") ?? "SMS_SENDER_ID";
        var VONAGE_APPLICATION_ID = Environment.GetEnvironmentVariable("VONAGE_APPLICATION_ID") ?? "VONAGE_APPLICATION_ID";
        var VONAGE_PRIVATE_KEY_PATH = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
        var credentials = Credentials.FromAppIdAndPrivateKeyPath(VONAGE_APPLICATION_ID, VONAGE_PRIVATE_KEY_PATH);
        var vonageClient = new VonageClient(credentials);
        var request = new RcsTextRequest
        {
            To = MESSAGES_TO_NUMBER,
            From = RCS_SENDER_ID,
            Text = "This is an RCS text message sent via the Vonage Messages API",
            Failover = new List<IMessage>
            {
                new SmsRequest
                {
                    To = MESSAGES_TO_NUMBER,
                    From = SMS_SENDER_ID,
                    Text = "This is an SMS text message sent via the Vonage Messages API"
                }
            }
        };
        var response = await vonageClient.MessagesClient.SendAsync(request);
        Console.WriteLine($"Message UUID: {response.MessageUuid}");
    }
}