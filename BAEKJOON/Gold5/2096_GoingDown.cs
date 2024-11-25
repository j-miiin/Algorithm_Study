using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold5
{
    internal class GoingDown
    {
        static void Main(string[] args)
        {
            const int INF = 100_000_000;

            int N = int.Parse(Console.ReadLine());
            int[,] nums = new int[N, 3];

            for (int i = 0; i < N; i++)
            {
                string[] str = Console.ReadLine().Split(" ");

                nums[i, 0] = int.Parse(str[0]); 
                nums[i, 1] = int.Parse(str[1]); 
                nums[i, 2] = int.Parse(str[2]); 
            }

            int[,] dpMax = new int[N, 3];
            int[,] dpMin = new int[N, 3];

            for (int i = 0; i < N; i++)
            {
                dpMin[i, 0] = INF;
                dpMin[i, 1] = INF;
                dpMin[i, 2] = INF;
            }

            dpMax[0, 0] = dpMin[0, 0] = nums[0, 0];
            dpMax[0, 1] = dpMin[0, 1] = nums[0, 1];
            dpMax[0, 2] = dpMin[0, 2] = nums[0, 2];

            for (int i = 1; i < N; i++)
            {
                dpMax[i, 0] = Math.Max(dpMax[i - 1, 0], dpMax[i - 1, 1]) + nums[i, 0];
                dpMax[i, 1] = Math.Max(Math.Max(dpMax[i - 1, 0], dpMax[i - 1, 1]), dpMax[i - 1, 2]) + nums[i, 1];
                dpMax[i, 2] = Math.Max(dpMax[i - 1, 1], dpMax[i - 1, 2]) + nums[i, 2];

                dpMin[i, 0] = Math.Min(dpMin[i - 1, 0], dpMin[i - 1, 1]) + nums[i, 0];
                dpMin[i, 1] = Math.Min(Math.Min(dpMin[i - 1, 0], dpMin[i - 1, 1]), dpMin[i - 1, 2]) + nums[i, 1];
                dpMin[i, 2] = Math.Min(dpMin[i - 1, 1], dpMin[i - 1, 2]) + nums[i, 2];
            }

            int max = Math.Max(Math.Max(dpMax[N - 1, 0], dpMax[N - 1, 1]), dpMax[N - 1, 2]);
            int min = Math.Min(Math.Min(dpMin[N - 1, 0], dpMin[N - 1, 1]), dpMin[N - 1, 2]);

            Console.WriteLine(max + " " + min);
        }
    }
}
