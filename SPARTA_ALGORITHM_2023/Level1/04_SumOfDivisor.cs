using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata
{
    internal class SumOfDivisor
    {
        public class Solution
        {
            public int solution(int n)
            {
                int answer = 0;
                for (int i = 1; i <= n; i++)
                {
                    if (n % i == 0) answer += i;
                }
                return answer;
            }
        }
    }
}
