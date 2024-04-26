using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level5
{
    internal class IntegerPairs
    {
        public class Solution
        {
            public long solution(int r1, int r2)
            {
                long answer = 0;
                double x1, x2;
                for (int i = 1; i <= r2; i++)
                {
                    x2 = Math.Sqrt((long)r2 * (long)r2 - (long)i * (long)i);
                    if (i < r1)
                    {
                        x1 = Math.Sqrt((long)r1 * (long)r1 - (long)i * (long)i);
                        answer += (long)Math.Floor(x2) - (long)Math.Ceiling(x1) + 1;
                    }
                    else
                    {
                        answer += (long)Math.Floor(x2) + 1;
                    }
                }

                return answer * 4;
            }
        }
    }
}
