using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold4
{
    internal class StringExplosion
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            string explosion = Console.ReadLine();

            Stack<char> stack = new Stack<char>();

            StringBuilder sb = new StringBuilder();
            for (int i = str.Length - 1; i >= 0; i--)
            {
                stack.Push(str[i]);

                if (stack.Count >= explosion.Length && stack.Peek() == explosion[0])
                {
                    for (int j = 0; j < explosion.Length; j++)
                    {
                        sb.Append(stack.Pop());
                    }

                    string cur = sb.ToString();
                    if (cur != explosion)
                    {
                        for (int j = cur.Length - 1; j >= 0; j--)
                        {
                            stack.Push(cur[j]);
                        }
                    }

                    sb.Clear();
                }
            }

            while (stack.Count > 0)
            {
                sb.Append(stack.Pop());
            }

            Console.WriteLine((sb.Length == 0) ? "FRULA" : sb.ToString());
        }
    }
}
