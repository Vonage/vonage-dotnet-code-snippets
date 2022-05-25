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
            var yourSecondNumber = Environment.GetEnvironmentVariable("YOUR_SECOND_NUMBER") ?? "YOUR_SECOND_NUMBER";
            var vonageNumber = Environment.GetEnvironmentVariable("VONAGE_NUMBER") ?? "VONAGE_NUMBER";

            var talkAction = new TalkAction()
            {
                Text = "Thank you for calling",
                Language = "en-gb",
                Style = 2
            };

            var secondNumberEndpoint = new PhoneEndpoint() { Number=yourSecondNumber};            
            var connectAction = new ConnectAction() { From=vonageNumber, Endpoint= new[] { secondNumberEndpoint } };
            
            var ncco = new Ncco(talkAction,connectAction);
            return ncco.ToString();
        }
    }
}