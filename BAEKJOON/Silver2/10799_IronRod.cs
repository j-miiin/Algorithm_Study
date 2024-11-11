using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Silver2
{
    internal class IronRod
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();

            Stack<char> stack = new Stack<char>();

            int answer = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    if (s[i + 1] == ')')
                    {
                        answer += stack.Count;
                        i++;
                    } else
                    {
                        stack.Push(s[i]);
                    }
                } else
                {
                    stack.Pop();
                    answer++;
                }
            }

            Console.WriteLine(answer);
        }
    }
}
