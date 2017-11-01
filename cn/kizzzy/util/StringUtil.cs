using System;
using System.Text;
using System.Text.RegularExpressions;

namespace cn.kizzzy.util
{
    public class StringUtil
    {
        public static bool IsNullOrEmpty(String s)
        {
            if (s == null || s.Length == 0 || s.Trim().Length == 0)
                return true;
            return false;
        }

        public static bool IsNotNullAndEmpty(String s)
        {
            return !IsNotNullAndEmpty(s);
        }
        /// <summary>
        /// Unicode转中文
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string UnicodeToString(string text)
        {
            string value = new Regex(@"\\u([0-9A-F]{4})",
                RegexOptions.IgnoreCase).Replace(
                     text, x => string.Empty + Convert.ToChar(Convert.ToUInt16(x.Result("$1"), 16)));
            return value;
        }

        /// <summary>  
        /// Base64编码  
        /// </summary>  
        public static string Base64Encode(string message)
        {
            byte[] bytes = Encoding.GetEncoding("utf-8").GetBytes(message);
            return Convert.ToBase64String(bytes);
        }

        /// <summary>  
        /// Base64解码  
        /// </summary>  
        public static string Base64Decode(string message)
        {
            byte[] bytes = Convert.FromBase64String(message);
            return Encoding.GetEncoding("utf-8").GetString(bytes);
        }
    }
}
