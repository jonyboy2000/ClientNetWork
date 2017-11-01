using System;
using System.Reflection;
using System.Collections.Generic;

namespace cn.kizzzy.util
{
    public class ClassUtil
    {
        public static T GetAttribe<T>(Type type) where T : Attribute
        {
            return (T)Attribute.GetCustomAttribute(type, typeof(T));
        }

        public static List<Type> GetClasses(string nameSpace)
        {
            if (StringUtil.IsNullOrEmpty(nameSpace))
                return null;

            List<Type> types = new List<Type>();
            foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
            {
                if (nameSpace.Equals(type.Namespace))
                    types.Add(type);
            }
            return types;
        }
    }
}
