using Abp.AutoMapper;
using System;
using Abp.Application.Services.Dto;
using MultipleDbContextDemo.Core;

namespace Demo.Application
{
    [AutoMap(typeof(AccountInfo))]
    public class AccountInfoOutput : EntityDto, IOutputDto
    {
        /// <summary>
        /// 账号
        /// </summary>
        public string Accounts { get; set; }

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


    }
}
