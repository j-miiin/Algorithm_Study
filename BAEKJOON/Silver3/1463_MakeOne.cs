using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmStudy.Baekjoon.Silver3
{
    class MakeOne
    {

        static void Main(string[] args)
        {
            const int INF = 100_000_000;

            int n = int.Parse(Console.ReadLine());

            int[] dp = new int[n + 1];
            Array.Fill(dp, INF);

            dp[1] = 0;

            for (int i = 2; i <= n; i++)
            {
                if (i % 3 == 0 && i % 2 == 0)
                    dp[i] = Math.Min(Math.Min(dp[i / 3], dp[i / 2]), dp[i - 1]) + 1;
                else if (i % 3 == 0)
                    dp[i] = Math.Min(dp[i / 3], dp[i - 1]) + 1;
                else if (i % 2 == 0)
                    dp[i] = Math.Min(dp[i / 2], dp[i - 1]) + 1;
                else
                    dp[i] = dp[i - 1] + 1;
            }

            Console.WriteLine(dp[n]);
        }
    }
}
