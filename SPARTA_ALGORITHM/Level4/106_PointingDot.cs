using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level4
{
    internal class PointingDot
    {
        public class Solution
        {
            public long solution(int k, int d)
            {
                long answer = 0;
                for (int i = 0; i <= d; i += k)
                {
                    long sub = (long)d * (long)d - (long)i * (long)i;
                    answer += (int)Math.Sqrt(sub) / k + 1;
                }

                return answer;
            }
        }
    }
}
