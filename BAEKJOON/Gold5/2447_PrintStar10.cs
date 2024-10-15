using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold5
{
    internal class PrintStar10
    {
        static int N;
        static char[,] map;

        static void Main(string[] args)
        {
            N = int.Parse(Console.ReadLine());
            map = new char[N, N];

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    map[i, j] = ' ';
                }
            }

            Fill(N, 0, 0);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    sb.Append(map[i, j]);
                }
                sb.Append("\n");
            }

            Console.WriteLine(sb.ToString());   
        }

        static void Fill(int n, int x, int y)
        {
            if (n == 1)
            {
                map[x, y] = '*';
                return;
            }

            int div = n / 3;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i == 1 && j == 1)
                    {
                        continue;
                    }

                    Fill(div, x + (div * i), y + (div * j));
                }
            }
        }
    }
}
