using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level5
{
    internal class Robot
    {
        public class Solution
        {
            const int EMPTY = 0;
            const int WALL = 1;
            static int[] dx = { -1, 1, 0, 0 };
            static int[] dy = { 0, 0, -1, 1 };
            static int N, M;

            public int solution(string[] board)
            {
                N = board.Length;
                M = board[0].Length;
                int[,] gameBoard = new int[N, M];

                int startX = 0, startY = 0, goalX = 0, goalY = 0;
                for (int i = 0; i < N; i++)
                {
                    string s = board[i];
                    for (int j = 0; j < s.Length; j++)
                    {
                        if (s[j] == 'D') gameBoard[i, j] = WALL;
                        else if (s[j] == 'R')
                        {
                            startX = i;
                            startY = j;
                        }
                        else if (s[j] == 'G')
                        {
                            goalX = i;
                            goalY = j;
                        }
                    }
                }

                return MoveRobot(startX, startY, goalX, goalY, gameBoard);
            }

            static int MoveRobot(int startX, int startY, int goalX, int goalY, int[,] board)
            {
                bool[,] visited = new bool[N, M];
                Queue<int[]> queue = new Queue<int[]>();

                visited[startX, startY] = true;
                queue.Enqueue(new int[] { startX, startY, 0 });

                while (queue.Count > 0)
                {
                    int[] cur = queue.Dequeue();
                    int curX = cur[0];
                    int curY = cur[1];
                    int curCount = cur[2];

                    for (int i = 0; i < dx.Length; i++)
                    {
                        int nextX = curX, nextY = curY;
                        while (nextX >= 0 && nextY >= 0 && nextX < N && nextY < M
                            && board[nextX, nextY] != WALL)
                        {
                            nextX += dx[i];
                            nextY += dy[i];
                        }

                        nextX -= dx[i];
                        nextY -= dy[i];
                        if (nextX == goalX && nextY == goalY) return curCount + 1;
                        if (visited[nextX, nextY]) continue;
                        visited[nextX, nextY] = true;
                        queue.Enqueue(new int[] { nextX, nextY, curCount + 1 });
                    }
                }

                return -1;
            }
        }
    }
}
