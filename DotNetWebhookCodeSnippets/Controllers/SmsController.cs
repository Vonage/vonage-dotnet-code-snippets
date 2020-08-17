using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Nexmo.Api;
using Nexmo.Api.Messaging;
using Nexmo.Api.Utility;

namespace DotnetWebhookCodeSnippets.Controllers
{
    public class SmsController : Controller
    {
        [HttpGet("webhooks/inbound-sms")]        
        public IActionResult InboundSms()
        {            
            var sms = WebhookParser.ParseQuery<InboundSms>(Request.Query);
            Console.WriteLine($"SMS Received with message: {sms.Text}");
            return NoContent();
        }

        [HttpGet("webhooks/delivery-receipt")]
        public async Task<IActionResult> DeliveryReceipt()
        {
            var dlr = WebhookParser.ParseQuery<DeliveryReceipt>(Request.Query);
            Console.WriteLine($"Delivery receipt received for messages {dlr.MessageId} at {dlr.MessageTimestamp}");
            return NoContent();
        }

        [HttpPost("webhooks/verify-sms")]
        public IActionResult VerifySms()
        {
            var NEXMO_API_SIGNATURE_SECRET = Environment.GetEnvironmentVariable("NEXMO_API_SIGNATURE_SECRET") ?? "NEXMO_API_SIGNATURE_SECRET";
            var sms = WebhookParser.ParseQuery<InboundSms>(Request.Query);
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