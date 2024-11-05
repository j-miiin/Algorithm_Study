using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Silver2
{
    internal class SumOfSubsequence
    {
        static int answer;

        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(" ");
            int N = int.Parse(str[0]);
            int S = int.Parse(str[1]);

            int[] nums = new int[N];
            str = Console.ReadLine().Split(" ");
            for (int i = 0; i < N; i++)
            {
                nums[i] = int.Parse(str[i]);
            }

            FindSubsequence(0, 0, S, nums);

            Console.WriteLine((S == 0) ? answer - 1 : answer);
        }

        static void FindSubsequence(int start, int cur, int target, int[] nums)
        {
            if (cur == target)
            {
                answer++;
            }

            for (int i = start; i < nums.Length; i++)
            {
                FindSubsequence(i + 1, cur + nums[i], target, nums);
            }
        }
    }
}
