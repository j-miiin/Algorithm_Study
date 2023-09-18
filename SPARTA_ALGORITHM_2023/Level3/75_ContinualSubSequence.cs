using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level3
{
    internal class ContinualSubSequence
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Solution.solution(new int[] { 7, 9, 1, 1, 4 }));
        }

        public class Solution
        {
            public static int solution(int[] elements)
            {
                int[] circularArr = new int[elements.Length * 2];
                for (int i = 0; i < elements.Length; i++)
                {
                    circularArr[i] = elements[i];
                    circularArr[i + elements.Length] = elements[i];
                }

                HashSet<int> arrSet = new HashSet<int>();

                for (int i = 0; i < elements.Length; i++)
                {
                    int num = 0;
                    for (int j = 0; j < elements.Length; j++)
                    {
                        num += circularArr[i + j];
                        arrSet.Add(num);
                    }
                }
                

                int answer = arrSet.Count;
                return answer;
            }
        }
    }
}
