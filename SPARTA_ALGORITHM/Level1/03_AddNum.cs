using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata
{
    internal class AddNum
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Solution.solution(123));
        }
        public class Solution
        {
            public static int solution(int n)
            {
                int answer = 0;
                string numStr = n.ToString();
                for (int i = 0; i < numStr.Length; i++)
                {
                    answer += int.Parse(numStr[i]+"");
                }
                return answer;
            }
        }
    }
}
