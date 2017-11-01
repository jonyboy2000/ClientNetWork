using cn.kizzzy.netty.connection;
using DotNetty.Common.Utilities;

namespace cn.kizzzy.netty
{
    public class NettyConst
    {
        /** 游戏服务器连接 */
        public static readonly AttributeKey<IConnection> SERVER_GAME = AttributeKey<IConnection>.ValueOf("SERVER_GAME");
    }
}
