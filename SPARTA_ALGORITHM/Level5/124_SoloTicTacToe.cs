namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level5
{
    internal class SoloTicTacToe
    {
        public class Solution
        {
            const int EMPTY = 0;
            const int FIRST = 1;
            const int SECOND = 2;

            public int solution(string[] board)
            {
                int[,] gameBoard = new int[3, 3];

                int firstCount = 0;
                int secondCount = 0;

                for (int i = 0; i < board.Length; i++)
                {
                    for (int j = 0; j < board[i].Length; j++)
                    {
                        if (board[i][j] == '.')
                        {
                            gameBoard[i, j] = EMPTY;
                        } else if (board[i][j] == 'O')
                        {
                            gameBoard[i, j] = FIRST;
                            firstCount++;
                        } else
                        {
                            gameBoard[i, j] = SECOND;
                            secondCount++;
                        }
                    }
                }

                int answer = 1;
                if (firstCount < secondCount)
                {
                    answer = 0;
                }
                else if (firstCount == secondCount)
                {
                    if (IsGameOver(gameBoard, FIRST))
                    {
                        answer = 0;
                    }
                }
                else
                {
                    if (IsGameOver(gameBoard, SECOND))
                    {
                        answer = 0;
                    }
                    else if (firstCount - secondCount > 1)
                    {
                        answer = 0;
                    }
                }

                if (IsGameOver(gameBoard, FIRST) && IsGameOver(gameBoard, SECOND))
                {
                    answer = 0;
                }

                return answer;
            }

            public static bool IsGameOver(int[,] gameBoard, int firstOrSecond)
            {
                bool result = false;

                if (gameBoard[0, 0] == firstOrSecond)
                {
                    if (gameBoard[0, 1] == firstOrSecond && gameBoard[0, 2] == firstOrSecond)
                    {
                        result = true;
                    } else if (gameBoard[1, 1] == firstOrSecond && gameBoard[2, 2] == firstOrSecond)
                    {
                        result = true;
                    }
                }

                if (gameBoard[1, 0] == firstOrSecond && gameBoard[1, 1] == firstOrSecond
                    && gameBoard[1, 2] == firstOrSecond)
                {
                    result = true;
                }
                
                if (gameBoard[2, 0] == firstOrSecond && gameBoard[2, 1] == firstOrSecond
                    && gameBoard[2, 2] == firstOrSecond)
                {
                    result = true;
                }
                
                if (gameBoard[0, 0] == firstOrSecond && gameBoard[1, 0] == firstOrSecond
                    && gameBoard[2, 0] == firstOrSecond)
                {
                    result = true;
                }
                
                if (gameBoard[0, 1] == firstOrSecond && gameBoard[1, 1] == firstOrSecond
                    && gameBoard[2, 1] == firstOrSecond)
                {
                    result = true;
                }
                
                if (gameBoard[0, 2] == firstOrSecond)
                {
                    if (gameBoard[1, 2] == firstOrSecond && gameBoard[2, 2] == firstOrSecond)
                    {
                        result = true;
                    }
                    else if (gameBoard[1, 1] == firstOrSecond && gameBoard[2, 0] == firstOrSecond)
                    {
                        result = true;
                    }
                }

                return result;
            }
        }
    }
}
