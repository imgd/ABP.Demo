
using System;
using System.Collections.Generic;
using Demo.Application;
using MultipleDbContextDemo.Core;
using Abp.Application.Services;

namespace MultipleDbContextDemo.Application
{
    public interface IDictionaryAppService : IApplicationService
    {
        /// <summary>
        /// 查找所有的数据库类型
        /// </summary>
        /// <returns></returns>
        IList<DictionaryTypeOutput> GetALlDataBasesType();
        /// <summary>
        /// 查找某数据库下所有的表类型
        /// </summary>
        /// <param name="dataBaseId"></param>
        /// <returns></returns>
        IList<DictionaryTypeOutput> GetAllTablesType(string dataBaseName);

        /// <summary>
        /// 插入信息到字典
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        bool InsertDictionary(DictionaryInput dic);

        /// <summary>
        /// 分页查找字典信息记录
        /// </summary>
        /// <returns></returns>
        PageResult<Dictionary> GetDictionaryList(int pageSize, int pageIndex, Func<Dictionary, bool> where, Func<Dictionary, int> orderby, OrderBy orderbyType);

    }
}
