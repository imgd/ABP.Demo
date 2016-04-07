using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleDbContextDemo.Core
{
    public enum AccountsEnum
    {

    }
    /// <summary>
    /// 登录状态
    /// </summary>
    public enum LoginStatusEnum
    {
        //成功
        SUCCESS,
        //登录失败 用户名或密码错误
        FAIL,
        //禁用
        DISABLE
    }
}
