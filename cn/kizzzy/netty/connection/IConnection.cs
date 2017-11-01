using cn.kizzzy.protocol;

namespace cn.kizzzy.netty.connection
{
    public interface IConnection
    {
        void Send(PacketMessage msg);

        IConnectionHolder GetHolder();

        void SetHolder(IConnectionHolder holder);
    }
}
