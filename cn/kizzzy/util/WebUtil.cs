using cn.kizzzy.util;
using System.Threading;
using UnityEngine;

namespace cn.kizzzy.util
{
    public class WebUtil
    {
        /// <summary>
        /// 获取相关链接的返回值
        /// </summary>
        /// <param name="url">链接</param>
        /// <returns></returns>
        public static string GetUrlText(string url)
        {
            float enterTime = Time.time;
            WWW www = new WWW(url);
            while (!www.isDone)
            {
                Thread.Sleep(100);
                if(Time.time - enterTime > 3000)
                {
                    return "";
                }
            }
            Debug.Log(StringUtil.UnicodeToString(www.text));
            return StringUtil.UnicodeToString(www.text);
        }
    }
}
