using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nexmo.Api.Messaging;

namespace DotnetWebhookCodeSnippets.Controllers
{
    [Route("[controller]")]
    public class SmsController : Controller
    {
        [HttpPost("webhooks/inbound-sms")]        
        public IActionResult InboundSms([FromBody]InboundSms sms)
        {
            Console.WriteLine($"SMS Received with message: {sms.Text}");
            return NoContent();
        }

        [HttpGet("webhooks/delivery-receipt")]
        public IActionResult DeliveryReceipt([FromQuery]DeliveryReceipt dlr)
        {
            Console.WriteLine($"Delivery receipt received for messages {dlr.MessageId}");
            return NoContent();
        }

        [HttpGet("webhooks/verify-sms")]
        public IActionResult VerifySms([FromQuery]InboundSms sms)
        {
            var NEXMO_API_SIGNATURE_SECRET = Environment.GetEnvironmentVariable("NEXMO_API_SIGNATURE_SECRET") ?? "NEXMO_API_SIGNATURE_SECRET";
            if (sms.ValidateSignature(NEXMO_API_SIGNATURE_SECRET, Nexmo.Api.Cryptography.SmsSignatureGenerator.Method.md5hash))
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