using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Nexmo.Api.Voice.AnswerWebhooks;
using Nexmo.Api.Voice.EventWebhooks;
using Nexmo.Api.Voice.Nccos;
using Nexmo.Api.Utility;

namespace DotnetWebhookCodeSnippets.Controllers
{
    //[Route("[controller]")]
    public class AsrController : Controller
    {
        [HttpGet("[controller]/webhooks/answer")]
        public IActionResult Answer()
        {
            var host = Request.Host.ToString();
            //Uncomment the next line if using ngrok with --host-header option
            //host = Request.Headers["X-Original-Host"];

            var request = WebhookParser.ParseQuery<Answer>(Request.Query);
            var eventUrl = $"{Request.Scheme}://{host}/webhooks/asr";
            var speechSettings = new SpeechSettings { Language = "en-US", EndOnSilence = 1, Uuid = new[] { request.Uuid } };
            var inputAction = new MultiInputAction { Speech = speechSettings, EventUrl = new[] { eventUrl } };

            var talkAction = new TalkAction { Text = "Please speak now" };

            var ncco = new Ncco(talkAction, inputAction);
            return Ok(ncco.ToString());
        }

        [HttpPost("/webhooks/asr")]
        public async Task<IActionResult> OnInput()
        {            
            var input = await WebhookParser.ParseWebhookAsync<MultiInput>(Request.Body, Request.ContentType);
            var talkAction = new TalkAction();
            talkAction.Text = input.Speech.SpeechResults[0].Text;
            var ncco = new Ncco(talkAction);
            return Ok(ncco.ToString());
        }
    }
}