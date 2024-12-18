using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold4
{
    internal class Algospot
    {
        static int[] dx = { -1, 1, 0, 0 };
        static int[] dy = { 0, 0, -1, 1 };

        static int N, M;
        static int[,] maze;

        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(" ");
            M = int.Parse(str[0]);
            N = int.Parse(str[1]);
            maze = new int[N, M];

            for (int i = 0; i < N; i++)
            {
                string s = Console.ReadLine();
                for (int j = 0; j < s.Length; j++)
                {
                    maze[i, j] = (s[j] == '0') ? 0 : 1;
                }
            }

            Console.WriteLine(Move());
        }

        static int Move()
        {
            int result = 0;

            bool[,] visited = new bool[N, M];
            List<int[]> dequeue = new List<int[]>();
            
            visited[0, 0] = true;
            dequeue.Add(new int[] { 0, 0, 0 });

            while (dequeue.Count > 0)
            {
                int[] cur = dequeue[0];
                dequeue.RemoveAt(0);

                int curX = cur[0];
                int curY = cur[1];
                int curWall = cur[2];

                if (curX == N - 1 && curY == M - 1)
                {
                    result = curWall;
                    break;
                }

                for (int i = 0; i < dx.Length; i++)
                {
                    int nextX = curX + dx[i];
                    int nextY = curY + dy[i];

                    if (nextX < 0 || nextY < 0 || nextX >= N || nextY >= M
                        || visited[nextX, nextY])
                    {
                        continue;
                    }

                    visited[nextX, nextY] = true;
                    if (maze[nextX, nextY] == 0)
                    {
                        dequeue.Insert(0, new int[] { nextX, nextY, curWall });
                    } else
                    {
                        dequeue.Add(new int[] { nextX, nextY, curWall + 1 });
                    }
                }
            }

            return result;
        }
    }
}
