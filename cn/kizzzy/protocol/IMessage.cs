using DotNetty.Buffers;

namespace cn.kizzzy.protocol
{
    public interface IMessage
    {
        IByteBuffer ToByteBuf(IMessage msg);

        IMessage ValueOf(IByteBuffer buf);

        short CmdType { get; set; }

        byte[] Data { get; set; }
    }
}
