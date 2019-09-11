using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Nexmo.Api;

namespace NexmoDotnetCodeSnippets.Senders
{
    public class SMSSender
    {
        private const string API_KEY = "NEXMO_API_KEY";
        private const string API_SECRET = "NEXMO_API_SECRET";        

        public static SMS.SMSResponse SendSMS(string toNumber, string fromNumber, string message)
        {     
            var client = new Client(creds: new Nexmo.Api.Request.Credentials(nexmoApiKey: API_KEY, nexmoApiSecret: API_SECRET));

            var results = client.SMS.Send(new SMS.SMSRequest
            {
                from = fromNumber,
                to = toNumber,
                text = message
            });

            return results;
        }

        public static SMS.SMSResponse SendSMSUnicode(string toNumber, string fromNumber, string message)
        {
            var client = new Client(creds: new Nexmo.Api.Request.Credentials(nexmoApiKey: API_KEY, nexmoApiSecret: API_SECRET));

            var messageType = "unicode";
            var results = client.SMS.Send(new SMS.SMSRequest
            {
                from = fromNumber,
                to = toNumber,
                text = message,
                type = messageType
            });

            return results;
        }
    }
}
