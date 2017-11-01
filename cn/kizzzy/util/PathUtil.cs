using System;
using System.IO;
using UnityEngine;

namespace cn.kizzzy.util
{
    public class PathUtil
    {
        private static string _appDataPath;
        private static string PRIVATE_FOLDER = "";
        private static string DATA_FOLDER = "";
        /// <summary>
        /// 获取我的文档地址
        /// </summary>
        /// <returns></returns>
        public static string GetPrivateFolder()
        {
            if (PRIVATE_FOLDER == "")
            {
                PRIVATE_FOLDER = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            }
            return PRIVATE_FOLDER;
        }

        public static string GetDataFolder()
        {
            if (DATA_FOLDER == "")
            {
                DATA_FOLDER = Application.dataPath;
            }
            return DATA_FOLDER;
        }

        public static void ScreenCut(int size = 0)
        {
            ScreenCapture.CaptureScreenshot(GetPrivateFolder() + "/" + UnityEngine.Random.Range(1, 10000) + ".png", size);
        }

        public static string AppDataPath
        {
            get
            {
                if (string.IsNullOrEmpty(_appDataPath))
                {
                    if (Application.platform == RuntimePlatform.IPhonePlayer)
                    {
                        _appDataPath = Application.persistentDataPath + "/NimUnityDemo";
                    }
                    else if (Application.platform == RuntimePlatform.Android)
                    {
                        string androidPathName = "com.netease.nim_unity_android_demo";
                        if (Directory.Exists("/sdcard"))
                            _appDataPath = Path.Combine("/sdcard", androidPathName);
                        else
                            _appDataPath = Path.Combine(Application.persistentDataPath, androidPathName);
                    }
                    else if (Application.platform == RuntimePlatform.WindowsEditor ||
                    Application.platform == RuntimePlatform.WindowsPlayer)
                    {
                        _appDataPath = "appData";
                    }
                    Debug.Log("AppDataPath:" + _appDataPath);
                }
                return _appDataPath;
            }
        }
    }
}
