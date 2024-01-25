using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level2
{
    internal class StrangeStr
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Solution.solution("AA aa ZZ zz"));
        }

        public class Solution
        {
            public static string solution(string s)
            {
                StringBuilder sb = new StringBuilder();
                int idx = 0;
                for (int i = 0; i < s.Length; i++)
                {
                    string cur = s[i] + "";
                    if (cur == " ") {
                        sb.Append(cur);
                        idx = 0;
                    }
                    else
                    {
                        if (idx % 2 == 0) sb.Append(cur.ToUpper());
                        else sb.Append(cur.ToLower());
                        idx++;
                    }
                }
                string answer = sb.ToString();
                return answer;
            }
        }
    }
}
