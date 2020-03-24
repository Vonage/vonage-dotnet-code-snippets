using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nexmo.Api.Voice.EventWebhooks;
using Nexmo.Api.Voice.Nccos;

namespace DotNetWebhookCodeSnippets.Controllers
{
    [Route("[controller]")]
    public class HandlDtmfInputController : Controller
    {
        [HttpGet("webhooks/answer")]
        public string Answer()
        {
            var sitebase = $"{Request.Scheme}://{Request.Host}";
            sitebase = "http://ngrok.io.slorello.ngrok.io/HandlDtmfInput";

            var talkAction = new TalkAction() { Text = "Hello please press any key to continue" };
            var inputAction = new InputAction()
            {
                EventUrl = new[] { $"{sitebase}/webhooks/dtmf" },
                MaxDigits = 1
            };
            var ncco = new Ncco(talkAction, inputAction);
            return ncco.ToString();
        }

        [HttpPost("webhooks/dtmf")]
        public string Dtmf()
        {
            Input input;
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                input = EventBase.ParseEvent(reader.ReadToEndAsync().Result) as Input;
            }
            var talkAction = new TalkAction() { Text = $"You Pressed {input?.Dtmf}, goodbye" };
            var ncco = new Ncco(talkAction);
            return ncco.ToString();
        }
    }
}