using System;
using Abp.Dependency;
using Abp.Web;
using Castle.Facilities.Logging;

namespace MultipleDbContextDemo.WebApi2
{
    public class WebApiApplication : AbpWebApplication
    {
        protected override void Application_Start(object sender, EventArgs e)
        {

            IocManager.Instance.IocContainer.AddFacility<LoggingFacility>(f => f.UseLog4Net().WithConfig("Config/Log4Net.config"));
            base.Application_Start(sender, e);
        }
    }
}
