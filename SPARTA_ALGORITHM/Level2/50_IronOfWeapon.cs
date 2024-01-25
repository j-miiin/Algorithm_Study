using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level2
{
    internal class IronOfWeapon
    {
        public class Solution
        {
            public int solution(int number, int limit, int power)
            {
                int answer = 0;

                for (int i = 1; i <= number; i++)
                {
                    int curPower = GetDividerNum(i, limit);
                    if (curPower <= limit) answer += curPower;
                    else answer += power;
                }

                return answer;
            }

            public static int GetDividerNum(int num, int limit)
            {
                int count = 0;
                for (int i = 1; i * i <= num; i++)
                {
                    if (num % i == 0)
                    {
                        count++;
                        if (i * i < num) count++;
                    }
                    if (count > limit) break;
                }
                return count;
            }
        }
    }
}
