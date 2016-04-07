using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Demo.Application;
using Demo.EntityFramework.Common;
using MultipleDbContextDemo.Core;


namespace MultipleDbContextDemo.Application
{
    public class DictionaryAppService : MultipleDbContextDemoAppServiceBase, IDictionaryAppService
    {
        private readonly IRepository<Dictionary> _dicRepository;
        public DictionaryAppService(IRepository<Dictionary> dicRepository)
        {
            _dicRepository = dicRepository;
        }

        public IList<DictionaryTypeOutput> GetALlDataBasesType()
        {
            var result = (from c in _dicRepository.GetAll().AsEnumerable()
                          select c).DistinctBy(d => d.DataBaseName);

            return Mapper.Map<List<DictionaryTypeOutput>>(result);
        }

        public IList<DictionaryTypeOutput> GetAllTablesType(string dataBaseName)
        {
            var result = _dicRepository.GetAllList(d => d.DataBaseName == dataBaseName).DistinctBy(d => d.TableName);
            return Mapper.Map<List<DictionaryTypeOutput>>(result);
        }

        public bool InsertDictionary(DictionaryInput dic)
        {
            var result= _dicRepository.InsertAndGetId(Mapper.Map<Dictionary>(dic)) > 0;
            return result;
        }

        public PageResult<Dictionary> GetDictionaryList(int pageSize,
            int pageIndex,
            Func<Dictionary, bool> where,
            Func<Dictionary, int> orderby,
            OrderBy orderbyType)
        {

            PageResult<Dictionary> pager = new PageResult<Dictionary>(
                pageSize,
                pageIndex,
                _dicRepository.GetAll().AsEnumerable(),
                where,
                orderby,
                orderbyType);
            //如果需要dto转换 pager.PageData 

            return pager;
        }

    }
}
