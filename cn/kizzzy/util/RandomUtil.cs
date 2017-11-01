using System;

namespace cn.kizzzy.util
{
    public class RandomUtil
    {
        private Random random;
        private static RandomUtil inst = new RandomUtil();
        private RandomUtil()
        {
            random = new Random();
            
        }

        public static RandomUtil getInstance()
        {
            return inst;
        }

        public int Next()
        {
            return random.Next();
        }

        public int Next(int min, int max)
        {
            return random.Next(min, max);
        }
    }
}
