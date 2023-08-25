using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata
{
    internal class ReverseTernary
    {
        public class Solution
        {
            public static int solution(int n)
            {
                int answer = 0;
                while (n > 0)
                {
                    answer *= 3;
                    answer += n % 3;
                    n /= 3;
                }
                return answer;
            }
        }
    }
}
