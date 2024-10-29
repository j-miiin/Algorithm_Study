using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold4
{
    internal class PartialSum
    {
        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(" ");
            int N = int.Parse(str[0]);
            int S = int.Parse(str[1]);

            int[] sum = new int[N + 1];
            str = Console.ReadLine().Split(" ");
            for (int i = 1; i < N + 1; i++)
            {
                sum[i] = sum[i - 1] + int.Parse(str[i - 1]);
            }

            int front = 0;
            int end = 0;
            int answer = 100001;

            while (end <= N)
            {
                int partialSum = sum[end] - sum[front];

                if (partialSum >= S)
                {
                    answer = Math.Min(answer, end - front);
                    front++;
                } else
                {
                    end++;
                }
            }

            Console.WriteLine((answer == 100001) ? 0 : answer);
        }
    }
}
