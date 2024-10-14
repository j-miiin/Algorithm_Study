using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold5
{
    internal class Kanpsack
    {
        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(" ");
            int N = int.Parse(str[0]);
            int K = int.Parse(str[1]);

            int[] weight = new int[N + 1];
            int[] value = new int[N + 1];

            for (int i = 1; i <= N; i++)
            {
                str = Console.ReadLine().Split(" ");
                weight[i] = int.Parse(str[0]);
                value[i] = int.Parse(str[1]);
            }

            int[,] dp = new int[N + 1, K + 1];
            for (int i = 0; i <= N; i++)
            {
                for (int j = 0; j <= K; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        continue;
                    }

                    if (weight[i] <= j)
                    {
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i - 1, j - weight[i]] + value[i]);
                    } else
                    {
                        dp[i, j] = dp[i - 1, j];
                    }
                }
            }

            Console.WriteLine(dp[N, K]);
        }
    }
}
