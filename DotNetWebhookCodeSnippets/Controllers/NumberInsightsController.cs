using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Nexmo.Api.NumberInsights;
using System;
using System.IO;
using System.Text;

namespace DotnetWebhookCodeSnippets.Controllers
{
    public class NumberInsightsController : Controller
    {
        [HttpPost("webhooks/insight")]
        public IActionResult AdvancedInsights()
        {
            AdvancedInsightsResponse insights;
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                insights = JsonConvert.DeserializeObject<AdvancedInsightsResponse>(reader.ReadToEndAsync().Result);
            }
            Console.WriteLine($"Advanced insights received: {insights.RequestId} " +
                $"that number's carrier is {insights.CurrentCarrier.Name} " +
                $"and it's ported status is: {insights.Ported}");
            return NoContent();
        }
    }
}