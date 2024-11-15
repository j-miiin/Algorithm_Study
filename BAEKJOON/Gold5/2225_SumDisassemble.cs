using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold4
{
    internal class SumDisassemble
    {
        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(" ");
            int N = int.Parse(str[0]);
            int K = int.Parse(str[1]);

            long[,] dp = new long[N + 1, K + 1];

            for (int i = 0; i <= N; i++)
            {
                dp[i, 1] = 1;
            }

            Console.WriteLine(Count(N, K, dp));
        }

        static long Count(int n, int k, long[,] dp)
        {
            if (dp[n, k] != 0)
            {
                return dp[n, k];
            }

            long sum = 0;
            for (int i = 0; i <= n; i++)
            {
                sum += Count(n - i, k - 1, dp) % 1_000_000_000;
            }

            dp[n, k] = sum % 1_000_000_000;

            return dp[n, k];
        }
    }
}
