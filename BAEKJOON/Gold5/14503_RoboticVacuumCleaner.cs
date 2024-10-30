using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold5
{
    internal class RoboticVacuumCleaner
    {
        static int[] dx = { -1, 0, 1, 0 };
        static int[] dy = { 0, 1, 0, -1 };

        static int N, M;
        static int[,] area;

        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(" ");
            N = int.Parse(str[0]);
            M = int.Parse(str[1]);
            area = new int[N, M];

            str = Console.ReadLine().Split(" ");
            int startX = int.Parse(str[0]);
            int startY = int.Parse(str[1]);
            int dir = int.Parse(str[2]);

            for (int i = 0; i < N; i++)
            {
                str = Console.ReadLine().Split(" ");
                for (int j = 0; j < M; j++)
                {
                    area[i, j] = int.Parse(str[j]);
                }
            }

            int curX = startX;
            int curY = startY;
            int answer = 0;
            while (true)
            {
                if (area[curX, curY] == 0)
                {
                    area[curX, curY] = 2;
                    answer++;
                }

                bool isBack = true;
                for (int i = 0; i < 4; i++)
                {
                    int nextX = curX + dx[i];
                    int nextY = curY + dy[i];

                    if (nextX < 0 || nextY < 0 || nextX >= N || nextY >= M
                        || area[nextX, nextY] != 0)
                    {
                        continue;
                    }

                    isBack = false;
                    break;
                }

                if (isBack)
                {
                    int backDir = (dir + 2) % 4;
                    curX += dx[backDir];
                    curY += dy[backDir];

                    if (curX < 0 || curY < 0 || curX >= N || curY >= M
                        || area[curX, curY] == 1)
                    {
                        break;
                    }
                }
                else
                {
                    while (true)
                    {
                        dir--;
                        if (dir < 0)
                        {
                            dir = 3;
                        }

                        int nextX = curX + dx[dir];
                        int nextY = curY + dy[dir];

                        if (nextX < 0 || nextY < 0 || nextX >= N || nextY >= M
                            || area[nextX, nextY] != 0)
                        {
                            continue;
                        }

                        curX = nextX;
                        curY = nextY;
                        break;
                    }
                }
            }

            Console.WriteLine(answer);
        }
    }
}
