using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SASTokenAuthCustomBinding.Binding;

namespace MyApimWidget
{
    public static class GetApimUsers
    {
        [FunctionName("GetApimUsers")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "getapimusers")] HttpRequest req,
            ILogger log,
            [SASToken] SASTokenResult sasTokenResult)
        {

            if(sasTokenResult.Status == SASTokenStatus.Valid)
            {               
                //Insert business logic here 
                return new OkObjectResult(JsonConvert.SerializeObject(sasTokenResult.User));
            }
            else
            {
                return new BadRequestObjectResult(JsonConvert.SerializeObject(sasTokenResult.ErrorMessage));
            }
        }
    }
}
