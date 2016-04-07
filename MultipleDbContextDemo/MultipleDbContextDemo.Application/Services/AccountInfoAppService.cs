using System;
using Abp.Domain.Repositories;
using AutoMapper;
using Demo.Application;
using Demo.EntityFramework.Common;
using MultipleDbContextDemo.Core;

namespace MultipleDbContextDemo.Application
{
    /// <summary>
    /// 用户 业务类
    /// </summary>
    public class AccountInfoAppService : MultipleDbContextDemoAppServiceBase, IAccountInfoAppService
    {
        private readonly IRepository<AccountInfo> _accRespository;
        public AccountInfoAppService(IRepository<AccountInfo> accRespository)
        {
            _accRespository = accRespository;
        }


        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="accounts">账号</param>
        /// <param name="password">密码</param>
        /// <returns>登录成功返回用户id,客户端保存使用</returns>
        public Result Login(string accounts, string password)
        {
            var result = _accRespository.FirstOrDefault(d => d.Accounts == accounts && d.PassWord == password);
            if (result.IsNull())
            {
                return new Result(LoginStatusEnum.FAIL.ToString(), "用户名密码错误或用户不存在。");
            }

            if (result.AccountStatus == 0)
            {
                //更新登录信息
                result.LoginCounts += 1;
                result.LastLoginIp = "127.0.0.1";
                result.LastLoginTime = DateTime.Now;
                _accRespository.Update(result);

                return new Result(LoginStatusEnum.SUCCESS.ToString(), "登录成功。", result.Id);
            }
            else
            {
                return new Result(LoginStatusEnum.DISABLE.ToString(), "当前账号已被封禁，无法登录。", result.Id);
            }
        }


        /// <summary>
        /// 获取管理员登录基本信息
        /// </summary>
        /// <param name="accountid"></param>
        /// <returns></returns>
        public AccountInfoOutput GetAdminBaseInfo(int accountid)
        {
            var result = _accRespository.FirstOrDefault(d => d.Id == accountid);
            if (result.IsNull())
            {
                return new AccountInfoOutput();
            }
            return Mapper.Map<AccountInfoOutput>(result);
        }
    }
}
