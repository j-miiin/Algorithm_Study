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
                Stack<int> mainStack = new Stack<int>();
                Stack<int> subStack = new Stack<int>();

                for (int i = 0; i < order.Length; i++) {
                    mainStack.Push(order.Length - i);
                }

                int answer = 0;
                int idx = 0;
                while (idx < order.Length)
                {
                    if (order[idx] == mainStack.Peek())
                    {
                        mainStack.Pop();
                        idx++;
                        answer++;
                    } else
                    {
                        if (mainStack.Count > 0) subStack.Push(mainStack.Pop());

                        if (subStack.Count > 0 && subStack.Peek() == order[idx])
                        {
                            subStack.Pop();
                            idx++;
                            answer++;
                        }
                        else
                        {
                            subStack.Push(order[idx]);
                        }
                    }
                }
                
                return answer;
            }
        }
    }
}
