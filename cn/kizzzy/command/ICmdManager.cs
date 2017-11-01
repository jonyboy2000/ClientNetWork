using cn.kizzzy.command;

namespace cn.kizzzy.manager
{
    public interface ICmdManager : IManager
    {
        ICommand GetCommand(short code);
    }
}
