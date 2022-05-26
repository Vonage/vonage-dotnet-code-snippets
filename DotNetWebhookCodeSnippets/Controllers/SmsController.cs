using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vonage.Messaging;
using Vonage.Utility;

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
        public IActionResult DeliveryReceipt()
        {
            var dlr = WebhookParser.ParseQuery<DeliveryReceipt>(Request.Query);
            Console.WriteLine($"Delivery receipt received for messages {dlr.MessageId} at {dlr.MessageTimestamp}");
            return NoContent();
        }

        [HttpGet("webhooks/verify-sms")]
        public IActionResult VerifySms()
        {
            var vonageApiSignatureSecret = Environment.GetEnvironmentVariable("VONAGE_API_SIGNATURE_SECRET") ?? "VONAGE_API_SIGNATURE_SECRET";
            var sms = WebhookParser.ParseQuery<InboundSms>(Request.Query);
            if (sms.ValidateSignature(vonageApiSignatureSecret, Vonage.Cryptography.SmsSignatureGenerator.Method.md5hash))
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