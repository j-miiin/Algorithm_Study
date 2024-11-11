using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold4
{
    internal class SpecificShortestPath
    {
        class Node
        {
            public int node;
            public int cost;

            public Node (int node, int cost)
            {
                this.node = node;
                this.cost = cost;
            }
        }

        public const int INF = 200_000_000;

        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(" ");
            int N = int.Parse(str[0]);
            int E = int.Parse(str[1]);

            List<List<Node>> graph = new List<List<Node>>();
            for (int i = 0; i <= N; i++)
            {
                graph.Add(new List<Node>());
            }

            for (int i = 0; i < E; i++)
            {
                str = Console.ReadLine().Split(" ");
                int v1 = int.Parse(str[0]);
                int v2 = int.Parse(str[1]);
                int cost = int.Parse(str[2]);

                graph[v1].Add(new Node(v2, cost));
                graph[v2].Add(new Node(v1, cost));
            }

            str = Console.ReadLine().Split(" ");
            int node1 = int.Parse(str[0]);
            int node2 = int.Parse(str[1]);

            int r1 = Dijkstra(1, node1, N, graph) 
                + Dijkstra(node1, node2, N, graph)
                + Dijkstra(node2, N, N, graph);
            
            int r2 = Dijkstra(1, node2, N, graph)
                + Dijkstra(node2, node1, N, graph)
                + Dijkstra(node1, N, N, graph);

            int r3 = Dijkstra(1, node1, N, graph)
                + Dijkstra(node1, node2, N, graph)
                + Dijkstra(node2, node1, N, graph)
                + Dijkstra(node1, N, N, graph);

            int r4 = Dijkstra(1, node2, N, graph)
                + Dijkstra(node2, node1, N, graph)
                + Dijkstra(node1, node2, N, graph)
                + Dijkstra(node2, N, N, graph);

            if ((r1 < 0 || r1 >= INF) && (r2 < 0 || r2 >= INF)
                && (r3 < 0 || r3 >= INF) && (r4 < 0 || r4 >= INF))
            {
                Console.WriteLine(-1);
            } else
            {
                Console.WriteLine(Math.Min(r1, Math.Min(r2, Math.Min(r3, r4))));
            }
        }

        static int Dijkstra(int start, int end, int N, List<List<Node>> graph)
        {
            if (start == end)
            {
                return 0;
            }

            int[] dist = new int[N + 1];
            bool[] visited = new bool[N + 1];

            Array.Fill(dist, INF);
            dist[start] = 0;

            for (int i = 0; i < N; i++)
            {
                int nodeIdx = 0;
                int nodeValue = int.MaxValue;

                for (int j = 1; j <= N; j++)
                {
                    if (!visited[j] && dist[j] < nodeValue)
                    {
                        nodeIdx = j;
                        nodeValue = dist[j];
                    }
                }

                visited[nodeIdx] = true;

                for (int j = 0; j < graph[nodeIdx].Count; j++)
                {
                    Node nextNode = graph[nodeIdx][j];

                    dist[nextNode.node] = Math.Min(dist[nextNode.node],
                        dist[nodeIdx] + nextNode.cost);
                }
            }

            return dist[end];
        }
    }
}
