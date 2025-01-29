using System;
using Microsoft.AspNetCore.Mvc;
using Vonage.Voice.Nccos;

namespace DotNetWebhookCodeSnippets.Controllers
{
    [Route("[controller]")]
    public class ConnectCallersToConferenceController : Controller
    {
        [HttpGet("webhooks/answer")]
        public string Answer()
        {
            var VOICE_CONFERENCE_NAME = Environment.GetEnvironmentVariable("VOICE_CONFERENCE_NAME") ?? "VOICE_CONFERENCE_NAME";
            var talkAction = new TalkAction() { Text = "Please wait while we connect you to the conference" };
            var conversationAction = new ConversationAction() { Name = VOICE_CONFERENCE_NAME };
            var ncco = new Ncco(talkAction, conversationAction);
            return ncco.ToString();
        }
    }
}