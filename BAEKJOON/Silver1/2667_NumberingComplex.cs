using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Silver1
{
    internal class NumberingComplex
    {
        static int[] dx = { -1, 1, 0, 0 };
        static int[] dy = { 0, 0, -1, 1 };

        static int N;
        static int[,] map;

        static void Main(string[] args)
        {
            N = int.Parse(Console.ReadLine());
            map = new int[N, N];

            for (int i = 0; i < N; i++)
            {
                string str = Console.ReadLine();
                for (int j = 0; j < str.Length; j++)
                {
                    if (str[j] == '1')
                    {
                        map[i, j] = 1;
                    } else
                    {
                        map[i, j] = 0;
                    }
                }
            }

            int complexCount = 0;
            List<int> complexNumList = new List<int>();
            bool[,] visited = new bool[N, N];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (!visited[i, j] && map[i, j] == 1)
                    {
                        complexNumList.Add(Bfs(i, j, visited));
                        complexCount++;
                    }
                }
            }
            complexNumList.Sort();

            Console.WriteLine(complexCount);
            for (int i = 0; i < complexNumList.Count; i++)
            {
                Console.WriteLine(complexNumList[i]);
            }
        }

        static int Bfs(int x, int y, bool[,] visited)
        {
            int count = 0;

            Queue<int[]> queue = new Queue<int[]>();

            visited[x, y] = true;
            queue.Enqueue(new int[] { x, y });

            while (queue.Count > 0)
            {
                int[] cur = queue.Dequeue();
                int curX = cur[0];
                int curY = cur[1];

                count++;

                for (int i = 0; i < 4; i++)
                {
                    int nextX = curX + dx[i];
                    int nextY = curY + dy[i];

                    if (nextX < 0 || nextY < 0 || nextX >= N || nextY >= N
                        || visited[nextX, nextY] || map[nextX, nextY] != 1)
                    {
                        continue;
                    }

                    visited[nextX, nextY] = true;
                    queue.Enqueue(new int[] { nextX, nextY });
                }
            }

            return count;
        }
    }
}
