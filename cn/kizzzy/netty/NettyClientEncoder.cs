using cn.kizzzy.protocol;
using DotNetty.Buffers;
using DotNetty.Codecs;
using DotNetty.Transport.Channels;

namespace cn.kizzzy.netty
{
    class NettyClientEncoder<T> : MessageToByteEncoder<T> where T:IMessage
    {
        protected override void Encode(IChannelHandlerContext context, T message, IByteBuffer output)
        {
            output.WriteBytes(ProtocolUtil.MessageToByteBuf(message));
        }
    }
}
