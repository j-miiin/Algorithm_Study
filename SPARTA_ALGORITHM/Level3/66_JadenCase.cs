using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level3
{
    internal class JadenCase
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Solution.solution("3people unFollowed me"));
        }
        public class Solution
        {
            public static string solution(string s)
            {
                string answer = "";

                string tmp = "";
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] == ' ')
                    {
                        if (tmp.Length > 0)
                        {
                            answer += tmp;
                            tmp = "";
                        }
                        answer += s[i];
                    }
                    else if (s[i] >= '0' && s[i] <= '9') tmp += s[i];
                    else
                    {
                        if (tmp.Length == 0) tmp += (s[i] + "").ToUpper();
                        else tmp += (s[i] + "").ToLower();
                    }
                }

                answer += tmp;

                return answer;
            }
        }
    }
}
