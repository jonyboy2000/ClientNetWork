using cn.kizzzy.netty.connection;
using cn.kizzzy.protocol;
using DotNetty.Transport.Channels;
using UnityEngine;

namespace cn.kizzzy.netty.client
{
    public class NettyClientHandler : ChannelHandlerAdapter
    {
        private NettyDispatcher dispatcher;
        public NettyClientHandler(NettyDispatcher dispatcher)
        {
            this.dispatcher = dispatcher;
        }

        public override void ChannelActive(IChannelHandlerContext context)
        {
            Debug.Log("channel active");
            context.Channel.GetAttribute(NettyConst.SERVER_GAME).Set(new ServerConnection(context.Channel));
        }

        public override void ChannelRead(IChannelHandlerContext context, object message)
        {
            Debug.Log("channel read");
            IConnection conn = context.Channel.GetAttribute(NettyConst.SERVER_GAME).Get();
            dispatcher.Dispatcher(conn, message as PacketMessage);
        }

        public override void ChannelReadComplete(IChannelHandlerContext context)
        {
            Debug.Log("channel read complete");
        }
    }
}
