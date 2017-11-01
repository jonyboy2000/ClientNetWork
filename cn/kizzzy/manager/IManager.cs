namespace cn.kizzzy.manager
{
    public interface IManager
    {
        bool Init();

        bool Start();

        bool Stop();

        bool Reload();

        string Name { get; }
    }
}