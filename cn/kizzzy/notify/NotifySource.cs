using System.Collections.Generic;

namespace cn.kizzzy.notify
{
    public class NotifySource : INotifySource
    {
        private Dictionary<int, List<INotifyListener>> allListeners = new Dictionary<int, List<INotifyListener>>();

        public bool AddListener(int notifyType, INotifyListener listener)
        {
            List<INotifyListener> listeners = allListeners[notifyType];
            if (listeners == null)
            {
                listeners = new List<INotifyListener>();
                allListeners[notifyType] = listeners;
            }
            listeners.Add(listener);
            return true;
        }

        public bool RemoveListener(int notifyType, INotifyListener listener)
        {
            List<INotifyListener> listeners = allListeners[notifyType];
            if (listeners == null)
                return false;
            return listeners.Remove(listener);
        }

        public bool NotifyListener(NotifyArgs arg)
        {
            if (arg == null)
                return false;

            List<INotifyListener> listeners = allListeners[arg.NotifyType];
            if (listeners == null)
                return false;

            foreach (INotifyListener listener in listeners)
                listener.OnNotify(arg);
            return true;
        }

        public bool NotifyListener(int notifyType, object notifyParams)
        {
            NotifyArgs arg = new NotifyArgs(this, notifyType, notifyParams);

            List<INotifyListener> listeners = allListeners[arg.NotifyType];
            if (listeners == null)
                return false;

            foreach (INotifyListener listener in listeners)
                listener.OnNotify(arg);
            return true;
        }

        public bool NotifyListener(int notifyType)
        {
            NotifyArgs arg = new NotifyArgs(this, notifyType, null);

            List<INotifyListener> listeners = allListeners[arg.NotifyType];
            if (listeners == null)
                return false;

            foreach (INotifyListener listener in listeners)
                listener.OnNotify(arg);
            return true;
        }
    }
}
