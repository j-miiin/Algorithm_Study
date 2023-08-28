using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level2
{
    internal class CaesarCipher
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Solution.solution("a Z z", 4));
        }

        public class Solution
        {
            public static string solution(string s, int n)
            {
                string answer = "";
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] == ' ')
                    {
                        answer += s[i];
                        continue;
                    }

                    int curChar = s[i] + n;
                    Console.WriteLine(curChar);

                    if (s[i] >= 65 && s[i] <= 90)
                    {
                        if (curChar > 90)
                        {
                            curChar -= 26;
                            Console.WriteLine("빼기" +curChar);
                        }
                    } else
                    {
                        if (curChar > 122) curChar -= 26;
                    }

                    answer += (char)curChar;
                }
                return answer;
            }
        }
    }
}
