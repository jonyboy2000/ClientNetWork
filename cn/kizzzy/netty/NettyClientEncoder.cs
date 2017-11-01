using cn.kizzzy.protocol;
using DotNetty.Buffers;
using DotNetty.Codecs;
using DotNetty.Transport.Channels;
using System;

namespace cn.kizzzy.netty
{
    class NettyClientEncoder<T> : MessageToByteEncoder<T> where T:IMessage
    {
        protected override void Encode(IChannelHandlerContext context, T message, IByteBuffer output)
        {
            //output.WriteBytes(PacketMessage.ToByteBuf(message));
            Type type = Type.GetType(typeof(T).FullName);
            T msg = (T)Activator.CreateInstance(type);
            output.WriteBytes(msg.ToByteBuf(message));
        }
    }
}
