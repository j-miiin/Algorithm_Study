using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata
{
    internal class CoverPhoneNum
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Solution.solution("01033334444"));
        }

        public class Solution
        {
            public static string solution(string phone_number)
            {
                int length = phone_number.Length;
                string str1 = Regex.Replace(phone_number.Substring(0, length - 4), @"[0-9]", "*");
                string str2 = phone_number.Substring(length - 4, 4);
                string answer = str1 + str2;
                return answer;
            }
        }
    }
}
