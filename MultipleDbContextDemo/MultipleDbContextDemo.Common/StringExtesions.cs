using System.Security.Cryptography;
using System.Text;

namespace Demo.EntityFramework.Common
{
    public static class StringExtesions
    {
        /// <summary>
        /// 返回MD5加密后的字符串
        /// </summary>
        /// <param name="str">原始字符串</param>
        /// <returns>MD5加密字符串</returns>
        public static string StringToMd5(this string encryptString)
        {
            byte[] b = Encoding.Default.GetBytes(encryptString);
            b = new MD5CryptoServiceProvider().ComputeHash(b);

            string ret = "";
            for (int i = 0; i < b.Length; i++)
                ret += b[i].ToString("x").PadLeft(2, '0');

            return ret;
        }
    }
}
