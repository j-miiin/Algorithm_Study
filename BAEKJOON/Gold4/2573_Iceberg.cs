using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold4
{
    internal class Iceberg
    {
        static int[] dx = { -1, 1, 0, 0 };
        static int[] dy = { 0, 0, -1, 1 };

        static int N, M;
        static int[,] area;

        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(" ");
            N = int.Parse(str[0]);
            M = int.Parse(str[1]);
            area = new int[N, M];

            for (int i = 0; i < N; i++)
            {
                str = Console.ReadLine().Split(" ");
                for (int j = 0; j < M; j++)
                {
                    area[i, j] = int.Parse(str[j]);
                }
            }

            bool[,] visited = new bool[N, M];

            int year = 0;
            while (true)
            {
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < M; j++)
                    {
                        visited[i, j] = false;
                    }
                }

                int icebergCnt = 0;
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < M; j++)
                    {
                        if (!visited[i, j] && area[i, j] > 0)
                        {
                            icebergCnt++;
                            SearchIceberg(i, j, visited);
                        }
                    }
                }

                if (icebergCnt == 0)
                {
                    Console.WriteLine(0);
                    break;
                }

                if (icebergCnt >= 2)
                {
                    Console.WriteLine(year);
                    break;
                }

                Melt();

                year++;
            }
        }

        static void SearchIceberg(int x, int y, bool[,] visited)
        {
            Queue<int[]> queue = new Queue<int[]>();

            visited[x, y] = true;
            queue.Enqueue(new int[] { x, y });

            while(queue.Count > 0)
            {
                int[] cur = queue.Dequeue();
                int curX = cur[0];
                int curY = cur[1];

                for (int i = 0; i < 4; i++)
                {
                    int nextX = curX + dx[i];
                    int nextY = curY + dy[i];

                    if (nextX < 0 || nextY < 0 || nextX >= N || nextY >= M
                        || visited[nextX, nextY] || area[nextX, nextY] == 0)
                    {
                        continue;
                    }

                    visited[nextX, nextY] = true;
                    queue.Enqueue(new int[] { nextX, nextY });
                }
            }
        }
    
        static void Melt()
        {
            int[,] meltCount = new int[N, M];

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    if (area[i, j] > 0)
                    {
                        meltCount[i, j] = CheckSea(i, j);
                    }
                }
            }

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    if (area[i, j] > 0)
                    {
                        area[i, j] = Math.Max(0, area[i, j] - meltCount[i, j]);
                    }
                }
            }
        }

        static int CheckSea(int x, int y)
        {
            int count = 0;
            for (int i = 0; i < 4; i++)
            {
                int nextX = x + dx[i];
                int nextY = y + dy[i];

                if (nextX < 0 || nextY < 0 || nextX >= N || nextY >= M
                    || area[nextX, nextY] > 0)
                {
                    continue;
                }

                count++;
            }

            return count;
        }
    }
}
