using System.Collections.Generic;

namespace cn.kizzzy.notify
{
    public class NotifySource : INotifySource
    {
        private Dictionary<int, List<INotifyListener>> allListeners = new Dictionary<int, List<INotifyListener>>();

        public bool AddListener(int notifyType, INotifyListener listener)
        {
            if (!allListeners.ContainsKey(notifyType))
                allListeners[notifyType] = new List<INotifyListener>();
            allListeners[notifyType].Add(listener);
            return true;
        }

        public bool RemoveListener(int notifyType, INotifyListener listener)
        {
            if (!allListeners.ContainsKey(notifyType))
                return false;
            return allListeners[notifyType].Remove(listener);
        }

        public bool NotifyListener(NotifyArgs arg)
        {
            if (arg == null)
                return false;

            if (!allListeners.ContainsKey(arg.NotifyType))
                return false;

            foreach (INotifyListener listener in allListeners[arg.NotifyType])
                listener.OnNotify(arg);
            return true;
        }

        public bool NotifyListener(int notifyType, object notifyParams)
        {
            NotifyArgs arg = new NotifyArgs(this, notifyType, notifyParams);

            if (!allListeners.ContainsKey(arg.NotifyType))
                return false;

            foreach (INotifyListener listener in allListeners[arg.NotifyType])
                listener.OnNotify(arg);
            return true;
        }

        public bool NotifyListener(int notifyType)
        {
            NotifyArgs arg = new NotifyArgs(this, notifyType, null);

            if (!allListeners.ContainsKey(arg.NotifyType))
                return false;

            foreach (INotifyListener listener in allListeners[arg.NotifyType])
                listener.OnNotify(arg);
            return true;
        }
    }
}
