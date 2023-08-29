using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level2
{
    internal class YearOf2016
    {
        public class Solution
        {
            public string solution(int a, int b)
            {
                string[] days = { "FRI", "SAT", "SUN", "MON", "TUE", "WED", "THU" };

                int totalDays = 0;
                for (int i = 1; i < a; i++)
                {
                    if (i == 2) totalDays += 29;
                    else if (i == 4 || i == 6 || i == 9 || i == 1) totalDays += 30;
                    else totalDays += 31;
                }
                totalDays += (b - 1);

                string answer = days[totalDays % 7];
                return answer;
            }
        }
    }
}
