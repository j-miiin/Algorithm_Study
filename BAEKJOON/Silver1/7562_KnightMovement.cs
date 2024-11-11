using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Silver1
{
    internal class KnightMovement
    {
        static int[] dx = { -2, -2, -1, -1, 1, 1, 2, 2 };
        static int[] dy = { -1, 1, -2, 2, -2, 2, -1, 1 };

        static void Main(string[] args)
        {
            int T = int.Parse(Console.ReadLine());

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < T; i++)
            {
                int N = int.Parse(Console.ReadLine());
                int[,] board = new int[N, N];

                string[] str = Console.ReadLine().Split(" ");
                int curX = int.Parse(str[0]);
                int curY = int.Parse(str[1]);

                str = Console.ReadLine().Split(" ");
                int desX = int.Parse(str[0]);
                int desY = int.Parse(str[1]);

                if (curX == desX && curY == desY)
                {
                    sb.Append(0).Append("\n");
                } else
                {
                    sb.Append(MoveKnight(curX, curY, desX, desY, board)).Append("\n");
                }
            }

            Console.WriteLine(sb.ToString());
        }

        static int MoveKnight(int x, int y, int desX, int desY, int[,] board)
        {
            int result = 0;

            int N = board.GetLength(0);
            bool[,] visited = new bool[N, N];
            Queue<int[]> queue = new Queue<int[]>();

            visited[x, y] = true;
            queue.Enqueue(new int[] { x, y, 0 });

            while (queue.Count > 0)
            {
                int[] cur = queue.Dequeue();
                int curX = cur[0];
                int curY = cur[1];
                int curMove = cur[2];

                if (curX == desX && curY ==  desY)
                {
                    result = curMove;
                    break;
                }

                for (int i = 0; i < dx.Length; i++)
                {
                    int nextX = curX + dx[i];
                    int nextY = curY + dy[i];

                    if (nextX < 0 || nextY < 0 || nextX >= N || nextY >= N
                        || visited[nextX, nextY])
                    {
                        continue;
                    }

                    visited[nextX, nextY] = true;
                    queue.Enqueue(new int[] { nextX, nextY, curMove + 1 });
                }
            }

            return result;
        }
    }
}
