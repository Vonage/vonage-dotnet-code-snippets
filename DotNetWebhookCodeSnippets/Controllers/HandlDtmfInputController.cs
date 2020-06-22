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
    public class HandlDtmfInputController : Controller
    {
        [HttpGet("[controller]/webhooks/answer")]
        public string Answer()
        {
            var host = Request.Host.ToString();
            //Uncomment the next line if using ngrok with --host-header option
            //host = Request.Headers["X-Original-Host"];

            var eventUrl = $"{Request.Scheme}://{host}/webhooks/dtmf";

            var talkAction = new TalkAction() { Text = "Hello please press any key to continue" };
            var inputAction = new InputAction()
            {
                EventUrl = new[] { eventUrl },
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