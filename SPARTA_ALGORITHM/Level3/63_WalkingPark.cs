using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level3
{
    internal class WalkingPark
    {
        public class Solution
        {
            static int[] dx = { 0, 0, 1, -1 };
            static int[] dy = { 1, -1, 0, 0 };

            static int E = 0, W = 1, S = 2, N = 3;
            static int EMPTY = 0, WALL = 1;

            static int[,] board;

            public int[] solution(string[] park, string[] routes)
            {
                int startX = 0, startY = 0;
                board = new int[park.Length, park[0].Length];

                for (int i = 0; i < park.Length; i++)
                {
                    for (int j = 0; j < park[i].Length; j++)
                    {
                        if (park[i][j] == 'S')
                        {
                            board[i, j] = EMPTY;
                            startX = i;
                            startY = j;
                        }
                        else if (park[i][j] == 'O')
                        {
                            board[i, j] = EMPTY;
                        }
                        else
                        {
                            board[i, j] = WALL;
                        }
                    }
                }

                int[] answer = BFS(startX, startY, routes);
                return answer;
            }

            static int[] BFS(int x, int y, string[] routes)
            {
                int curX = x, curY = y;
                foreach (string str in routes)
                {
                    string[] pos = str.Split(' ');
                    int dir = 0;
                    switch (pos[0])
                    {
                        case "E" : dir = E; break;
                        case "W": dir = W; break;
                        case "S": dir = S; break;
                        case "N": dir = N; break;
                    }

                    bool isPossible = true;
                    int nextX = curX, nextY = curY;
                    for (int i = 0; i < int.Parse(pos[1]); i++)
                    {
                        nextX += dx[dir];
                        nextY += dy[dir];

                        if (nextX < 0 || nextY < 0 || nextX >= board.GetLength(0) || nextY >= board.GetLength(1)
                            || board[nextX, nextY] == WALL)
                        {
                            isPossible = false;
                            break;
                        }
                    }

                    if (isPossible)
                    {
                        curX = nextX;
                        curY = nextY;
                    }
                }

                return new int[] { curX, curY };
            }
        }
    }
}
