using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nexmo.Api.Voice.Nccos;
using Nexmo.Api.Voice.Nccos.Endpoints;

namespace DotNetWebhookCodeSnippets.Controllers
{
    [Route("[controller]")]
    public class ConnectInboundCallController : Controller
    {
        [Route("webhooks/answer")]
        public string Answer()
        {
            var YOUR_SECOND_NUMBER = Environment.GetEnvironmentVariable("YOUR_SECOND_NUMBER") ?? "YOUR_SECOND_NUMBER";
            var NEXMO_NUMBER = Environment.GetEnvironmentVariable("NEXMO_NUMBER") ?? "NEXMO_NUMBER";

            var talkAction = new TalkAction()
            {
                Text = "Thank you for calling",
                VoiceName = "Kimberly"
            };

            var secondNumberEndpoint = new PhoneEndpoint() { Number=YOUR_SECOND_NUMBER};            
            var connectAction = new ConnectAction() { From=NEXMO_NUMBER, Endpoint= new[] { secondNumberEndpoint } };
            
            var ncco = new Ncco(talkAction,connectAction);
            return ncco.ToString();
        }
    }
}