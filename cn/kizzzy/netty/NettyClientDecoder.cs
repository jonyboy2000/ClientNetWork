using cn.kizzzy.protocol;
using DotNetty.Buffers;
using DotNetty.Codecs;
using DotNetty.Transport.Channels;
using System;
using System.Collections.Generic;

namespace cn.kizzzy.netty
{
    public class NettyClientDecoder<T> : ByteToMessageDecoder where T : IMessage
    {
        protected override void Decode(IChannelHandlerContext context, IByteBuffer input, List<object> output)
        {
            //PacketMessage msg = PacketMessage.ValueOf(input);
            //if (msg != null)
            //    output.Add(msg);
            Type type = Type.GetType(typeof(T).FullName);
            T msg = (T)Activator.CreateInstance(type);
            msg = (T)msg.ValueOf(input);
            if (msg != null)
                output.Add(msg);
        }
    }
}

