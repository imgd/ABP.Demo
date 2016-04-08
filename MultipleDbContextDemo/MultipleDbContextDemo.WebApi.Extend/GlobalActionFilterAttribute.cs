using Abp.Web.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Abp.Json;

namespace MultipleDbContextDemo.WebApi.Extend
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class GlobalActionFilterAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 身份验证 拦截实例 具体需要实现
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            //验证细节待实现
            if (false)
            {
                actionContext.Response = new HttpResponseMessage()
                {
                    Content = new StringContent(
                        new AjaxResponse<string>()
                        {
                            Success = false,
                            Result = null,
                            Error =new ErrorInfo()
                            {
                                 Code = 401,
                                 Message = "No permission to request .",
                                 Details = "Sorry, you do not have permission to request . Please confirm your identity .",
                            } 
                        }.ToJsonString()),

                    StatusCode = HttpStatusCode.Unauthorized
                };
            }
            base.OnActionExecuting(actionContext);
        }
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);
        }
    }
}