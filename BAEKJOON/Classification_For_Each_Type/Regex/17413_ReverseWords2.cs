using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Regex
{
    internal class ReverseWords2
    {
        static void Main(string[] args)
        {
            string S = Console.ReadLine();

            StringBuilder sb = new StringBuilder();

            bool isTag = false;
            Stack<char> stack = new Stack<char>();
            for (int i = 0; i < S.Length; i++)
            {
                if (S[i] == '<')
                {
                    isTag = true;

                    while (stack.Count > 0)
                    {
                        sb.Append(stack.Pop());
                    }

                    sb.Append(S[i]);
                    continue;
                } else if (S[i] == '>')
                {
                    isTag = false;
                    sb.Append(S[i]);
                    continue;
                } 
                
                if (isTag)
                {
                    sb.Append(S[i]);
                    continue;
                }

                if (S[i] == ' ')
                {
                    while (stack.Count > 0)
                    {
                        sb.Append(stack.Pop());
                    }
                    sb.Append(" ");
                } else
                {
                    stack.Push(S[i]);
                }
            }

            while (stack.Count > 0)
            {
                sb.Append(stack.Pop());
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
