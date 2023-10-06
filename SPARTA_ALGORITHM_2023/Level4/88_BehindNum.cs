using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level4
{
    internal class BehindNum
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(", " ,Solution.solution(new int[] { 9, 1, 5, 3, 6, 2 })));
        }
        class Solution
        {
            public static int[] solution(int[] numbers)
            {
                Stack<int> stack = new Stack<int>();
                Array.Reverse(numbers);

                int[] answer = new int[numbers.Length];
                for (int i = 0; i < answer.Length; i++)
                {
                    if (stack.Count == 0)
                    {
                        answer[i] = -1;
                        stack.Push(numbers[i]);
                    }
                    else if (stack.Peek() <= numbers[i])
                    {
                        while (stack.Count > 0)
                        {
                            stack.Pop();
                            if (stack.Count == 0)
                            {
                                answer[i] = -1;
                                stack.Push(numbers[i]);
                                break;
                            }
                            else if (stack.Peek() > numbers[i])
                            {
                                answer[i] = stack.Peek();
                                stack.Push(numbers[i]);
                                break;
                            }
                        }
                    } else
                    {
                        answer[i] = stack.Peek();
                        stack.Push(numbers[i]);
                    }
                }

                Array.Reverse(answer);
                return answer;
            }
        }
    }
}
