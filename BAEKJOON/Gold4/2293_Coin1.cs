using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold4
{
    internal class Coin1
    {
        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(" ");
            int n = int.Parse(str[0]);
            int k = int.Parse(str[1]);

            int[] value = new int[n];
            for (int i = 0; i < n; i++)
            {
                value[i] = int.Parse(Console.ReadLine());
            }

            Array.Sort(value);

            int[] dp = new int[k + 1];
            dp[0] = 1;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= k; j++)
                {
                    if (value[i] <= j)
                    {
                        dp[j] += dp[j - value[i]];
                    }
                }
            }

            Console.WriteLine(dp[k]);
        }
    }
}
