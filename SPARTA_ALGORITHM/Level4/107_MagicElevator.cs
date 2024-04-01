using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level4
{
    internal class MagicElevator
    {
        public class Solution
        {
            public int solution(int storey)
            {
                int answer = 0;

                int digit = 10;
                while(storey >= 1)
                {
                    if (storey % digit == 5)
                    {
                        if ((storey / 10) % digit >= 5)
                            storey += 5;
                        else
                            storey -= 5;
                        answer += 5;
                    }
                    else if (storey % digit > 5)
                    {
                        int tmp = 10 - (storey % digit);
                        answer += tmp;
                        storey += tmp;
                    } else
                    {
                        answer += (storey % digit);
                        storey -= (storey % digit);
                    }
                    storey /= 10;
                }

                return answer;
            }
        }
    }
}
