using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold4
{
    internal class Tetromino
    {
        static int[] dx = { -1, 1, 0, 0 };
        static int[] dy = { 0, 0, -1, 1 };

        static int N, M;
        static int answer = 0;
        static int[,] board;
        static bool[,] visited;

        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(" ");
            N = int.Parse(str[0]);
            M = int.Parse(str[1]);

            answer = int.MinValue;
            board = new int[N, M];
            visited = new bool[N, M];

            for (int i = 0; i < N; i++)
            {
                str = Console.ReadLine().Split(" ");
                for (int j = 0; j < M; j++)
                {
                    board[i, j] = int.Parse(str[j]);
                }
            }

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    visited[i, j] = true;
                    PlaceTetromino(i, j, 1, board[i, j]);
                    visited[i, j] = false;

                    answer = Math.Max(answer, PlaceAdditionalTetromino(i, j));
                }
            }

            Console.WriteLine(answer);
        }

        static void PlaceTetromino(int x, int y, int count, int sum)
        {
            if (count == 4)
            {
                answer = Math.Max(answer, sum);
                return;
            }

            for (int i = 0; i < 4; i++)
            {
                int nextX = x + dx[i];
                int nextY = y + dy[i];

                if (nextX < 0 || nextY < 0 || nextX >= N || nextY >= M
                    || visited[nextX, nextY])
                {
                    continue;
                }

                visited[nextX, nextY] = true;
                PlaceTetromino(nextX, nextY, count + 1, sum + board[nextX, nextY]);
                visited[nextX, nextY] = false;
            }
        }

        static int PlaceAdditionalTetromino(int x, int y)
        {
            List<int[]> positionList = new List<int[]>();

            for (int i = 0; i < 4; i++)
            {
                int nextX = x + dx[i];
                int nextY = y + dy[i];

                if (nextX < 0 || nextY < 0 || nextX >= N || nextY >= M
                    || visited[nextX, nextY])
                {
                    continue;
                }

                positionList.Add(new int[] { nextX, nextY });
            }

            if (positionList.Count < 3)
            {
                return 0;
            }

            int sum = board[x, y];
            for (int i = 0; i < positionList.Count; i++)
            {
                sum += board[positionList[i][0], positionList[i][1]];
            }

            if (positionList.Count == 3)
            {
                return sum;
            }

            int result = 0;
            for (int i = 0; i < positionList.Count; i++)
            {
                sum -= board[positionList[i][0], positionList[i][1]];
                result = Math.Max(result, sum);
                sum += board[positionList[i][0], positionList[i][1]];
            }

            return result;
        }
    }
}
