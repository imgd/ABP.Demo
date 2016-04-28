using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MultipleDbContextDemo.Inspector;
using MultipleDbContextDemo.OutputCache;

namespace MultipleDbContextDemo.WebApi2.Controllers.web
{
    public class InspectorController : MultipleDbContextDemoApiControllerBase
    {
        [HttpGet]
        [Route("aouth/gettoken/{clientKey}")]
        [CacheOutput(ServerTimeSpan = 3500, ClientTimeSpan = 3500)]
        public string CreateToken(string clientKey)
        {
            return new WebApiInspector().GetToken(clientKey);
        }
    }
}