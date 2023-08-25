using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata
{
    internal class DescendingOrderStr
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Solution.solution("Zbcdefg"));
        }
        public class Solution
        {
            public static string solution(string s)
            {
                string answer = "";
                char[] charArr = s.ToCharArray();
                Array.Sort(charArr);
                Array.Reverse(charArr);
                foreach (char c in charArr) answer += c;
                return answer;
            }
        }
    }
}
