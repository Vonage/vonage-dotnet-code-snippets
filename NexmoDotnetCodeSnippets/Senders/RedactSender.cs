using System;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Nexmo.Api;
using Nexmo.Api.Request;
using NexmoDotnetCodeSnippets.Authentication;


namespace NexmoDotnetCodeSnippets.Senders
{
    public class RedactSender
    {
        public const string API_KEY = "API_KEY";
        public const string API_SECRET = "API_SECRET";
        private const string REDACT_URL = @"https://api.nexmo.com/v1/redact/transaction";
        public static NexmoResponse RedactWithId(string id, string product)
        {
            var client = BasicAuth.GetClient();
            return client.Redact.RedactTransaction(redactRequest: new Redact.RedactRequest(id, product));
        }

        public static NexmoResponse RedactWithIdAndType(string id, string product, string type)
        {
            var client = BasicAuth.GetClient();
            return client.Redact.RedactTransaction(redactRequest: new Redact.RedactRequest(id, product, type));
        }
    }
}
