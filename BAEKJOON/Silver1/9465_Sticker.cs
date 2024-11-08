using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Silver1
{
    internal class Sticker
    {
        static void Main(string[] args)
        {
            int T = int.Parse(Console.ReadLine());

            int n;
            int[,] sticker;
            string[] str;

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < T; i++)
            {
                n = int.Parse(Console.ReadLine());
                sticker = new int[2, n];

                for (int j = 0; j < 2; j++)
                {
                    str = Console.ReadLine().Split(" ");
                    for (int k = 0; k < n; k++)
                    {
                        sticker[j, k] = int.Parse(str[k]);
                    }
                }

                sb.Append(GetMaxScore(n, sticker)).Append("\n");
            }

            Console.WriteLine(sb.ToString());
        }

        static int GetMaxScore(int n, int[,] sticker)
        {
            if (n == 1)
            {
                return Math.Max(sticker[0, 0], sticker[1, 0]);
            }

            int[,] dp = new int[2, n];

            dp[0, 0] = sticker[0, 0];
            dp[1, 0] = sticker[1, 0];

            dp[0, 1] = dp[1, 0] + sticker[0, 1];
            dp[1, 1] = dp[0, 0] + sticker[1, 1];

            for (int i = 2; i < n; i++)
            {
                dp[0, i] = Math.Max(dp[1, i - 1], dp[1, i - 2]) + sticker[0, i];
                dp[1, i] = Math.Max(dp[0, i - 1], dp[0, i - 2]) + sticker[1, i];
            }

            return Math.Max(dp[0, n - 1], dp[1, n - 1]);
        }
    }
}
