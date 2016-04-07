
using Abp.Application.Services;
using Demo.Application;

namespace MultipleDbContextDemo.Application
{
    public interface IAccountInfoAppService : IApplicationService
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="accounts">账号</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        Result Login(string accounts, string password);

        /// <summary>
        /// 查找管理员的基本信息
        /// </summary>
        /// <param name="accountid"></param>
        /// <returns></returns>
        AccountInfoOutput GetAdminBaseInfo(int accountid);

    }
}
