using System.Web.Http;
using Abp.Domain.Uow;
using Demo.Application;
using MultipleDbContextDemo.OutputCache;
using MultipleDbContextDemo.Services;

namespace MultipleDbContextDemo.WebApi2.Controllers.Web
{
    /// <summary>
    /// 此版本 说明 TestController  的 V1.1.0.2版本 命名规则 Test+V+版本号（版本号用 '_' 代替'.'）+Controller
    /// </summary>
    public class TestV1_1_0_2Controller : MultipleDbContextDemoApiControllerBase
    {
        private readonly ITestAppService _tappservice;
        public TestV1_1_0_2Controller(ITestAppService tappservice)
        {
            _tappservice = tappservice;
        }

        [HttpGet]
        [UnitOfWork]
        [CacheOutput(ServerTimeSpan = 5, ClientTimeSpan = 5)]
        public string GetVersion(string abc)
        {
            Logger.Info("调用一次GetVersion方法");
            var a = _tappservice.GetPeople(5);
            return "version is v 1.1.0.2 -> " + new PersonInput() { Name = abc }.Name;
        }

    }
}
