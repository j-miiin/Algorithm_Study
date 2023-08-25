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
                string answer = "";
                string[] strArr = s.Split(' ');
                StringBuilder sb = new StringBuilder();
                foreach (string str in strArr)
                {
                    for (int i = 0; i < str.Length; i++)
                    {
                        if (i % 2 == 0) sb.Append((str[i] + "").ToUpper());
                         else sb.Append((str[i] + "").ToLower());
                    }
                    sb.Append(" ");
                }
                answer = sb.ToString().TrimEnd(' ');
                return answer;
            }
        }
    }
}
