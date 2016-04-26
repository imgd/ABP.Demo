using System.Collections.Generic;
using Abp.Application.Services;
using System.Web.Http;
using MultipleDbContextDemo.OutputCache;

namespace MultipleDbContextDemo.Services
{
    
    public interface ITestAppService : IApplicationService
    {
        [HttpGet]
        List<string> GetPeople();

        

        
        void CreatePerson(string name);
    }
}