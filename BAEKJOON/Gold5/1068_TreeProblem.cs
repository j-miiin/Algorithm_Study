using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold5
{
    internal class TreeProblem
    {
        static List<List<int>> graph = new List<List<int>>();

        static int answer = 0;

        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                graph.Add(new List<int>());
            }

            int parentNode = 0;

            string[] str = Console.ReadLine().Split(" ");
            for (int i = 0; i < N; i++)
            {
                int parent = int.Parse(str[i]);
                if (parent == -1)
                {
                    parentNode = i;
                    continue;
                }
                graph[parent].Add(i);
            }

            int removeNode = int.Parse(Console.ReadLine());
            for (int i = 0; i < N; i++)
            {
                if (graph[i] != null && graph[i].Contains(removeNode))
                {
                    graph[i].Remove(removeNode);
                    break;
                }
            }

            RemoveNode(removeNode);

            SearchLeafNode(parentNode);

            Console.WriteLine(answer);
        }

        static void RemoveNode(int curNode)
        {
            for (int i = 0; i < graph[curNode].Count; i++)
            {
                RemoveNode(graph[curNode][i]);
            }

            graph[curNode] = null;
        }

        static void SearchLeafNode(int curNode)
        {
            if (graph[curNode] == null)
            {
                return;
            }

            if (graph[curNode].Count == 0)
            {
                answer++;
                return;
            }

            for (int i = 0; i < graph[curNode].Count; i++)
            {
                SearchLeafNode(graph[curNode][i]);
            }
        }
    }
}
