using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold4
{
    internal class Floyd
    {
        static void Main(string[] args)
        {
            const int INF = 100_000_000;

            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            int[,] city = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                    {
                        city[i, j] = 0;
                    } else
                    {
                        city[i, j] = INF;
                    }
                }
            }

            string[] str;
            for (int i = 0; i < m; i++)
            {
                str = Console.ReadLine().Split(" ");

                int c1 = int.Parse(str[0]) - 1;
                int c2 = int.Parse(str[1]) - 1;
                int cost = int.Parse(str[2]);

                city[c1, c2] = Math.Min(city[c1, c2], cost);
            }

            for (int k = 0; k < n; k++)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        city[i, j] = Math.Min(city[i, j], city[i, k] + city[k, j]);
                    }
                }
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int cost = city[i, j];
                    sb.Append((cost == INF) ? 0 : cost).Append(" ");
                }
                sb.Append("\n");
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
