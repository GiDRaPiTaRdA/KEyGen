using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KeyGen
{
    public static class KeyGenerator
    {
        public static string Generate()
        {
            string key = KeyOpertaions.ShuffleKey(KeyOpertaions.GetValidSecretKey(NetTime.GetNetworkTime()));
            return key;
        }

        public static Task<string> GenerateAsync()
        {
            return new Task<string>(()=> Generate());
        }

        public static string Generate(DateTime time)
        {
            string key = KeyOpertaions.ShuffleKey(KeyOpertaions.GetValidSecretKey(time));
            return key;
        }

        public static Task<string> GenerateAsync(DateTime time)
        {
            return new Task<string>(() => Generate(time));
        }
    }
}
