﻿using Nexmo.Api;
using Nexmo.Api.Voice;
using System;
using System.Diagnostics;
using System.IO;
using System.Web.Mvc;

namespace NexmoDotNetQuickStarts.Controllers
{
    public class VoiceController : Controller
    {
        public Client Client
        {
            get
            {
                var NEXMO_APPLICATION_PRIVATE_KEY = System.IO.File.ReadAllText("PATH_TO_KEY");

                return new Client(creds: new Nexmo.Api.Request.Credentials
                {
                    ApiKey = "NEXMO_API_KEY",
                    ApiSecret = "NEXMO_API_SECRET",
                    ApplicationId = "NEXMO_APPLICATION_ID",
                    ApplicationKey = NEXMO_APPLICATION_PRIVATE_KEY
                });
            }

            set
            {
            }
        }

        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult MakeCall()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MakeCall(string to)
        {
            var NEXMO_TO_NUMBER = to;

            var results = Client.Call.Do(new Call.CallCommand
            {
                to = new[]
                {
                    new Call.Endpoint {
                        type = "phone",
                        number = NEXMO_TO_NUMBER
                    }
                },
                from = new Call.Endpoint
                {
                    type = "phone",
                    number = "NEXMO_FROM_NUMBER"
                },
                answer_url = new[]
                {
                    "https://nexmo-community.github.io/ncco-examples/first_call_talk.json"
                }
            });
            var result = new HttpStatusCodeResult(200);

            return RedirectToAction("Index", "Voice");
        }

        [HttpGet]
        public ActionResult CallList()
        {
            var results = Client.Call.List()._embedded.calls;
            for (int i = 0; i < results.Count; i++)
            {
                Debug.WriteLine(results[i].conversation_uuid);
            }
            ViewData.Add("results", results);
            ViewData.Add("count", results.Count);
            return View();
        }

        [HttpGet]
        public ActionResult GetCall()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GetCall(string id)
        {
            var call = Client.Call.Get(id);
            ViewData.Add("call", call);
            return View();
        }
    }
}
