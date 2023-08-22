using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Programmers
{
    internal class MakeDoubleArray
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Solution.solution(new int[] { 1, 2, 3, 4, 5 }));
        }

        public class Solution
        {
            public static int[] solution(int[] numbers)
            {
                int[] answer = new int[numbers.Length];

                for (int i = 0; i < numbers.Length; i++)
                {
                    answer[i] = numbers[i] * 2;
                }
                return answer;
            }
        }
    }
}
