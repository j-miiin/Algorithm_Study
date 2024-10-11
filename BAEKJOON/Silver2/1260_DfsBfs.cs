using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Silver2
{
    internal class DfsBfs
    {
        static List<int> dfsResult;
        static List<int> bfsResult;

        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(" ");
            int N = int.Parse(str[0]);
            int M = int.Parse(str[1]);
            int V = int.Parse(str[2]);

            List<SortedSet<int>> graph = new List<SortedSet<int>>();
            for (int i = 0; i <= N; i++)
            {
                graph.Add(new SortedSet<int>());
            }

            for (int i = 0; i < M; i++)
            {
                str = Console.ReadLine().Split(" ");
                int node1 = int.Parse(str[0]);
                int node2 = int.Parse(str[1]);
                graph[node1].Add(node2);
                graph[node2].Add(node1);
            }

            dfsResult = new List<int>();
            bfsResult = new List<int>();

            bool[] visited = new bool[N + 1];
            visited[V] = true;
            dfsResult.Add(V);

            Dfs(N, V, graph, visited);
            Bfs(N, V, graph);

            StringBuilder sb1 = new StringBuilder();
            StringBuilder sb2 = new StringBuilder();
            for (int i = 0; i < dfsResult.Count; i++)
            {
                sb1.Append(dfsResult[i]).Append(" ");
                sb2.Append(bfsResult[i]).Append(" ");
            }

            Console.WriteLine(sb1.ToString());
            Console.WriteLine(sb2.ToString());
        }

        public static void Dfs(int nodeNum, int curNode, List<SortedSet<int>> graph, bool[] visited)
        {
            if (dfsResult.Count == nodeNum)
            {
                return;
            }

            foreach (int node in graph[curNode])
            {
                if (!visited[node])
                {
                    visited[node] = true;
                    dfsResult.Add(node);
                    Dfs(nodeNum, node, graph, visited);
                }
            }
        }

        public static void Bfs(int nodeNum, int curNode, List<SortedSet<int>> graph)
        {
            bool[] visited = new bool[nodeNum + 1];
            Queue<int> queue = new Queue<int>();

            visited[curNode] = true;
            queue.Enqueue(curNode);

            while (queue.Count > 0)
            {
                int cur = queue.Dequeue();
                bfsResult.Add(cur);

                foreach (int node in graph[cur])
                {
                    if (!visited[node])
                    {
                        visited[node] = true;
                        queue.Enqueue(node);
                    }
                }
            }
        }
    }
}
