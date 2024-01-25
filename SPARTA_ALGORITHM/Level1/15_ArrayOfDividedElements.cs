using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata
{
    internal class ArrayOfDividedElements
    {
        public class Solution
        {
            public int[] solution(int[] arr, int divisor)
            {
                int[] answer = new int[] { };
                List<int> list = new List<int>();
                foreach (int i in arr)
                {
                    if (i % divisor == 0) list.Add(i);
                }
                if (list.Count == 0) list.Add(-1);
                list.Sort();
                answer = list.ToArray();
                return answer;
            }
        }
    }
}
