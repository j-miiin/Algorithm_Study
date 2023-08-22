using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Programmers
{
    internal class ReverseArray
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Solution.solution(new int[] { 1, 2, 3, 4, 5 }));
        }

        public class Solution
        {
            public static int[] solution(int[] num_list)
            {
                int[] answer = new int[num_list.Length];

                for (int i = 0, j = num_list.Length - 1; i < num_list.Length; i++, j--)
                {
                    answer[i] = num_list[j];
                }
                return answer;
            }
        }
    }
}
