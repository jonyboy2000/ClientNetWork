using cn.kizzzy.manager;
using cn.kizzzy.protocol;
using DotNetty.Transport.Channels;
using UnityEngine;

namespace cn.kizzzy.netty.connection
{
    public class ServerConnection : IConnection
    {
        private IChannel channel;
        private IConnectionHolder holder;

        public ServerConnection(IChannel channel)
        {
            this.channel = channel;

            IServerManager sm = MgrManager.Instance.GetManager<IServerManager>();
            if (sm == null)
            {
                Debug.Log("server manager is null");
                return;
            }

            if (sm.GetServerConnection() == null)
            {
                sm.AddServerConnection(this);
            }
        }

        public void Send(PacketMessage msg)
        {
            channel.WriteAndFlushAsync(msg);
        }

        public IConnectionHolder GetHolder()
        {
            return holder;
        }

        public void SetHolder(IConnectionHolder holder)
        {
            this.holder = holder;
        }
    }
}
