using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level4
{
    internal class DivideElectricalGrid
    {
        public class Solution
        {
            static List<List<int>> graph = new List<List<int>>();
            static bool[,] isConnected;
            static bool[] visited;

            public int solution(int n, int[,] wires)
            {
                for (int i = 0; i < n + 1; i++)
                {
                    graph.Add(new List<int>());
                }

                isConnected = new bool[n + 1, n + 1];
                for (int i = 0; i < wires.GetLength(0); i++)
                {
                    int node1 = wires[i, 0];
                    int node2 = wires[i, 1];

                    isConnected[node1, node2] = true;
                    isConnected[node2, node1] = true;
                    graph[node1].Add(node2);
                    graph[node2].Add(node1);
                }

                int answer = int.MaxValue;
                for (int i = 0; i < wires.GetLength(0); i++)
                {
                    int node1 = wires[i, 0];
                    int node2 = wires[i, 1];

                    isConnected[node1, node2] = false;
                    isConnected[node2, node1] = false;

                    visited = new bool[n + 1];
                    int[] result = CountNodes(n, node1);

                    answer = Math.Min(answer, Math.Abs(result[0] - result[1]));

                    isConnected[node1, node2] = true;
                    isConnected[node2, node1] = true;
                }
                return answer;
            }

            static int[] CountNodes(int n, int node)
            {
                int count = 1;

                Queue<int> queue = new Queue<int>();
                queue.Enqueue(node);
                visited[node] = true;

                while (queue.Count > 0) 
                { 
                    int curNode = queue.Dequeue();

                    for (int i = 0; i < graph[curNode].Count; i++)
                    {
                        int nextNode = graph[curNode][i];
                        if (isConnected[curNode, nextNode] && !visited[nextNode])
                        {
                            queue.Enqueue(nextNode);
                            visited[nextNode] = true;
                            count++;
                        }
                    }
                }

                return new int[] { count, n - count };
            }
        }
    }
}
