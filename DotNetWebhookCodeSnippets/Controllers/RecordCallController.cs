using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vonage.Voice.Nccos;
using Vonage.Voice.Nccos.Endpoints;
using Vonage.Voice.EventWebhooks;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using Vonage.Utility;

namespace DotNetWebhookCodeSnippets.Controllers
{
    [Route("[controller]")]
    public class RecordCallController : Controller
    {   
        [HttpGet("webhooks/answer")]
        public IActionResult Answer()
        {
            var TO_NUMBER = Environment.GetEnvironmentVariable("TO_NUMBER") ?? "TO_NUMBER";
            var VONAGE_NUMBER = Environment.GetEnvironmentVariable("VONAGE_NUMBER") ?? "VONAGE_NUMBER";
            var host = Request.Host.ToString();
            //Uncomment the next line if using ngrok with --host-header option
            //host = Request.Headers["X-Original-Host"];
            var sitebase = $"{Request.Scheme}://{host}";

            var recordAction = new RecordAction()
            {
                EventUrl = new string[] { $"{sitebase}/recordcall/webhooks/recording" },
                EventMethod = "POST"
            };

            var connectAction = new ConnectAction() { From = VONAGE_NUMBER, Endpoint = new[] { new PhoneEndpoint{ Number = TO_NUMBER } } };

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