using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata
{
    internal class GetMidChar
    {
        public class Solution
        {
            public string solution(string s)
            {
                if (s.Length == 1) return s;
                string answer = "";
                int idx = s.Length / 2;
                if (s.Length % 2 == 0) answer = s.Substring(idx - 1, 2);
                else answer = s.Substring(idx, 1);
                return answer;
            }
        }
    }
}
