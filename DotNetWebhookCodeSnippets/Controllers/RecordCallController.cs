using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vonage.Voice.Nccos;
using Vonage.Voice.Nccos.Endpoints;
using Vonage.Voice.EventWebhooks;
using Vonage.Utility;

namespace DotNetWebhookCodeSnippets.Controllers
{
    [Route("[controller]")]
    public class RecordCallController : Controller
    {   
        [HttpGet("webhooks/answer")]
        public IActionResult Answer()
        {
            var toNumber = Environment.GetEnvironmentVariable("TO_NUMBER") ?? "TO_NUMBER";
            var vonageNumber = Environment.GetEnvironmentVariable("VONAGE_NUMBER") ?? "VONAGE_NUMBER";
            var host = Request.Host.ToString();
            //Uncomment the next line if using ngrok with --host-header option
            //host = Request.Headers["X-Original-Host"];
            var sitebase = $"{Request.Scheme}://{host}";

            var recordAction = new RecordAction()
            {
                EventUrl = new string[] { $"{sitebase}/recordcall/webhooks/recording" },
                EventMethod = "POST"
            };

            var connectAction = new ConnectAction() { From = vonageNumber, Endpoint = new[] { new PhoneEndpoint{ Number = toNumber } } };

            var ncco = new Ncco(recordAction, connectAction);            
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