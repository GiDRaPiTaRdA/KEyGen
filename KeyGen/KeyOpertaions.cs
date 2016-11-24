using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyGen
{
    static class KeyOpertaions
    {
        public static string ShuffleKey(string key)
        {
            var a = ShuffleArray(key.ToArray());
            var b = new string(a.ToArray());
            return b;
        }
        public static int GetSumOfKey(string str)
        {
            int sum = 0;
            if (string.Empty != str)
            {
                foreach (char ch in str)
                {
                    try
                    {
                        sum += int.Parse(ch.ToString());
                    }
                    catch
                    {
                        sum += ch;
                    }
                }
            }
            return sum;
        }
        public static string GetValidSecretKey(DateTime time)
        {
            string finalString = CreateKey(DateTimeSum(time));

            return finalString;
        }
        public static string CreateKey(int sum)
        {
            string finalKey = "";
            Random random = new Random();
            while (true)
            {
                int keySum = GetSumOfKey(finalKey);
                if ((sum / 2) > keySum)
                    finalKey += (char)random.Next(97, 122);// a-z
                else if (sum - keySum > 90)
                    finalKey += (char)random.Next(65, 90);// A-Z
                else if (sum - keySum >= 10)
                    finalKey += random.Next(10);
                else
                {
                    finalKey += sum - keySum;
                    var temp = GetSumOfKey(finalKey);
                    if (sum != temp)
                        throw new Exception("WTF");

                    return finalKey;
                }
            }

        }
        public static int DateTimeSum(DateTime time)
        {
            int year, month, day, hour, minute;

            year = time.Year;
            month = time.Month;
            day = time.Day;
            hour = time.Hour;
            minute = time.Minute;

            int sum = year + month + day + hour + minute;
            return sum;
        }
        public static IEnumerable<T> ShuffleArray<T>(IEnumerable<T> array)
        {
            var random = new Random();
            array = array.OrderBy(x => random.Next()).ToArray();
            return array;
        }
    }
}
