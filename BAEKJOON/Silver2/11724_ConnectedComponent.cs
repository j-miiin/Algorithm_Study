using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Silver2
{
    internal class ConnectedComponent
    {
        static List<List<int>> graph;
        static bool[] visited;

        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(" ");
            int N = int.Parse(str[0]);
            int M = int.Parse(str[1]);

            graph = new List<List<int>>();
            visited = new bool[N + 1];

            for (int i = 0; i <= N; i++)
            {
                graph.Add(new List<int>());
            }

            for (int i = 0; i < M; i++)
            {
                str = Console.ReadLine().Split(" ");

                int node1 = int.Parse(str[0]);
                int node2 = int.Parse(str[1]);

                graph[node1].Add(node2);
                graph[node2].Add(node1);
            }

            int count = 0;
            for (int i = 1; i <= N; i++)
            {
                if (!visited[i])
                {
                    visited[i] = true;
                    SearchGraph(i);
                    count++;
                }
            }

            Console.WriteLine(count);
        }

        static void SearchGraph(int curNode)
        {
            for (int i = 0; i < graph[curNode].Count; i++)
            {
                int nextNode = graph[curNode][i];
                if (!visited[nextNode])
                {
                    visited[nextNode] = true;
                    SearchGraph(nextNode);
                }
            }
        }
    }
}
