using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata
{
    internal class DealWithStr
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Solution.solution("1234"));
        }

        public static class Solution
        {
            public static bool solution(string s)
            {
                bool answer = true;
                if (s.Length != 4 && s.Length != 6) answer = false;
                else
                {
                    int i = 0;
                    bool isNum = int.TryParse(s, out i);
                    answer = isNum;
                }
                return answer;
            }
        }
    }
}
