using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold5
{
    internal class Z_Problem
    {
        static int r, c;

        static int count = 0;
        static int answer = 0;

        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(" ");
            int N = int.Parse(str[0]);
            r = int.Parse(str[1]);
            c = int.Parse(str[2]);

            int length = (int)Math.Pow(2, N);

            Z_Search(length, 0, 0);

            Console.WriteLine(answer);
        }

        static void Z_Search(int n, int x, int y)
        {
            if (x == r && y == c)
            {
                answer = count;
                return;
            }

            if (r < x + n && r >= x && c < y + n && c >= y)
            {
                int div = n / 2;
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        Z_Search(div, x + (div * i), y + (div * j));
                    }
                }
            } else
            {
                count += n * n;
            }
        }
    }
}
