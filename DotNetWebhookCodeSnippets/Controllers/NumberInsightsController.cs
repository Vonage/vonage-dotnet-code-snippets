using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Nexmo.Api.NumberInsights;
using Nexmo.Api.Utility;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DotnetWebhookCodeSnippets.Controllers
{
    public class NumberInsightsController : Controller
    {
        [HttpPost("webhooks/insight")]
        public async Task<IActionResult> AdvancedInsights()
        {            
            var insights = await WebhookParser.ParseWebhookAsync<AdvancedInsightsResponse>
                (Request.Body, Request.ContentType);
            Console.WriteLine($"Advanced insights received: {insights.RequestId} " +
                $"that number's carrier is {insights.CurrentCarrier.Name} " +
                $"and it's ported status is: {insights.Ported}");
            return NoContent();
        }
    }
}