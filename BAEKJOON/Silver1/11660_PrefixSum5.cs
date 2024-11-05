using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Silver1
{
    internal class PrefixSum5
    {
        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(" ");
            int N = int.Parse(str[0]);
            int M = int.Parse(str[1]);

            int[,] table = new int[N + 1, N + 1];
            for (int i = 1; i <= N; i++)
            {
                str = Console.ReadLine().Split(" ");
                for (int j = 1; j <= N; j++)
                {
                    table[i, j] = table[i, j - 1] + int.Parse(str[j - 1]);
                }
            }

            for (int i = 1; i <= N; i++)
            {
                for (int j = 1; j <= N; j++)
                {
                    table[i, j] += table[i - 1, j];
                }
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < M; i++)
            {
                str = Console.ReadLine().Split(" ");
                int x1 = int.Parse(str[0]) - 1;
                int y1 = int.Parse(str[1]) - 1;
                int x2 = int.Parse(str[2]);
                int y2 = int.Parse(str[3]);

                int sum = table[x2, y2] - (table[x1, y2] + table[x2, y1]) + table[x1, y1];
                sb.Append(sum).Append("\n");
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
