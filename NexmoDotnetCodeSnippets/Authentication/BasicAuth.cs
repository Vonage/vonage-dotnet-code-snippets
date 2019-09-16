using Nexmo.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NexmoDotnetCodeSnippets.Authentication
{    
    public class BasicAuth
    {
        /// <summary>
        /// Static method to create the client, replace constants with actual        
        /// </summary>
        /// <returns></returns>
        public static Client GetClient()
        {
            const string API_KEY = "NEXMO_API_KEY";
            const string API_SECRET = "NEXMO_API_SECRET";

            var client = new Client(creds: new Nexmo.Api.Request.Credentials(
                nexmoApiKey: API_KEY, nexmoApiSecret: API_SECRET));
            return client;
        }
    }
}
