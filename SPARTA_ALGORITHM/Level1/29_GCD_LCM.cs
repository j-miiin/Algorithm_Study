using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata
{
    internal class GCD_LCM
    {
        public class Solution
        {
            public int[] solution(int n, int m)
            {
                int[] answer = new int[2];
                int gcd = getGCD(n, m);
                answer[0] = gcd;
                answer[1] = gcd * (n / gcd) * (m / gcd);
                return answer;
            }

            static int getGCD(int n1, int n2)
            {
                while (n2 > 0)
                {
                    int r = n1 % n2;
                    n1 = n2;
                    n2 = r;
                }
                return n1;
            }
        }
    }
}
