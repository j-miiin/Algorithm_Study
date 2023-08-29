using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level2
{
    internal class ColaProblem
    {
        public class Solution
        {
            public int solution(int a, int b, int n)
            {
                int answer = 0;

                int colaNum = n;
                while (colaNum >= a)
                {
                    int newCola = (colaNum / a) * b;
                    int leftCola = colaNum % a;
                    colaNum = newCola + leftCola;
                    answer += newCola;
                }

                return answer;
            }
        }
    }
}
