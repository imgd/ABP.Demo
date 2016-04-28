using System.Collections.Generic;
using Abp.Application.Services;
using System.Web.Http;
using MultipleDbContextDemo.OutputCache;

namespace MultipleDbContextDemo.Services
{
    
    public interface ITestAppService : IApplicationService
    {
        
        List<string> GetPeople(int top);

        
        void CreatePerson(string name);
    }
}