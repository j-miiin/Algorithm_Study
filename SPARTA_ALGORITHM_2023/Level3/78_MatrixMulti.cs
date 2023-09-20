﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level3
{
    internal class MatrixMulti
    {
        public class Solution
        {
            public int[,] solution(int[,] arr1, int[,] arr2)
            {
                int[,] answer = new int[arr1.GetLength(0), arr2.GetLength(1)];

                for (int i = 0; i < answer.GetLength(0); i++)
                {
                    for (int j = 0; j < answer.GetLength(1); j++)
                    {
                        answer[i, j] = MultiMatrix(arr1, arr2, i, j);
                    }
                }
                return answer;
            }

            static int MultiMatrix(int[,] arr1, int[,] arr2, int x, int y)
            {
                int result = 0;
                for (int i = 0; i < arr1.GetLength(1); i++)
                {
                    result += arr1[x, i] * arr2[i, y];
                }
                return result;
            }
        }
    }
}
