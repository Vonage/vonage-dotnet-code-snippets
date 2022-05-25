using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Vonage.Voice.Nccos;

namespace DotNetWebhookCodeSnippets.Controllers
{
    [Route("[controller]")]
    public class ReceiveInboundCallController : Controller
    {
        [HttpGet("webhooks/answer")]
        public string Answer()
        {            
            var talkAction = new TalkAction
            { 
                Text = "Thank you for calling from " +
                $"{string.Join(" ", Request.Query["from"].ToString().ToCharArray())}"
            };
            var ncco = new Ncco(talkAction);
            return ncco.ToString();
        }
    }
}