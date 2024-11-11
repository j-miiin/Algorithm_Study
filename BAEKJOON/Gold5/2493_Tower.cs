using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold5
{
    internal class Tower
    {
        class Node
        {
            public int idx;
            public int height;

            public Node (int idx, int height)
            {
                this.idx = idx;
                this.height = height;
            }
        }

        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int[] tower = new int[N];

            string[] str = Console.ReadLine().Split(" ");
            for (int i = 0; i < N; i++)
            {
                tower[i] = int.Parse(str[i]);
            }

            int[] answer = new int[N];
            int idx = N - 1;
            Stack<Node> stack = new Stack<Node>();
            for (int i = N - 1; i >= 0; i--)
            {
                while (stack.Count > 0)
                {
                    if (stack.Peek().height < tower[i])
                    {
                        Node node = stack.Pop();
                        answer[node.idx] = i + 1;
                    } else
                    {
                        break;
                    }
                }
                stack.Push(new Node(i, tower[i]));
            }

            while (stack.Count > 0)
            {
                Node node = stack.Pop();
                answer[node.idx] = 0;
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < answer.Length; i++)
            {
                sb.Append(answer[i]).Append(" ");
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
