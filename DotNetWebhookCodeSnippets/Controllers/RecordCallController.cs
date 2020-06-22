using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nexmo.Api.Voice.Nccos;
using Nexmo.Api.Voice.Nccos.Endpoints;
using Nexmo.Api.Voice.EventWebhooks;
using Newtonsoft.Json;
using System.IO;
using System.Text;

namespace DotNetWebhookCodeSnippets.Controllers
{
    [Route("[controller]")]
    public class RecordCallController : Controller
    {   
        [HttpGet("webhooks/answer")]
        public string Answer()
        {
            var TO_NUMBER = Environment.GetEnvironmentVariable("TO_NUMBER") ?? "TO_NUMBER";
            var NEXMO_NUMBER = Environment.GetEnvironmentVariable("NEXMO_NUMBER") ?? "NEXMO_NUMBER";
            var host = Request.Host.ToString();
            //Uncomment the next line if using ngrok with --host-header option
            //host = Request.Headers["X-Original-Host"];
            var sitebase = $"{Request.Scheme}://{host}";

            var recordAction = new RecordAction()
            {
                EventUrl = new string[] { $"{sitebase}/recordcall/webhooks/recording" },
                EventMethod = "POST"
            };

            var connectAction = new ConnectAction() { From = NEXMO_NUMBER, Endpoint = new[] { new PhoneEndpoint{ Number = TO_NUMBER } } };

            var ncco = new Ncco(recordAction, connectAction);
            var json = ncco.ToString();
            return json;
        }
                
        [HttpPost("webhooks/recording")]
        public IActionResult Recording()
        {
            Record record;
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                record = JsonConvert.DeserializeObject<Record>(reader.ReadToEndAsync().Result);
            }
            
            Console.WriteLine($"Record event received on webhook - URL: {record?.RecordingUrl}");
            return StatusCode(204);
        }
    }
}