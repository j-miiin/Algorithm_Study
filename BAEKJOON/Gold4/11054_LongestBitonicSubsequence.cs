using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold4
{
    internal class LongestBitonicSubsequence
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            int[] sequence = new int[N];

            string[] str = Console.ReadLine().Split(" ");
            for (int i = 0; i < N; i++)
            {
                sequence[i] = int.Parse(str[i]);
            }

            int[] increase = new int[N];
            int[] reverse_increase = new int[N];

            for (int i = 0; i < N; i++)
            {
                increase[i] = 1;
                for (int j = 0; j < i; j++)
                {
                    if (sequence[j] < sequence[i] && increase[i] < increase[j] + 1)
                    {
                        increase[i] = increase[j] + 1;
                    }
                }
            }
            
            for (int i = N - 1; i >= 0; i--)
            {
                reverse_increase[i] = 1;
                for (int j = N - 1; j > i; j--)
                {
                    if (sequence[j] < sequence[i] 
                        && reverse_increase[i] < reverse_increase[j] + 1)
                    {
                        reverse_increase[i] = reverse_increase[j] + 1;
                    }
                }
            }

            int answer = int.MinValue;
            for (int i = 0; i < N; i++)
            {
                answer = Math.Max(answer, increase[i] + reverse_increase[i]);
            }

            Console.WriteLine(answer - 1);
        }
    }
}
