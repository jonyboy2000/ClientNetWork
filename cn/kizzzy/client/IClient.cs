namespace cn.kizzzy.client
{
    public interface IClient
    {
         bool Init();

         bool Start();

         bool Stop();

         bool Reload();

         bool Restart();
    }
}
