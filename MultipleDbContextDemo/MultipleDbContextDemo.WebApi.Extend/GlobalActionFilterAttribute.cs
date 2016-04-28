using Abp.Web.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Abp.Json;
using MultipleDbContextDemo.Common;
using MultipleDbContextDemo.Inspector;

namespace MultipleDbContextDemo.WebApi.Extend
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class GlobalActionFilterAttribute : ActionFilterAttribute
    {
        public bool authenticationSwitch { get; set; }
        public bool sqlinjectionSwitch { get; set; }
        public GlobalActionFilterAttribute()
        {
            this.authenticationSwitch = true;
            this.sqlinjectionSwitch = true;
        }
        public GlobalActionFilterAttribute(bool _authenticationSwitch)
        {
            this.authenticationSwitch = _authenticationSwitch;
            this.sqlinjectionSwitch = true;
        }
        public GlobalActionFilterAttribute(bool _authenticationSwitch,bool _sqlinjectionSwitch)
        {
            this.authenticationSwitch = _authenticationSwitch;
            this.sqlinjectionSwitch = _sqlinjectionSwitch;
        }

        /// <summary>
        /// 身份验证 拦截实例 具体需要实现
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            //身份验证通过
            if (authenticationSwitch && !EdentityPass(actionContext))
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
            //检查全局身请求参数是否带有SQL注入信息
            if (sqlinjectionSwitch && !IsParametersSafe(actionContext))
            {
                actionContext.Response = new HttpResponseMessage()
                {
                    Content = new StringContent(
                        new AjaxResponse<string>()
                        {
                            Success = false,
                            Result = null,
                            Error = new ErrorInfo()
                            {
                                Code = 400,
                                Message = "zhe parameters not safe.",
                                Details = "Sorry, you has a bad request for notsafe parameters . Please confirm your request parameters .",
                            }
                        }.ToJsonString()),

                    StatusCode = HttpStatusCode.BadRequest
                };
            }
            base.OnActionExecuting(actionContext);
        }

        /// <summary>
        /// 身份验证
        /// </summary>
        /// <param name="actionContext"></param>
        private bool EdentityPass(HttpActionContext actionContext)
        {
            //排除特例不需要验证身份
            if (actionContext.Request.RequestUri.LocalPath.
                IsInArray<string>(new string[] { "/aouth/gettoken" }))
                return true;

            WebApiInspector inspector =WebApiInspector.CreateInstance(actionContext.Request);
            return inspector.IsPass();
        }

        /// <summary>
        /// 请求参数验证
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        private bool IsParametersSafe(HttpActionContext context)
        {
            //验证请求 路由参数合法性
            //2015.12.15 create
            IDictionary<string, object> routeDataValues = context.Request.GetRouteData().Values;
            if (!routeDataValues.IsNull() && routeDataValues.Count > 0)
            {
                foreach (var item in routeDataValues)
                {
                    if (!item.Value.ToString().IsSqlTextSafe())
                        return false;
                    else
                        continue;
                }
            }

            //验证上下文对象的querystring 和 from 对象中的参数合法性
            HttpRequestBase request = ((HttpContextBase)context.Request.Properties["MS_HttpContext"]).Request;
            NameValueCollection paras = request.HttpMethod.ToString().ToUpper() == "GET"
                ? request.QueryString : request.Form;

            if (!paras.IsNull() && paras.Count > 0)
            {
                foreach (string item in paras)
                {
                    if (!paras[item].ToString().IsSqlTextSafe())
                        return false;
                    else
                        continue;
                }
            }

            return true;
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);
        }
    }
}