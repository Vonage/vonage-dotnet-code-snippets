using System;
using Microsoft.AspNetCore.Mvc;
using Vonage.Voice.Nccos;
using Vonage.Voice.Nccos.Endpoints;

namespace DotNetWebhookCodeSnippets.Controllers
{
    [Route("[controller]")]
    public class ConnectInboundCallController : Controller
    {
        [Route("webhooks/answer")]
        public string Answer()
        {
            var VOICE_TO_NUMBER = Environment.GetEnvironmentVariable("VOICE_TO_NUMBER") ?? "VOICE_TO_NUMBER";
            var VONAGE_VIRTUAL_NUMBER = Environment.GetEnvironmentVariable("VONAGE_VIRTUAL_NUMBER") ?? "VONAGE_VIRTUAL_NUMBER";

            var talkAction = new TalkAction()
            {
                Text = "Thank you for calling",
                Language = "en-gb",
                Style = 2
            };

            var secondNumberEndpoint = new PhoneEndpoint() { Number=VOICE_TO_NUMBER};            
            var connectAction = new ConnectAction() { From=VONAGE_VIRTUAL_NUMBER, Endpoint= new[] { secondNumberEndpoint } };
            
            var ncco = new Ncco(talkAction,connectAction);
            return ncco.ToString();
        }
    }
}