using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata
{
    internal class HarshadNum
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Solution.solution(10));
        }
        public class Solution
        {
            public static bool solution(int x)
            {
                bool answer = true;
                string numStr = x.ToString();
                int digitSum = 0;
                for (int i = 0; i < numStr.Length; i++) digitSum += int.Parse(numStr[i]+"");
                answer = (x % digitSum == 0);
                return answer;
            }
        }
    }
}
