using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using MultipleDbContextDemo.Common;
using MultipleDbContextDemo.Compress;
using MultipleDbContextDemo.WebApi.Extend;

namespace MultipleDbContextDemo.WebApi2
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //允许特性注入路由
            //此项设置如果配置必须放在MapHttpRoute前面
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{namespaces}/{controller}/{action}",
                defaults: new { namespaces = string.Format("MultipleDbContextDemo.WebApi2.Controllers.{0}", RouteParameter.Optional) }
            );


            var GLOBAL_AUTHENTICATION_SWITCH = ConfigHelper.GetAppSettingsString("GLOBAL_AUTHENTICATION_SWITCH").ToString().ToLower() == "on" ? true : false;
            var GLOBAL_SQLINJECTION_SWITCH = ConfigHelper.GetAppSettingsString("GLOBAL_SQLINJECTION_SWITCH").ToString().ToLower() == "on" ? true : false;

            //消息JSON返回
            //重写了datetime 序列化json默认格式 
            config.Services.Replace(typeof(IContentNegotiator), new JsonContentNegotiator());

            //全局身份验证+请求参数验证
            config.Filters.Add(new GlobalActionFilterAttribute(GLOBAL_AUTHENTICATION_SWITCH, GLOBAL_SQLINJECTION_SWITCH));

            //JSONP服务端支持
            config.Filters.Add(new JsonpFormatterAttribute());

            //Version版本支持
            //待研究
            config.Services.Replace(typeof(IHttpControllerSelector), new NamespaceHttpControllerSelector(config));

            //全局消息压缩
            //压缩阀值 返回主体内容1000字节以上采用压缩
            config.MessageHandlers.Insert(0, new ServerCompressionHandler(1000, new GZipCompressor(), new DeflateCompressor()));
        }
    }
}
