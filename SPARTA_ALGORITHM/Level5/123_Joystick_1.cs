using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level5
{
    internal class Joystick_1
    {
        public class Solution
        {
            public int solution(string name)
            {
                int answer = 0;
                int length = name.Length;
                int minDist = length - 1;

                for (int i = 0; i < length; i++)
                {
                    int next = i + 1;
                    char target = name[i];
                    int up = target - 'A';
                    int down = 'Z' - target + 1;
                    answer += Math.Min(up, down);

                    while (next < length && name[next] == 'A') next++;
                    minDist = Math.Min(minDist
                        , i + length - next + Math.Min(i, length - next));
                }
                answer += minDist;
                return answer;
            }
        }
    }
}
