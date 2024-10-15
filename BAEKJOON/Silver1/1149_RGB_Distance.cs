using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Silver1
{
    internal class RGB_Distance
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            int[,] cost = new int[N, 3];
            for (int i = 0; i < N; i++)
            {
                string[] str = Console.ReadLine().Split(" ");
                cost[i, 0] = int.Parse(str[0]);
                cost[i, 1] = int.Parse(str[1]);
                cost[i, 2] = int.Parse(str[2]);
            }

            int[,] dp = new int[N, 3];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i == 0)
                    {
                        dp[i, j] = cost[i, j];
                    } else
                    {
                        int prevColor = (j == 0) ? 2 : j - 1;
                        int nextColor = (j == 2) ? 0 : j + 1;

                        dp[i, j] = Math.Min(dp[i - 1, prevColor] + cost[i, j],
                            dp[i - 1, nextColor] + cost[i, j]);
                    }
                }
            }

            int answer = int.MaxValue;
            for (int i = 0; i < 3; i++)
            {
                if (dp[N - 1, i] < answer)
                {
                    answer = dp[N - 1, i];
                }
            }
            Console.WriteLine(answer);
        }
    }
}
