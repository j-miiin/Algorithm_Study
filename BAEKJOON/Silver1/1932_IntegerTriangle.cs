using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Silver1
{
    internal class IntegerTriangle
    {
        static int n;
        static int answer = int.MinValue;
        static List<List<int>> triangle;

        static void Main(string[] args)
        {
            n = int.Parse(Console.ReadLine());
            triangle = new List<List<int>>(n);

            string[] str;
            for (int i = 0; i < n; i++)
            {
                triangle.Add(new List<int>());

                str = Console.ReadLine().Split(" ");
                for (int j = 0; j< str.Length; j++)
                {
                    triangle[i].Add(int.Parse(str[j]));
                }
            }

            int[,] dp = new int[n, n];
            dp[0, 0] = triangle[0][0];
            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < triangle[i].Count; j++)
                {
                    if (j == 0)
                    {
                        dp[i, j] = dp[i - 1, j] + triangle[i][j];
                    } else if (j == triangle[i].Count - 1)
                    {
                        dp[i, j] = dp[i - 1, j - 1] + triangle[i][j];
                    }
                    else
                    {
                        dp[i, j] = triangle[i][j] 
                            + Math.Max(dp[i - 1, j - 1], dp[i - 1, j]);
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                answer = Math.Max(answer, dp[n - 1, i]);
            }

            Console.WriteLine(answer);
        }
    }
}
