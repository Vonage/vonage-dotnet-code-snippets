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
            var confName = Environment.GetEnvironmentVariable("CONF_NAME") ?? "CONF_NAME";
            var talkAction = new TalkAction() { Text = "Please wait while we connect you to the conference" };
            var conversationAction = new ConversationAction() { Name = confName };
            var ncco = new Ncco(talkAction, conversationAction);
            return ncco.ToString();
        }
    }
}