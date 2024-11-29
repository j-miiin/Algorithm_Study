using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold5
{
    internal class Solution
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int[] solutions = new int[N];

            string[] str = Console.ReadLine().Split(" ");
            for (int i = 0; i < N; i++)
            {
                solutions[i] = int.Parse(str[i]);   
            }

            int front = 0;
            int back = solutions.Length - 1;

            int ansIdx1 = 0;
            int ansIdx2 = solutions.Length - 1;
            long answer = long.MaxValue;
            while (front < back)
            {
                long cur = solutions[front] + solutions[back];

                if (cur == 0)
                {
                    ansIdx1 = front;
                    ansIdx2 = back;
                    break;
                } else if (cur > 0)
                {
                    if (Math.Abs(cur) < answer)
                    {
                        ansIdx1 = front;
                        ansIdx2 = back;
                        answer = Math.Abs(cur);
                    }
                    back--;
                } else
                {
                    if (Math.Abs(cur) < answer)
                    {
                        ansIdx1 = front;
                        ansIdx2 = back;
                        answer = Math.Abs(cur);
                    }
                    front++;
                }
            }

            Console.WriteLine(solutions[ansIdx1] + " " + solutions[ansIdx2]);
        }
    }
}
