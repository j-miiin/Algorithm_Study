using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level2
{
    internal class NumStrAndWords
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Solution.solution("one4seveneight"));
        }
        public class Solution
        {
            public static int solution(string s)
            {
                int answer = 0;
                List<string> numList = new List<string> { "zero", "one", "two", "three", "four"
                    , "five", "six", "seven", "eight", "nine" };

                string resultStr = "";
                string curStr = "";
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] >= '0' && s[i] <= '9')
                    {
                        resultStr += s[i];
                        continue;
                    }

                    curStr += s[i];
                    if (numList.Contains(curStr))
                    {
                        resultStr += numList.IndexOf(curStr);
                        curStr = "";
                    }
                }

                answer = int.Parse(resultStr);
                return answer;
            }
        }
    }
}
