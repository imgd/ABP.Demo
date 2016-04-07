using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Demo.EntityFramework.Common
{
    /// <summary>
    /// object 扩展类
    /// </summary>
    public static class ObjectExtesions
    {
        /// <summary>
        /// 类型空判断
        /// </summary>
        /// <param name="objectval"></param>
        /// <returns></returns>
        public static bool IsNull(this object objectval)
        {
            if (objectval == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsNullOrEnpty(this object value)
        {
            if (value == null)
            {
                return true;
            }
            else
            {
                return value.ToString().Trim().Length > 0;
            }
        }

        #region JSON (反)序列化

        /// <summary>
        /// 返回对象的序列化成JSON字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string DocumentsToJson(this object obj)
        {
            if (obj == null)
                return string.Empty;

            return (new JavaScriptSerializer()).Serialize(obj);
        }



        /// <summary>
        /// 返回JSON字符串反序列化成泛型对象
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T JsonToDocument<T>(this string json) where T : new()
        {
            if (json == null)
                return new T();

            return (new JavaScriptSerializer()).Deserialize<T>(json);
        }

        /// <summary>
        /// 返回JSON字符串反序列化成List泛型对象
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static List<T> JsonToDocuments<T>(this string json)
        {
            if (json == null)
                return new List<T>();

            return (new JavaScriptSerializer()).Deserialize<List<T>>(json);
        }

        /// <summary>
        /// 返回JSON字符串反序列化成Dic字典对象
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Dictionary<string, object> JsonToDocuments(this string json)
        {
            if (json == null)
                return new Dictionary<string, object>();

            return (new JavaScriptSerializer()).Deserialize<Dictionary<string, object>>(json);
        }





        #endregion
    }
}
