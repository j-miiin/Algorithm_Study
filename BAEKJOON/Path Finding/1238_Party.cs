using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon
{
    internal class Party
    {
        class Node
        {
            public int idx;
            public int cost;

            public Node(int idx, int cost)
            {
                this.idx = idx;
                this.cost = cost;
            }
        }

        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(" ");
            int N = int.Parse(str[0]);
            int M = int.Parse(str[1]);
            int X = int.Parse(str[2]);

            List<List<Node>> graph = new List<List<Node>>();
            List<List<Node>> reverseGraph = new List<List<Node>>();
            for (int i = 0; i < N + 1; i++)
            {
                graph.Add(new List<Node>());
                reverseGraph.Add(new List<Node>());
            }

            for (int i = 0; i < M; i++)
            {
                string[] edges = Console.ReadLine().Split(" ");
                int start = int.Parse(edges[0]);
                int end = int.Parse(edges[1]);
                int cost = int.Parse(edges[2]);

                graph[start].Add(new Node(end, cost));
                reverseGraph[end].Add(new Node(start, cost));
            }

            int[] dist = new int[N + 1];
            int[] reverseDist = new int[N + 1];
            for (int i = 0; i < N + 1; i++)
            {
                dist[i] = int.MaxValue;
                reverseDist[i] = int.MaxValue;
            }

            Dijkstra(N, X, dist, graph);
            Dijkstra(N, X, reverseDist, reverseGraph);

            int result = -1;
            for (int i = 1; i < N + 1; i++)
                result = Math.Max(result, dist[i] + reverseDist[i]);
            Console.WriteLine(result);
        }

        static void Dijkstra(int N, int start, int[] dist, List<List<Node>> graph)
        {
            bool[] visited = new bool[N + 1];

            dist[start] = 0;

            for (int i = 0; i < N; i++)
            {
                int nodeIdx = 0;
                int nodeValue = int.MaxValue;

                for (int j = 1; j < N + 1; j++)
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
                    Node node = graph[nodeIdx][j];

                    if (dist[node.idx] > dist[nodeIdx] + node.cost)
                    {
                        dist[node.idx] = dist[nodeIdx] + node.cost;
                    }
                }
            }
        }
    }
}
