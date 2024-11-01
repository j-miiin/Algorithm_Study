using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold4
{
    internal class PopulationMovement
    {
        static int[] dx = { -1, 1, 0, 0 };
        static int[] dy = { 0, 0, -1, 1 };

        static int N, L, R;
        static int[,] area;
        static bool[,] visited;

        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(" ");
            N = int.Parse(str[0]);
            L = int.Parse(str[1]);
            R = int.Parse(str[2]);
            area = new int[N, N];
            visited = new bool[N, N];

            for (int i = 0; i < N; i++)
            {
                str = Console.ReadLine().Split(" ");
                for (int j = 0; j < N; j++)
                {
                    area[i, j] = int.Parse(str[j]);
                }
            }

            int answer = 0;
            bool isMoving = true;
            while (true)
            {
                isMoving = false;

                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        visited[i, j] = false;
                    }
                }

                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        if (!visited[i, j] && Move(i, j))
                        {
                            isMoving = true;
                        }
                    }
                }

                if (!isMoving)
                {
                    break;
                }

                answer++;
            }

            Console.WriteLine(answer);
        }

        static bool Move(int x, int y)
        {
            Queue<int[]> queue = new Queue<int[]>();
            queue.Enqueue(new int[] { x, y });
            visited[x, y] = true;

            int totalPopulation = area[x, y];
            List<int[]> areaList = new List<int[]>
            {
                new int[] { x, y }
            };

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
                        || visited[nextX, nextY])
                    {
                        continue;
                    }

                    int diff = Math.Abs(area[nextX, nextY] - area[curX, curY]);
                    if (L <= diff && diff <= R)
                    {
                        queue.Enqueue(new int[] { nextX, nextY });
                        visited[nextX, nextY] = true;

                        totalPopulation += area[nextX, nextY];
                        areaList.Add(new int[] { nextX, nextY });
                    }
                }
            }

            if (areaList.Count == 1)
            {
                return false;
            }

            int avgPopulation = totalPopulation / areaList.Count;
            foreach (int[] pos in areaList)
            {
                int posX = pos[0];
                int posY = pos[1];
                area[posX, posY] = avgPopulation;
            }

            return true;
        }
    }
}
