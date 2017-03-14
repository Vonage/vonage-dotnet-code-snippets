using Nexmo.Api;
using System.Web.Mvc;
using System.Diagnostics;

using System.Web.Http;
namespace NexmoDotNetQuickStarts.Controllers
{
    // For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860
    
        public class SMSController : Controller
        {

            public ActionResult Index()
            {
                return View();
            }

            [HttpGet]
            public ActionResult Send()
            {
                return View();
            }
            
            [HttpPost]
            public ActionResult Send(string to, string text)
            {
                var results = SMS.Send(new SMS.SMSRequest
                {

                    from = "NEXMO_VIRTUAL_NUMBER",
                    to = to,
                    text = text
                });
                return View("Index");
            }

            [HttpGet]
            public ActionResult Recieve([FromUri]SMS.SMSInbound response)
            {

                if (null != response.to && null != response.msisdn)
                {
                    Debug.WriteLine("-------------------------------------------------------------------------");
                    Debug.WriteLine("INCOMING TEXT");
                    Debug.WriteLine("From: " + response.msisdn);
                    Debug.WriteLine(" Message: " + response.text);
                    Debug.WriteLine("-------------------------------------------------------------------------");
                    return new HttpStatusCodeResult(200);

                }
                else {
                    Debug.WriteLine("-------------------------------------------------------------------------");
                    Debug.WriteLine("Endpoint was hit.");
                    Debug.WriteLine("-------------------------------------------------------------------------");
                    return new HttpStatusCodeResult(200);
                
                }

            }

            [HttpGet]
            public ActionResult DLR([FromUri]SMS.SMSDeliveryReceipt response)
            {

                Debug.WriteLine("-------------------------------------------------------------------------");
                Debug.WriteLine("DELIVERY RECIEPT");
                Debug.WriteLine("Message ID: " + response.messageId);
                Debug.WriteLine("From: " + response.msisdn);
                Debug.WriteLine("To: " + response.to);
                Debug.WriteLine("Status: " + response.status);
                Debug.WriteLine("-------------------------------------------------------------------------");

                return new HttpStatusCodeResult(200);
            }
    
    }

}
