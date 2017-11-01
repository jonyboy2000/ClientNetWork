namespace cn.kizzzy.notify
{
    public interface INotifySource
    {
        bool AddListener(int notifyType, INotifyListener listener);

        bool RemoveListener(int notifyType, INotifyListener listener);

        bool NotifyListener(NotifyArgs arg);

        bool NotifyListener(int notifyType, object notifyParams);

        bool NotifyListener(int notifyType);
    }
}