
using System;
using System.Web;

namespace MultipleDbContextDemo.Common
{
    public static class WebRequestExtesion
    {
        public static string GetCurrentClientUrl()
        {
            if (HttpContext.Current == null)
            {
                return String.Empty;
            }
            return HttpContext.Current.Request.Url.LocalPath;
        }
        public static string GetCurrentClientUrlReferrer()
        {
            if (HttpContext.Current == null)
            {
                return String.Empty;
            }
            return HttpContext.Current.Request.Url.ToString();
        }
    }
}
