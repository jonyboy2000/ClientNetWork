using DotNetty.Buffers;

namespace cn.kizzzy.protocol
{
    public interface IMessage
    {
        short HEADER_SIZE { get; }

        short HEADER { get; }

        short CmdType { get; set; }

        byte[] Data { get; set; }
    }
}
