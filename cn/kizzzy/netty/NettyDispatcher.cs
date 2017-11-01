using cn.kizzzy.command;
using cn.kizzzy.manager;
using cn.kizzzy.netty.connection;
using cn.kizzzy.protocol;
using UnityEngine;

namespace cn.kizzzy.netty
{
    public class NettyDispatcher
    {
        public void Dispatcher(IConnection conn, PacketMessage msg)
        {
            ICmdManager cm = MgrManager.Instance.GetManager<ICmdManager>();
            if (cm == null)
            {
                Debug.Log("cmd manager is null");
                return;
            }

            ICommand cmd = cm.GetCommand(msg.CmdType);
            if (cmd == null)
            {
                Debug.Log("cmd is null");
                return;
            }

            cmd.Execute(conn, msg.Data);
        }
    }
}
