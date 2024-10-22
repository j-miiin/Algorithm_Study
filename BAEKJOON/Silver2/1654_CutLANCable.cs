using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Silver2
{
    internal class CutLANCable
    {
        static long N, K;
        static long[] cable;

        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(" ");
            K = long.Parse(str[0]);
            N = long.Parse(str[1]);

            cable = new long[K];
            long maxLength = int.MinValue;
            for (int i = 0; i < K; i++)
            {
                cable[i] = long.Parse(Console.ReadLine());

                if (maxLength < cable[i])
                {
                    maxLength = cable[i];
                }
            }

            Console.WriteLine(BinarySearch(1, maxLength));
        }

        static long BinarySearch(long low, long high)
        {
            if (low > high)
            {
                return high;
            }

            long mid = (low + high) / 2;

            long cableCount = GetCableCount(mid);

            if (cableCount < N)
            {
                return BinarySearch(low, mid - 1);
            }
            else
            {
                return BinarySearch(mid + 1, high);
            }
        }

        static long GetCableCount(long length)
        {
            long count = 0;

            for (int i = 0; i < cable.Length; i++)
            {
                if (cable[i] < length)
                {
                    continue;
                }

                count += (cable[i] / length);
            }

            return count;
        }
    }
}
