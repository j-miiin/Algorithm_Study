using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold5
{
    internal class NovelPrimeNum
    {
        static int N;
        static StringBuilder sb = new StringBuilder();

        static void Main(string[] args)
        {
            N = int.Parse(Console.ReadLine());

            for (int i = 2; i < 9; i++)
            {
                if (IsPrime(i))
                {
                    GetNovelPrime(i, 1);
                }
            }

            Console.WriteLine(sb.ToString());
        }

        static void GetNovelPrime(int curNum, int depth)
        {
            if (depth == N)
            {
                sb.Append(curNum).Append("\n");
                return;
            }

            for (int i = 0; i <= 9; i++)
            {
                int next = curNum * 10 + i;
                if (IsPrime(next))
                {
                    GetNovelPrime(next, depth + 1);
                } 
            }
        }

        static bool IsPrime(int n)
        {
            if (n == 0 || n == 1)
            {
                return false;
            }

            for (int i = 2; i * i <= n; i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
