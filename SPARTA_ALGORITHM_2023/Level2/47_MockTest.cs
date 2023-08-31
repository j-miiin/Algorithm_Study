using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level2
{
    internal class MockTest
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(", ", Solution.solution(new int[] { 1, 3, 2, 4, 2 })));
        }
        public class Solution
        {
            public static int[] solution(int[] answers)
            {
                int[] person1Ans = new int[] { 1, 2, 3, 4, 5 };
                int[] person2Ans = new int[] { 2, 1, 2, 3, 2, 4, 2, 5 };
                int[] person3Ans = new int[] { 3, 3, 1, 1, 2, 2, 4, 4, 5, 5 };

                int[] countAns = new int[3];

                for (int i = 0; i < answers.Length; i++)
                {
                    if (answers[i] == person1Ans[i % person1Ans.Length]) countAns[0]++;
                    if (answers[i] == person2Ans[i % person2Ans.Length]) countAns[1]++;
                    if (answers[i] == person3Ans[i % person3Ans.Length]) countAns[2]++;
                }
                
                List<int> answerList = new List<int>();

                for (int i = 0; i < countAns.Length; i++)
                {
                    if (countAns[i] == countAns.Max()) answerList.Add(i + 1);
                }

                int[] answer = answerList.ToArray();

                return answer;
            }
        }
    }
}
