using System.Reflection;
using System.Web.Http.Filters;
using Abp.Application.Services;
using Abp.Modules;
using Abp.WebApi;
using Abp.WebApi.Controllers.Dynamic.Builders;
using MultipleDbContextDemo.OutputCache;

namespace MultipleDbContextDemo
{
    [DependsOn(typeof(AbpWebApiModule), typeof(MultipleDbContextDemoApplicationModule))]
    public class MultipleDbContextDemoWebApiModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            DynamicApiControllerBuilder
                .ForAll<IApplicationService>(typeof(MultipleDbContextDemoApplicationModule).Assembly, "app")
                //.WithFilters(new CacheOutputAttribute())
                .Build();
        }
    }
}
