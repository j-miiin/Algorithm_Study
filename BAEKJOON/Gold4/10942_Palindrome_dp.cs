using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold4
{
    internal class Palindrome_dp
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

            // dp[S, E] = S부터 E까지 팰린드롬인가
            int[,] dp = new int[N, N];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j + i < N; j++)
                {
                    int k = j + i;
                    
                    if (j == k)
                    {
                        dp[j, k] = 1;
                        continue;
                    }

                    if (i == 1)
                    {
                        if (nums[j] == nums[k])
                        {
                            dp[j, k] = 1;
                        } else
                        {
                            dp[j, k] = 0;
                        }

                        continue;
                    } 

                    if (nums[j] == nums[k] && dp[j + 1, k - 1] == 1)
                    {
                        dp[j, k] = 1;
                    } else
                    {
                        dp[j, k] = 0;
                    }
                }
            }

            int M = int.Parse(Console.ReadLine());

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < M; i++)
            {
                str = Console.ReadLine().Split(" ");

                int start = int.Parse(str[0]) - 1;
                int end = int.Parse(str[1]) - 1;

                sb.Append(dp[start, end]).Append("\n");
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
