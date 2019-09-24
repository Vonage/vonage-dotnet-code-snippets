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
        public static NexmoResponse RedactWithId(string NEXMO_REDACT_ID, string NEXMO_REDACT_PRODUCT)
        {
            var client = BasicAuth.GetClient();
            var result = client.Redact.RedactTransaction(redactRequest: new Redact.RedactRequest(NEXMO_REDACT_ID, NEXMO_REDACT_PRODUCT));
            return result;
        }

        public static NexmoResponse RedactWithIdAndType(string NEXMO_REDACT_ID, string NEXMO_REDACT_PRODUCT, string NEXMO_REDACT_TYPE)
        {
            var client = BasicAuth.GetClient();
            var result = client.Redact.RedactTransaction(redactRequest: new Redact.RedactRequest(NEXMO_REDACT_ID, NEXMO_REDACT_PRODUCT, NEXMO_REDACT_TYPE));
            return result;
        }
    }
}
