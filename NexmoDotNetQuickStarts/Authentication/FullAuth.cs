using Nexmo.Api.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NexmoDotNetQuickStarts.Authentication
{
    public class FullAuth
    {
        public Credentials Creds { get; set; }

        public FullAuth(string nexmoApiKey, string nexmoApiSecret, string nexmoApplicationId, string nexmoApplicationPrivateKey)
        {
            Creds = new Credentials
            {
                ApiKey = nexmoApiKey,
                ApiSecret = nexmoApiSecret,
                ApplicationId = nexmoApplicationId,
                ApplicationKey = nexmoApplicationPrivateKey
            };
        }
    }
}