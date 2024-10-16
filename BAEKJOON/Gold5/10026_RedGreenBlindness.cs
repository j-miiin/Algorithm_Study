using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold5
{
    internal class RedGreenBlindness
    {
        static int[] dx = { -1, 1, 0, 0 };
        static int[] dy = { 0, 0, -1, 1 };

        static int N;
        static char[,] painting;

        static void Main(string[] args)
        {
            N = int.Parse(Console.ReadLine());

            painting = new char[N, N];
            for (int i = 0; i < N; i++)
            {
                string str = Console.ReadLine();
                for (int j = 0; j < N; j++)
                {
                    painting[i, j] = str[j];
                }
            }

            int[] answer = new int[2];

            int area = 0;
            bool[,] visited = new bool[N, N];

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (!visited[i, j])
                    {
                        CheckArea(i, j, visited, false);
                        area++;
                    }
                }
            }

            answer[0] = area;

            area = 0;
            visited = new bool[N, N];

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (!visited[i, j])
                    {
                        CheckArea(i, j, visited, true);
                        area++;
                    }
                }
            }

            answer[1] = area;

            Console.WriteLine($"{answer[0]} {answer[1]}");
        }

        static void CheckArea(int x, int y, bool[,] visited, bool isRedGreen)
        {
            Queue<int[]> queue = new Queue<int[]>();

            visited[x, y] = true;
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
                        || visited[nextX, nextY])
                    {
                        continue;
                    }

                    if (painting[curX, curY] == painting[nextX, nextY])
                    {
                        visited[nextX, nextY] = true;
                        queue.Enqueue(new int[] { nextX, nextY });
                    } else
                    {
                        if (isRedGreen && painting[curX, curY] != 'B'
                            && painting[nextX, nextY] != 'B')
                        {
                            visited[nextX, nextY] = true;
                            queue.Enqueue(new int[] { nextX, nextY });
                        }
                    }
                }
            }
        }
    }
}
