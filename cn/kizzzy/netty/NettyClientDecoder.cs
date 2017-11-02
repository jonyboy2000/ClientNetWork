using cn.kizzzy.protocol;
using DotNetty.Buffers;
using DotNetty.Codecs;
using DotNetty.Transport.Channels;
using System.Collections.Generic;

namespace cn.kizzzy.netty
{
    public class NettyClientDecoder<T> : ByteToMessageDecoder where T : IMessage
    {
        protected override void Decode(IChannelHandlerContext context, IByteBuffer input, List<object> output)
        {
            T msg = ProtocolUtil.ByteBufToMessage<T>(input);
            if (msg != null)
                output.Add(msg);
        }
    }
}

