using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold5
{
    internal class Tomato
    {
        const int EMPTY = -1;
        const int RAW = 0;
        const int RIPE = 1;

        static int[] dx = { -1, 1, 0, 0 };
        static int[] dy = { 0, 0, -1, 1 };

        static int M, N;
        static int[,] box;

        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(" ");
            M = int.Parse(str[1]);
            N = int.Parse(str[0]);

            box = new int[M, N];

            int rawTomatoCount = 0;
            for (int i = 0; i < M; i++)
            {
                str = Console.ReadLine().Split(" ");
                for (int j = 0; j < N; j++)
                {
                    box[i, j] = int.Parse(str[j]);
                    if (box[i, j] == RAW)
                    {
                        rawTomatoCount++;
                    }
                }
            }

            if (rawTomatoCount == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                int[,] visited = new int[M, N];

                for (int i = 0; i < M; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        visited[i, j] = -1;
                    }
                }

                Queue<int[]> queue = new Queue<int[]>();
                for (int i = 0; i < M; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        if (visited[i,j] == -1 && box[i, j] == RIPE)
                        {
                            queue.Enqueue(new int[] { i, j });
                            visited[i, j] = 0;
                        }
                    }
                }

                RawToRipe(visited, queue);

                int day = 0;
                for (int i = 0; i < M; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        if (box[i, j] == RAW)
                        {
                            Console.WriteLine(-1);
                            return;
                        }

                        day = Math.Max(day, visited[i, j]);
                    }
                }

                Console.WriteLine(day);
            }
        }

        static void RawToRipe(int[,] visited, Queue<int[]> queue)
        {
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
                        || visited[nextX, nextY] != -1 || box[nextX, nextY] != RAW)
                    {
                        continue;
                    }

                    visited[nextX, nextY] = visited[curX, curY] + 1;
                    box[nextX, nextY] = RIPE;
                    queue.Enqueue(new int[] { nextX, nextY });
                }
            }
        }
    }
}
