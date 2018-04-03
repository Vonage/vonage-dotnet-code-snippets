using Nexmo.Api.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NexmoDotNetQuickStarts.Authentication
{
    public class BasicAuth
    {
        public Credentials Creds { get; set; }

        public BasicAuth(string nexmoApiKey, string nexmoApiSecret)
        {
            Creds = new Credentials
            {
                ApiKey = nexmoApiKey,
                ApiSecret = nexmoApiSecret
            };
        }
    }
}