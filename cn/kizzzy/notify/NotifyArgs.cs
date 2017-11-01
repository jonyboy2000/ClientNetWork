using System;

namespace cn.kizzzy.notify
{
    public class NotifyArgs
    {
        private object notifySource;
        private int notifyType;
        private object notifyParams;

        public NotifyArgs(object notifySource, int notifyType, object notifyParams)
        {
            this.notifySource = notifySource;
            this.notifyType = notifyType;
            this.notifyParams = notifyParams;
        }

        public object NotifySource
        {
            get
            {
                return notifySource;
            }

            set
            {
                notifySource = value;
            }
        }

        public int NotifyType
        {
            get
            {
                return notifyType;
            }

            set
            {
                notifyType = value;
            }
        }

        public object NotifyParams
        {
            get
            {
                return notifyParams;
            }

            set
            {
                notifyParams = value;
            }
        }
    }
}
