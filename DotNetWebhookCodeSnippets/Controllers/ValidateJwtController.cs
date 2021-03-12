using Jose;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Text;

namespace DotnetWebhookCodeSnippets.Controllers
{
    public class ValidateJwtController : Controller
    {
        private readonly IConfiguration _config;

        public ValidateJwtController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost("/webhooks/validatejwt")]
        public IActionResult ValidateJwt()
        {
            var VONAGE_API_SIGNATURE_SECRET = Environment.GetEnvironmentVariable("VONAGE_API_SIGNATURE_SECRET") ?? "VONAGE_API_SIGNATURE_SECRET";
            var jwt = Request.Headers["Authorization"].ToString().Substring(7);
            try
            {
                var decoded = JWT.Decode(jwt, Encoding.ASCII.GetBytes(VONAGE_API_SIGNATURE_SECRET), alg: JwsAlgorithm.HS256);
                return Ok();
            }
            catch (Exception)
            {                
                return Unauthorized();
            }
        }
    }
}
