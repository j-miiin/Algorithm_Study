using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold3
{
    internal class Party 
    {
        class Node : IComparable<Node>
        {
            public int node;
            public int cost;

            public Node(int node, int cost)
            {
                this.node = node;
                this.cost = cost;
            }

            public int CompareTo(Node? other)
            {
                return cost - other.cost;
            }
        }

        class PriorityQueue<T> where T : IComparable<T>
        {
            private List<T> queue;

            public PriorityQueue()
            {
                queue = new List<T>();
            }

            public bool IsEmpty() => queue.Count == 0;

            public void Enqueue(T item)
            {
                queue.Add(item);

                int child = queue.Count - 1;
                while (child > 0)
                {
                    int parent = (child - 1) / 2;

                    if (queue[child].CompareTo(queue[parent]) >= 0)
                    {
                        break;
                    }

                    Swap(child, parent);
                    child = parent;
                }
            }

            public T Dequeue()
            {
                if (queue.Count == 0)
                {
                    return default(T);
                }

                T data = queue[0];
                queue[0] = queue[queue.Count - 1];
                queue.RemoveAt(queue.Count - 1);

                int maxIdx = queue.Count - 1;
                int parent = 0;

                while (parent <= maxIdx)
                {
                    int child = 2 * parent + 1;

                    if (child > maxIdx)
                    {
                        break;
                    }

                    if (child + 1 <= maxIdx && queue[child].CompareTo(queue[child + 1]) > 0)
                    {
                        child++;
                    }

                    if (queue[child].CompareTo(queue[parent]) >= 0)
                    {
                        break;
                    }

                    Swap(child, parent);
                    parent = child;
                }

                return data;
            }

            private void Swap(int x, int y)
            {
                T tmp = queue[x];
                queue[x] = queue[y];
                queue[y] = tmp;
            }
        }

        static int N, M, X;
        static int INF = 100_000_000;

        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(" ");
            N = int.Parse(str[0]);
            M = int.Parse(str[1]);
            X = int.Parse(str[2]);

            List<List<Node>> graph = new List<List<Node>>();
            List<List<Node>> reversedGraph = new List<List<Node>>();

            for (int i = 0; i <= N; i++)
            {
                graph.Add(new List<Node>());
                reversedGraph.Add(new List<Node>());
            }

            for (int i = 0; i < M; i++)
            {
                str = Console.ReadLine().Split(" ");
                int node1 = int.Parse(str[0]);
                int node2 = int.Parse(str[1]);
                int cost = int.Parse(str[2]);

                graph[node1].Add(new Node(node2, cost));
                reversedGraph[node2].Add(new Node(node1, cost));
            }

            //int[] distance = Dijkstra(graph);
            //int[] reversedDistance = Dijkstra(reversedGraph);

            int[] distance = DijkstraWithPriorityQueue(graph);
            int[] reversedDistance = DijkstraWithPriorityQueue(reversedGraph);

            int answer = 0;
            for (int i = 1; i <= N; i++)
            {
                answer = Math.Max(answer, distance[i] + reversedDistance[i]);
            }

            Console.WriteLine(answer);
        }

        static int[] Dijkstra(List<List<Node>> graph)
        {
            bool[] visited = new bool[N + 1];
            int[] distance = new int[N + 1];
            Array.Fill(distance, INF);

            distance[X] = 0;

            for (int i = 0; i < N; i++)
            {
                int nodeIdx = 0;
                int nodeValue = INF;

                for (int j = 1; j <= N; j++)
                {
                    if (!visited[j] && distance[j] < nodeValue)
                    {
                        nodeIdx = j;
                        nodeValue = distance[j];
                    }
                }

                visited[nodeIdx] = true;

                for (int j = 0; j < graph[nodeIdx].Count; j++)
                {
                    Node nextNode = graph[nodeIdx][j];

                    if (distance[nextNode.node] > distance[nodeIdx] + nextNode.cost)
                    {
                        distance[nextNode.node] = distance[nodeIdx] + nextNode.cost;
                    }
                }
            }

            return distance;
        }
        
        static int[] DijkstraWithPriorityQueue(List<List<Node>> graph)
        {
            PriorityQueue<Node> pq = new PriorityQueue<Node>();
            int[] distance = new int[N + 1];

            pq.Enqueue(new Node(X, 0));
            Array.Fill(distance, INF);
            distance[X] = 0;

            while (!pq.IsEmpty())
            {
                Node curNode = pq.Dequeue();

                if (distance[curNode.node] < curNode.cost)
                {
                    continue;
                }

                for (int i = 0; i < graph[curNode.node].Count; i++)
                {
                    Node nextNode = graph[curNode.node][i];

                    if (distance[nextNode.node] > distance[curNode.node] + nextNode.cost)
                    {
                        distance[nextNode.node] = distance[curNode.node] + nextNode.cost;
                        pq.Enqueue(new Node(nextNode.node, distance[nextNode.node]));
                    }
                }
            }

            return distance;
        }
    }
}
