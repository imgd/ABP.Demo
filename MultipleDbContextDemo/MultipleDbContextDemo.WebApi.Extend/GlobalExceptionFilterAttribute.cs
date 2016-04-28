using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using Abp.Json;
using Abp.Web.Models;


namespace MultipleDbContextDemo.WebApi.Extend
{
    [AttributeUsage(AttributeTargets.Assembly)]
    public class GlobalExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            Exception ex = context.Exception;
            string method = ex.TargetSite.Name;
            string message = ex.Message.ToString();

            context.Response = new HttpResponseMessage()
            {
                Content = new StringContent(
                    new AjaxResponse<string>()
                    {
                        Success = false,
                        Result = null,
                        Error = new ErrorInfo()
                        {
                            Code = 400,
                            Message = "request arguments error .",
                            Details = string.Format("描述: {0} 来源: {1}",message, context.Request.RequestUri.ToString()),
                        }
                    }.ToJsonString()),

                StatusCode = HttpStatusCode.BadRequest
            };
        }
    }
}