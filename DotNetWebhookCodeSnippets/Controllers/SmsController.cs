using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Nexmo.Api.Messaging;

namespace DotnetWebhookCodeSnippets.Controllers
{
    [Route("[controller]")]
    public class SmsController : Controller
    {
        [HttpPost("webhooks/inbound-sms")]        
        public IActionResult InboundSms()
        {
            InboundSms sms;
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                sms = JsonConvert.DeserializeObject<InboundSms>(reader.ReadToEndAsync().Result);
            }
            Console.WriteLine($"SMS Received with message: {sms.Text}");
            return NoContent();
        }

        [HttpPost("webhooks/delivery-receipt")]
        public IActionResult DeliveryReceipt()
        {
            DeliveryReceipt dlr;
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                dlr = JsonConvert.DeserializeObject<DeliveryReceipt>(reader.ReadToEndAsync().Result);
            }
            Console.WriteLine($"Delivery receipt received for messages {dlr.MessageId}");
            return NoContent();
        }

        [HttpPost("webhooks/verify-sms")]
        public IActionResult VerifySms()
        {
            var NEXMO_API_SIGNATURE_SECRET = Environment.GetEnvironmentVariable("NEXMO_API_SIGNATURE_SECRET") ?? "NEXMO_API_SIGNATURE_SECRET";
            InboundSms sms;
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                sms = JsonConvert.DeserializeObject<InboundSms>(reader.ReadToEndAsync().Result);
            }
            if (sms.ValidateSignature(NEXMO_API_SIGNATURE_SECRET, Nexmo.Api.Cryptography.SmsSignatureGenerator.Method.sha512))
            {
                Console.WriteLine("Signature is valid");
            }
            else
            {
                Console.WriteLine("Signature not valid");
            }
            return NoContent();
        }
    }
}