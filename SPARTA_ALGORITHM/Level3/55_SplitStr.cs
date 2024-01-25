using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level3
{
    internal class SplitStr
    {
        public class Solution
        {
            public int solution(string s)
            {
                List<string> resultStr = new List<string>();
                string x = s[0] + "";
                int same = 0, diff = 0;
                for (int i = 0; i < s.Length; i++)
                {
                    string curStr = s[i] + "";
                    if (x == curStr) same++;
                    else diff++;

                    if (same > 0 && diff > 0 && same == diff)
                    {
                        resultStr.Add(x);
                        same = 0;
                        diff = 0;
                        if (i != s.Length - 1) x = s[i + 1] + "";
                    }
                }

                if (same != diff) resultStr.Add(x);

                int answer = resultStr.Count;
                return answer;
            }
        }
    }
}
