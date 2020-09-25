using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

using Newtonsoft.Json;


namespace MeatGeek.AppleSignin
{
    public class AppleOpenIdConfiguration
    {

        [FunctionName("AppleSignin")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "signinwithapple/.well-known/openid-configuration")] 
            HttpRequest req, ILogger log)
        {
            return (ActionResult)new OkObjectResult(new {
                issuer = "https://appleid.apple.com",
                authorization_endpoint = "https://appleid.apple.com/auth/authorize",
                token_endpoint = "https://appleid.apple.com/auth/token",
                jwks_uri = "https://appleid.apple.com/auth/keys",
                id_token_signing_alg_values_supported = new [] { "RS256" }
            });
        }
    }
}