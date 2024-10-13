using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold4
{
    internal class Laboratory
    {
        static int[] dx = { -1, 1, 0, 0 };
        static int[] dy = { 0, 0, -1, 1 };

        static int N, M; 
        static int result;
        static int[,] laboratory;

        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(" ");
            N = int.Parse(str[0]);
            M = int.Parse(str[1]);
            laboratory = new int[N, M];

            for (int i = 0; i < N; i++)
            {
                str = Console.ReadLine().Split(" ");
                for (int j = 0; j < M; j++)
                {
                    laboratory[i, j] = int.Parse(str[j]);
                }
            }

            result = 0;

            SelectWallPosition(0, 0, new List<int>());

            Console.WriteLine(result);
        }

        static void SelectWallPosition(int start, int wallCount, List<int> pos)
        {
            if (wallCount == 3)
            {
                int[,] lab = (int[,])laboratory.Clone();
                bool[,] visited = new bool[N, M];
                int curResult = 0;

                for (int i = 0; i < pos.Count; i++)
                {
                    int xPos = pos[i] / M;
                    int yPos = pos[i] % M;
                    lab[xPos, yPos] = 1;
                }

                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < M; j++)
                    {
                        if (!visited[i, j] && lab[i, j] == 2)
                        {
                            Infect(i, j, lab, visited);
                        }
                    }
                }

                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < M; j++)
                    {
                        if (lab[i, j] == 0)
                        {
                            curResult ++;
                        }
                    }
                }

                result = Math.Max(result, curResult);

                return;
            }

            for (int i = start; i < N * M; i++)
            {
                int x = i / M;
                int y = i % M;

                if (laboratory[x, y] == 0)
                {
                    pos.Add(i);
                    SelectWallPosition(i + 1, wallCount + 1, pos);
                    pos.Remove(i);
                }
            }
        }

        static void Infect(int x, int y, int[,] lab, bool[,] visited)
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

                    if (nextX < 0 || nextY < 0 || nextX >= N || nextY >= M
                        || visited[nextX, nextY] || lab[nextX, nextY] != 0)
                    {
                        continue;
                    }

                    lab[nextX, nextY] = 2;
                    visited[nextX, nextY] = true;
                    queue.Enqueue(new int[] { nextX, nextY });
                }
            }
        }
    }
}
