using MultipleDbContextDemo.OutputCache;
using System.Web.Http;
using Abp.Domain.Uow;
using Abp.WebApi.Controllers;
using MultipleDbContextDemo.Services;

namespace MultipleDbContextDemo.WebApi2.Controllers.Web
{
    public class TestController : MultipleDbContextDemoApiControllerBase
    {
        private readonly ITestAppService _tappservice;
        public TestController(ITestAppService tappservice)
        {
            _tappservice = tappservice;
        }

        [HttpGet]
        [UnitOfWork]
        [CacheOutput(ServerTimeSpan = 100, ClientTimeSpan = 100)]
        public string GetVersion()
        {
            var a = _tappservice.GetPeople(5);
            return "version is v 1.0.0.1" + a[0];
        }
        
    }
}
