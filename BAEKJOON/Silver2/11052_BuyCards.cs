using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Silver2
{
    internal class BuyCards
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int[] cards = new int[N + 1];
            int[] dp = new int[N + 1];

            string[] str = Console.ReadLine().Split(" ");
            for (int i = 1; i <= N; i++)
            {
                cards[i] = int.Parse(str[i - 1]);
                dp[i] = cards[i];
            }

            for (int i = 1; i <= N; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    dp[i] = Math.Max(dp[i], dp[i - j] + cards[j]);
                }
            }

            Console.WriteLine(dp[N]);
        }
    }
}
