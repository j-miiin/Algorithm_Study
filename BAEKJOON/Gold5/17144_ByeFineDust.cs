using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold5
{
    internal class ByeFineDust
    {
        static int[] dx = { -1, 1, 0, 0 };
        static int[] dy = { 0, 0, -1, 1 };

        static int R, C;
        static int[] airCleaner = new int[2];
        static int[,] room;

        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(" ");
            R = int.Parse(str[0]);
            C = int.Parse(str[1]);
            int T = int.Parse(str[2]);

            int idx = 0;
            room = new int[R, C];
            for (int i = 0; i < R; i++)
            {
                str = Console.ReadLine().Split(" ");
                for (int j = 0; j < C; j++)
                {
                    room[i, j] = int.Parse(str[j]);

                    if (room[i, j] == -1)
                    {
                        airCleaner[idx] = i;
                        idx++;
                    }
                }
            }

            while (T > 0)
            {
                T--;

                SpreadDust();
                CleanAir();
            }

            int answer = 0;
            for (int i = 0; i < R; i++)
            {
                for (int j = 0; j < C; j++)
                {
                    if (room[i, j] > 0)
                    {
                        answer += room[i, j];
                    }
                }
            }

            Console.WriteLine(answer);
        }

        static void SpreadDust()
        {
            int[,] dust = new int[R, C];

            for (int i = 0; i < R; i++)
            {
                for (int j = 0; j < C; j++)
                {
                    if (room[i, j] >= 5)
                    {
                        SpreadDirectional(i, j, dust);
                    }
                }
            }

            for (int i = 0; i < R; i++)
            {
                for (int j = 0; j < C; j++)
                {
                    room[i, j] += dust[i, j];
                }
            }
        }

        static void SpreadDirectional(int x, int y, int[,] dust)
        {
            int spreadCount = 0;
            int spreadAmount = room[x, y] / 5;

            for (int i = 0; i < dx.Length; i++)
            {
                int nextX = x + dx[i];
                int nextY = y + dy[i];

                if (nextX < 0 || nextY < 0 || nextX >= R || nextY >= C
                    || room[nextX, nextY] == -1)
                {
                    continue;
                }

                spreadCount++;
                dust[nextX, nextY] += spreadAmount;
            }

            dust[x, y] -= spreadAmount * spreadCount;
        }

        static void CleanAir()
        {
            // 위 공기청정기
            int upX = airCleaner[0];

            // RIGHT
            int tmp1 = room[upX, C - 1];
            for (int i = C - 1; i > 1; i--)
            {
                room[upX, i] = room[upX, i - 1];
            }
            room[upX, 1] = 0;

             // UP
            int tmp2 = room[0, C - 1];
            for (int i = 0; i < upX - 1; i++)
            {
                room[i, C - 1] = room[i + 1, C - 1];
            }
            room[upX - 1, C - 1] = tmp1;

            // LEFT
            int tmp3 = room[0, 0];
            for (int i = 0; i < C - 2; i++)
            {
                room[0, i] = room[0, i + 1];
            }
            room[0, C - 2] = tmp2;

            // DOWN
            for (int i = upX - 1; i > 1; i--)
            {
                room[i, 0] = room[i - 1, 0];
            }
            room[1, 0] = tmp3;

            // 아래 공기청정기 
            int downX = airCleaner[1];

            // RIGHT
            tmp1 = room[downX, C - 1];
            for (int i = C - 1; i > 1; i--)
            {
                room[downX, i] = room[downX, i - 1];
            }
            room[downX, 1] = 0;

            // DOWN
            tmp2 = room[R - 1, C - 1];
            for (int i = R - 1; i > downX + 1; i--)
            {
                room[i, C - 1] = room[i - 1, C - 1];
            }
            room[downX + 1, C - 1] = tmp1;

            // LEFT
            tmp3 = room[R - 1, 0];
            for (int i = 0; i < C - 2; i++)
            {
                room[R - 1, i] = room[R - 1, i + 1];
            }
            room[R - 1, C - 2] = tmp2;

            // UP
            for (int i = downX + 1; i < R - 1; i++)
            {
                room[i, 0] = room[i + 1, 0];
            }
            room[R - 2, 0] = tmp3;
        }
    }
}
