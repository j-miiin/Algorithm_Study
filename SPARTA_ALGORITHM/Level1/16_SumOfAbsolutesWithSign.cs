using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata
{
    internal class SumOfAbsolutesWithSign
    {
        public class Solution
        {
            public int solution(int[] absolutes, bool[] signs)
            {
                int answer = 0;
                for (int i = 0; i < absolutes.Length; i++)
                {
                    if (signs[i]) answer += absolutes[i];
                    else answer -= absolutes[i];
                }
                return answer;
            }
        }
    }
}
