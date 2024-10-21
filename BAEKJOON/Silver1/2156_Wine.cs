using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Silver1
{
    internal class Wine
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] wine = new int[n + 1];
            for (int i = 1; i <= n; i++)
            {
                wine[i] = int.Parse(Console.ReadLine());
            }

            int[] dp = new int[n + 1];
            dp[0] = 0;
            dp[1] = wine[1];
            
            if (n > 1)
            {
                dp[2] = dp[1] + wine[2];
            }

            for (int i = 3; i <= n; i++)
            {
                dp[i] = Math.Max(dp[i - 2] + wine[i],
                    Math.Max(dp[i - 3] + wine[i - 1] + wine[i], dp[i - 1]));
            }

            Console.WriteLine(Math.Max(dp[n], dp[n - 1]));
        }
    }
}
