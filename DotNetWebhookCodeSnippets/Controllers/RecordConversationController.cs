using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Nexmo.Api.Voice.EventWebhooks;
using Nexmo.Api.Voice.Nccos;

namespace DotNetWebhookCodeSnippets.Controllers
{
    [Route("[controller]")]
    public class RecordConversationController : Controller
    {
        [HttpGet("webhooks/answer")]
        public string Answer()
        {
            var TO_NUMBER = Environment.GetEnvironmentVariable("TO_NUMBER") ?? "TO_NUMBER";
            var NEXMO_NUMBER = Environment.GetEnvironmentVariable("NEXMO_NUMBER") ?? "NEXMO_NUMBER";
            var CONF_NAME = Environment.GetEnvironmentVariable("CONF_NAME") ?? "CONF_NAME";
            var host = Request.Host.ToString();
            //Uncomment the next line if using ngrok with --host-header option
            //host = Request.Headers["X-Original-Host"];
            var sitebase = $"{Request.Scheme}://{host}";

            var conversationAction = new ConversationAction() 
            { 
                Name = CONF_NAME, Record = "true", 
                EventMethod = "POST",
                EventUrl = new string[] { $"{sitebase}/recordconversation/webhooks/recording" }
            };
            var ncco = new Ncco(conversationAction);
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