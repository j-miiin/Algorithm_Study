using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold4
{
    internal class Cheese
    {
        static int[] dx = { -1, 1, 0, 0 };
        static int[] dy = { 0, 0, -1, 1 };

        static int N, M;
        static int[,] board;
        static bool[,] melted;

        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(" ");
            N = int.Parse(str[0]);
            M = int.Parse(str[1]);
            board = new int[N, M];
            melted = new bool[N, M];

            for (int i = 0; i < N; i++)
            {
                str = Console.ReadLine().Split(" ");
                for (int j = 0; j < M; j++)
                {
                    board[i, j] = int.Parse(str[j]);
                }
            }

            int time = 0;
            int lastCheese = 0;
            while (true)
            {
                time++;
                Search();
                lastCheese = Melt();

                bool isEnd = true;
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < M; j++)
                    {
                        if (board[i, j] == 1)
                        {
                            isEnd = false;
                            break;
                        }
                    }

                    if (!isEnd)
                    {
                        break;
                    }
                }

                if (isEnd)
                {
                    Console.WriteLine(time + "\n" + lastCheese);
                    break;
                }
            }
        }

        static void Search()
        {
            bool[,] visited = new bool[N, M];
            Queue<int[]> queue = new Queue<int[]>();

            visited[0, 0] = true;
            queue.Enqueue(new int[] { 0, 0 });

            while (queue.Count > 0)
            {
                int[] cur = queue.Dequeue();
                int curX = cur[0];
                int curY = cur[1];

                for (int i = 0; i < dx.Length; i++)
                {
                    int nextX = curX + dx[i];
                    int nextY = curY + dy[i];

                    if (nextX < 0 || nextY < 0 || nextX >= N || nextY >= M
                        || visited[nextX, nextY])
                    {
                        continue;
                    }

                    if (board[nextX, nextY] == 0)
                    {
                        visited[nextX, nextY] = true;
                        queue.Enqueue(new int[] { nextX, nextY });
                    } else
                    {
                        melted[nextX, nextY] = true;
                    }
                }
            }
        }

        static int Melt()
        {
            int meltedCheese = 0;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    if (melted[i, j] && board[i, j] == 1)
                    {
                        board[i, j] = 0;
                        melted[i, j] = false;
                        meltedCheese++;
                    }
                }
            }
            return meltedCheese;
        }
    }
}
