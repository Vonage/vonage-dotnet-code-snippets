using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nexmo.Api.Utility;
using Nexmo.Api.Voice.EventWebhooks;
using Nexmo.Api.Voice.Nccos;

namespace DotNetWebhookCodeSnippets.Controllers
{
    public class HandleDtmfInputController : Controller
    {
        [HttpGet("[controller]/webhooks/answer")]
        public IActionResult Answer()
        {
            var host = Request.Host.ToString();
            //Uncomment the next line if using ngrok with --host-header option
            //host = Request.Headers["X-Original-Host"];

            var eventUrl = $"{Request.Scheme}://{host}/webhooks/dtmf";

            var talkAction = new TalkAction() { Text = "Hello please press any key to continue" };
            var inputAction = new MultiInputAction()
            {
                EventUrl = new[] { eventUrl },
                Dtmf = new DtmfSettings { MaxDigits = 1}
            };
            var ncco = new Ncco(talkAction, inputAction);
            return Ok(ncco.ToString());
        }

        [HttpPost("webhooks/dtmf")]
        public async Task<IActionResult> Dtmf()
        {            
            var input = WebhookParser.ParseWebhook<MultiInput>(Request.Body, Request.ContentType);
            var talkAction = new TalkAction() { Text = $"You Pressed {input?.Dtmf.Digits}, goodbye" };
            var ncco = new Ncco(talkAction);
            return Ok(ncco.ToString());
        }
    }
}