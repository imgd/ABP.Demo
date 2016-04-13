using System.Web.Http;
using MultipleDbContextDemo.OutputCache;

namespace MultipleDbContextDemo.WebApi.Controllers
{
    public class TestController : ApiController
    {
        [HttpGet]
        [CacheOutput(ServerTimeSpan = 100, ClientTimeSpan = 100)]
        public string GetVersion()
        {
            return "version is v 1.0.0.1";
        }
    }
}
