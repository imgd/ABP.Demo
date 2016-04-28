using System;
using System.Collections.Generic;
using System.Linq;
using Abp.Domain.Repositories;
using MultipleDbContextDemo.OutputCache;
using MultipleDbContextDemo.WebApi.Extend;


namespace MultipleDbContextDemo.Services
{
    //设置controller缓存
    //[CacheOutput(ServerTimeSpan = 100, ClientTimeSpan = 50)]
    public class TestAppService : MultipleDbContextDemoAppServiceBase, ITestAppService
    {
        private readonly IRepository<Person> _personRepository; //in the first db
        //private readonly IRepository<Course> _courseRepository; //in the second db

        public TestAppService(IRepository<Person> personRepository)
        {
            _personRepository = personRepository;
            //_courseRepository = courseRepository;
        }

        
        public List<string> GetPeople(int top)
        {
            var peopleNames = _personRepository.GetAllList().Select(p => p.PersonName).ToList();
            return peopleNames;
        }
        

        public void CreatePerson(string name)
        {
            _personRepository.Insert(new Person(name));
        }
    }
}
