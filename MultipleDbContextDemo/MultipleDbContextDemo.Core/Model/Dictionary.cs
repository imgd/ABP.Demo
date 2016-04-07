
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace MultipleDbContextDemo.Core
{
    [Table("WH_Dictionary")]
    public class Dictionary : Entity
    {
        /// <summary>
        /// 数据库名
        /// </summary>
        public string DataBaseName { get; set; }

        /// <summary>
        /// 表名
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// 字段名
        /// </summary>
        public string CloumName { get; set; }

        /// <summary>
        /// 字段排序
        /// </summary>
        public string CloumSort { get; set; }

        /// <summary>
        /// 是否是标识列 是”√  否：空
        /// </summary>
        public string IsIdentity { get; set; }

        /// <summary>
        /// 是否是主键
        /// </summary>
        public string IsPrimaryKey { get; set; }

        /// <summary>
        /// 字段类型
        /// </summary>
        public string CloumType { get; set; }

        /// <summary>
        /// 占用字节数
        /// </summary>
        public string ByteCounts { get; set; }

        /// <summary>
        /// 是否为空
        /// </summary>
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
