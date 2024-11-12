using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold5
{
    internal class Coin2
    {
        static void Main(string[] args)
        {
            const int INF = 100_000_000;

            string[] str = Console.ReadLine().Split(" ");
            int n = int.Parse(str[0]);
            int k = int.Parse(str[1]);

            int[] coins = new int[n];
            for (int i = 0; i < n; i++)
            {
                coins[i] = int.Parse(Console.ReadLine());
            }

            int[] dp = new int[k + 1];
            Array.Fill(dp, INF);
            dp[0] = 0;

            for (int i = 0; i <= k; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (coins[j] <= i)
                    {
                        dp[i] = Math.Min(dp[i], dp[i - coins[j]] + 1);
                    }
                }
            }

            Console.WriteLine((dp[k] == INF) ? -1 : dp[k]);
        }

        //static void Combination(int count, int value, int[] coins)
        //{
        //    if (value == k)
        //    {
        //        answer = Math.Min(answer, count);
        //        return;
        //    }

        //    for (int i = 0; i < n; i++)
        //    {
        //        if (value + coins[i] <= k)
        //        {
        //            Combination(count + 1, value + coins[i], coins);
        //        }
        //    }
        //}
    }
}
