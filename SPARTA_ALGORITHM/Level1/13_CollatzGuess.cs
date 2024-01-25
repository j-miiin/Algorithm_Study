using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata
{
    internal class CollatzGuess
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Solution.solution(626331));
        }
        public class Solution
        {
            public static int solution(int num)
            {
                int answer = 0;
                long result = num;
                if (num == 1) return 0;
                while (result != 1)
                {
                    if (result % 2 == 0) result /= 2;
                    else result = result * 3 + 1;
                    answer++;
                    if (answer == 500 && result != 1)
                    {
                        answer = -1;
                        break;
                    }
                }
                return answer;
            }
        }
    }
}
