using DotNetty.Buffers;
using System;

namespace cn.kizzzy.protocol
{
    public class ProtocolUtil
    {
        public static IByteBuffer MessageToByteBuf(IMessage msg)
        {
            int length = msg.Data == null ? 0 : msg.Data.Length;
            IByteBuffer buf = Unpooled.Buffer(msg.HEADER_SIZE + length + 2);
            buf.WriteShort(msg.HEADER);     // HEADER
            buf.WriteInt(length);           // LENGTH
            buf.WriteShort(0);              // CHECK_SUM
            buf.WriteShort(msg.CmdType);    // CMD_TYPE
            if (msg.Data != null)           // DATA
                buf.WriteBytes(msg.Data);
            return buf;
        }

        public static T ByteBufToMessage<T>(IByteBuffer buf) where T : IMessage
        {
            Type type = Type.GetType(typeof(T).FullName);
            T msg = (T)Activator.CreateInstance(type);

            buf.MarkReaderIndex();

            if (buf.ReadableBytes < msg.HEADER_SIZE)
            {
                buf.ResetReaderIndex();
                return default(T);
            }

            if (buf.ReadShort() != msg.HEADER)
            {
                buf.ResetReaderIndex();
                return default(T);
            }

            int length = buf.ReadInt();
            /*int checksum = */
            buf.ReadShort();

            if (buf.ReadableBytes < length + 2)
            {
                buf.ResetReaderIndex();
                return default(T);
            }

            byte[] d = new byte[length];

            msg.CmdType = buf.ReadShort();
            buf.ReadBytes(d);
            msg.Data = d;
            return msg;
        }
    }
}
