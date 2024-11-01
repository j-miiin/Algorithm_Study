using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold5
{
    internal class MinCost
    {
        class Node
        {
            public int node;
            public int cost;

            public Node(int node, int cost) 
            { 
                this.node = node;
                this.cost = cost;
            }
        }

        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int M = int.Parse(Console.ReadLine());

            List<List<Node>> graph = new List<List<Node>>();
            for (int i = 0; i <= N; i++)
            {
                graph.Add(new List<Node>());
            }

            string[] str;
            for (int i = 0; i < M; i++)
            {
                str = Console.ReadLine().Split(" ");
                int v1 = int.Parse(str[0]);
                int v2 = int.Parse(str[1]);
                int cost = int.Parse(str[2]);

                graph[v1].Add(new Node(v2, cost));
            }

            str = Console.ReadLine().Split(" ");
            int start = int.Parse(str[0]);
            int end = int.Parse(str[1]);

            int INF = 200_000_000;
            bool[] visited = new bool[N + 1];
            int[] dist = new int[N + 1];

            Array.Fill(dist, INF);
            dist[start] = 0;

            for (int i = 0; i < N; i++)
            {
                int nodeIdx = 0;
                int nodeValue = INF;

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

            Console.WriteLine(dist[end]);
        }

        #region Floyd
        //static void Main(string[] args)
        //{
        //    int N = int.Parse(Console.ReadLine());
        //    int M = int.Parse(Console.ReadLine());

        //    int INF = 200_000_000;
        //    int[,] city = new int[N + 1, N + 1];
        //    for (int i = 0; i <= N; i++)
        //    {
        //        for (int j = 0; j <= N; j++)
        //        {
        //            if (i == j)
        //            {
        //                city[i, j] = 0;
        //            }
        //            else
        //            {
        //                city[i, j] = INF;
        //            }
        //        }
        //    }

        //    string[] str;
        //    for (int i = 0; i < M; i++)
        //    {
        //        str = Console.ReadLine().Split(" ");
        //        int v1 = int.Parse(str[0]);
        //        int v2 = int.Parse(str[1]);
        //        int cost = int.Parse(str[2]);

        //        city[v1, v2] = Math.Min(city[v1, v2], cost);
        //    }

        //    for (int k = 1; k <= N; k++)
        //    {
        //        for (int i = 1; i <= N; i++)
        //        {
        //            for (int j = 1; j <= N; j++)
        //            {
        //                if (city[i, j] > city[i, k] + city[k, j])
        //                {
        //                    city[i, j] = city[i, k] + city[k, j];
        //                }
        //            }
        //        }
        //    }

        //    str = Console.ReadLine().Split(" ");
        //    int start = int.Parse(str[0]);
        //    int end = int.Parse(str[1]);

        //    Console.WriteLine(city[start, end]);
        //}
        #endregion
    }
}
