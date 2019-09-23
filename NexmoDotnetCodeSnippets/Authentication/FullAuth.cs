using Nexmo.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NexmoDotnetCodeSnippets.Authentication
{
    /// <summary>
    /// This class is only used for the purpose of building documentation on https://developer.nexmo.com/
    /// It is not used in any of the code samples provided in these Quickstarts
    /// </summary>
    public class FullAuth
    {
        public static Client GetClient()
        {
            var client = new Client(creds: new Nexmo.Api.Request.Credentials
            {
                ApiKey = "NEXMO_API_KEY",
                ApiSecret = "NEXMO_API_SECRET",
                ApplicationId = "NEXMO_APPLICATION_ID",
                ApplicationKey = "NEXMO_APPLICATION_PRIVATE_KEY"
            });
            return client;
        }
    }
}
