using System.Linq;
using System.Net.Http;

namespace MultipleDbContextDemo.Inspector
{
    public class WebApiInspector
    {
        /// <summary>
        /// 身份请求头 key
        /// </summary>
        private const string InspectorHeaderName = "X-SourceToken";

        public BaseClientCheckFactory _inspectorFactory { get; private set; }
        public HttpRequestMessage _request { get; set; }

        private static WebApiInspector _instance = null;

        private static readonly object lockthis = new object();

        /// <summary>
        /// 单例线程安全
        /// </summary>
        /// <returns></returns>
        public static WebApiInspector CreateInstance()
        {
            if (_instance == null)
            {
                lock (lockthis)
                {
                    if (_instance == null)
                    {
                        _instance = new WebApiInspector();
                    }
                }
            }
            return _instance;
        }
        public static WebApiInspector CreateInstance(HttpRequestMessage request)
        {
            if (_instance == null)
            {
                lock (lockthis)
                {
                    if (_instance == null)
                    {
                        _instance = new WebApiInspector(request);
                    }
                }
            }
            return _instance;
        }


        public WebApiInspector(HttpRequestMessage request)
        {
            this._request = request;
            this._inspectorFactory = new BaseClientCheckFactory();
        }

        public WebApiInspector()
        {
            this._inspectorFactory = new BaseClientCheckFactory();
        }


        public bool IsPass()
        {
            var headers = _request.Headers;
            if (headers.Contains(InspectorHeaderName))
            {
                var token = headers.GetValues(InspectorHeaderName).FirstOrDefault();
                if (token == null)
                    return false;
                else
                    return _inspectorFactory.ClientIdentityCheck(token);
            }
            else
                return false;

        }
        public string GetToken(string key)
        {
            return _inspectorFactory.GetClientToken(key);
        }
    }
}
