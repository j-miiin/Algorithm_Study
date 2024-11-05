using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold4
{
    internal class RollDice
    {
        static int[] dx = { 0, 0, -1, 1 };
        static int[] dy = { 1, -1, 0, 0 };

        static int N, M;

        static int[] dice = new int[6]; // up back right left front down

        static int curX, curY;
        static int[,] map;

        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(" ");
            N = int.Parse(str[0]);
            M = int.Parse(str[1]);
            curX = int.Parse(str[2]);
            curY = int.Parse(str[3]);
            int K = int.Parse(str[4]);

            map = new int[N, M];
            for (int i = 0; i < N; i++)
            {
                str = Console.ReadLine().Split(" ");
                for (int j = 0; j < M; j++)
                {
                    map[i, j] = int.Parse(str[j]);
                }
            }

            StringBuilder sb = new StringBuilder();
            str = Console.ReadLine().Split(" ");
            for (int i = 0; i < K; i++)
            {
                int command = int.Parse(str[i]) - 1;
                int result = Roll(command);
                if (result != -1)
                {
                    sb.Append(result).Append("\n");
                }
            }

            Console.WriteLine(sb.ToString());
        }

        static int Roll(int command)
        {
            int nextX = curX + dx[command];
            int nextY = curY + dy[command];

            if (nextX < 0 || nextY < 0 || nextX >= N || nextY >= M)
            {
                return -1;
            }

            curX = nextX;
            curY = nextY;

            if (command == 0)
            {
                MoveRight();
            } else if (command == 1)
            {
                MoveLeft();
            } else if (command == 2)
            {
                MoveUp();
            } else
            {
                MoveDown();
            }

            if (map[curX, curY] == 0)
            {
                map[curX, curY] = dice[5];
            } else
            {
                dice[5] = map[curX, curY];
                map[curX, curY] = 0;
            }

            return dice[0];
        }

        static void MoveDown()
        {
            int tmp = dice[0]; 
            dice[0] = dice[4];  // up -> front
            dice[4] = dice[5];  // front -> down
            dice[5] = dice[1];  // down -> back
            dice[1] = tmp;      // back -> up
        }

        static void MoveUp()
        {
            int tmp = dice[0];
            dice[0] = dice[1];  // up -> back
            dice[1] = dice[5];  // back -> down
            dice[5] = dice[4];  // down -> front
            dice[4] = tmp;      // front -> up
        }

        static void MoveLeft()
        {
            int tmp = dice[0];
            dice[0] = dice[3];  // up -> left
            dice[3] = dice[5];  // left -> down
            dice[5] = dice[2];  // down -> right
            dice[2] = tmp;      // right -> up
        }

        static void MoveRight()
        {
            int tmp = dice[0];
            dice[0] = dice[2];  // up -> right
            dice[2] = dice[5];  // right -> down
            dice[5] = dice[3];  // down -> left
            dice[3] = tmp;      // left -> up
        }
    }
}
