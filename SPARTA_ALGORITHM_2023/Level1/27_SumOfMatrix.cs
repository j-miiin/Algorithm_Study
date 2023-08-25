using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata
{
    internal class SumOfMatrix
    {
        static void Main(string[] args)
        {
            int[,] answer = Solution.solution(new int[,] { { 1, 2 }, { 2, 3 } }
            , new int[,] { { 3, 4 }, { 5, 6 } });
            foreach (int i in answer)
            {
                Console.WriteLine(i);
            }
        }

        public class Solution
        {
            public static int[,] solution(int[,] arr1, int[,] arr2)
            {
                int[,] answer = new int[arr1.GetLength(0), arr1.GetLength(1)];
                for (int i = 0; i < arr1.GetLength(0); i++)
                {
                    for (int j = 0; j < arr1.GetLength(1); j++)
                    {
                        answer[i, j] = arr1[i, j] + arr2[i, j];
                    }
                }
                return answer;
            }
        }
    }
}
