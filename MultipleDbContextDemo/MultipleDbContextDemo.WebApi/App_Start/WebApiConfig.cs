using System.Web.Http;

namespace MultipleDbContextDemo.WebApi
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
                routeTemplate: "api/{controller}/{action}",
                defaults: new { id = string.Format("{0}", RouteParameter.Optional) }
            );   
        }
    }
}
