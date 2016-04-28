using System.Reflection;
using System.Web.Http;
using Abp.Modules;

namespace MultipleDbContextDemo.WebApi2
{
    [DependsOn(typeof(MultipleDbContextDemoDataModule), typeof(MultipleDbContextDemoApplicationModule))]
    public class MultipleDbContextDemoWebApiModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            //开启审计日志
            Configuration.Auditing.IsEnabled = true;
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;
            
            //注册webapi配置
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
