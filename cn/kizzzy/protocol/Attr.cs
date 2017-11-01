using System;

namespace cn.kizzzy.protocol
{
    [AttributeUsage(AttributeTargets.Class)]
    public class Attr : Attribute
    {
        public short Code { get; set; }

        public string Desc { get; set; }
    }
}
