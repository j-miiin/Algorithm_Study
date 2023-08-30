using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level2
{
    internal class FruitSeller
    {
        public class Solution
        {
            public int solution(int k, int m, int[] score)
            {
                int answer = 0;

                Array.Sort(score);
                Array.Reverse(score);
                for (int i = m - 1; i < score.Length; i += m)
                {
                    answer += (score[i] * m);
                }

                return answer;
            }
        }
    }
}
