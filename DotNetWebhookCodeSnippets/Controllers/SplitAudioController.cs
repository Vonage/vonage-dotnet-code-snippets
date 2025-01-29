using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vonage.Utility;
using Vonage.Voice.EventWebhooks;
using Vonage.Voice.Nccos;
using Vonage.Voice.Nccos.Endpoints;

namespace DotNetWebhookCodeSnippets.Controllers
{
    [Route("[controller]")]
    public class SplitAudioController : Controller
    {
        [HttpGet("webhooks/answer")]
        public IActionResult Answer()
        {
            var VOICE_TO_NUMBER = Environment.GetEnvironmentVariable("VOICE_TO_NUMBER") ?? "VOICE_TO_NUMBER";
            var VONAGE_VIRTUAL_NUMBER = Environment.GetEnvironmentVariable("VONAGE_VIRTUAL_NUMBER") ?? "VONAGE_VIRTUAL_NUMBER";
            var host = Request.Host.ToString();
            //Uncomment the next line if using ngrok with --host-header option
            //host = Request.Headers["X-Original-Host"];

            var eventUrl = $"{Request.Scheme}://{host}/SplitAudio/webhooks/recording";
            var talkAction = new TalkAction {Text = "recording call", BargeIn = false};
            var recordAction = new RecordAction
            {
                EventUrl = new[] {eventUrl},
                EventMethod = "POST",
                Channels = 2,
                Split = "conversation"
            };

            var connectAction = new ConnectAction()
            {
                From = VONAGE_VIRTUAL_NUMBER,
                Endpoint = new[] {new PhoneEndpoint {Number = VOICE_TO_NUMBER}},
            };

            var ncco = new Ncco(talkAction, recordAction, connectAction);
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