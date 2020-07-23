using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Nexmo.Api.Utility;
using Nexmo.Api.Voice.EventWebhooks;
using Nexmo.Api.Voice.Nccos;

namespace DotnetWebhookCodeSnippets.Controllers
{
    public class TrackNccoController : Controller
    {
        [HttpGet("[controller]/webhooks/answer")]
        public IActionResult Answer()
        {
            var host = Request.Host.ToString();
            //Uncomment the next line if using ngrok with --host-header option
            //host = Request.Headers["X-Original-Host"];

            var eventUrl = $"{Request.Scheme}://{host}/webhooks/notification";

            var talkAction = new TalkAction() { Text = "Thanks for calling the notification line" };
            var notifyAction = new NotifyAction()
            {
                EventUrl = new[] { eventUrl },
                Payload = new FooBar() { Foo = "bar" }
            };
            var talkAction2 = new TalkAction() { Text = "You will never hear me as the notification URL will return an NCCO" };
            var ncco = new Ncco(talkAction, notifyAction, talkAction2);
            return Ok(ncco.ToString());
        }

        [HttpPost("webhooks/notification")]
        public async Task<IActionResult> Notify()
        {
            var notification = await WebhookParser.ParseWebhookAsync<Notification<FooBar>>(Request.Body, Request.ContentType);
            Console.WriteLine($"Notification received payload's foo = {notification.Payload.Foo}");
            var talkAction = new TalkAction() { Text = "Your notification has been received, loud and clear" };
            var ncco = new Ncco(talkAction);
            return Ok(ncco.ToString());
        }

        public class FooBar
        {
            public string Foo { get; set; }
        }
    }
}