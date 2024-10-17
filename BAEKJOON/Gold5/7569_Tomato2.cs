using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold5
{
    internal class Tomato2
    {
        const int EMPTY = -1;
        const int RAW = 0;
        const int RIPE = 1;

        static int[] dx = { -1, 1, 0, 0, 0, 0 };
        static int[] dy = { 0, 0, -1, 1, 0, 0 };
        static int[] dh = { 0, 0, 0, 0, -1, 1 };

        static int N, M, H;
        static int[,,] box;

        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(" ");
            N = int.Parse(str[1]); 
            M = int.Parse(str[0]);
            H = int.Parse(str[2]);

            box = new int[N, M, H];

            int rawTomatoCount = 0;
            for (int h = 0; h < H; h++)
            {
                for (int i = 0; i < N; i++)
                {
                    str = Console.ReadLine().Split(" ");
                    for (int j = 0; j < M; j++)
                    {
                        box[i, j, h] = int.Parse(str[j]);
                        if (box[i, j, h] == RAW)
                        {
                            rawTomatoCount++;
                        }
                    }
                }
            }

            if (rawTomatoCount == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                int[,,] visited = new int[N, M, H];

                for (int h = 0; h < H; h++)
                {
                    for (int i = 0; i < N; i++)
                    {
                        for (int j = 0; j < M; j++)
                        {
                            visited[i, j, h] = -1;
                        }
                    }
                }

                Queue<int[]> queue = new Queue<int[]>();
                for (int h = 0; h < H; h++)
                {
                    for (int i = 0; i < N; i++)
                    {
                        for (int j = 0; j < M; j++)
                        {
                            if (visited[i, j, h] == -1 && box[i, j, h] == RIPE)
                            {
                                queue.Enqueue(new int[] { i, j, h });
                                visited[i, j, h] = 0;
                            }
                        }
                    }
                }

                RawToRipe(visited, queue);

                int day = 0;
                for (int h = 0; h < H; h++)
                {
                    for (int i = 0; i < N; i++)
                    {
                        for (int j = 0; j < M; j++)
                        {
                            if (box[i, j, h] == RAW)
                            {
                                Console.WriteLine(-1);
                                return;
                            }

                            day = Math.Max(day, visited[i, j, h]);
                        }
                    }
                }

                Console.WriteLine(day);
            }
        }

        static void RawToRipe(int[,,] visited, Queue<int[]> queue)
        {
            while (queue.Count > 0)
            {
                int[] cur = queue.Dequeue();
                int curX = cur[0];
                int curY = cur[1];
                int curH = cur[2];

                for (int i = 0; i < dx.Length; i++)
                {
                    int nextX = curX + dx[i];
                    int nextY = curY + dy[i];
                    int nextH = curH + dh[i];

                    if (nextX < 0 || nextY < 0 || nextH < 0 
                        || nextX >= N || nextY >= M || nextH >= H
                        || visited[nextX, nextY, nextH] != -1 
                        || box[nextX, nextY, nextH] != RAW)
                    {
                        continue;
                    }

                    visited[nextX, nextY, nextH] = visited[curX, curY, curH] + 1;
                    box[nextX, nextY, nextH] = RIPE;
                    queue.Enqueue(new int[] { nextX, nextY, nextH });
                }
            }
        }
    }
}
