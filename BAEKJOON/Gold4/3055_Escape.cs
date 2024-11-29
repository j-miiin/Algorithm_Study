using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold4
{
    internal class Escape
    {
        public const int EMPTY = 0;
        public const int WATER = 1;
        public const int STONE = 2;
        public const int DESTINATION = 3;

        static int[] dx = { -1, 1, 0, 0 };
        static int[] dy = { 0, 0, -1, 1 };

        static int R, C;
        static int desX = 0, desY = 0;

        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(" ");
            R = int.Parse(str[0]);
            C = int.Parse(str[1]);

            int curX = 0, curY = 0;
            int[,] area = new int[R, C];

            for (int i = 0; i < R; i++)
            {
                string s = Console.ReadLine();
                for (int j = 0; j < C; j++)
                {
                    if (s[j] == 'D')
                    {
                        desX = i;
                        desY = j;
                        area[i, j] = DESTINATION;
                    } else if (s[j] == 'S')
                    {
                        curX = i;
                        curY = j;
                    } else if (s[j] == '.')
                    {
                        area[i, j] = EMPTY;
                    } else if (s[j] == '*')
                    {
                        area[i, j] = WATER;
                    } else
                    {
                        area[i, j] = STONE;
                    }
                }
            }

            Queue<int[]> hedgehogQueue = new Queue<int[]>();
            Queue<int[]> waterQueue = new Queue<int[]>();
            bool[,] hedgehogVisited = new bool[R, C];
            bool[,] waterVisited = new bool[R, C];

            hedgehogQueue.Enqueue(new int[] { curX, curY, 0 });
            hedgehogVisited[curX, curY] = true;

            while (true)
            {
                for (int i = 0; i < R; i++)
                {
                    for (int j = 0; j < C; j++)
                    {
                        if (area[i, j] == WATER && !waterVisited[i, j])
                        {
                            waterVisited[i, j] = true;
                            waterQueue.Enqueue(new int[] { i, j });
                        }
                    }
                }

                while (waterQueue.Count > 0)
                {
                    int[] pos = waterQueue.Dequeue();
                    Flood(pos[0], pos[1], area, waterVisited);
                }

                int result = Move(hedgehogQueue, area, hedgehogVisited);

                if (result > 0)
                {
                    Console.WriteLine(result);
                    break;
                }

                if (hedgehogQueue.Count == 0)
                {
                    Console.WriteLine("KAKTUS");
                    break;
                }
            }
        }

        static int Move(Queue<int[]> queue, int[,] area, bool[,] visited)
        {
            int result = 0;

            int count = queue.Count;
            while (count > 0)
            {
                count--;

                int[] cur = queue.Dequeue();
                int curX = cur[0];
                int curY = cur[1];
                int curTime = cur[2];

                if (curX == desX && curY == desY)
                {
                    result = curTime;
                    break;
                }

                for (int i = 0; i < dx.Length; i++)
                {
                    int nextX = curX + dx[i];
                    int nextY = curY + dy[i];

                    if (nextX < 0 || nextY < 0 || nextX >= R || nextY >= C
                        || visited[nextX, nextY])
                    {
                        continue;
                    }

                    if (area[nextX, nextY] == EMPTY || area[nextX, nextY] == DESTINATION)
                    {
                        visited[nextX, nextY] = true;
                        queue.Enqueue(new int[] { nextX, nextY, curTime + 1 });
                    }
                }
            }

            return result;
        }

        static void Flood(int x, int y, int[,] area, bool[,] visited)
        {
            for (int i = 0; i < dx.Length; i++)
            {
                int nextX = x + dx[i];
                int nextY = y + dy[i];

                if (nextX < 0 || nextY < 0 || nextX >= R || nextY >= C
                    || visited[nextX, nextY])
                {
                    continue;
                }

                if (area[nextX, nextY] == EMPTY)
                {
                    area[nextX, nextY] = WATER;
                }
            }
        }
    }
}
