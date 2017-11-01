using cn.kizzzy.netty.connection;
using UnityEngine;

namespace cn.kizzzy.manager
{
    public class ServerManager : IServerManager
    {
        private IConnection serverConnection;

        public bool Init()
        {
            Debug.Log("Server组件初始化成功");
            return true;
        }

        public bool Start()
        {
            Debug.Log("Server组件启动成功");
            return true;
        }

        public bool Stop()
        {
            Debug.Log("Server组件关闭成功");
            return true;
        }

        public bool Reload()
        {
            Debug.Log("Server组件重启成功");
            return true;
        }

        public string Name
        {
            get
            {
                return typeof(IServerManager).FullName;
            }
        }

        public void AddServerConnection(IConnection connection)
        {
            serverConnection = connection;
        }

        public IConnection GetServerConnection()
        {
            return serverConnection;
        }
    }
}
