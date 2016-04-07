using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;

namespace MultipleDbContextDemo.Core
{
    [Table("AccountInfo")]
    public class AccountInfo : Entity
    {
        public AccountInfo()
        {
            NickName = Accounts;
            RegTime = DateTime.Now;
            LastLoginTime = DateTime.Now;
            LastLoginIp = "127.0.0.0";
        }

        /// <summary>
        /// 账号
        /// </summary>
        public string Accounts { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string PassWord { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime RegTime { get; set; }

        /// <summary>
        /// 上次登录时间
        /// </summary>
        public DateTime LastLoginTime { get; set; }

        /// <summary>
        /// 上次登录Ip
        /// </summary>
        public string LastLoginIp { get; set; }

        /// <summary>
        /// 登录次数
        /// </summary>
        public int LoginCounts { get; set; }

        /// <summary>
        /// 账号状态 0正常 1禁用
        /// </summary>
        public int AccountStatus { get; set; }

    }
}
