using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Silver1
{
    internal class EasyStairNumber
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            long[,] dp = new long[N + 1, 10];

            for (int i = 0; i < 10; i++)
            {
                dp[1, i] = 1;
            }

            for (int i = 2; i <= N; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (j == 0)
                    {
                        dp[i, j] = dp[i - 1, 1];
                    } else if (j == 9)
                    {
                        dp[i, j] = dp[i - 1, 8];
                    } else
                    {
                        dp[i, j] = dp[i - 1, j - 1] + dp[i - 1, j + 1];
                    }

                    dp[i, j] %= 1000000000;
                }
            }

            long sum = 0;
            for (int i = 1; i < 10; i++)
            {
                sum += dp[N, i];
            }

            Console.WriteLine(sum % 1000000000);
        }
    }
}
