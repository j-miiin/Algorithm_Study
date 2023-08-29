using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level2
{
    internal class K_th_Num
    {
        public class Solution
        {
            public int[] solution(int[] array, int[,] commands)
            {
                int[] answer = new int[commands.GetLength(0)];

                for (int i = 0; i < commands.GetLength(0); i++)
                {
                    int start = commands[i, 0];
                    int end = commands[i, 1];
                    int k = commands[i, 2];

                    int length = end - start + 1;
                    int[] subArr = new int[length];
                    Array.Copy(array, start - 1, subArr, 0, length);
                    Array.Sort(subArr);
                    answer[i] = subArr[k - 1];
                }
                return answer;
            }
        }
    }
}
