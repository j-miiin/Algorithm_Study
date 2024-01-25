namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level4
{
    internal class RotateMatrixBorder
    {
        public class Solution
        {
            static int[,] board;

            public int[] solution(int rows, int columns, int[,] queries)
            {
                board = new int[rows, columns];
                int num = 1;
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        board[i, j] = num;
                        num++;
                    }
                }

                int[] answer = new int[queries.GetLength(0)];
                for (int i = 0; i < queries.GetLength(0); i++)
                {
                    answer[i] = Rotate(
                        queries[i, 0] - 1,
                        queries[i, 1] - 1,
                        queries[i, 2] - 1,
                        queries[i, 3] - 1);
                }

                return answer;
            }

            public static int Rotate(int x1, int y1, int x2, int y2)
            {
                int result = 10001;
                int preNum = 0;

                for (int i = y1; i < y2; i++)
                {
                    if (i == y1)
                    {
                        preNum = board[x1, i];
                        if (preNum < result) result = preNum;
                        continue;
                    }
                    int tmp = board[x1, i];
                    board[x1, i] = preNum;
                    preNum = tmp;
                    if (preNum < result) result = preNum;
                }

                for (int i = x1; i < x2; i++)
                {
                    int tmp = board[i, y2];
                    board[i, y2] = preNum;
                    preNum = tmp;
                    if (preNum < result) result = preNum;
                }

                for (int i = y2; i > y1; i--)
                {
                    int tmp = board[x2, i];
                    board[x2, i] = preNum;
                    preNum = tmp;
                    if (preNum < result) result = preNum;
                }

                for (int i = x2; i > x1; i--)
                {
                    int tmp = board[i, y1];
                    board[i, y1] = preNum;
                    preNum = tmp;
                    if (preNum < result) result = preNum;
                }

                board[x1, y1] = preNum;

                return result;
            }
        }
    }
}
