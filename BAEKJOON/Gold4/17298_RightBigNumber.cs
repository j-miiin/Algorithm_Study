using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold4
{
    internal class RightBigNumber
    {
        class Num
        {
            public int idx;
            public int value;

            public Num (int i, int v)
            {
                idx = i;
                value = v;
            }
        }

        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            int[] result = new int[N];
            Stack<Num> stack = new Stack<Num>();

            string[] str = Console.ReadLine().Split(" ");
            for (int i = 0; i < N; i++)
            {
                int value = int.Parse(str[i]);

                while (stack.Count > 0)
                {
                    if (stack.Peek().value >= value)
                    {
                        break;
                    }
                    
                    Num peek = stack.Pop();
                    result[peek.idx] = value;

                }

                stack.Push(new Num(i, value));
            }

            while (stack.Count > 0)
            {
                Num peek = stack.Pop();
                result[peek.idx] = -1;
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < N; i++)
            {
                sb.Append(result[i]).Append(" ");
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
