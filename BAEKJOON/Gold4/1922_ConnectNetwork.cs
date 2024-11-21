using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold4
{
    internal class ConnectNetwork
    {
        class Edge
        {
            public int v1;
            public int v2;
            public int cost;

            public Edge (int v1, int v2, int cost)
            {
                this.v1 = v1;
                this.v2 = v2;
                this.cost = cost;
            }
        }

        static int[] parent;

        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int M = int.Parse(Console.ReadLine());

            parent = new int[N + 1];
            for (int i = 1; i <= N; i++)
            {
                parent[i] = i;
            }

            List<Edge> edges = new List<Edge>();    

            for (int i = 0; i < M; i++)
            {
                string[] str = Console.ReadLine().Split(" ");
                int v1 = int.Parse(str[0]);
                int v2 = int.Parse(str[1]);
                int cost = int.Parse(str[2]);

                edges.Add(new Edge(v1, v2, cost));
            }

            edges.Sort((e1, e2) => { return e1.cost - e2.cost; });

            int answer = 0;
            for (int i = 0; i < edges.Count; i++)
            {
                Edge cur = edges[i];
                if (!IsSameParent(cur.v1, cur.v2))
                {
                    answer += cur.cost;
                    Union(cur.v1, cur.v2);
                }
            }

            Console.WriteLine(answer);
        }

        static int Find(int x)
        {
            if (x == parent[x])
            {
                return x;
            }

            return parent[x] = Find(parent[x]);
        }

        static void Union(int x, int y)
        {
            x = Find(x);
            y = Find(y);

            if (x != y)
            {
                if (x < y)
                {
                    parent[y] = x;
                } else
                {
                    parent[x] = y;
                }
            }
        }

        static bool IsSameParent(int x, int y)
        {
            x = Find(x);
            y = Find(y);

            return x == y;
        }
    }
}
