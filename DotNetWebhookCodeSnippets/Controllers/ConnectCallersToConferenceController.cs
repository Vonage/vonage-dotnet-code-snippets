using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            var CONF_NAME = Environment.GetEnvironmentVariable("CONF_NAME") ?? "CONF_NAME";
            var talkAction = new TalkAction() { Text = "Please wait while we connect you to the conference" };
            var conversationAction = new ConversationAction() { Name = CONF_NAME };
            var ncco = new Ncco(talkAction, conversationAction);
            return ncco.ToString();
        }
    }
}