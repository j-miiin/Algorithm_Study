using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold5
{
    internal class ABCDE
    {
        static List<List<int>> graph;
        static bool isTrue;

        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(" ");
            int N = int.Parse(str[0]);
            int M = int.Parse(str[1]);

            graph = new List<List<int>>();
            for (int i = 0; i < N; i++)
            {
                graph.Add(new List<int>());
            }

            for (int i = 0; i < M; i++)
            {
                str = Console.ReadLine().Split(" ");
                int n1 = int.Parse(str[0]);
                int n2 = int.Parse(str[1]);

                graph[n1].Add(n2);
                graph[n2].Add(n1);
            }

            bool[] visited = new bool[N];
            for (int i = 0; i < N; i++)
            {
                isTrue = false;
                Array.Fill(visited, false);
                visited[i] = true;
                Dfs(i, 0, visited);

                if (isTrue)
                {
                    Console.WriteLine(1);
                    return;
                }
            }

            Console.WriteLine(0);
        }

        static void Dfs(int cur, int depth, bool[] visited)
        {
            if (depth >= 4)
            {
                isTrue = true;
                return;
            }

            for (int i = 0; i < graph[cur].Count; i++)
            {
                int next = graph[cur][i];
                if (!visited[next])
                {
                    visited[next] = true;
                    Dfs(next, depth + 1, visited);
                    visited[next] = false;
                }
            }
        }
    }
}
