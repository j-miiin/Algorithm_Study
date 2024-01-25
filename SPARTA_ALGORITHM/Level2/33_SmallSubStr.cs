using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level2
{
    internal class SmallSubStr
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Solution.solution("500220839878", "7"));
        }

        public class Solution
        {
            public static int solution(string t, string p)
            {
                int answer = 0;

                int length = p.Length;
                for (int i = 0; i + length - 1 < t.Length; i++)
                {
                    string curStr = "";
                    for (int j = 0; j < length; j++) curStr += t[i + j];

                    if (ulong.Parse(curStr) <= ulong.Parse(p)) answer++;
                }

                return answer;
            }

        }
    }
}
