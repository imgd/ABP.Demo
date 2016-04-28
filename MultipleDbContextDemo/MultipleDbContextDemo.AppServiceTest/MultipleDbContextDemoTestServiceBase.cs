using System.Reflection;
using Abp.Modules;

namespace MultipleDbContextDemo.AppServiceTest
{
    public class MultipleDbContextDemoTestApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
