using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Vonage.Utility;
using Vonage.Voice.EventWebhooks;
using Vonage.Voice.Nccos;

namespace DotNetWebhookCodeSnippets.Controllers
{
    [Route("[controller]")]
    public class RecordMessageController : Controller
    {
        [HttpGet("webhooks/answer")]
        public IActionResult Answer()
        {
            var host = Request.Host.ToString();
            //Uncomment the next line if using ngrok with --host-header option
            //host = Request.Headers["X-Original-Host"];
            var sitebase = $"{Request.Scheme}://{host}";
            var outGoingAction = new TalkAction() { Text = "Please leave a message after the tone, then press #. We will get back to you as soon as we can" };            
            var recordAction = new RecordAction()
            {
                EventUrl = new string[] { $"{sitebase}/recordmessage/webhooks/recording" },
                EventMethod = "POST",
                EndOnSilence = "3",
                EndOnKey = "#",
                BeepStart="true"
            };
            var thankYouAction = new TalkAction { Text = "Thank you for your message. Goodbye" };
            var ncco = new Ncco(outGoingAction, recordAction, thankYouAction);
            return Ok(ncco.ToString());
        }

        [HttpPost("webhooks/recording")]
        public async Task<IActionResult> Recording()
        {
            var record = await WebhookParser.ParseWebhookAsync<Record>(Request.Body, Request.ContentType);
            Console.WriteLine($"Record event received on webhook - URL: {record?.RecordingUrl}");
            return StatusCode(204);
        }
    }
}