namespace cn.kizzzy.manager
{
    public abstract class AbstractChatManager : IChatManager
    {
        public bool Init()
        {
            return true;
        }

        public bool Start()
        {
            return true;
        }

        public bool Stop()
        {
            return true;
        }

        public bool Reload()
        {
            return true;
        }

        public string Name
        {
            get
            {
                return typeof(IChatManager).FullName;
            }
        }

        public abstract string AppKey { get; }
    }
}
