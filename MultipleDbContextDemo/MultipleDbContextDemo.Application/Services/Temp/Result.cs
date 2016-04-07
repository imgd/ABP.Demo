using Abp.Application.Services.Dto;
using System;

namespace MultipleDbContextDemo.Application
{
    [Serializable]
    public class Result
    {
        /// <summary>
        /// 返回结果code标识
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 返回结果描述信息
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 返回结果数据
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="description"></param>
        public Result(string code, string description)
        {
            this.Code = code;
            this.Description = description;
            this.Data = null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="description"></param>
        /// <param name="data"></param>
        public Result(string code, string description, object data)
        {
            this.Code = code;
            this.Description = description;
            this.Data = data;
        }
    }
}
