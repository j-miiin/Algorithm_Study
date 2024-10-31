using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Silver1
{
    internal class Multiplication
    {
        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(" ");
            long A = long.Parse(str[0]);
            long B = long.Parse(str[1]);
            long C = long.Parse(str[2]);
            
            Console.WriteLine(Power(A, B, C));
        }

        static long Power(long num, long count, long mod)
        {
            if (count == 1)
            {
                return num % mod;
            }

            long x = Power(num, count / 2, mod);

            if (count % 2 == 0)
            {
                return (x * x) % mod;
            } else
            {
                return ((x * x) % mod) * num % mod;
            }
        }
    }
}
