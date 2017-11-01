using cn.kizzzy.manager;
using UnityEngine;

namespace cn.kizzzy.client
{
    public abstract class AbstractClient : IClient
    {
        private string name;

        public AbstractClient(string name)
        {
            this.name = name;
            if (!Init())
                return;
            if (!Start())
                return;
        }

        /** 加载管理器 */
        public abstract bool LoadManager();


        public bool Init()
        {
            Debug.Log("==================初始化==================");
            if (!LoadManager())
            {
                Debug.Log("【Client: {}】添加失败" + name);
                return false;
            }
            if (!MgrManager.Instance.Init())
            {
                Debug.Log("【Client: {}】初始化失败" + name);
                return false;
            }
            Debug.Log("【Client: {}】初始化成功" + name);
            return true;
        }


        public bool Start()
        {
            Debug.Log("==================启动中==================");
            if (!MgrManager.Instance.Start())
            {
                Debug.Log("【Client: {}】启动失败" + name);
                return false;
            }
            Debug.Log("【Client: {}】启动成功" + name);
            return true;
        }


        public bool Stop()
        {
            Debug.Log("==================关闭中==================");
            if (!MgrManager.Instance.Stop())
            {
                Debug.Log("【Client: {}】关闭失败" + name);
                return false;
            }
            Debug.Log("【Client: {}】关闭成功" + name);
            return true;
        }


        public bool Reload()
        {
            Debug.Log("==================重启中==================");
            if (!MgrManager.Instance.Reload())
            {
                Debug.Log("【Client: {}】重启失败" + name);
                return false;
            }
            Debug.Log("【Client: {}】重启成功" + name);
            return true;
        }


        public bool Restart()
        {
            return true;
        }
    }
}
