using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Silver2
{
    internal class ContinuousSum
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] array = new int[n];
            string[] str = Console.ReadLine().Split(" ");
            for (int i = 0; i < n; i++)
            {
                array[i] = int.Parse(str[i]);
            }

            int[] sum = new int[n];
            sum[0] = array[0];
            int answer = Math.Max(int.MinValue, sum[0]);

            for (int i = 1; i < n; i++)
            {
                sum[i] = Math.Max(sum[i - 1] + array[i], array[i]);
                answer = Math.Max(answer, sum[i]);
            }

            Console.WriteLine(answer);
        }
    }
}
