using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Silver1
{
    internal class HideAndSeek
    {
        static int N, K;

        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(" ");
            N = int.Parse(str[0]);
            K = int.Parse(str[1]);

            Console.WriteLine(FindSister());
        }

        static int FindSister()
        {
            int[] dx = { -1, 1 };

            int[] visited = new int[100001];
            Queue<int> queue = new Queue<int>();

            visited[N] = 0;
            queue.Enqueue(N);

            while (queue.Count > 0)
            {
                int cur = queue.Dequeue();
                
                if (cur == K)
                {
                    break;
                }

                for (int i = 0; i < 3; i++)
                {
                    int next = 0;
                    if (i == 2)
                    {
                        next = cur * 2;
                    } else
                    {
                        next = cur + dx[i];
                    }

                    if (next < 0 || next > 100000 || visited[next] > 0)
                    {
                        continue;
                    }

                    visited[next] = visited[cur] + 1;
                    queue.Enqueue(next);
                }
            }

            return visited[K];
        }
    }
}
