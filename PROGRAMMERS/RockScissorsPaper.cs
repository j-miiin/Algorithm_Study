using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Programmers
{
    internal class RockScissorsPaper
    {
        public class Solution
        {
            public string solution(string rsp)
            {
                string answer = "";
                for (int i = 0; i < rsp.Length; i++)
                {
                    if (rsp[i] == '2') answer += "0";
                    else if (rsp[i] == '0') answer += "5";
                    else answer += "2";
                }
                return answer;
            }
        }
    }
}
