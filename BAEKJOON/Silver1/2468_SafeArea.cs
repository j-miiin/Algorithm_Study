using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Silver1
{
    internal class SafeArea
    {
        static int[] dx = { -1, 1, 0, 0 };
        static int[] dy = { 0, 0, -1, 1 };

        static int N;
        static int[,] area;
        static bool[,] visited;

        static void Main(string[] args)
        {
            N = int.Parse(Console.ReadLine());
            area = new int[N, N];
            visited = new bool[N, N];

            string[] str;
            int minHeight = 101;
            int maxHeight = 0;
            for (int i = 0; i < N; i++)
            {
                str = Console.ReadLine().Split(" ");
                for (int j = 0; j < N; j++)
                {
                    area[i, j] = int.Parse(str[j]);

                    minHeight = Math.Min(minHeight, area[i, j]);
                    maxHeight = Math.Max(maxHeight, area[i, j]);
                }
            }

            int answer = 0;
            for (int i = minHeight - 1; i < maxHeight; i++)
            {
                int count = 0;
                for (int x = 0; x < N; x++)
                {
                    for (int y = 0; y < N; y++)
                    {
                        visited[x, y] = false;
                    }
                }

                for (int x = 0; x < N; x++)
                {
                    for (int y = 0; y < N; y++)
                    {
                        if (!visited[x, y] && area[x, y] > i)
                        {
                            visited[x, y] = true;
                            SearchSafeArea(x, y, i);
                            count++;
                        }
                    }
                }

                answer = Math.Max(answer, count);
            }

            Console.WriteLine(answer);
        }

        static void SearchSafeArea(int x, int y, int height)
        {
            Queue<int[]> queue = new Queue<int[]>();
            queue.Enqueue(new int[] { x, y });

            while (queue.Count > 0)
            {
                int[] cur = queue.Dequeue();
                int curX = cur[0];
                int curY = cur[1];

                for (int i = 0; i < 4; i++)
                {
                    int nextX = curX + dx[i];
                    int nextY = curY + dy[i];

                    if (nextX < 0 || nextY < 0 || nextX >= N || nextY >= N
                        || visited[nextX, nextY] || area[nextX, nextY] <= height)
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
