using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MultipleDbContextDemo.Core;
using MultipleDbContextDemo.Application;



namespace Demo.Application
{
    [AutoMapTo(typeof(Dictionary))]
    public class DictionaryInput : EntityDto, IInputDto
    {
        public DictionaryInput()
        {
            CloumSort = "0";
            IsIdentity = "";
            IsPrimaryKey = "";
            IsNullable = "";
            DefaultValue = "";
        }

        /// <summary>
        /// 数据库名
        /// </summary>
        [Required]
        public string DataBaseName { get; set; }

        /// <summary>
        /// 表名
        /// </summary>
        [Required]
        public string TableName { get; set; }

        /// <summary>
        /// 字段名
        /// </summary>
        [Required]
        public string CloumName { get; set; }

        /// <summary>
        /// 字段排序
        /// </summary>
        [Range(typeof(Int32),"0","100")]
        public string CloumSort { get; set; }

        /// <summary>
        /// 是否是标识列 是”√  否：空
        /// </summary>
        [RangeArray(" ","√")]
        public string IsIdentity { get; set; }

        /// <summary>
        /// 是否是主键
        /// </summary>
        [RangeArray(" ","√")]
        public string IsPrimaryKey { get; set; }

        /// <summary>
        /// 字段类型
        /// </summary>
        [Required]
        public string CloumType { get; set; }

        /// <summary>
        /// 占用字节数
        /// </summary>
        [Required]
        public string ByteCounts { get; set; }

        /// <summary>
        /// 是否为空
        /// </summary>
        [RangeArray(" ","√")]
        public string IsNullable { get; set; }

        /// <summary>
        /// 默认值
        /// </summary>
        public string DefaultValue { get; set; }

        /// <summary>
        /// 字段说明
        /// </summary>
        public string Description { get; set; }
    }
}
