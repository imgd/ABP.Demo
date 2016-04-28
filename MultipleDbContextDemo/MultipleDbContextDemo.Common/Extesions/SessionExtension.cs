using System.Web;
namespace MultipleDbContextDemo.Common
{
    public static class SessionExtension
    {
        /// <summary>
        /// session存值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void UpdateSession(this string key, object value)
        {
            var session = HttpContext.Current.Session;
            session.Remove(key);
            session[key] = value;
            session.Timeout = 20;
        }

        /// <summary>
        /// 获取session值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static object GetSessionValue(this string key)
        {
            return HttpContext.Current.Session[key];
        }
    }
}
