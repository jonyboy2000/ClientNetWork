using cn.kizzzy.manager;
using DotNetty.Transport.Bootstrapping;
using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Sockets;
using System;
using System.Net;
using UnityEngine;

namespace cn.kizzzy.netty.client
{
    public abstract class AbstractNettyClientManager : INettyClientManager
    {
        IEventLoopGroup group = null;

        public bool Init()
        {
            Debug.Log("Netty组件初始化成功");
            return true;
        }

        public bool Start()
        {
            try
            {
                IPEndPoint server = new IPEndPoint(IPAddress.Parse(ServerAddr), ServerPort);
                group = new MultithreadEventLoopGroup();
                Bootstrap bootstrap = new Bootstrap();
                bootstrap.Group(group);
                bootstrap.Channel<TcpSocketChannel>();
                bootstrap.Option(ChannelOption.TcpNodelay, true);
                bootstrap.Handler(new NettyClientChannelInitializer(this));
                bootstrap.ConnectAsync(server);
            }
            catch (Exception e)
            {
                Debug.Log("Netty组件启动失败" + e);
                return false;
            }
            Debug.Log("Netty组件启动成功");
            return true;
        }

        public bool Stop()
        {
            if (group != null)
                group.ShutdownGracefullyAsync();
            Debug.Log("Netty组件关闭成功");
            return true;
        }

        public bool Reload()
        {
            Debug.Log("Netty组件重启成功");
            return true;
        }

        public string Name
        {
            get
            {
                return typeof(INettyClientManager).FullName;
            }
        }

        public abstract void AddChannel(IChannelPipeline p);

        public abstract string ServerAddr { get; }

        public abstract int ServerPort { get; }

        private class NettyClientChannelInitializer : ChannelInitializer<ISocketChannel>
        {
            AbstractNettyClientManager nettyManager;

            public NettyClientChannelInitializer(AbstractNettyClientManager nettyManager)
            {
                this.nettyManager = nettyManager;
            }

            protected override void InitChannel(ISocketChannel channel)
            {
                IChannelPipeline p = channel.Pipeline;
                nettyManager.AddChannel(p);
            }
        }
    }
}
