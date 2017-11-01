using System;
using UnityEngine;

namespace cn.kizzzy.util
{
    public class AndroidUtil
    {

        public static string LauncherPkgName = "com.hdlz.HeyHaLauncher";

        public static AndroidJavaObject Activity
        {
            get
            {
                AndroidJavaClass jcPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
                return jcPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            }
        }

        public static AndroidJavaObject PackageManager
        {
            get
            {
                return Activity.Call<AndroidJavaObject>("getPackageManager");
            }
        }

        public static AndroidJavaObject Intent
        {
            get
            {
                return Activity.Call<AndroidJavaObject>("getIntent");
            }
        }

        private static string currentPkgName;

        public static string CurrentPkgName
        {
            get
            {
                if (currentPkgName == null)
                    currentPkgName = Activity.Call<string>("getPackageName");
                return currentPkgName;
            }
        }

        public static void OpenPackage(string pkgName, string extraKey = null, string extraValue = null)
        {
            AndroidJavaObject joIntent = PackageManager.Call<AndroidJavaObject>("getLaunchIntentForPackage", pkgName);
            if (null != joIntent)
            {
                //HzEngine.HzUnInit();
                if (extraKey != null && extraValue != null)
                {
                    AndroidJavaObject newIntent = joIntent.Call<AndroidJavaObject>("putExtra", extraKey, extraValue);
                    Activity.Call("startActivity", newIntent);
                }
                else
                {
                    Activity.Call("startActivity", joIntent);
                }
            }
            Application.Quit();
        }

        public static string GetExtra(string key)
        {
            return Intent.Call<string>("getStringExtra", key);
        }

        //这函数用不了，有问题  
        public static void ToastShow(string text, int ms = 200)
        {
            try
            {
                AndroidJavaClass jcToast = new AndroidJavaClass("android.widget.Toast");
                AndroidJavaObject joContext = Activity.Call<AndroidJavaObject>("getApplicationContext");
                object[] args = { joContext, text, ms };
                //AndroidJavaClass jcLooper = new AndroidJavaClass("android.os.Looper");      
                //jcLooper.CallStatic("prepare");  
                AndroidJavaObject joToast = jcToast.CallStatic<AndroidJavaObject>("makeText", args);
                joToast.Call("show");
                //jcLooper.CallStatic("loop");  
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
        }
    }
}
