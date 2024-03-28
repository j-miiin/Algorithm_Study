using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level4
{
    internal class Delivery
    {
        class Solution
        {
            public int solution(int N, int[,] road, int K)
            {
                List<List<int>> graph = new List<List<int>>();
                int[,] costInfo = new int[N + 1, N + 1];
                bool[] visited = new bool[N + 1];
                int[] dist = new int[N + 1];

                for (int i = 0; i < N + 1; i++)
                {
                    graph.Add(new List<int>());
                }

                for (int i = 0; i < costInfo.GetLength(0); i++)
                {
                    for (int j = 0; j < costInfo.GetLength(1); j++)
                    {
                        costInfo[i, j] = 10001;
                    }
                }

                for (int i = 0; i < road.GetLength(0); i++)
                {
                    int node1 = road[i, 0];
                    int node2 = road[i, 1];
                    int cost = road[i, 2];

                    graph[node1].Add(node2);
                    graph[node2].Add(node1);
                    if (costInfo[node1, node2] > cost)
                        costInfo[node1, node2] = cost;
                    if (costInfo[node2, node1] > cost)
                        costInfo[node2, node1] = cost;
                }

                for (int i = 0; i < dist.Length; i++)
                {
                    dist[i] = int.MaxValue;
                }

                dist[1] = 0;
                for (int i = 0; i < N; i++)
                {
                    int nodeValue = int.MaxValue;
                    int nodeIdx = 0;
                    for (int j = 1; j < N + 1; j++)
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
                        int nextNode = graph[nodeIdx][j];
                        if (dist[nextNode] > dist[nodeIdx] + costInfo[nodeIdx, nextNode])
                        {
                            dist[nextNode] = dist[nodeIdx] + costInfo[nodeIdx, nextNode];
                        }
                    }
                }

                int answer = 0;

                for (int i = 0; i < dist.Length; i++)
                {
                    if (dist[i] <= K) answer++;
                }

                return answer;
            }
        }
    }
}
