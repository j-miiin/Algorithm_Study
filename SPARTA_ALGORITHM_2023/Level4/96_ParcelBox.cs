using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level4
{
    internal class ParcelBox
    {
        public class Solution
        {
            public int solution(int[] order)
            {
                int answer = 0;

                int idx = 0;
                Stack<int> stack = new Stack<int>();
                
                for (int i = 1; i <= order.Length; i++)
                {
                    bool isRight = false;

                    if (i == order[idx])
                    {
                        idx++;
                        answer++;
                        isRight = true;
                    }

                    while (stack.Count > 0 && stack.Peek() == order[idx])
                    {
                        stack.Pop();
                        idx++;
                        answer++;
                        isRight = true;
                    }

                    if (!isRight) stack.Push(i);
                }

                while (stack.Count > 0 && stack.Peek() == order[idx])
                {
                    stack.Pop();
                    idx++;
                    answer++;
                }

                return answer;
            }
        }
    }
}
