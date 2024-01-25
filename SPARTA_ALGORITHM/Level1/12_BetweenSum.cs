using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata
{
    internal class BetweenSum
    {
        public class Solution
        {
            public long solution(int a, int b)
            {
                long answer = 0;
                if (a <= b) for (long i = a; i <= b; i++) answer += i;
                else for (long i = b; i <= a; i++) answer += i;
                return answer;
            }
        }
    }
}
