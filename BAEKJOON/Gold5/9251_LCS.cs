using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold5
{
    internal class LCS
    {
        static void Main(string[] args)
        {
            string str1 = Console.ReadLine();
            string str2 = Console.ReadLine();

            int N = str1.Length;
            int M = str2.Length;
            int[,] dp = new int[N + 1, M + 1];

            for (int i = 0; i <= N; i++)
            {
                for (int j = 0; j <= M; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        dp[i, j] = 0;
                    } else if (str1[i - 1] == str2[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                    } else
                    {
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                    }
                }
            }

            Console.WriteLine(dp[N, M]);
        }
    }
}
