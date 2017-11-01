using ProtoBuf;
using System;
using System.IO;
using UnityEngine;

namespace cn.kizzzy.util
{
    public class ProtobufUtil
    {
        public static byte[] Serialize(IExtensible pb)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                Serializer.Serialize(ms, pb);
                return ms.ToArray();
            }
            catch (Exception ex)
            {
                Debug.Log("序列化失败: " + ex.ToString());
                return null;
            }
        }

        public static  T DeSerialize<T>(byte[] msg) where T :IExtensible
        {
            try
            {
                MemoryStream ms = new MemoryStream(msg);
                return Serializer.Deserialize<T>(ms);
            }
            catch (Exception ex)
            {
                Debug.Log("反序列化失败: " + ex.ToString());
                return default(T);
            }
        }
    }
}