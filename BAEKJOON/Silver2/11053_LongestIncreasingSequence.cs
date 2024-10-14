using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Silver2
{
    internal class LongestIncreasingSequence
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int[] num = new int[N];

            string[] str = Console.ReadLine().Split(" ");
            for (int i = 0; i < str.Length; i++)
            {
                num[i] = int.Parse(str[i]);
            }

            int[] count = new int[N];
            for (int i = 0; i < N; i++)
            {
                count[i] = 1;
                for (int j = 0; j < i; j++)
                {
                    if (num[j] < num[i] && count[i] < count[j] + 1)
                    {
                        count[i] = count[j] + 1;
                    }
                }
            }

            Console.WriteLine(count.Max());
        }
    }
}
