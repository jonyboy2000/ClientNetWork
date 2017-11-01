using cn.kizzzy.protocol;

namespace cn.kizzzy.netty.connection
{
    public interface IConnection
    {
        void Send<T>(T msg) where T: IMessage;

        IConnectionHolder GetHolder();

        void SetHolder(IConnectionHolder holder);
    }
}
