using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.WebApi.Controllers;

namespace MultipleDbContextDemo.WebApi2.Controllers
{
    public class MultipleDbContextDemoApiControllerBase : AbpApiController
    {
        protected MultipleDbContextDemoApiControllerBase()
        {
            LocalizationSourceName = MultipleDbContextDemoConsts.LocalizationSourceName;
        }
    }
}
