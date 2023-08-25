using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata
{
    internal class DivisorNumAndSum
    {
        public class Solution
        {
            public int solution(int left, int right)
            {
                int answer = 0;
                for (int i = left; i <= right; i++)
                {
                    if (IsDivisorEven(i)) answer += i;
                    else answer -= i;
                }
                return answer;
            }

            static bool IsDivisorEven(int num)
            {
                int count = 0;
                for (int i = 1; i <= num; i++)
                {
                    if (num % i == 0) count++;
                }
                return (count % 2 == 0);
            }
        }
    }
}
