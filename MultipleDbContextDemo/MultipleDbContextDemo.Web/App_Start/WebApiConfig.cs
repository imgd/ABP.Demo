using MultipleDbContextDemo.Compress;
using MultipleDbContextDemo.WebApi.Extend;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Dispatcher;


namespace MultipleDbContextDemo.Web.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //消息JSON返回
            //重写了datetime 序列化json默认格式 
            config.Services.Replace(typeof(IContentNegotiator), new JsonContentNegotiator());

            //全局身份验证
            config.Filters.Add(new GlobalActionFilterAttribute());
            //JSONP服务端支持
            config.Filters.Add(new JsonpFormatterAttribute());

            //Version版本支持
            //待研究
            //config.Services.Replace(typeof(IHttpControllerSelector), new NamespaceHttpControllerSelector(config));

            //全局消息压缩
            //压缩阀值 返回主体内容1000字节以上采用压缩
            config.MessageHandlers.Insert(0, new ServerCompressionHandler(1000, new GZipCompressor(), new DeflateCompressor()));


        }
    }
}