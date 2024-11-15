using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold5
{
    internal class Wire
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            List<int[]> wireList = new List<int[]>();
            for (int i = 0; i < N; i++)
            {
                string[] str = Console.ReadLine().Split(" ");
                int numA = int.Parse(str[0]);
                int numB = int.Parse(str[1]);

                wireList.Add(new int[] { numA, numB });
            }

            wireList.Sort((w1, w2) =>
            {
                return w1[0] - w2[0];
            });

            int[] dp = new int[N];
            Array.Fill(dp, 1);

            int max = 0;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (wireList[j][1] < wireList[i][1])
                    {
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                        max = Math.Max(max, dp[i]);
                    }
                }
            }

            Console.WriteLine(N - max);  
        }
    }
}
