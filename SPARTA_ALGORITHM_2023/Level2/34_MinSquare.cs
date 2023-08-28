using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level2
{
    internal class MinSquare
    {
        public class Solution
        {
            public int solution(int[,] sizes)
            {
                int answer = 0;
                int maxWidth = 0;
                int maxHeight = 0;

                for (int i = 0; i < sizes.GetLength(0); i++)
                {
                    if (sizes[i, 0] < sizes[i, 1])
                    {
                        int tmp = sizes[i, 0];
                        sizes[i, 0] = sizes[i, 1];
                        sizes[i, 1] = tmp;
                    }

                    if (maxWidth < sizes[i, 0]) maxWidth = sizes[i, 0];
                    if (maxHeight < sizes[i, 1]) maxHeight = sizes[i, 1];
                }

                answer = maxWidth * maxHeight;
                
                return answer;
            }
        }
    }
}
