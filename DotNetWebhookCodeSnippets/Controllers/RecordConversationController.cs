using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vonage.Utility;
using Vonage.Voice.EventWebhooks;
using Vonage.Voice.Nccos;

namespace DotNetWebhookCodeSnippets.Controllers
{
    [Route("[controller]")]
    public class RecordConversationController : Controller
    {
        [HttpGet("webhooks/answer")]
        public IActionResult Answer()
        {
            var VOICE_CONFERENCE_NAME = Environment.GetEnvironmentVariable("VOICE_CONFERENCE_NAME") ?? "VOICE_CONFERENCE_NAME";
            var host = Request.Host.ToString();
            //Uncomment the next line if using ngrok with --host-header option
            //host = Request.Headers["X-Original-Host"];
            var sitebase = $"{Request.Scheme}://{host}";

            var conversationAction = new ConversationAction
            { 
                Name = VOICE_CONFERENCE_NAME, Record = true, 
                EventMethod = "POST",
                EventUrl = new [] { $"{sitebase}/recordconversation/webhooks/recording" }
            };
            var ncco = new Ncco(conversationAction);
            var json = ncco.ToString();
            return Ok(json);
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