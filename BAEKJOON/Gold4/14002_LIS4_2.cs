using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold4
{
    internal class LIS4_2
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            int[] nums = new int[N];

            string[] str = Console.ReadLine().Split(" ");
            for (int i = 0; i < N; i++)
            {
                nums[i] = int.Parse(str[i]);
            }

            int[] dp = new int[N];
            Array.Fill(dp, 1);

            int max = 1;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (nums[j] < nums[i])
                    {
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                        max = Math.Max(max, dp[i]);
                    }
                }
            }

            StringBuilder sb = new StringBuilder();
            sb.Append(max).Append("\n");

            List<int> result = new List<int>();
            for (int i = N - 1; i >= 0; i--)
            {
                if (max < 1)
                {
                    break;
                }

                if (dp[i] == max)
                {
                    result.Add(nums[i]);
                    max--;
                }
            }

            for (int i = result.Count - 1; i >= 0; i--)
            {
                sb.Append(result[i]).Append(" ");
            }

            Console.WriteLine(sb.ToString());   
        }
    }
}
