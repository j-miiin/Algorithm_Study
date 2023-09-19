using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level3
{
    internal class SliceArr
    {
        public class Solution
        {
            public int[] solution(int n, long left, long right)
            {
                int[] answer = new int[right - left + 1];
                int idx = 0;
                for (long i = left; i <= right; i++)
                {
                    answer[idx++] = Math.Max((int)(i / n), (int)(i % n)) + 1;
                }
                return answer;
            }
        }
    }
}
