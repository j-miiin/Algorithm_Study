using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold4
{
    internal class FillTile
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            if (N % 2 != 0)
            {
                Console.WriteLine(0);
                return;
            }

            if (N == 2)
            {
                Console.WriteLine(3);
                return;
            }

            int[] dp = new int[N + 1];
            dp[0] = 1;
            dp[2] = 3;

            for (int i = 4; i <= N; i += 2)
            {
                dp[i] += dp[i - 2] * 3;
                for (int j = 4; j <= i; j += 2)
                {
                    dp[i] += dp[i - j] * 2;
                }
            }

            Console.WriteLine(dp[N]);
        }
    }
}
