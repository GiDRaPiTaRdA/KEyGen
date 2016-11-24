using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyGen
{
    public static class KeyValidator
    {
        public static bool IsValid(string key)
        {
            return KeyOpertaions.DateTimeSum(NetTime.GetNetworkTime()) == KeyOpertaions.GetSumOfKey(key);
        }

        public static bool IsValid(string key, DateTime time)
        {
            return KeyOpertaions.DateTimeSum(time) == KeyOpertaions.GetSumOfKey(key);
        }
    }
}
