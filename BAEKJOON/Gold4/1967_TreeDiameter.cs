using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold4
{
    internal class TreeDiameter
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

        static int answer = 0;
        static List<List<Node>> graph = new List<List<Node>>();
        static bool[] visited;

        static void Main(string[] args)
        {
            const int INF = 100_000_000;

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i <= n; i++)
            {
                graph.Add(new List<Node>());
            }

            for (int i = 0; i < n - 1; i++)
            {
                string[] str = Console.ReadLine().Split(" ");
                int parent = int.Parse(str[0]);
                int child = int.Parse(str[1]);
                int cost = int.Parse(str[2]);

                graph[parent].Add(new Node(child, cost));
                graph[child].Add(new Node(parent, cost));
            }

            visited = new bool[n + 1];
            for (int i = 1; i <= n; i++)
            {
                Array.Fill(visited, false);

                visited[i] = true;
                SearchGraph(i, 0);
            }

            Console.WriteLine(answer);
        }

        static void SearchGraph(int curNode, int diameter)
        {
            answer = Math.Max(answer, diameter);

            for (int i = 0; i < graph[curNode].Count; i++)
            {
                Node nextNode = graph[curNode][i];

                if (!visited[nextNode.node])
                {
                    visited[nextNode.node] = true;
                    SearchGraph(nextNode.node, diameter + nextNode.cost);
                    visited[nextNode.node] = false;
                }
            }
        }
    }
}
