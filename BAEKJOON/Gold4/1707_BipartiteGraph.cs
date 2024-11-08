using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold4
{
    internal class BipartiteGraph
    {
        static bool isBipartiteGraph;

        static void Main(string[] args)
        {
            int K = int.Parse(Console.ReadLine());

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < K; i++)
            {
                string[] str = Console.ReadLine().Split(" ");
                int V = int.Parse(str[0]);
                int E = int.Parse(str[1]);

                List<List<int>> graph = new List<List<int>>();
                for (int j = 0; j <= V; j++)
                {
                    graph.Add(new List<int>());
                }

                for (int j = 0; j < E; j++)
                {
                    str = Console.ReadLine().Split(" ");
                    int v1 = int.Parse(str[0]);
                    int v2 = int.Parse(str[1]);

                    graph[v1].Add(v2);
                    graph[v2].Add(v1);
                }

                isBipartiteGraph = true;
                int[] color = new int[V + 1];

                for (int j = 1; j <= V; j++)
                {
                    if (!isBipartiteGraph)
                    {
                        break;
                    }

                    if (color[j] == 0)
                    {
                        color[j] = 1;
                        CheckGraph(j, graph, color);
                    }
                }

                sb.Append((isBipartiteGraph) ? "YES" : "NO").Append("\n");
            }

            Console.WriteLine(sb.ToString());
        }

        static void CheckGraph(int curNode, List<List<int>> graph, int[] color)
        {
            for (int i = 0; i < graph[curNode].Count; i++)
            {
                int nextNode = graph[curNode][i];

                if (color[curNode] == color[nextNode])
                {
                    isBipartiteGraph = false;
                    break;
                }

                if (color[nextNode] == 0)
                {
                    color[nextNode] = color[curNode] * -1;
                    CheckGraph(nextNode, graph, color);
                }
            }
        }
    }
}
