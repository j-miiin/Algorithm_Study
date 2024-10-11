using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon
{
    internal class TimeMachine
    {
        static void Main(string[] args)
        {
            const int INF = 1_000_000_000;
            string[] str1 = Console.ReadLine().Split(" ");
            int N = int.Parse(str1[0]);
            int M = int.Parse(str1[1]);

            List<int[]> edges = new List<int[]>();
            for (int i = 0; i < M; i++)
            {
                string[] str2 = Console.ReadLine().Split(" ");
                int start = int.Parse(str2[0]) - 1;
                int end = int.Parse(str2[1]) - 1;
                int cost = int.Parse(str2[2]);

                edges.Add(new int[] { start, end, cost });
            }

            long[] dist = new long[N];
            Array.Fill(dist, INF);
            dist[0] = 0;

            bool isCycle = false;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < edges.Count; j++)
                {
                    int start = edges[j][0];
                    int end = edges[j][1];
                    int cost = edges[j][2];

                    if (dist[start] != INF && dist[end] > dist[start] + cost)
                    {
                        dist[end] = dist[start] + cost;

                        if (i == N - 1) isCycle = true;
                    }
                }
            }

            if (isCycle)
            {
                Console.WriteLine(-1);
                return;
            }

            for (int i = 1; i < dist.Length; i++)
            {
                if (dist[i] == INF) Console.WriteLine(-1);
                else Console.WriteLine(dist[i]);
            }
        }
    }
}
