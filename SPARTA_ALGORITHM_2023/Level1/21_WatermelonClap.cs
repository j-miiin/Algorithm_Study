using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata
{
    internal class WatermelonClap
    {
        public class Solution
        {
            public string solution(int n)
            {
                string answer = "";
                for (int i = 0; i < n; i++)
                {
                    if (i % 2 == 0) answer += "수";
                    else answer += "박";
                }
                return answer;
            }
        }
    }
}
