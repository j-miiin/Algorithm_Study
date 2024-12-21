using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold5
{
    internal class Rainwater
    {
        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(" ");
            int H = int.Parse(str[0]);
            int W = int.Parse(str[1]);

            int[] height = new int[W];
            str = Console.ReadLine().Split(" ");
            for (int i = 0; i < W; i++)
            {
                height[i] = int.Parse(str[i]);
            }

            int answer = 0;
            for (int i = 1; i < W - 1; i++)
            {
                int leftMax = 0;
                for (int j = 0; j < i; j++)
                {
                    leftMax = Math.Max(leftMax, height[j]);
                }

                int rightMax = 0;
                for (int j = i + 1; j < W; j++)
                {
                    rightMax = Math.Max(rightMax, height[j]);
                }

                int min = Math.Min(leftMax, rightMax);

                if (min > height[i])
                {
                    answer += min - height[i];
                }
            }

            Console.WriteLine(answer);
        }
    }
}
