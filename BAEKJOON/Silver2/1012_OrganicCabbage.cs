using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Silver2
{
    internal class OrganicCabbage
    {
        static int M, N;
        static int[,] ground;

        static void Main(string[] args)
        {
            int T = int.Parse(Console.ReadLine());

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < T; i++)
            {
                string[] str = Console.ReadLine().Split(" ");

                M = int.Parse(str[0]);
                N = int.Parse(str[1]);
                ground = new int[M, N];

                int K = int.Parse(str[2]);
                for (int j = 0; j < K; j++)
                {
                    str = Console.ReadLine().Split(" ");
                    int x = int.Parse(str[0]);
                    int y = int.Parse(str[1]);

                    ground[x, y] = 1;
                }

                int count = 0;
                bool[,] visited = new bool[M, N];
                for (int x = 0; x < M; x++)
                {
                    for (int y = 0; y < N; y++)
                    {
                        if (!visited[x, y] && ground[x, y] == 1)
                        {
                            Bfs(x, y, visited);
                            count++;
                        }
                    }
                }

                sb.Append(count).Append("\n");
            }

            Console.Write(sb.ToString());
        }

        static void Bfs(int x, int y, bool[,] visited)
        {
            int[] dx = { -1, 1, 0, 0 };
            int[] dy = { 0, 0, -1, 1 };

            Queue<int[]> queue = new Queue<int[]>();
            visited[x, y] = true;
            queue.Enqueue(new int[] { x, y });

            while (queue.Count > 0)
            {
                int[] cur = queue.Dequeue();
                int curX = cur[0];
                int curY = cur[1];  

                for (int i = 0; i < dx.Length; i++)
                {
                    int nextX = curX + dx[i];
                    int nextY = curY + dy[i];

                    if (nextX < 0 || nextY < 0 || nextX >= M || nextY >= N
                        || visited[nextX, nextY] || ground[nextX, nextY] == 0)
                    {
                        continue;
                    }

                    visited[nextX, nextY] = true;
                    queue.Enqueue(new int[] { nextX, nextY });
                }
            }
        }
    }
}
