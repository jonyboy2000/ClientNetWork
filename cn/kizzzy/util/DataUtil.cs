using UnityEngine;

namespace cn.kizzzy.util
{
    public class DataUtil
    {
        public static float DealWithInput(float input)
        {
            if (Mathf.Abs(input) < 0.1f)
            {
                input = 0;
            }
            else
            {
                input = Mathf.Sign(input);
            }
            return input;
        }
    }
}
