using cn.kizzzy.netty.connection;

namespace cn.kizzzy.command
{
    public interface ICommand
    {
        void Execute(IConnection conn, byte[] packet);
    }
}
