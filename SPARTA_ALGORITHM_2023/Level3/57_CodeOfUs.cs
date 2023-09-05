using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level3
{
    internal class CodeOfUs
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Solution.solution("zzzzz", "a", 1));
        }

        public class Solution
        {
            public static string solution(string s, string skip, int index)
            {
                string answer = "";

                for (int i = 0; i < s.Length; i++)
                {
                    char curStr = s[i];

                    for (int j = 0; j < index; j++)
                    {
                        curStr = (char)(curStr + 1);
                        if (curStr.CompareTo('z') > 0) curStr = (char)(curStr - 26);
                        while (skip.Contains(curStr)) curStr = (char)(curStr + 1);
                    }
                    answer += curStr;
                }

                return answer;
            }
        }
    }
}
