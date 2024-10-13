using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Silver2
{
    internal class StackSequence
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<int> sequence = new List<int>(n);
            for (int i = 0; i < n; i++)
            {
                sequence.Add(int.Parse(Console.ReadLine()));
            }

            int idx = 0;
            Stack<int> stack = new Stack<int>();
            StringBuilder sb = new StringBuilder();

            for (int i = 1; i <= n; i++)
            {
                stack.Push(i);
                sb.Append("+").Append("\n");

                while (stack.Count > 0 && stack.Peek() == sequence[idx])
                {
                    stack.Pop();
                    sb.Append("-").Append("\n");
                    idx++;
                }
            }

            if (stack.Count > 0)
            {
                Console.Write("NO");
            } else
            {
                Console.WriteLine(sb.ToString());
            }
        }
    }
}
