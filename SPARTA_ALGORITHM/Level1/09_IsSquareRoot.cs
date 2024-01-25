using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata
{
    internal class IsSquareRoot
    {
        public long solution(long n)
        {
            long answer = 0;
            double sqrtNum = Math.Sqrt(n);
            if (sqrtNum == Math.Floor(sqrtNum)) answer = ((long)sqrtNum + 1) * ((long)sqrtNum + 1);
            else answer = -1;
            return answer;
        }
    }
}
