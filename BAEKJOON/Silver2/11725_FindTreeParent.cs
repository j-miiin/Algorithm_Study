using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Silver2
{
    internal class FindTreeParent
    {
        static List<List<int>> graph = new List<List<int>>();
        static int[] parent;
        static bool[] visited;

        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            parent = new int[N + 1];
            visited = new bool[N + 1];

            for (int i = 0; i <= N; i++)
            {
                graph.Add(new List<int>());
            }

            string[] str;
            for (int i = 0; i < N - 1; i++)
            {
                str = Console.ReadLine().Split(" ");
                int node1 = int.Parse(str[0]);
                int node2 = int.Parse(str[1]);

                graph[node1].Add(node2);
                graph[node2].Add(node1);
            }

            SearchTree(1);

            StringBuilder sb = new StringBuilder();
            for (int i = 2; i <= N; i++)
            {
                sb.Append(parent[i]).Append("\n");
            }

            Console.WriteLine(sb.ToString());
        }

        static void SearchTree(int curNode)
        {
            for (int i = 0; i < graph[curNode].Count; i++)
            {
                int nextNode = graph[curNode][i];

                if (!visited[nextNode])
                {
                    visited[nextNode] = true;
                    parent[nextNode] = curNode;
                    SearchTree(nextNode);
                }
            }
        }
    }
}
