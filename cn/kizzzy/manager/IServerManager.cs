using cn.kizzzy.netty.connection;

namespace cn.kizzzy.manager
{
    public interface IServerManager : IManager
    {
        void AddServerConnection(IConnection connection);

        IConnection GetServerConnection();
    }
}
