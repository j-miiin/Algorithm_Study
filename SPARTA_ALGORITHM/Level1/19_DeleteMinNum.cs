using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata
{
    internal class DeleteMinNum
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Solution.solution(new int[] { 4, 3, 2, 1 }));
        }

        public class Solution
        {
            public static int[] solution(int[] arr)
            {
                int[] answer = new int[] { };
                int min = arr.Min();
                List<int> list = new List<int>();
                foreach (int i in arr)
                {
                    if (i != min) list.Add(i);
                }
                if (list.Count == 0) list.Add(-1);
                answer = list.ToArray();
                return answer;
            }
        }
    }
}
