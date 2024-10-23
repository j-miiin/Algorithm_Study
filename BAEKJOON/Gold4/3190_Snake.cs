using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold4
{
    internal class Snake
    {
        static int[] dx = { 0, 1, 0, -1 };
        static int[] dy = { 1, 0, -1, 0 };

        static int[,] board;

        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            board = new int[N, N];

            int K = int.Parse(Console.ReadLine());
            string[] str;
            for (int i = 0; i < K; i++)
            {
                str = Console.ReadLine().Split(" ");
                int x = int.Parse(str[0]) - 1;
                int y = int.Parse(str[1]) - 1;
                board[x, y] = 1;
            }

            int L = int.Parse(Console.ReadLine());
            Queue<int[]> directionQueue = new Queue<int[]>();
            for (int i = 0; i < L; i++)
            {
                str = Console.ReadLine().Split(" ");
                int time = int.Parse(str[0]);
                int direction = 1;
                if (str[1] == "L")
                {
                    direction = -1;
                }
                directionQueue.Enqueue(new int[] { time, direction });
            }

            int count = 0;
            int dir = 0;
            Queue<int[]> snake = new Queue<int[]>();
            snake.Enqueue(new int[] { 0, 0 });

            int curX = 0;
            int curY = 0;

            board[curX, curY] = 2;

            while (true)
            {
                count++;

                int nextX = curX + dx[dir];
                int nextY = curY + dy[dir];

                if (nextX < 0 || nextY < 0 || nextX >= N || nextY >= N
                    || board[nextX, nextY] == 2)
                {
                    Console.WriteLine(count);
                    break;
                }


                curX = nextX;
                curY = nextY;
                
                if (board[nextX, nextY] != 1)
                {
                    int[] tail = snake.Dequeue();
                    board[tail[0], tail[1]] = 0;
                }

                snake.Enqueue(new int[] { nextX, nextY });
                board[nextX, nextY] = 2;

                if (directionQueue.Count > 0)
                {
                    int[] nextDirection = directionQueue.Peek();
                    if (nextDirection[0] == count)
                    {
                        directionQueue.Dequeue();
                        dir += nextDirection[1];

                        if (dir < 0)
                        {
                            dir = 3;
                        }
                        else if (dir > 3)
                        {
                            dir = 0;
                        }
                    }
                }
            }
        }
    }
}
