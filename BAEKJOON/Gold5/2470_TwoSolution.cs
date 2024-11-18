using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold5
{
    internal class TwoSolution
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            long[] solutions = new long[N];
            string[] str = Console.ReadLine().Split(" ");
            for (int i = 0; i < N; i++)
            {
                solutions[i] = long.Parse(str[i]);
            }

            Array.Sort(solutions);  

            long minResult = long.MaxValue;
            long[] answer = new long[2];

            int front = 0;
            int back = solutions.Length - 1;

            while (front < back)
            {
                long sum = solutions[front] + solutions[back];
                if (sum == 0)
                {
                    answer[0] = solutions[front];
                    answer[1] = solutions[back];
                    break;
                } else if (sum > 0)
                {
                    if (Math.Abs(sum) < minResult)
                    {
                        minResult = Math.Abs(sum);
                        answer[0] = solutions[front];
                        answer[1] = solutions[back];
                    }
                    back--;
                } else
                {
                    if (Math.Abs(sum) < minResult)
                    {
                        minResult = Math.Abs(sum);
                        answer[0] = solutions[front];
                        answer[1] = solutions[back];
                    }
                    front++;
                }
            }

            Console.WriteLine(answer[0] + " " + answer[1]);
        }
    }
}
