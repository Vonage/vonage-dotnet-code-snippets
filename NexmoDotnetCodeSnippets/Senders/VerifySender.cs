using Nexmo.Api;
using NexmoDotnetCodeSnippets.Authentication;

namespace NexmoDotnetCodeSnippets.Senders
{
    public class VerifySender
    {
        public static NumberVerify.VerifyResponse StartVerify(string NUMBER)
        {
            var client = BasicAuth.GetClient();
            var BRAND_NAME = "AcmeInc";

            var result = client.NumberVerify.Verify(new NumberVerify.VerifyRequest
            {
                number = NUMBER,
                brand = BRAND_NAME
            });

            return result;
        }

        public static NumberVerify.CheckResponse Check(string CODE, string REQUEST_ID)
        {
            var client = BasicAuth.GetClient();

            var result = client.NumberVerify.Check(new NumberVerify.CheckRequest
            {
                request_id = REQUEST_ID,
                code = CODE
            });

            return result;
        }

        public static NumberVerify.SearchResponse Search(string REQUEST_ID)
        {
            var client = BasicAuth.GetClient();

            var result = client.NumberVerify.Search(new NumberVerify.SearchRequest
            {
                request_id = REQUEST_ID
            });

            return result;
        }

        public static NumberVerify.ControlResponse Cancel(string REQUEST_ID)
        {
            var client = BasicAuth.GetClient();

            var result = client.NumberVerify.Control(new NumberVerify.ControlRequest
            {
                request_id = REQUEST_ID,
                cmd = "cancel"
            });

            return result;
        }

        public static NumberVerify.ControlResponse TriggerNext(string REQUEST_ID)
        {
            var client = BasicAuth.GetClient();

            var result = client.NumberVerify.Control(new NumberVerify.ControlRequest
            {
                request_id = REQUEST_ID,
                cmd = "trigger_next_event"
            });

            return result;
        }

        public static NumberVerify.VerifyResponse VerifyWithWorkflowId(string NUMBER, string WORKFLOW = "4")
        {
            var client = BasicAuth.GetClient();

            var BRAND_NAME = "AcmeInc";            
            var result = client.NumberVerify.Verify(new NumberVerify.VerifyRequest()
            {
                number = NUMBER,
                brand = BRAND_NAME,
                workflow_id = WORKFLOW,
            });

            return result;
            
        }
    }
}
