using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level3
{
    internal class MakeHamburger
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Solution.solution(new int[] { 1, 3, 2, 3, 1 }));
        }

        public class Solution
        {
            static Stack<int> burgerStack;
            public static int solution(int[] ingredient)
            {
                int answer = 0;
                burgerStack = new Stack<int>();
                for (int i = 0; i < ingredient.Length; i++)
                {
                    int cur = ingredient[i];
                    if (cur == 1)
                    {
                        if (burgerStack.Count > 0 && burgerStack.Peek() == 3)
                        {
                            RemoveBurgerStack();
                            answer++;
                        } else
                        {
                            burgerStack.Push(cur);
                        }
                    } else 
                    {
                        if (burgerStack.Count > 0) {
                            if (burgerStack.Peek() == cur - 1)
                            {
                                burgerStack.Push(cur);
                            } else
                            {
                                burgerStack.Clear();
                            }
                        }
                    } 
                }
                return answer;
            }

            static void RemoveBurgerStack()
            {
                int prev = 0;
                do
                {
                    prev = burgerStack.Pop();
                } while (prev != 1);
            }
        }
    }
}
