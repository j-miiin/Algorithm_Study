namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level4
{
    internal class QuadCompression
    {
        public class Solution
        {
            static int[,] targetArr;
            static int[] answer;

            public int[] solution(int[,] arr)
            {
                targetArr = arr;
                answer = new int[2];

                Compress(0, 0, arr.GetLength(0));

                return answer;
            }

            static void Compress(int x, int y, int length)
            {
                int num = targetArr[x, y];

                if (length == 1)
                {
                    answer[num]++;
                    return;
                }

                bool isSame = true;
                for (int i = x; i < x + length; i++)
                {
                    for (int j = y; j < y + length; j++)
                    {
                        if (targetArr[i, j] != num)
                        {
                            isSame = false;
                            break;
                        }
                    }
                }

                if (isSame)
                {
                    answer[num]++;
                    return;
                }

                int halfLength = length / 2;
                Compress(x, y, halfLength);
                Compress(x + halfLength, y, halfLength);
                Compress(x, y + halfLength, halfLength);
                Compress(x + halfLength, y + halfLength, halfLength);
            }
        }
    }
}
