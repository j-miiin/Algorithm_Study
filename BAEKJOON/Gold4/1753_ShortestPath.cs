using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold4
{
    internal class ShortestPath
    {
        const int INF = 100_000_000;

        public class Node
        {
            public int node;
            public int cost;

            public Node(int n, int c)
            {
                node = n;
                cost = c;
            }
        }

        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(" ");
            int V = int.Parse(str[0]);
            int E = int.Parse(str[1]);

            int K = int.Parse(Console.ReadLine());

            List<List<Node>> graph = new List<List<Node>>();
            for (int i = 0; i <= V; i++)
            {
                graph.Add(new List<Node>());
            }

            for (int i = 0; i < E; i++)
            {
                str = Console.ReadLine().Split(" ");

                int node1 = int.Parse(str[0]);
                int node2 = int.Parse(str[1]);
                int cost = int.Parse(str[2]);

                graph[node1].Add(new Node(node2, cost));
            }

            bool[] visited = new bool[V + 1];
            int[] dist = new int[V + 1];
            Array.Fill(dist, INF);

            dist[K] = 0;

            for (int i = 0; i < V; i++)
            {
                int nodeValue = INF;
                int nodeIdx = 0;

                for (int j = 1; j <= V; j++)
                {
                    if (!visited[j] && dist[j] < nodeValue)
                    {
                        nodeValue = dist[j];
                        nodeIdx = j;
                    }
                }

                visited[nodeIdx] = true;

                for (int j = 0; j < graph[nodeIdx].Count; j++)
                {
                    Node adjNode = graph[nodeIdx][j];   
                    if (dist[adjNode.node] > dist[nodeIdx] + adjNode.cost)
                    {
                        dist[adjNode.node] = dist[nodeIdx] + adjNode.cost;
                    }
                }
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= V; i++)
            {
                sb.Append((dist[i] == INF) ? "INF" : dist[i]).Append("\n");
            }

            Console.WriteLine(sb.ToString());   
        }
    }
}
