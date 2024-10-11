using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon
{
    internal class Floyd
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int M = int.Parse(Console.ReadLine());
            int[,] dist = new int[N, N];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (i == j) dist[i, j] = 0;
                    else dist[i, j] = 10000001;
                }
            }

            for (int i = 0; i < M; i++)
            {
                string[] str = Console.ReadLine().Split(" ");
                int node1 = int.Parse(str[0]) - 1;
                int node2 = int.Parse(str[1]) - 1;
                int cost = int.Parse(str[2]);

                dist[node1, node2] = Math.Min(dist[node1, node2], cost);
            }

            for (int k = 0; k < N; k++)
            {
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        if (dist[i, k] + dist[k, j] < dist[i, j])
                        {
                            dist[i, j] = dist[i, k] + dist[k, j];
                        }
                    }
                }
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (dist[i, j] >= 10000001) sb.Append("0");
                    else sb.Append(dist[i, j]);
                    if (j != N) sb.Append(" ");
                }
                sb.Append("\n");
            }
            Console.WriteLine(sb);
        }
    }
}
