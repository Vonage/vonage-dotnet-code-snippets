﻿using Nexmo.Api;
using Nexmo.Api.Voice;
using NexmoDotNetQuickStarts.Authentication;
using System;
using System.Diagnostics;
using System.IO;
using System.Web.Mvc;

namespace NexmoDotNetQuickStarts.Controllers
{
    public class VoiceController : Controller
    {
        public Client Client { get; set; }
        public VoiceController()
        {
            FullAuth Auth = new FullAuth("NEXMO_API_KEY", "NEXMO_API_SECRET", 
                                         "NEXMO_APPLICATION_ID", "NEXMO_APPLICATION_PRIVATE_KEY");
            Client = new Client(Auth.Creds);
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
            var TO_NUMBER = to;
            var NEXMO_NUMBER = "NEXMO_NUMBER";

            var results = Client.Call.Do(new Call.CallCommand
            {
                to = new[]
                {
                    new Call.Endpoint {
                        type = "phone",
                        number = TO_NUMBER
                    }
                },
                from = new Call.Endpoint
                {
                    type = "phone",
                    number = NEXMO_NUMBER
                },
                answer_url = new[]
                {
                    "https://developer.nexmo.com/ncco/tts.json"
                }
            });
            
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