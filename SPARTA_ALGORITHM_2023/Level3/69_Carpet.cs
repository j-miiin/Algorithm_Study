using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level3
{
    internal class Carpet
    {
        public class Solution
        {
            public int[] solution(int brown, int yellow)
            {
                int carpet = brown + yellow;
                int resultX = 0, resultY = 0;
                bool isBreak = false;

                for (int i = 1; i <= carpet / 2; i++)
                {
                    for (int j = 1; j <= i; j++)
                    {
                        if (i * j > carpet) break;
                        if (i * j == carpet && (i - 2)*(j - 2) == yellow)
                        {
                            resultX = i;
                            resultY = j;
                            isBreak = true;
                            break;
                        }
                    }
                    if (isBreak) break;
                }

                int[] answer = new int[] { resultX, resultY };
                return answer;
            }
        }
    }
}
