using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Silver2
{
    internal class NumOfIsland
    {
        static int[] dx = { -1, 1, 0, 0, -1, -1, 1, 1 };
        static int[] dy = { 0, 0, -1, 1, -1, 1, -1, 1 };

        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            while (true)
            {
                string[] str = Console.ReadLine().Split(" ");
                int w = int.Parse(str[0]);
                int h = int.Parse(str[1]);

                if (w == 0 && h == 0)
                {
                    break;
                }

                int[,] area = new int[h, w];

                for (int i = 0; i < h; i++)
                {
                    str = Console.ReadLine().Split(" ");
                    for (int j = 0; j < w; j++)
                    {
                        area[i, j] = int.Parse(str[j]);
                    }
                }

                int count = 0;
                bool[,] visited = new bool[h, w];

                for (int i = 0; i < h; i++)
                {
                    for (int j = 0; j < w; j++)
                    {
                        if (!visited[i, j] && area[i, j] == 1)
                        {
                            count++;
                            SearchIsland(i, j, h, w, area, visited);
                        }
                    }
                }

                sb.Append(count).Append("\n");
            }

            Console.WriteLine(sb.ToString());
        }

        static void SearchIsland(int x, int y, int h, int w, int[,] area, bool[,] visited)
        {
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

                    if (nextX < 0 || nextY < 0 || nextX >= h || nextY >= w
                        || visited[nextX, nextY] || area[nextX, nextY] == 0)
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
