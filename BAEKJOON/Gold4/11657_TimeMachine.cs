using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold4
{
    internal class TimeMachine
    {
        class Edge
        {
            public long v1, v2;
            public long cost;

            public Edge(long v1, long v2, long cost)
            {
                this.v1 = v1;
                this.v2 = v2;
                this.cost = cost;
            }
        }

        static void Main(string[] args)
        {
            const int INF = 1_000_000_000;

            string[] str = Console.ReadLine().Split(" ");
            int N = int.Parse(str[0]);
            int M = int.Parse(str[1]);
            
            List<Edge> edges = new List<Edge>();
            for (int i = 0; i < M; i++)
            {
                str = Console.ReadLine().Split(" ");
                long v1 = long.Parse(str[0]);
                long v2 = long.Parse(str[1]);
                long cost = long.Parse(str[2]);

                edges.Add(new Edge(v1, v2, cost));
            }

            long[] dist = new long[N + 1];
            Array.Fill(dist, INF);
            dist[1] = 0;

            bool isCycle = false;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < edges.Count; j++)
                {
                    long curNode = edges[j].v1;
                    long nextNode = edges[j].v2;
                    long curCost = edges[j].cost;

                    if (dist[curNode] != INF
                        && dist[nextNode] > dist[curNode] + curCost)
                    {
                        dist[nextNode] = dist[curNode] + curCost;

                        if (i == N - 1)
                        {
                            isCycle = true;
                        }
                    }
                }
            }

            if (isCycle)
            {
                Console.WriteLine(-1);
            } else
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 2; i <= N; i++)
                {
                    sb.Append((dist[i] == INF) ? -1 : dist[i]).Append("\n");
                }
                Console.WriteLine(sb.ToString());
            }
        }
    }
}
